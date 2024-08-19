using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Siemens.Engineering;
using Siemens.Engineering.Hmi;
using Siemens.Engineering.Hmi.Tag;
using Siemens.Engineering.HW;
using Siemens.Engineering.HW.Features;
using Siemens.Engineering.Safety;
using Siemens.Engineering.SW;
using Siemens.Engineering.SW.Blocks;
using Siemens.Engineering.SW.ExternalSources;
using Siemens.Engineering.SW.Tags;
using static System.Collections.Specialized.BitVector32;

namespace TIAgenerator
{
    internal class TIAMethods
    {
        public static Project TIADirectConnection()
        {
            TiaPortalProcess TIA = TiaPortal.GetProcesses().First();
            TiaPortal TIAProcess = TIA.Attach();
            Project TIAProject = TIAProcess.Projects[0];
            return TIAProject;
        }

        public static void GenerateTagTable(int station, int device, string tagTableName)
        {
            Project TIAProject = TIADirectConnection();
            SoftwareContainer swContainer = TIAProject.Devices[station].DeviceItems[device].GetService<SoftwareContainer>();
            PlcSoftware sw = swContainer.Software as PlcSoftware;
            try
            {
                PlcTagTable tagTable = sw.TagTableGroup.TagTables.Create(tagTableName);
            }
            catch (EngineeringTargetInvocationException e)
            {
                Console.WriteLine("EngineeringTargetInvocationException: Tag table named \"" + tagTableName + "\" already exist in this project");
            }
        }

        public static void CompileTagTable(int station, int device, string tagTableName, List<PlcTag> plcTagList)
        {
            Project TIAProject = TIADirectConnection();
            SoftwareContainer swContainer = TIAProject.Devices[station].DeviceItems[device].GetService<SoftwareContainer>();
            PlcSoftware sw = swContainer.Software as PlcSoftware;
            int pos = 0;            
            foreach(PlcTagTable table in sw.TagTableGroup.TagTables)
            {
                if(table.Name == tagTableName)
                {
                    pos++;
                    break;
                }
            }
            foreach (PlcTag i in plcTagList)
            {
                sw.TagTableGroup.TagTables[1].Tags.Create(i.tag, i.type, i.address);
            }
        }

        public static void ImportBlock(int station, int device, string path)
        {
            Project TIAProject = TIADirectConnection();
            SoftwareContainer swContainer = TIAProject.Devices[station].DeviceItems[device].GetService<SoftwareContainer>();
            PlcSoftware sw = swContainer.Software as PlcSoftware;
            FileInfo fi = new FileInfo(path);
            sw.BlockGroup.Blocks.Import(fi, ImportOptions.None);            
        }

        public static void ImportBlock(int station, int device, string path, string userGroupName)
        {
            Project TIAProject = TIADirectConnection();
            SoftwareContainer swContainer = TIAProject.Devices[station].DeviceItems[device].GetService<SoftwareContainer>();
            PlcSoftware sw = swContainer.Software as PlcSoftware;
            FileInfo fi = new FileInfo(path);            
            PlcBlockUserGroup folder = sw.BlockGroup.Groups.Find(userGroupName);
            folder.Blocks.Import(fi, ImportOptions.None);
        }

        public static void NewBlockFolder(int station, int device, string userGroupName)
        {
            Project TIAProject = TIADirectConnection();
            SoftwareContainer swContainer = TIAProject.Devices[station].DeviceItems[device].GetService<SoftwareContainer>();
            PlcSoftware sw = swContainer.Software as PlcSoftware;
            sw.BlockGroup.Groups.Create(userGroupName);
        }

        public static void ExportBlock(int station, int device, string blockName, string path)
        {
            Project TIAProject = TIADirectConnection();
            SoftwareContainer swContainer = TIAProject.Devices[station].DeviceItems[device].GetService<SoftwareContainer>();
            PlcSoftware sw = swContainer.Software as PlcSoftware;
            FileInfo fi = new FileInfo(path);
            sw.BlockGroup.Blocks.Find(blockName).Export(fi, ExportOptions.None);
        }

        public static void ExportBlock(int station, int device, string blockName, string path, string userGroupName)
        {
            Project TIAProject = TIADirectConnection();
            SoftwareContainer swContainer = TIAProject.Devices[station].DeviceItems[device].GetService<SoftwareContainer>();
            PlcSoftware sw = swContainer.Software as PlcSoftware;
            FileInfo fi = new FileInfo(path);
            PlcBlockUserGroup folder = sw.BlockGroup.Groups.Find(userGroupName);
            PlcBlock block = folder.Blocks.Find(blockName);
            block.Export(fi, ExportOptions.None);
        }

        public static void CreateIstanceDB(int station, int device, string FBName, string name, int DBNumber, bool isAutoNumbered, string userGroupName)
        {
            Project TIAProject = TIADirectConnection();
            SoftwareContainer swContainer = TIAProject.Devices[station].DeviceItems[device].GetService<SoftwareContainer>();
            PlcSoftware sw = swContainer.Software as PlcSoftware;
            PlcBlockUserGroup folder = sw.BlockGroup.Groups.Find(userGroupName);
            folder.Blocks.CreateInstanceDB(name, isAutoNumbered, DBNumber, FBName);
        }

        /*
        public static void UnlockBlock(int station, int device)
        {
            Project TIAProject = TIADirectConnection();
            SoftwareContainer swContainer = TIAProject.Devices[station].DeviceItems[device].GetService<SoftwareContainer>();
            PlcSoftware sw = swContainer.Software as PlcSoftware;
            
            PlcBlockProtectionProvider khp = sw.BlockGroup.Blocks[11].GetService<PlcBlockProtectionProvider>();
            char[] password1 = new char[] { '1', '2', '3', '4' };
            SecureString securePassword1 = new SecureString();
            foreach (char ch in password1)
                securePassword1.AppendChar(ch);
            khp.Unprotect(securePassword1);
        }
        */
    }

}
