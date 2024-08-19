using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using TIAgenerator.Class;

namespace TIAgenerator
{
    internal class Methods
    {
        //return relative path combined with folderName and fileName. If the target is nested inside more than one folder, remember to include @"\" between eachone
        public static string GetRelativePath(string folderName, string fileName)
        {
            return Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\TIAgenerator\" + folderName + @"\" + fileName));
        }

        //return relative path combined with fileName
        public static string GetRelativePath(string fileName)
        {
            return Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\TIAgenerator\" + fileName));
        }

        //
        public static List<T> JsonToList<T>(string jsonPath)
        {
            JsonData<T> myJson = new JsonData<T>(Methods.GetRelativePath(jsonPath));            
            myJson.GetJson();            
            return myJson.objectList;
        }

        public static List<T> JsonToList<T>(string jsonPath, bool toFix)
        {
            JsonData<T> myJson = new JsonData<T>(Methods.GetRelativePath(jsonPath));
            myJson.GetFixedJson();
            return myJson.objectList;
        }

        public static void GenerateIstanceDB_DI(int station, int device, List<DigitalSignal> signalList, string FBName, string userGroupName)
        {
            foreach(DigitalSignal i in signalList)
            {
                if(i.isAlarm == "true" || i.isTrip == "true")
                {
                    TIAMethods.CreateIstanceDB(station, device, FBName, i.tag, Convert.ToInt32(i.DBNumber), false, userGroupName);
                }
            }
        }

        public static void GenerateIstanceDB_AI(int station, int device, List<AnalogSignal> signalList, string FBName, string userGroupName)
        {
            foreach(AnalogSignal i in signalList)
            {
                if(i is AnalogInput)
                {
                    AnalogInput ai = (AnalogInput)i;
                    if(ai.isRedundant == "false")
                    {
                        TIAMethods.CreateIstanceDB(station, device, FBName, ai.tag, Convert.ToInt32(ai.DBNumber), false, userGroupName);
                    }
                }
                if (i is AnalogVals)
                {
                    AnalogVals ai = (AnalogVals)i;
                    if (ai.isRedundant == "false")
                    {
                        TIAMethods.CreateIstanceDB(station, device, FBName, ai.tag, Convert.ToInt32(ai.DBNumber), false, userGroupName);
                    }
                }
                if (i is AnalogInput1oo2)
                {
                    AnalogInput1oo2 ai = (AnalogInput1oo2)i;
                    TIAMethods.CreateIstanceDB(station, device, FBName, ai.tag, Convert.ToInt32(ai.DBNumber), false, userGroupName);                    
                }
                if (i is AnalogInput2oo2)
                {
                    AnalogInput2oo2 ai = (AnalogInput2oo2)i;
                    TIAMethods.CreateIstanceDB(station, device, FBName, ai.tag, Convert.ToInt32(ai.DBNumber), false, userGroupName);
                }
                if (i is AnalogInput2oo3)
                {
                    AnalogInput2oo3 ai = (AnalogInput2oo3)i;
                    TIAMethods.CreateIstanceDB(station, device, FBName, ai.tag, Convert.ToInt32(ai.DBNumber), false, userGroupName);
                }
            }
        }

        public static void GenerateDB_DI(List<DigitalSignal> list, string DBNumber)
        {
            string xmlBody = "";
            string path = GetRelativePath(@"\Xml\DB_DI.xml");
            DBNumber = DBNumber.Substring(3);
            foreach (DigitalSignal i in list)
            {
                xmlBody = xmlBody + "    <Member Name=\"" + i.tag + "\" Datatype=\"Bool\">\r\n      <Comment>\r\n        <MultiLanguageText Lang=\"en-US\">" + i.description + "</MultiLanguageText>\r\n      </Comment>\r\n    </Member>" + "\n";
            }
            xmlBody = xmlBody + "  </Section>\r\n</Sections></Interface>\r\n      <MemoryLayout>Optimized</MemoryLayout>\r\n      <MemoryReserve>100</MemoryReserve>\r\n      <Name>DI</Name>\r\n      <Number>" + DBNumber + "</Number>\r\n";
            string xmlDB = XmlData.xmlHeader_DB_DI + xmlBody + XmlData.xmlFooter_DB_DI;
            //Console.WriteLine(xmlDB12);
            File.WriteAllText(path, xmlDB);
            TIAMethods.ImportBlock(0, 1, path);
        }

        public static void GenerateDB_Settings(List<AnalogInput> analogInputsList, List<AnalogVals> analogValsList, List<AnalogInput1oo2> analogInputs1oo2List, List<AnalogInput2oo2> analogInputs2oo2List, List<AnalogInput2oo3> analogInputs2oo3List, List<AnalogCFC> analogCFCsList, List<AnalogBN> analogBNsList, ConfigSettings settings)
        {
            string xml = XmlData.xmlHeader_DB_Settings;
            string path = GetRelativePath(@"\Xml\DB_SETTINGS.xml");
            foreach (AnalogInput i in analogInputsList)
            {
                if (i.is1oo2Member == "false" && i.is2oo2Member == "false" && i.is2oo3Member == "false")
                {
                    XmlData.DB_SettingsBody(ref xml, i);
                }
            }
            foreach (AnalogVals i in analogValsList)
            {
                if (i.is1oo2Member == "false" && i.is2oo2Member == "false" && i.is2oo3Member == "false")
                {
                    XmlData.DB_SettingsBody(ref xml, i);
                }
            }
            foreach (AnalogCFC i in analogCFCsList)
            {
                if (i.is1oo2Member == "false" && i.is2oo2Member == "false" && i.is2oo3Member == "false")
                {
                    XmlData.DB_SettingsBody(ref xml, i);
                }
            }
            foreach (AnalogBN i in analogBNsList)
            {
                if (i.is1oo2Member == "false" && i.is2oo2Member == "false" && i.is2oo3Member == "false")
                {
                    XmlData.DB_SettingsBody(ref xml, i);
                }
            }
            foreach (AnalogInput1oo2 i in analogInputs1oo2List)
            {
                XmlData.DB_SettingsBody(ref xml, i);
            }
            foreach (AnalogInput2oo2 i in analogInputs2oo2List)
            {
                XmlData.DB_SettingsBody(ref xml, i);
            }
            foreach (AnalogInput2oo3 i in analogInputs2oo3List)
            {
                XmlData.DB_SettingsBody(ref xml, i);
            }
            xml += XmlData.xmlFooter_DB_Settings;
            XmlDocument doc = new XmlDocument();
            XmlNode node;
            doc.LoadXml(xml);
            node = doc.SelectSingleNode("//SW.Blocks.GlobalDB//MemoryLayout");
            node.InnerText = "Standard";
            node = doc.SelectSingleNode("//SW.Blocks.GlobalDB//Name");
            node.InnerText = "SETTINGS";
            node = doc.SelectSingleNode("//SW.Blocks.GlobalDB//Number");
            node.InnerText = settings.settingsDBAddr.Substring(3);
            xml = doc.OuterXml;
            File.WriteAllText(path, xml);
            TIAMethods.ImportBlock(0, 1, path);
        }

        public static void GenerateFC_DI(List<DigitalSignal> list, ConfigSettings settings)
        {
            int ID = 10;
            string nameDB = "DI";
            string xml = XmlData.xmlHeader_FC_DI;
            foreach (DigitalSignal signal in list)
            {
                ID += 1;
                if (signal.isCFC == "false" && signal.address != "")
                {
                    if (signal.isAlarm == "true" || signal.isTrip == "true")
                    {
                        if (signal.isRedundant == "true")
                        {
                            XmlData.FC_DI_NetworkATR(settings, ID, ref xml, signal);
                        }
                        else
                        {
                            XmlData.FC_DI_NetworkAT(settings, ID, ref xml, signal);
                        }                        
                    }
                    else
                    {
                        if (signal.isRedundant == "true")
                        {
                            XmlData.FC_DI_NetworkR(ID, nameDB, ref xml, signal);
                        }
                        else
                        {
                            XmlData.FC_DI_Network(ID, nameDB, ref xml, signal);
                        }                        
                    }
                }                
            }
            xml += "\n" + XmlData.xmlFooter_FC_DI;
            XmlDocument doc = new XmlDocument();
            XmlNode node;
            doc.LoadXml(xml);
            node = doc.SelectSingleNode("//SW.Blocks.FC//MemoryLayout");
            node.InnerText = "Standard";
            node = doc.SelectSingleNode("//SW.Blocks.FC//Name");
            node.InnerText = "FC_DI";
            node = doc.SelectSingleNode("//SW.Blocks.FC//Number");
            node.InnerText = settings.digitalFCAddr.Substring(3);
            xml = doc.OuterXml;
            XmlWriterSettings XmlSettings = new XmlWriterSettings();
            XmlSettings.Indent = true;
            using (XmlWriter writer = XmlWriter.Create(GetRelativePath(@"\Xml\FC_DI.xml"), XmlSettings))
            {
                writer.WriteRaw(xml);
            }            
        }

        public static void GenerateFC_AIn(List<AnalogInput> analogInputsList, ConfigSettings settings)
        {
            int ID = 20;
            string path = GetRelativePath(@"\Xml\FC_AIn.xml");
            string xml = XmlData.xmlHeader_FC_AIn;
            foreach (AnalogInput signal in analogInputsList)
            {
                ID += 1;
                XmlData.FC_AIn_Network(settings, ID, ref xml, signal);
            }
            xml += "\n" + XmlData.xmlFooter_FC_AIn;
            XmlDocument doc = new XmlDocument();
            XmlNode node;
            doc.LoadXml(xml);
            node = doc.SelectSingleNode("//SW.Blocks.FC//MemoryLayout");
            node.InnerText = "Standard";
            node = doc.SelectSingleNode("//SW.Blocks.FC//Name");
            node.InnerText = "FC_AIn";
            node = doc.SelectSingleNode("//SW.Blocks.FC//Number");
            node.InnerText = settings.fcAIsAddr.Substring(3);
            xml = doc.OuterXml;
            File.WriteAllText(path, xml);            
        }

        public static void GenerateFC_AIn2oo3(List<AnalogInput2oo3> analogInputs2oo3List, ConfigSettings settings)
        {
            int ID = 20;
            string path = GetRelativePath(@"\Xml\FC_AIn2oo3.xml");
            string xml = XmlData.xmlHeader_FC_AIn2oo3;
            foreach (AnalogInput2oo3 signal in analogInputs2oo3List)
            {
                ID += 1;
                XmlData.FC_AIn2oo3_Network(settings, ID, ref xml, signal);
            }
            xml += "\n" + XmlData.xmlFooter_FC_AIn2oo3;
            XmlDocument doc = new XmlDocument();
            XmlNode node;
            doc.LoadXml(xml);
            node = doc.SelectSingleNode("//SW.Blocks.FC//MemoryLayout");
            node.InnerText = "Standard";
            node = doc.SelectSingleNode("//SW.Blocks.FC//Name");
            node.InnerText = "FC_AIn2oo3";
            node = doc.SelectSingleNode("//SW.Blocks.FC//Number");
            node.InnerText = settings.fcAI2oo3sAddr.Substring(3);
            xml = doc.OuterXml;
            File.WriteAllText(path, xml);
        }
    }
}
