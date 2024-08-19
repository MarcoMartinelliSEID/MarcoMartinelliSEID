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

        public static void GenerateDB12(List<DigitalSignal> list, int DBNumber)
        {
            string xmlBody = "";
            string path = GetRelativePath(@"\Xml\DB_DI.xml");
            foreach (DigitalSignal i in list)
            {
                xmlBody = xmlBody + "    <Member Name=\"" + i.tag + "\" Datatype=\"Bool\">\r\n      <Comment>\r\n        <MultiLanguageText Lang=\"en-US\">" + i.description + "</MultiLanguageText>\r\n      </Comment>\r\n    </Member>" + "\n";
            }
            xmlBody = xmlBody + "  </Section>\r\n</Sections></Interface>\r\n      <MemoryLayout>Optimized</MemoryLayout>\r\n      <MemoryReserve>100</MemoryReserve>\r\n      <Name>DI</Name>\r\n      <Number>" + DBNumber + "</Number>\r\n";
            string xmlDB = XmlData.xmlHeader_DB_DI + xmlBody + XmlData.xmlFooter_DB_DI;
            //Console.WriteLine(xmlDB12);
            File.WriteAllText(path, xmlDB);
            Console.WriteLine("Done");
            TIAMethods.ImportDB(0, 1, path);
        }

        public void CreateNetworks_FC_DI(List<DigitalSignal> list, List<PlcTag> PlcTagList)
        {
            int ID = 0;
            string nameDB = "DI";
            string xml = "";
            XmlDocument doc = new XmlDocument();                                    //create empty virtual XmlDoc
            doc.Load(GetRelativePath(@"\Xml\FSWS_DI.xml"));                         //load doc from file
            XmlNamespaceManager ns = new XmlNamespaceManager(doc.NameTable);        //create namespace manager to use if necessary
            foreach (DigitalSignal i in list)
            {
                ID += 1;
                if (i.isAlarm == "true" || i.isTrip == "true")
                {
                    continue;
                }
                else
                {
                    ns.AddNamespace("ns", "http://www.siemens.com/automation/Openness/SW/NetworkSource/FlgNet/v4");             //Add namespace for Node reference if necessary in XML file
                    XmlNode node = doc.SelectSingleNode("//SW.Blocks.CompileUnit");                                             //pointer to a specific Node
                    node.Attributes["ID"].Value = ID.ToString();                                                                //change value of a specific Node's Attibute 
                    node = doc.SelectSingleNode("//ns:Component", ns);
                    node.Attributes["Name"].Value = "TAG" + "_FLD";
                    node = doc.SelectSingleNode("//ns:Access[2]//ns:Component[1]", ns);
                    node.Attributes["Name"].Value = nameDB;
                    node = doc.SelectSingleNode("//ns:Access[2]//ns:Component[2]", ns);
                    node.Attributes["Name"].Value = "TAG";
                    node = doc.SelectSingleNode("//SW.Blocks.CompileUnit//MultilingualText[1]");
                    node.Attributes["ID"].Value = "A" + ID.ToString();
                    node = doc.SelectSingleNode("//SW.Blocks.CompileUnit//MultilingualText[1]//MultilingualTextItem");
                    node.Attributes["ID"].Value = "B" + ID.ToString();
                    node = doc.SelectSingleNode("//SW.Blocks.CompileUnit//MultilingualText[2]");
                    node.Attributes["ID"].Value = "C" + ID.ToString();
                    node = doc.SelectSingleNode("//SW.Blocks.CompileUnit//MultilingualText[2]//MultilingualTextItem");
                    node.Attributes["ID"].Value = "D" + ID.ToString();
                    node = doc.SelectSingleNode("//SW.Blocks.CompileUnit//MultilingualText[2]//MultilingualTextItem//Text");
                    node.InnerText = "DESCRIPTION";                                                                             //change text between XML Tag
                    xml += doc.OuterXml;
                    doc.Save(Methods.GetRelativePath(@"\Xml\FSWS_DI.xml"));                                                     //save file
                }
            }
            /*
            XmlDocumentFragment fragment = doc.CreateDocumentFragment();
            fragment.InnerXml = "\n      <FIGANASTRO>Optimized</FIGANASTRO>\r\n      <Name>COGLIONEEEEEE</Name>\r\n      <Number>1</Number>\n";
            XmlNode node = doc.SelectSingleNode("//ObjectList");
            node.AppendChild(fragment);
            */
            
            doc.Save("C:\\Users\\Win10\\Desktop\\PROVAAAA.xml");
        }
    }
}
