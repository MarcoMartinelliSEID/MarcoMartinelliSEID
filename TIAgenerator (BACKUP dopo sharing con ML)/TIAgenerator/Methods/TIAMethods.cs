using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Siemens.Engineering;
using Siemens.Engineering.HW.Features;
using Siemens.Engineering.SW;
using Siemens.Engineering.SW.Blocks;
using Siemens.Engineering.SW.Tags;

namespace TIAgenerator
{
    //Methods for the connection and import/export of data with the TIA PORTAL process
    internal class TIAMethods
    {
        //Connection with the TIA PORTAL process opened
        public static Project TIADirectConnection()
        {
            TiaPortalProcess TIA = TiaPortal.GetProcesses().First();
            TiaPortal TIAProcess = TIA.Attach();
            Project TIAProject = TIAProcess.Projects[0];
            return TIAProject;
        }

        //Generate an empty tag table directly in the TIA PORTAL project
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

        //Fill the tag table target with all symbols of the list
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

        //import block from file to the TIAPortal project
        public static void ImportBlock(int station, int device, string path)
        {
            Project TIAProject = TIADirectConnection();
            SoftwareContainer swContainer = TIAProject.Devices[station].DeviceItems[device].GetService<SoftwareContainer>();
            PlcSoftware sw = swContainer.Software as PlcSoftware;
            FileInfo fi = new FileInfo(path);
            sw.BlockGroup.Blocks.Import(fi, ImportOptions.None);            
        }

        //import block from file to the TIAPortal project inside a specific blocks folder
        public static void ImportBlock(int station, int device, string path, string userGroupName)
        {
            Project TIAProject = TIADirectConnection();
            SoftwareContainer swContainer = TIAProject.Devices[station].DeviceItems[device].GetService<SoftwareContainer>();
            PlcSoftware sw = swContainer.Software as PlcSoftware;
            FileInfo fi = new FileInfo(path);            
            PlcBlockUserGroup folder = sw.BlockGroup.Groups.Find(userGroupName);
            folder.Blocks.Import(fi, ImportOptions.None);
        }

        //create a new block folder inside the TIAPortal project
        public static void NewBlockFolder(int station, int device, string userGroupName)
        {
            Project TIAProject = TIADirectConnection();
            SoftwareContainer swContainer = TIAProject.Devices[station].DeviceItems[device].GetService<SoftwareContainer>();
            PlcSoftware sw = swContainer.Software as PlcSoftware;
            sw.BlockGroup.Groups.Create(userGroupName);
        }

        //export block from the TIAPortal project. The File will be save to the specified path
        public static void ExportBlock(int station, int device, string blockName, string path)
        {
            Project TIAProject = TIADirectConnection();
            SoftwareContainer swContainer = TIAProject.Devices[station].DeviceItems[device].GetService<SoftwareContainer>();
            PlcSoftware sw = swContainer.Software as PlcSoftware;
            FileInfo fi = new FileInfo(path);
            sw.BlockGroup.Blocks.Find(blockName).Export(fi, ExportOptions.None);
        }

        //export block from the TIAPortal project included inside a blockfolder. The File will be save to the specified path
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

        //Generate istanceDB inside a block folder directly in the TIAPortal project
        public static void CreateIstanceDB(int station, int device, string FBName, string name, int DBNumber, bool isAutoNumbered, string userGroupName)
        {
            Project TIAProject = TIADirectConnection();
            SoftwareContainer swContainer = TIAProject.Devices[station].DeviceItems[device].GetService<SoftwareContainer>();
            PlcSoftware sw = swContainer.Software as PlcSoftware;
            PlcBlockUserGroup folder = sw.BlockGroup.Groups.Find(userGroupName);
            folder.Blocks.CreateInstanceDB(name, isAutoNumbered, DBNumber, FBName);
        }
    }

}
