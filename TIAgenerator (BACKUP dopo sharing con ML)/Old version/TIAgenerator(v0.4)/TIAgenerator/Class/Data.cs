using Newtonsoft.Json;
using Siemens.Engineering.SW.Blocks;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Xml;
using TIAgenerator.Class;

namespace TIAgenerator
{
    //useful class to deserialize a json formatted text into a list
    internal class JsonData<T>
    {
        public List<T> objectList;
        public string data;

        public JsonData(string jsonFilePath)
        {
            data = File.ReadAllText(jsonFilePath);
        }

        public void GetJson()
        {  
            objectList = JsonConvert.DeserializeObject<List<T>>(data);
        }

        public void GetFixedJson()
        {
            //Console.WriteLine(data);
            string text = "[\n" + data + "\n]";
            //Console.WriteLine(text);
            objectList = JsonConvert.DeserializeObject<List<T>>(text);
        }
    }

    public class ConfigSettings
    {
        public string digitalFCAddr { get; set; }
        public string NormalDIDBAddr { get; set; }
        public string fcAIsAddr { get; set; }
        public string fcValsAddr { get; set; }
        public string fcAI2oo3sAddr { get; set; }
        public string fcAI2oo2sAddr { get; set; }
        public string fcAI1oo2sAddr { get; set; }
        public string fcCFCSetAddr { get; set; }
        public string CfcDigitalAlarmsDBAddr { get; set; }
        public string CfcDigitalsDBAddr { get; set; }
        public string fcUPsAddr { get; set; }
        public string upDBAddr { get; set; }
        public string fcBNsAddr { get; set; }
        public string settingsDBAddr { get; set; }
        public string settingsBNDBAddr { get; set; }
        public string settingsCFCDBAddr { get; set; }
        public string tagReset { get; set; }
        public string addressReset { get; set; }
        public string tagCmnFo { get; set; }
        public string addressCmnFo { get; set; }
        public string TimerCmnAlm { get; set; }
        public string TimerCmnSh { get; set; }
        public string tagCmnSh { get; set; }
        public string tagCmnAlm { get; set; }
        public string tagCmnMOS { get; set; }
        public string tagAlmFlash { get; set; }
        public string tagTripFlash { get; set; }
        public string ThereIsADigitalAlarm { get; set; }
        public string ThereIsASafetyProgram { get; set; }
        public string ThereIsASafetyDigital { get; set; }
    }

    public class XmlData
    {
        public static string xmlHeader_DB_DI = "<?xml version=\"1.0\" encoding=\"utf-8\"?>\r\n<Document>\r\n  <Engineering version=\"V17\" />\r\n  <DocumentInfo>\r\n    <Created>2023-03-08T16:44:23.1874801Z</Created>\r\n" +
        "    <ExportSetting>None</ExportSetting>\r\n    <InstalledProducts>\r\n      <Product>\r\n        <DisplayName>Totally Integrated Automation Portal</DisplayName>\r\n        " +
        "<DisplayVersion>V17 Update 4</DisplayVersion>\r\n      </Product>\r\n      <OptionPackage>\r\n        <DisplayName>TIA Portal Openness</DisplayName>\r\n        <DisplayVersion>V17 Update 4</DisplayVersion>\r\n" +
        "      </OptionPackage>\r\n      <OptionPackage>\r\n        <DisplayName>TIA Portal Version Control Interface</DisplayName>\r\n        <DisplayVersion>V17</DisplayVersion>\r\n      </OptionPackage>\r\n" +
        "      <Product>\r\n        <DisplayName>STEP 7 Professional</DisplayName>\r\n        <DisplayVersion>V17 Update 4</DisplayVersion>\r\n      </Product>\r\n      <OptionPackage>\r\n        " +
        "<DisplayName>STEP 7 Safety</DisplayName>\r\n        <DisplayVersion>V17</DisplayVersion>\r\n      </OptionPackage>\r\n      <Product>\r\n        <DisplayName>WinCC Advanced / Unified PC</DisplayName>\r\n" +
        "        <DisplayVersion>V17 Update 4</DisplayVersion>\r\n      </Product>\r\n    </InstalledProducts>\r\n  </DocumentInfo>\r\n  <SW.Blocks.GlobalDB ID=\"0\">\r\n    <AttributeList>\r\n      " +
        "<AutoNumber>false</AutoNumber>\r\n      <Interface><Sections xmlns=\"http://www.siemens.com/automation/Openness/SW/Interface/v5\">\r\n  <Section Name=\"Static\">\n";

        public static string xmlFooter_DB_DI = "      <ProgrammingLanguage>DB</ProgrammingLanguage>\r\n    </AttributeList>\r\n    <ObjectList>\r\n      <MultilingualText ID=\"1\" CompositionName=\"Comment\">\r\n        <ObjectList>\r\n          " +
            "<MultilingualTextItem ID=\"2\" CompositionName=\"Items\">\r\n            <AttributeList>\r\n              <Culture>en-US</Culture>\r\n              <Text />\r\n            </AttributeList>\r\n          " +
            "</MultilingualTextItem>\r\n        </ObjectList>\r\n      </MultilingualText>\r\n      <MultilingualText ID=\"3\" CompositionName=\"Title\">\r\n        <ObjectList>\r\n          " +
            "<MultilingualTextItem ID=\"4\" CompositionName=\"Items\">\r\n            <AttributeList>\r\n              <Culture>en-US</Culture>\r\n              <Text />\r\n            </AttributeList>\r\n          " +
            "</MultilingualTextItem>\r\n        </ObjectList>\r\n      </MultilingualText>\r\n    </ObjectList>\r\n  </SW.Blocks.GlobalDB>\r\n</Document>";

        public static string xmlHeader_FC_DI = "\r\n<Document>\r\n  <Engineering version=\"V17\" />\r\n  <DocumentInfo>\r\n    <Created>2023-03-24T09:45:04.5136241Z</Created>\r\n    <ExportSetting>None</ExportSetting>\r\n    <InstalledProducts>\r\n      <Product>\r\n        <DisplayName>Totally Integrated Automation Portal</DisplayName>\r\n        <DisplayVersion>V17 Update 4</DisplayVersion>\r\n      </Product>\r\n      <OptionPackage>\r\n        <DisplayName>TIA Portal Openness</DisplayName>\r\n        <DisplayVersion>V17 Update 4</DisplayVersion>\r\n      </OptionPackage>\r\n      <OptionPackage>\r\n        <DisplayName>TIA Portal Version Control Interface</DisplayName>\r\n        <DisplayVersion>V17</DisplayVersion>\r\n      </OptionPackage>\r\n      <Product>\r\n        <DisplayName>STEP 7 Professional</DisplayName>\r\n        <DisplayVersion>V17 Update 4</DisplayVersion>\r\n      </Product>\r\n      <OptionPackage>\r\n        <DisplayName>STEP 7 Safety</DisplayName>\r\n        <DisplayVersion>V17</DisplayVersion>\r\n      </OptionPackage>\r\n      <Product>\r\n        <DisplayName>WinCC Advanced / Unified PC</DisplayName>\r\n        <DisplayVersion>V17 Update 4</DisplayVersion>\r\n      </Product>\r\n    </InstalledProducts>\r\n  </DocumentInfo>\r\n  <SW.Blocks.FC ID=\"0\">\r\n    <AttributeList>\r\n      <Interface>\r\n        <Sections xmlns=\"http://www.siemens.com/automation/Openness/SW/Interface/v5\">\r\n          <Section Name=\"Input\" />\r\n          <Section Name=\"Output\" />\r\n          <Section Name=\"InOut\" />\r\n          <Section Name=\"Temp\" />\r\n          <Section Name=\"Constant\" />\r\n          <Section Name=\"Return\">\r\n            <Member Name=\"Ret_Val\" Datatype=\"Void\" />\r\n          </Section>\r\n        </Sections>\r\n      </Interface>\r\n      <MemoryLayout>Optimized</MemoryLayout>\r\n      <Name>FC_PROVA</Name>\r\n      <Number>1</Number>\r\n      <ProgrammingLanguage>LAD</ProgrammingLanguage>\r\n      <SetENOAutomatically>false</SetENOAutomatically>\r\n    </AttributeList>\r\n    <ObjectList>\r\n      <MultilingualText ID=\"1\" CompositionName=\"Comment\">\r\n        <ObjectList>\r\n          <MultilingualTextItem ID=\"2\" CompositionName=\"Items\">\r\n            <AttributeList>\r\n              <Culture>en-US</Culture>\r\n              <Text>Digital Input</Text>\r\n            </AttributeList>\r\n          </MultilingualTextItem>\r\n        </ObjectList>\r\n      </MultilingualText>";
        public static string xmlFooter_FC_DI = "      <MultilingualText ID=\"D\" CompositionName=\"Title\">\r\n        <ObjectList>\r\n          <MultilingualTextItem ID=\"E\" CompositionName=\"Items\">\r\n            <AttributeList>\r\n              <Culture>en-US</Culture>\r\n              <Text>FC_DI</Text>\r\n            </AttributeList>\r\n          </MultilingualTextItem>\r\n        </ObjectList>\r\n      </MultilingualText>\r\n    </ObjectList>\r\n  </SW.Blocks.FC>\r\n</Document>";
        public static string xmlHeader_DB_Settings = "<?xml version=\"1.0\" encoding=\"utf-8\"?>\r\n<Document>\r\n  <Engineering version=\"V17\" />\r\n  <DocumentInfo>\r\n    <Created>2023-04-06T14:59:51.4519566Z</Created>\r\n    <ExportSetting>None</ExportSetting>\r\n    <InstalledProducts>\r\n      <Product>\r\n        <DisplayName>Totally Integrated Automation Portal</DisplayName>\r\n        <DisplayVersion>V17 Update 4</DisplayVersion>\r\n      </Product>\r\n      <OptionPackage>\r\n        <DisplayName>TIA Portal Openness</DisplayName>\r\n        <DisplayVersion>V17 Update 4</DisplayVersion>\r\n      </OptionPackage>\r\n      <OptionPackage>\r\n        <DisplayName>TIA Portal Version Control Interface</DisplayName>\r\n        <DisplayVersion>V17</DisplayVersion>\r\n      </OptionPackage>\r\n      <Product>\r\n        <DisplayName>STEP 7 Professional</DisplayName>\r\n        <DisplayVersion>V17 Update 4</DisplayVersion>\r\n      </Product>\r\n      <OptionPackage>\r\n        <DisplayName>STEP 7 Safety</DisplayName>\r\n        <DisplayVersion>V17</DisplayVersion>\r\n      </OptionPackage>\r\n      <Product>\r\n        <DisplayName>WinCC Advanced / Unified PC</DisplayName>\r\n        <DisplayVersion>V17 Update 4</DisplayVersion>\r\n      </Product>\r\n    </InstalledProducts>\r\n  </DocumentInfo>\r\n  <SW.Blocks.GlobalDB ID=\"0\">\r\n    <AttributeList>\r\n      <AutoNumber>false</AutoNumber>\r\n      <Interface><Sections xmlns=\"http://www.siemens.com/automation/Openness/SW/Interface/v5\">\r\n  <Section Name=\"Static\">";
        public static string xmlFooter_DB_Settings = "  </Section>\r\n</Sections></Interface>\r\n      <MemoryLayout>Standard</MemoryLayout>\r\n      <Name>SETTINGS</Name>\r\n      <Number>25</Number>\r\n      <ProgrammingLanguage>DB</ProgrammingLanguage>\r\n    </AttributeList>\r\n    <ObjectList>\r\n      <MultilingualText ID=\"1\" CompositionName=\"Comment\">\r\n        <ObjectList>\r\n          <MultilingualTextItem ID=\"2\" CompositionName=\"Items\">\r\n            <AttributeList>\r\n              <Culture>en-US</Culture>\r\n              <Text />\r\n            </AttributeList>\r\n          </MultilingualTextItem>\r\n        </ObjectList>\r\n      </MultilingualText>\r\n      <MultilingualText ID=\"3\" CompositionName=\"Title\">\r\n        <ObjectList>\r\n          <MultilingualTextItem ID=\"4\" CompositionName=\"Items\">\r\n            <AttributeList>\r\n              <Culture>en-US</Culture>\r\n              <Text />\r\n            </AttributeList>\r\n          </MultilingualTextItem>\r\n        </ObjectList>\r\n      </MultilingualText>\r\n    </ObjectList>\r\n  </SW.Blocks.GlobalDB>\r\n</Document>";
        public static string xmlHeader_FC_AIn = "<?xml version=\"1.0\" encoding=\"utf-8\"?>\r\n<Document>\r\n\t<Engineering version=\"V17\" />\r\n\t<DocumentInfo>\r\n\t\t<Created>2023-04-26T11:43:36.2466218Z</Created>\r\n\t\t<ExportSetting>None</ExportSetting>\r\n\t\t<InstalledProducts>\r\n\t\t\t<Product>\r\n\t\t\t\t<DisplayName>Totally Integrated Automation Portal</DisplayName>\r\n\t\t\t\t<DisplayVersion>V17 Update 4</DisplayVersion>\r\n\t\t\t</Product>\r\n\t\t\t<OptionPackage>\r\n\t\t\t\t<DisplayName>TIA Portal Openness</DisplayName>\r\n\t\t\t\t<DisplayVersion>V17 Update 4</DisplayVersion>\r\n\t\t\t</OptionPackage>\r\n\t\t\t<OptionPackage>\r\n\t\t\t\t<DisplayName>TIA Portal Version Control Interface</DisplayName>\r\n\t\t\t\t<DisplayVersion>V17</DisplayVersion>\r\n\t\t\t</OptionPackage>\r\n\t\t\t<Product>\r\n\t\t\t\t<DisplayName>STEP 7 Professional</DisplayName>\r\n\t\t\t\t<DisplayVersion>V17 Update 4</DisplayVersion>\r\n\t\t\t</Product>\r\n\t\t\t<OptionPackage>\r\n\t\t\t\t<DisplayName>STEP 7 Safety</DisplayName>\r\n\t\t\t\t<DisplayVersion>V17</DisplayVersion>\r\n\t\t\t</OptionPackage>\r\n\t\t\t<Product>\r\n\t\t\t\t<DisplayName>WinCC Advanced / Unified PC</DisplayName>\r\n\t\t\t\t<DisplayVersion>V17 Update 4</DisplayVersion>\r\n\t\t\t</Product>\r\n\t\t</InstalledProducts>\r\n\t</DocumentInfo>\r\n\t<SW.Blocks.FC ID=\"0\">\r\n\t\t<AttributeList>\r\n\t\t\t<Interface>\r\n\t\t\t\t<Sections xmlns=\"http://www.siemens.com/automation/Openness/SW/Interface/v5\">\r\n\t\t\t\t\t<Section Name=\"Input\" />\r\n\t\t\t\t\t<Section Name=\"Output\" />\r\n\t\t\t\t\t<Section Name=\"InOut\" />\r\n\t\t\t\t\t<Section Name=\"Temp\" />\r\n\t\t\t\t\t<Section Name=\"Constant\" />\r\n\t\t\t\t\t<Section Name=\"Return\">\r\n\t\t\t\t\t\t<Member Name=\"Ret_Val\" Datatype=\"Void\" />\r\n\t\t\t\t\t</Section>\r\n\t\t\t\t</Sections>\r\n\t\t\t</Interface>\r\n\t\t\t<MemoryLayout>Standard</MemoryLayout>\r\n\t\t\t<Name>FC_AIn</Name>\r\n\t\t\t<Number>1</Number>\r\n\t\t\t<ProgrammingLanguage>LAD</ProgrammingLanguage>\r\n\t\t\t<SetENOAutomatically>false</SetENOAutomatically>\r\n\t\t</AttributeList>\r\n\t\t<ObjectList>\r\n\t\t\t<MultilingualText ID=\"1\" CompositionName=\"Comment\">\r\n\t\t\t\t<ObjectList>\r\n\t\t\t\t\t<MultilingualTextItem ID=\"2\" CompositionName=\"Items\">\r\n\t\t\t\t\t\t<AttributeList>\r\n\t\t\t\t\t\t\t<Culture>en-US</Culture>\r\n\t\t\t\t\t\t\t<Text>Analog Input</Text>\r\n\t\t\t\t\t\t</AttributeList>\r\n\t\t\t\t\t</MultilingualTextItem>\r\n\t\t\t\t</ObjectList>\r\n\t\t\t</MultilingualText>";
        public static string xmlFooter_FC_AIn = "\t\t\t<MultilingualText ID=\"12\" CompositionName=\"Title\">\r\n\t\t\t\t<ObjectList>\r\n\t\t\t\t\t<MultilingualTextItem ID=\"13\" CompositionName=\"Items\">\r\n\t\t\t\t\t\t<AttributeList>\r\n\t\t\t\t\t\t\t<Culture>en-US</Culture>\r\n\t\t\t\t\t\t\t<Text>FC_AIn</Text>\r\n\t\t\t\t\t\t</AttributeList>\r\n\t\t\t\t\t</MultilingualTextItem>\r\n\t\t\t\t</ObjectList>\r\n\t\t\t</MultilingualText>\r\n\t\t</ObjectList>\r\n\t</SW.Blocks.FC>\r\n</Document>";
        public static string xmlHeader_FC_AIn2oo3 = "<?xml version=\"1.0\" encoding=\"utf-8\"?>\r\n<Document>\r\n  <Engineering version=\"V17\" />\r\n  <DocumentInfo>\r\n    <Created>2023-12-29T10:44:22.8737876Z</Created>\r\n    <ExportSetting>None</ExportSetting>\r\n    <InstalledProducts>\r\n      <Product>\r\n        <DisplayName>Totally Integrated Automation Portal</DisplayName>\r\n        <DisplayVersion>V17 Update 4</DisplayVersion>\r\n      </Product>\r\n      <OptionPackage>\r\n        <DisplayName>TIA Portal Openness</DisplayName>\r\n        <DisplayVersion>V17 Update 4</DisplayVersion>\r\n      </OptionPackage>\r\n      <OptionPackage>\r\n        <DisplayName>TIA Portal Version Control Interface</DisplayName>\r\n        <DisplayVersion>V17</DisplayVersion>\r\n      </OptionPackage>\r\n      <Product>\r\n        <DisplayName>STEP 7 Professional</DisplayName>\r\n        <DisplayVersion>V17 Update 4</DisplayVersion>\r\n      </Product>\r\n      <OptionPackage>\r\n        <DisplayName>STEP 7 Safety</DisplayName>\r\n        <DisplayVersion>V17</DisplayVersion>\r\n      </OptionPackage>\r\n      <Product>\r\n        <DisplayName>WinCC Advanced / Unified PC</DisplayName>\r\n        <DisplayVersion>V17 Update 4</DisplayVersion>\r\n      </Product>\r\n    </InstalledProducts>\r\n  </DocumentInfo>\r\n  <SW.Blocks.FC ID=\"0\">\r\n    <AttributeList>\r\n      <AutoNumber>false</AutoNumber>\r\n      <Interface><Sections xmlns=\"http://www.siemens.com/automation/Openness/SW/Interface/v5\">\r\n  <Section Name=\"Input\" />\r\n  <Section Name=\"Output\" />\r\n  <Section Name=\"InOut\" />\r\n  <Section Name=\"Temp\" />\r\n  <Section Name=\"Constant\" />\r\n  <Section Name=\"Return\">\r\n    <Member Name=\"Ret_Val\" Datatype=\"Void\" />\r\n  </Section>\r\n</Sections></Interface>\r\n      <MemoryLayout>Optimized</MemoryLayout>\r\n      <Name>FCAIn2oo3</Name>\r\n      <Number>31</Number>\r\n      <ProgrammingLanguage>LAD</ProgrammingLanguage>\r\n      <SetENOAutomatically>false</SetENOAutomatically>\r\n    </AttributeList>\r\n    <ObjectList>\r\n      <MultilingualText ID=\"1\" CompositionName=\"Comment\">\r\n        <ObjectList>\r\n          <MultilingualTextItem ID=\"2\" CompositionName=\"Items\">\r\n            <AttributeList>\r\n              <Culture>en-US</Culture>\r\n              <Text>AnalogInput2oo3</Text>\r\n            </AttributeList>\r\n          </MultilingualTextItem>\r\n        </ObjectList>\r\n      </MultilingualText>";
        public static string xmlFooter_FC_AIn2oo3 = "      <MultilingualText ID=\"12\" CompositionName=\"Title\">\r\n        <ObjectList>\r\n          <MultilingualTextItem ID=\"13\" CompositionName=\"Items\">\r\n            <AttributeList>\r\n              <Culture>en-US</Culture>\r\n              <Text />\r\n            </AttributeList>\r\n          </MultilingualTextItem>\r\n        </ObjectList>\r\n      </MultilingualText>\r\n    </ObjectList>\r\n  </SW.Blocks.FC>\r\n</Document>";
        public static string xmlHeader_FC_AIn2oo2 = "";
        public static string xmlFooter_FC_AIn2oo2 = "";
        public static string xmlHeader_FC_AIn1oo2 = "";
        public static string xmlFooter_FC_AIn1oo2 = "";

        //Adding element with component to a XML document
        private static XmlNode AddChildXML(XmlDocument doc, XmlNamespaceManager ns, string targetNodeName, string newElementName, string newAttributeName, string newAttributeValue)
        {
            //find the element target
            XmlNode node = doc.SelectSingleNode(targetNodeName, ns);
            if (node != null)
            {
                //create and append the new element with component
                XmlElement element = doc.CreateElement(newElementName);
                element.SetAttribute(newAttributeName, newAttributeValue);
                node.AppendChild(element);
            }

            return node;
        }
        public static void FC_DI_Network(int ID, string nameDB, ref string xml, DigitalSignal signal)
        {
            XmlDocument doc = new XmlDocument();                                                                        //create empty virtual XmlDoc
            XmlNode node;
            XmlNamespaceManager ns = new XmlNamespaceManager(doc.NameTable);                                            //create namespace manager to use if necessary
            ns.AddNamespace("ns", "http://www.siemens.com/automation/Openness/SW/NetworkSource/FlgNet/v4");             //Add namespace for Node reference if necessary in XML file
            doc.Load(Methods.GetRelativePath(@"\Xml\FC_DI_Network.xml"));                                                       //load doc from file
            node = doc.SelectSingleNode("//SW.Blocks.CompileUnit");                                             //pointer to a specific Node
            node.Attributes["ID"].Value = ID.ToString();                                                                //change value of a specific Node's Attibute 
            node = doc.SelectSingleNode("//ns:Component", ns);
            node.Attributes["Name"].Value = signal.tag + "_FLD";
            node = doc.SelectSingleNode("//ns:Access[2]//ns:Component[1]", ns);
            node.Attributes["Name"].Value = nameDB;
            node = doc.SelectSingleNode("//ns:Access[2]//ns:Component[2]", ns);
            node.Attributes["Name"].Value = signal.tag;
            node = doc.SelectSingleNode("//SW.Blocks.CompileUnit//MultilingualText[1]");
            node.Attributes["ID"].Value = "A" + ID.ToString();
            node = doc.SelectSingleNode("//SW.Blocks.CompileUnit//MultilingualText[1]//MultilingualTextItem");
            node.Attributes["ID"].Value = "B" + ID.ToString();
            node = doc.SelectSingleNode("//SW.Blocks.CompileUnit//MultilingualText[2]");
            node.Attributes["ID"].Value = "C" + ID.ToString();
            node = doc.SelectSingleNode("//SW.Blocks.CompileUnit//MultilingualText[2]//MultilingualTextItem");
            node.Attributes["ID"].Value = "D" + ID.ToString();
            node = doc.SelectSingleNode("//SW.Blocks.CompileUnit//MultilingualText[2]//MultilingualTextItem//Text");
            node.InnerText = signal.description;                                                                             //change text between XML Tag
            xml += "\n" + doc.OuterXml;
        }

        public static void FC_DI_NetworkR(int ID, string nameDB, ref string xml, DigitalSignal signal)
        {
            XmlDocument doc = new XmlDocument();                                                                        //create empty virtual XmlDoc
            XmlNode node;
            XmlNamespaceManager ns = new XmlNamespaceManager(doc.NameTable);                                            //create namespace manager to use if necessary
            ns.AddNamespace("ns", "http://www.siemens.com/automation/Openness/SW/NetworkSource/FlgNet/v4");             //Add namespace for Node reference if necessary in XML file
            doc.Load(Methods.GetRelativePath(@"\Xml\FC_DI_NetworkR.xml"));                                                       //load doc from file
            node = doc.SelectSingleNode("//SW.Blocks.CompileUnit");                                             //pointer to a specific Node
            node.Attributes["ID"].Value = ID.ToString();                                                                //change value of a specific Node's Attibute 
            node = doc.SelectSingleNode("//ns:Component", ns);
            node.Attributes["Name"].Value = signal.tag + "_FLD";
            node = doc.SelectSingleNode("//ns:Access[2]//ns:Component[1]", ns);
            node.Attributes["Name"].Value = signal.tag + "_FLDR";
            node = doc.SelectSingleNode("//ns:Access[3]//ns:Component[1]", ns);
            node.Attributes["Name"].Value = nameDB;
            node = doc.SelectSingleNode("//ns:Access[3]//ns:Component[2]", ns);
            node.Attributes["Name"].Value = signal.tag;
            node = doc.SelectSingleNode("//SW.Blocks.CompileUnit//MultilingualText[1]");
            node.Attributes["ID"].Value = "A" + ID.ToString();
            node = doc.SelectSingleNode("//SW.Blocks.CompileUnit//MultilingualText[1]//MultilingualTextItem");
            node.Attributes["ID"].Value = "B" + ID.ToString();
            node = doc.SelectSingleNode("//SW.Blocks.CompileUnit//MultilingualText[2]");
            node.Attributes["ID"].Value = "C" + ID.ToString();
            node = doc.SelectSingleNode("//SW.Blocks.CompileUnit//MultilingualText[2]//MultilingualTextItem");
            node.Attributes["ID"].Value = "D" + ID.ToString();
            node = doc.SelectSingleNode("//SW.Blocks.CompileUnit//MultilingualText[2]//MultilingualTextItem//Text");
            node.InnerText = signal.description;                                                                             //change text between XML Tag
            xml += "\n" + doc.OuterXml;
        }

        public static void FC_DI_NetworkAT(ConfigSettings settings, int ID, ref string xml, DigitalSignal signal)
        {
            XmlDocument doc = new XmlDocument();                                                                        //create empty virtual XmlDoc
            XmlNode node;
            XmlNamespaceManager ns = new XmlNamespaceManager(doc.NameTable);                                            //create namespace manager to use if necessary
            ns.AddNamespace("ns", "http://www.siemens.com/automation/Openness/SW/NetworkSource/FlgNet/v4");             //Add namespace for Node reference if necessary in XML file
            doc.Load(Methods.GetRelativePath(@"\Xml\FC_DI_Network_AT.xml"));                                                       //load doc from file
            node = doc.SelectSingleNode("//SW.Blocks.CompileUnit");                                             //pointer to a specific Node
            node.Attributes["ID"].Value = ID.ToString();
            node = doc.SelectSingleNode("//ns:Access[1]//ns:Component", ns);
            node.Attributes["Name"].Value = signal.tag + "_FLD";
            node = doc.SelectSingleNode("//ns:Access[2]//ns:Component", ns);
            node.Attributes["Name"].Value = settings.tagReset;
            node = doc.SelectSingleNode("//ns:Access[3]//ns:ConstantValue", ns);
            node.InnerText = "false";
            node = doc.SelectSingleNode("//ns:Access[4]//ns:ConstantValue", ns);
            node.InnerText = "false";
            node = doc.SelectSingleNode("//ns:Access[5]//ns:ConstantValue", ns);
            node.InnerText = "t#1s";
            node = doc.SelectSingleNode("//ns:Access[6]//ns:ConstantValue", ns);
            node.InnerText = signal.isTrip;
            node = doc.SelectSingleNode("//ns:Access[7]//ns:ConstantValue", ns);
            node.InnerText = "false";
            node = doc.SelectSingleNode("//ns:Access[8]//ns:Component[1]", ns);
            node.Attributes["Name"].Value = "UP";
            node = doc.SelectSingleNode("//ns:Access[8]//ns:Component[2]", ns);
            node.Attributes["Name"].Value = settings.tagTripFlash;
            node = doc.SelectSingleNode("//ns:Access[9]//ns:Component[1]", ns);
            node.Attributes["Name"].Value = "UP";
            node = doc.SelectSingleNode("//ns:Access[9]//ns:Component[2]", ns);
            node.Attributes["Name"].Value = settings.tagAlmFlash;
            node = doc.SelectSingleNode("//ns:Access[10]//ns:Component", ns);
            node.Attributes["Name"].Value = settings.tagCmnFo;
            node = doc.SelectSingleNode("//ns:Call//ns:Component", ns);
            node.Attributes["Name"].Value = signal.tag;
            node = doc.SelectSingleNode("//SW.Blocks.CompileUnit//MultilingualText[1]");
            node.Attributes["ID"].Value = "A" + ID.ToString();
            node = doc.SelectSingleNode("//SW.Blocks.CompileUnit//MultilingualText[1]//MultilingualTextItem");
            node.Attributes["ID"].Value = "B" + ID.ToString();
            node = doc.SelectSingleNode("//SW.Blocks.CompileUnit//MultilingualText[2]");
            node.Attributes["ID"].Value = "C" + ID.ToString();
            node = doc.SelectSingleNode("//SW.Blocks.CompileUnit//MultilingualText[2]//MultilingualTextItem");
            node.Attributes["ID"].Value = "D" + ID.ToString();
            node = doc.SelectSingleNode("//SW.Blocks.CompileUnit//MultilingualText[2]//MultilingualTextItem//Text");
            node.InnerText = signal.description;                                                                             //change text between XML Tag
            xml += "\n" + doc.OuterXml;
        }

        public static void FC_DI_NetworkATR(ConfigSettings settings, int ID, ref string xml, DigitalSignal signal)
        {
            XmlDocument doc = new XmlDocument();                                                                        //create empty virtual XmlDoc
            XmlNode node;
            XmlNamespaceManager ns = new XmlNamespaceManager(doc.NameTable);                                            //create namespace manager to use if necessary
            ns.AddNamespace("ns", "http://www.siemens.com/automation/Openness/SW/NetworkSource/FlgNet/v4");             //Add namespace for Node reference if necessary in XML file
            doc.Load(Methods.GetRelativePath(@"\Xml\FC_DI_Network_ATR.xml"));                                                       //load doc from file
            node = doc.SelectSingleNode("//SW.Blocks.CompileUnit");                                             //pointer to a specific Node
            node.Attributes["ID"].Value = ID.ToString();
            node = doc.SelectSingleNode("//ns:Access[1]//ns:Component", ns);
            node.Attributes["Name"].Value = signal.tag + "_FLD";
            node = doc.SelectSingleNode("//ns:Access[2]//ns:Component", ns);
            node.Attributes["Name"].Value = signal.tag + "_FLDR";
            node = doc.SelectSingleNode("//ns:Access[3]//ns:Component", ns);
            node.Attributes["Name"].Value = settings.tagReset;
            node = doc.SelectSingleNode("//ns:Access[4]//ns:ConstantValue", ns);
            node.InnerText = "false";
            node = doc.SelectSingleNode("//ns:Access[5]//ns:ConstantValue", ns);
            node.InnerText = "false";
            node = doc.SelectSingleNode("//ns:Access[6]//ns:ConstantValue", ns);
            node.InnerText = "t#1s";
            node = doc.SelectSingleNode("//ns:Access[7]//ns:ConstantValue", ns);
            node.InnerText = signal.isTrip;
            node = doc.SelectSingleNode("//ns:Access[8]//ns:ConstantValue", ns);
            node.InnerText = "false";
            node = doc.SelectSingleNode("//ns:Access[9]//ns:Component[1]", ns);
            node.Attributes["Name"].Value = "UP";
            node = doc.SelectSingleNode("//ns:Access[9]//ns:Component[2]", ns);
            node.Attributes["Name"].Value = settings.tagTripFlash;
            node = doc.SelectSingleNode("//ns:Access[10]//ns:Component[1]", ns);
            node.Attributes["Name"].Value = "UP";
            node = doc.SelectSingleNode("//ns:Access[10]//ns:Component[2]", ns);
            node.Attributes["Name"].Value = settings.tagAlmFlash;
            node = doc.SelectSingleNode("//ns:Access[11]//ns:Component", ns);
            node.Attributes["Name"].Value = settings.tagCmnFo;
            node = doc.SelectSingleNode("//ns:Call//ns:Component", ns);
            node.Attributes["Name"].Value = signal.tag;
            node = doc.SelectSingleNode("//SW.Blocks.CompileUnit//MultilingualText[1]");
            node.Attributes["ID"].Value = "A" + ID.ToString();
            node = doc.SelectSingleNode("//SW.Blocks.CompileUnit//MultilingualText[1]//MultilingualTextItem");
            node.Attributes["ID"].Value = "B" + ID.ToString();
            node = doc.SelectSingleNode("//SW.Blocks.CompileUnit//MultilingualText[2]");
            node.Attributes["ID"].Value = "C" + ID.ToString();
            node = doc.SelectSingleNode("//SW.Blocks.CompileUnit//MultilingualText[2]//MultilingualTextItem");
            node.Attributes["ID"].Value = "D" + ID.ToString();
            node = doc.SelectSingleNode("//SW.Blocks.CompileUnit//MultilingualText[2]//MultilingualTextItem//Text");
            node.InnerText = signal.description;                                                                             //change text between XML Tag
            xml += "\n" + doc.OuterXml;
        }

        public static void DB_SettingsBody(ref string xml, AnalogSignal signal)
        {
            XmlDocument doc = new XmlDocument();                                                                        //create empty virtual XmlDoc
            XmlNode node;
            XmlNamespaceManager ns = new XmlNamespaceManager(doc.NameTable);                                            //create namespace manager to use if necessary
            ns.AddNamespace("ns", "");             //Add namespace for Node reference if necessary in XML file
            doc.Load(Methods.GetRelativePath(@"\Xml\DB_SettingsBody.xml"));                                                       //load doc from file                                                            //change value of a specific Node's Attibute 
            node = doc.SelectSingleNode("//ns:Member", ns);
            node.Attributes["Name"].Value = signal.tag;
            node = doc.SelectSingleNode("//ns:Member//ns:MultiLanguageText", ns);
            node.InnerText = signal.description;
            node = doc.SelectSingleNode("//ns:Member//ns:Member[1]//ns:StartValue", ns);
            node.InnerText = signal.minRange;
            node = doc.SelectSingleNode("//ns:Member//ns:Member[2]//ns:StartValue", ns);
            node.InnerText = signal.maxRange;
            node = doc.SelectSingleNode("//ns:Member//ns:Member[3]//ns:StartValue", ns);
            node.InnerText = signal.LoLoSP;
            node = doc.SelectSingleNode("//ns:Member//ns:Member[4]//ns:StartValue", ns);
            node.InnerText = signal.LoSP;
            node = doc.SelectSingleNode("//ns:Member//ns:Member[5]//ns:StartValue", ns);
            node.InnerText = signal.HiSP;
            node = doc.SelectSingleNode("//ns:Member//ns:Member[6]//ns:StartValue", ns);
            node.InnerText = signal.HiHiSP;
            xml += "\n" + doc.OuterXml;
        }

        public static void FC_AIn_Network(ConfigSettings settings, int ID, ref string xml, AnalogSignal signal)
        {

            XmlDocument doc = new XmlDocument();                                                                        //create empty virtual XmlDoc
            XmlNode node;
            XmlNamespaceManager ns = new XmlNamespaceManager(doc.NameTable);                                            //create namespace manager to use if necessary
            ns.AddNamespace("ns", "http://www.siemens.com/automation/Openness/SW/NetworkSource/FlgNet/v4");             //Add namespace for Node reference if necessary in XML file
            doc.Load(Methods.GetRelativePath(@"\Xml\FC_AIn_Network.xml"));                                           //load doc from file                                                            //change value of a specific Node's Attibute 
            if (signal.isRedundant == "false")
            {
                node = doc.SelectSingleNode("//SW.Blocks.CompileUnit");                                             //pointer to a specific Node
                node.Attributes["ID"].Value = ID.ToString();
                node = doc.SelectSingleNode("//ns:Access[1]//ns:Component[1]", ns);//inp_PV
                node.Attributes["Name"].Value = signal.tag + "_FLD";
                node = doc.SelectSingleNode("//ns:Access[2]//ns:Component[1]", ns);//cfg_PVEUMin
                node.Attributes["Name"].Value = "SETTINGS";
                node = doc.SelectSingleNode("//ns:Access[2]//ns:Component[2]", ns);
                node.Attributes["Name"].Value = signal.tag;
                node = doc.SelectSingleNode("//ns:Access[2]//ns:Component[3]", ns);
                node.Attributes["Name"].Value = "RANGE_L";
                node = doc.SelectSingleNode("//ns:Access[3]//ns:Component[1]", ns); //cfg_PVEUMax
                node.Attributes["Name"].Value = "SETTINGS";;
                node = doc.SelectSingleNode("//ns:Access[3]//ns:Component[2]", ns);
                node.Attributes["Name"].Value = signal.tag;
                node = doc.SelectSingleNode("//ns:Access[3]//ns:Component[3]", ns);
                node.Attributes["Name"].Value = "RANGE_H";
                node = doc.SelectSingleNode("//ns:Access[18]//ns:Component[1]", ns);//oset_HiHiLim
                node.Attributes["Name"].Value = "SETTINGS";;
                node = doc.SelectSingleNode("//ns:Access[18]//ns:Component[2]", ns);
                node.Attributes["Name"].Value = signal.tag;
                node = doc.SelectSingleNode("//ns:Access[18]//ns:Component[3]", ns);
                node.Attributes["Name"].Value = "SP_HH";
                node = doc.SelectSingleNode("//ns:Access[25]//ns:Component[1]", ns);//oset_HiLim
                node.Attributes["Name"].Value = "SETTINGS";;
                node = doc.SelectSingleNode("//ns:Access[25]//ns:Component[2]", ns);
                node.Attributes["Name"].Value = signal.tag;
                node = doc.SelectSingleNode("//ns:Access[25]//ns:Component[3]", ns);
                node.Attributes["Name"].Value = "SP_H";
                node = doc.SelectSingleNode("//ns:Access[31]//ns:Component[1]", ns);//oset_LoLim
                node.Attributes["Name"].Value = "SETTINGS";;
                node = doc.SelectSingleNode("//ns:Access[31]//ns:Component[2]", ns);
                node.Attributes["Name"].Value = signal.tag;
                node = doc.SelectSingleNode("//ns:Access[31]//ns:Component[3]", ns);
                node.Attributes["Name"].Value = "SP_L";
                node = doc.SelectSingleNode("//ns:Access[37]//ns:Component[1]", ns);//oset_LoLoLim
                node.Attributes["Name"].Value = "SETTINGS";;
                node = doc.SelectSingleNode("//ns:Access[37]//ns:Component[2]", ns);
                node.Attributes["Name"].Value = signal.tag;
                node = doc.SelectSingleNode("//ns:Access[37]//ns:Component[3]", ns);
                node.Attributes["Name"].Value = "SP_LL";
                node = doc.SelectSingleNode("//ns:Access[4]//ns:ConstantValue", ns);
                node.InnerText = "0";
                node = doc.SelectSingleNode("//ns:Access[5]//ns:ConstantValue", ns);
                node.InnerText = "27648";
                node = doc.SelectSingleNode("//ns:Access[6]//ns:ConstantValue", ns);
                node.InnerText = "29376";
                node = doc.SelectSingleNode("//ns:Access[7]//ns:ConstantValue", ns);
                node.InnerText = "-691";
                node = doc.SelectSingleNode("//ns:Access[10]//ns:ConstantValue", ns);//cfg_FailTripsUnit
                node.InnerText = signal.FailTrips;
                node = doc.SelectSingleNode("//ns:Access[14]//ns:Component[1]", ns);//cfg_InFailUseValSub
                node.Attributes["Name"].Value = "AlwaysFALSE";
                node = doc.SelectSingleNode("//ns:Access[15]//ns:ConstantValue", ns);//cfg_ValSub
                node.InnerText = "0.0";
                node = doc.SelectSingleNode("//ns:Access[43]//ns:Component[1]", ns);//inp_Reset
                node.Attributes["Name"].Value = settings.tagReset;
                node = doc.SelectSingleNode("//ns:Access[47]//ns:Component[1]", ns);//commonFirstOut
                node.Attributes["Name"].Value = settings.tagCmnFo;
                node = doc.SelectSingleNode("//ns:Access[48]//ns:Component[1]", ns);//isaAlarmFlashing
                node.Attributes["Name"].Value = "UP";
                node = doc.SelectSingleNode("//ns:Access[48]//ns:Component[2]", ns);
                node.Attributes["Name"].Value = settings.tagAlmFlash;
                node = doc.SelectSingleNode("//ns:Access[49]//ns:Component[1]", ns);//isaTripsFlashing
                node.Attributes["Name"].Value = "UP";
                node = doc.SelectSingleNode("//ns:Access[49]//ns:Component[2]", ns);
                node.Attributes["Name"].Value = settings.tagTripFlash;

                if(signal.hasHiHi == "true" || (signal.hasHi == "true" && signal.hasLoLo == "false"))
                {
                    node = doc.SelectSingleNode("//ns:Access[12]//ns:Component[1]", ns);//cfg_InFailUsePVEUMax
                    node.Attributes["Name"].Value = "AlwaysTRUE";
                }
                else
                {
                    node = doc.SelectSingleNode("//ns:Access[12]//ns:Component[1]", ns);
                    node.Attributes["Name"].Value = "AlwaysFALSE";
                }

                if (!(signal.hasHiHi == "true" || (signal.hasHi == "true" && signal.hasLoLo == "false")))
                {
                    node = doc.SelectSingleNode("//ns:Access[13]//ns:Component[1]", ns);//cfg_InFailUsePVEUMin
                    node.Attributes["Name"].Value = "AlwaysTRUE";
                }
                else
                {
                    node = doc.SelectSingleNode("//ns:Access[13]//ns:Component[1]", ns);
                    node.Attributes["Name"].Value = "AlwaysFALSE";
                }

                if (signal.description.ToLower().Contains("temperature"))
                {
                    node = doc.SelectSingleNode("//ns:Access[19]//ns:ConstantValue", ns);//cfg_HiHiDelay
                    node.InnerText = "T#5s";
                    node = doc.SelectSingleNode("//ns:Access[26]//ns:ConstantValue", ns);//cfg_HiDelay
                    node.InnerText = "T#5s";
                    node = doc.SelectSingleNode("//ns:Access[32]//ns:ConstantValue", ns);//cfg_LoDelay
                    node.InnerText = "T#5s";
                    node = doc.SelectSingleNode("//ns:Access[38]//ns:ConstantValue", ns);//cfg_LoLoDelay
                    node.InnerText = "T#5s";
                }
                else
                {
                    node = doc.SelectSingleNode("//ns:Access[19]//ns:ConstantValue", ns);//cfg_HiHiDelay
                    node.InnerText = "T#1s";
                    node = doc.SelectSingleNode("//ns:Access[26]//ns:ConstantValue", ns);//cfg_HiDelay
                    node.InnerText = "T#1s";
                    node = doc.SelectSingleNode("//ns:Access[32]//ns:ConstantValue", ns);//cfg_LoDelay
                    node.InnerText = "T#1s";
                    node = doc.SelectSingleNode("//ns:Access[38]//ns:ConstantValue", ns);//cfg_LoLoDelay
                    node.InnerText = "T#1s";
                }

                if (signal.FailTrips == "true")
                {
                    node = doc.SelectSingleNode("//ns:Access[10]//ns:ConstantValue", ns);//cfg_FailTripsUnit
                    node.InnerText = "true";
                }
                if (signal.HiHiTrips == "true")
                {
                    node = doc.SelectSingleNode("//ns:Access[22]//ns:ConstantValue", ns);//cfg_HiHiTripsUnit
                    node.InnerText = "true";
                }
                if (signal.LoLoTrips == "true")
                {
                    node = doc.SelectSingleNode("//ns:Access[41]//ns:ConstantValue", ns);//cfg_LoLoTripsUnit
                    node.InnerText = "true";
                }

                //VOTING
                if (signal.is1oo2Member == "true" || signal.is2oo2Member == "true" || signal.is2oo3Member == "true")
                {
                    node = doc.SelectSingleNode("//ns:Access[2]//ns:Component[1]", ns);//cfg_PVEUMin
                    node.Attributes["Name"].Value = "SETTINGS"; ;
                    node = doc.SelectSingleNode("//ns:Access[2]//ns:Component[2]", ns);
                    node.Attributes["Name"].Value = signal.tagVooting;
                    node = doc.SelectSingleNode("//ns:Access[2]//ns:Component[3]", ns);
                    node.Attributes["Name"].Value = "RANGE_H";
                    node = doc.SelectSingleNode("//ns:Access[3]//ns:Component[1]", ns); //cfg_PVEUMax
                    node.Attributes["Name"].Value = "SETTINGS"; ;
                    node = doc.SelectSingleNode("//ns:Access[3]//ns:Component[2]", ns);
                    node.Attributes["Name"].Value = signal.tagVooting;
                    node = doc.SelectSingleNode("//ns:Access[3]//ns:Component[3]", ns);
                    node.Attributes["Name"].Value = "RANGE_L";
                    node = doc.SelectSingleNode("//ns:Access[18]//ns:Component[1]", ns);//oset_HiHiLim
                    node.Attributes["Name"].Value = "SETTINGS"; ;
                    node = doc.SelectSingleNode("//ns:Access[18]//ns:Component[2]", ns);
                    node.Attributes["Name"].Value = signal.tagVooting;
                    node = doc.SelectSingleNode("//ns:Access[18]//ns:Component[3]", ns);
                    node.Attributes["Name"].Value = "SP_HH";
                    node = doc.SelectSingleNode("//ns:Access[25]//ns:Component[1]", ns);//oset_HiLim
                    node.Attributes["Name"].Value = "SETTINGS"; ;
                    node = doc.SelectSingleNode("//ns:Access[25]//ns:Component[2]", ns);
                    node.Attributes["Name"].Value = signal.tagVooting;
                    node = doc.SelectSingleNode("//ns:Access[25]//ns:Component[3]", ns);
                    node.Attributes["Name"].Value = "SP_H";
                    node = doc.SelectSingleNode("//ns:Access[31]//ns:Component[1]", ns);//oset_LoLim
                    node.Attributes["Name"].Value = "SETTINGS"; ;
                    node = doc.SelectSingleNode("//ns:Access[31]//ns:Component[2]", ns);
                    node.Attributes["Name"].Value = signal.tagVooting;
                    node = doc.SelectSingleNode("//ns:Access[31]//ns:Component[3]", ns);
                    node.Attributes["Name"].Value = "SP_L";
                    node = doc.SelectSingleNode("//ns:Access[37]//ns:Component[1]", ns);//oset_LoLoLim
                    node.Attributes["Name"].Value = "SETTINGS"; ;
                    node = doc.SelectSingleNode("//ns:Access[37]//ns:Component[2]", ns);
                    node.Attributes["Name"].Value = signal.tagVooting;
                    node = doc.SelectSingleNode("//ns:Access[37]//ns:Component[3]", ns);
                    node.Attributes["Name"].Value = "SP_LL";
                    node = doc.SelectSingleNode("//ns:Access[12]//ns:Component[1]", ns);//cfg_InFailUsePVEUMax
                    node.Attributes["Name"].Value = signal.tagVooting;
                    XmlData.AddChildXML(doc, ns, "//ns:Access[12]//ns:Symbol[1]", "Component", "Name", "Cfg_InFailUsePVEUMax");
                    node = doc.SelectSingleNode("//ns:Access[13]//ns:Component[1]", ns);//cfg_InFailUsePVEUMin
                    node.Attributes["Name"].Value = signal.tagVooting;
                    XmlData.AddChildXML(doc, ns, "//ns:Access[13]//ns:Symbol[1]", "Component", "Name", "Cfg_InFailUsePVEUMin");
                    node = doc.SelectSingleNode("//ns:Access[14]//ns:Component[1]", ns);//cfg_InFailUseValSub
                    node.Attributes["Name"].Value = signal.tagVooting;
                    XmlData.AddChildXML(doc, ns, "//ns:Access[14]//ns:Symbol[1]", "Component", "Name", "Cfg_InFailUseValSub");
                    /*
                    node = doc.SelectSingleNode("//ns:Access[15]//ns:Component[1]", ns);//cfg_ValSub
                    node.Attributes["Name"].Value = signal.tagVooting;
                    XmlData.AddChildXML(doc, ns, "//ns:Access[15]//ns:Symbol[1]", "Component", "Name", "Cfg_ValSub");
                    */
                    node = doc.SelectSingleNode("//ns:Access[17]//ns:Component[1]", ns);//cfg_HasHiHiAlm
                    node.Attributes["Name"].Value = signal.tagVooting;
                    XmlData.AddChildXML(doc, ns, "//ns:Access[17]//ns:Symbol[1]", "Component", "Name", "Cfg_HasHiHiAlm");
                    node = doc.SelectSingleNode("//ns:Access[24]//ns:Component[1]", ns);//cfg_HasHiAlm
                    node.Attributes["Name"].Value = signal.tagVooting;
                    XmlData.AddChildXML(doc, ns, "//ns:Access[24]//ns:Symbol[1]", "Component", "Name", "Cfg_HasHiAlm");
                    node = doc.SelectSingleNode("//ns:Access[30]//ns:Component[1]", ns);//cfg_HasLoAlm
                    node.Attributes["Name"].Value = signal.tagVooting;
                    XmlData.AddChildXML(doc, ns, "//ns:Access[30]//ns:Symbol[1]", "Component", "Name", "Cfg_HasLoAlm");
                    node = doc.SelectSingleNode("//ns:Access[36]//ns:Component[1]", ns);//cfg_HasLoLoAlm
                    node.Attributes["Name"].Value = signal.tagVooting;
                    XmlData.AddChildXML(doc, ns, "//ns:Access[36]//ns:Symbol[1]", "Component", "Name", "Cfg_HasLoLoAlm");
                }
                else
                {
                    if (signal.hasHiHi == "true")
                    {
                        node = doc.SelectSingleNode("//ns:Access[17]//ns:Component[1]", ns);//cfg_HasHiHiAlm
                        node.Attributes["Name"].Value = "AlwaysTRUE";
                    }
                    if (signal.hasHi == "true")
                    {
                        node = doc.SelectSingleNode("//ns:Access[24]//ns:Component[1]", ns);//cfg_HasHiAlm
                        node.Attributes["Name"].Value = "AlwaysTRUE";
                    }
                    if (signal.hasLo == "true")
                    {
                        node = doc.SelectSingleNode("//ns:Access[30]//ns:Component[1]", ns);//cfg_HasLoAlm
                        node.Attributes["Name"].Value = "AlwaysTRUE";
                    }
                    if (signal.hasLoLo == "true")
                    {
                        node = doc.SelectSingleNode("//ns:Access[36]//ns:Component[1]", ns);//cfg_HasLoLoAlm
                        node.Attributes["Name"].Value = "AlwaysTRUE";
                    }
                }
                
                //NETWORK FOOTER
                node = doc.SelectSingleNode("//ns:Call//ns:Component", ns);
                node.Attributes["Name"].Value = signal.tag;
                node = doc.SelectSingleNode("//SW.Blocks.CompileUnit//MultilingualText[1]");
                node.Attributes["ID"].Value = "A" + ID.ToString();
                node = doc.SelectSingleNode("//SW.Blocks.CompileUnit//MultilingualText[1]//MultilingualTextItem");
                node.Attributes["ID"].Value = "B" + ID.ToString();
                node = doc.SelectSingleNode("//SW.Blocks.CompileUnit//MultilingualText[2]");
                node.Attributes["ID"].Value = "C" + ID.ToString();
                node = doc.SelectSingleNode("//SW.Blocks.CompileUnit//MultilingualText[2]//MultilingualTextItem");
                node.Attributes["ID"].Value = "D" + ID.ToString();
                node = doc.SelectSingleNode("//SW.Blocks.CompileUnit//MultilingualText[2]//MultilingualTextItem//Text");
                node.InnerText = signal.description;

            }
            string txt = doc.OuterXml;
            //questa parte è temporanea, se si trova un metodo migliore per cfg_ValSub va eliminato AL MOMENTO NON FUNZIONA
            if (signal.is1oo2Member == "true" || signal.is2oo2Member == "true" || signal.is2oo3Member == "true")
            {
                //node.SelectNodes()
                //Console.WriteLine("xml");
                txt = txt.Replace("<Access Scope=\"LiteralConstant\" UId=\"35\">\r\n\t\t\t\t\t\t\t\t\t<Constant>\r\n\t\t\t\t\t\t\t\t\t\t<ConstantType>Real</ConstantType>\r\n\t\t\t\t\t\t\t\t\t\t<ConstantValue>0.0</ConstantValue>\r\n\t\t\t\t\t\t\t\t\t</Constant>\r\n\t\t\t\t\t\t\t\t</Access>", "<Access Scope=\"GlobalVariable\" UId=\"35\">\r\n      <Symbol>\r\n        <Component Name=\"UP\" />\r\n        <Component Name=\"ALM_FLASHING\" />\r\n      </Symbol>\r\n    </Access>");
            }
            xml += "\n" + txt;
        }

        public static void FC_AIn2oo3_Network(ConfigSettings settings, int ID, ref string xml, AnalogSignal ai)
        {            
            AnalogInput2oo3 signal = (AnalogInput2oo3)ai;
            XmlDocument doc = new XmlDocument();                                                                        //create empty virtual XmlDoc
            XmlNode node;
            XmlNamespaceManager ns = new XmlNamespaceManager(doc.NameTable);                                            //create namespace manager to use if necessary
            ns.AddNamespace("ns", "http://www.siemens.com/automation/Openness/SW/NetworkSource/FlgNet/v4");             //Add namespace for Node reference if necessary in XML file
            doc.Load(Methods.GetRelativePath(@"\Xml\FC_AIn2oo3_Network.xml"));                                           //load doc from file                                                            //change value of a specific Node's Attibute 
            if (signal.isRedundant == "false")
            {
                node = doc.SelectSingleNode("//SW.Blocks.CompileUnit");                                             //pointer to a specific Node
                node.Attributes["ID"].Value = ID.ToString();
                node = doc.SelectSingleNode("//ns:Access[1]//ns:Component[1]", ns);//Inp_ValA
                node.Attributes["Name"].Value = signal.tagA;
                node = doc.SelectSingleNode("//ns:Access[1]//ns:Component[2]", ns);
                node.Attributes["Name"].Value = "Val";
                node = doc.SelectSingleNode("//ns:Access[2]//ns:Component[1]", ns);//Inp_ValB
                node.Attributes["Name"].Value = signal.tagB;
                node = doc.SelectSingleNode("//ns:Access[2]//ns:Component[2]", ns);
                node.Attributes["Name"].Value = "Val";
                node = doc.SelectSingleNode("//ns:Access[3]//ns:Component[1]", ns);//Inp_ValC
                node.Attributes["Name"].Value = signal.tagC;
                node = doc.SelectSingleNode("//ns:Access[3]//ns:Component[2]", ns);
                node.Attributes["Name"].Value = "Val";
                node = doc.SelectSingleNode("//ns:Access[4]//ns:Component[1]", ns);//Cfg_PVEUMin
                node.Attributes["Name"].Value = "SETTINGS";
                node = doc.SelectSingleNode("//ns:Access[4]//ns:Component[2]", ns);
                node.Attributes["Name"].Value = signal.tag;
                node = doc.SelectSingleNode("//ns:Access[4]//ns:Component[3]", ns);
                node.Attributes["Name"].Value = "RANGE_L";
                node = doc.SelectSingleNode("//ns:Access[5]//ns:Component[1]", ns);//Cfg_PVEUMax
                node.Attributes["Name"].Value = "SETTINGS";
                node = doc.SelectSingleNode("//ns:Access[5]//ns:Component[2]", ns);
                node.Attributes["Name"].Value = signal.tag;
                node = doc.SelectSingleNode("//ns:Access[5]//ns:Component[3]", ns);
                node.Attributes["Name"].Value = "RANGE_H";
                node = doc.SelectSingleNode("//ns:Access[6]//ns:Component[1]", ns);//Inp_FailAlmA
                node.Attributes["Name"].Value = signal.tagA;
                node = doc.SelectSingleNode("//ns:Access[6]//ns:Component[2]", ns);
                node.Attributes["Name"].Value = "Alm_Fail";
                node = doc.SelectSingleNode("//ns:Access[7]//ns:Component[1]", ns);//Inp_FailAlmB
                node.Attributes["Name"].Value = signal.tagB;
                node = doc.SelectSingleNode("//ns:Access[7]//ns:Component[2]", ns);
                node.Attributes["Name"].Value = "Alm_Fail";
                node = doc.SelectSingleNode("//ns:Access[8]//ns:Component[1]", ns);//Inp_FailAlmC
                node.Attributes["Name"].Value = signal.tagC;
                node = doc.SelectSingleNode("//ns:Access[8]//ns:Component[2]", ns);
                node.Attributes["Name"].Value = "Alm_Fail";
                node = doc.SelectSingleNode("//ns:Access[9]//ns:ConstantValue", ns);//Cfg_FailBypass
                node.InnerText = "false";
                node = doc.SelectSingleNode("//ns:Access[10]//ns:ConstantValue", ns);//Cfg_FailTripsUnit
                node.InnerText = "false";
                node = doc.SelectSingleNode("//ns:Access[11]//ns:ConstantValue", ns);//Cfg_FailResetRequired
                node.InnerText = "false";
                node = doc.SelectSingleNode("//ns:Access[12]//ns:ConstantValue", ns);//Cfg_InFailUsePVEUMax
                node.InnerText = "false";
                node = doc.SelectSingleNode("//ns:Access[13]//ns:ConstantValue", ns);//Cfg_InFailUsePVEUMin
                node.InnerText = "false";
                node = doc.SelectSingleNode("//ns:Access[14]//ns:ConstantValue", ns);//Cfg_InFailUseValSub
                node.InnerText = "false";
                node = doc.SelectSingleNode("//ns:Access[15]//ns:ConstantValue", ns);//Cfg_ValSub
                node.InnerText = "0.0";

                //-------------------------------------------------------------------------------------------------
                node = doc.SelectSingleNode("//ns:Access[16]//ns:Component[1]", ns);//Inp_HiHiAlmA
                node.Attributes["Name"].Value = signal.tagA;
                node = doc.SelectSingleNode("//ns:Access[16]//ns:Component[2]", ns);
                node.Attributes["Name"].Value = "Alm_HiHi";
                node = doc.SelectSingleNode("//ns:Access[17]//ns:Component[1]", ns);//Inp_HiHiAlmB
                node.Attributes["Name"].Value = signal.tagB;
                node = doc.SelectSingleNode("//ns:Access[17]//ns:Component[2]", ns);
                node.Attributes["Name"].Value = "Alm_HiHi";
                node = doc.SelectSingleNode("//ns:Access[18]//ns:Component[1]", ns);//Inp_HiHiAlmC
                node.Attributes["Name"].Value = signal.tagC;
                node = doc.SelectSingleNode("//ns:Access[18]//ns:Component[2]", ns);
                node.Attributes["Name"].Value = "Alm_HiHi";
                node = doc.SelectSingleNode("//ns:Access[19]//ns:ConstantValue", ns);//Cfg_HasHiHiAlm
                node.InnerText = "false";
                node = doc.SelectSingleNode("//ns:Access[20]//ns:Component[1]", ns);//Oset_HiHiLim
                node.Attributes["Name"].Value = "SETTINGS";
                node = doc.SelectSingleNode("//ns:Access[20]//ns:Component[2]", ns);
                node.Attributes["Name"].Value = signal.tag;
                node = doc.SelectSingleNode("//ns:Access[20]//ns:Component[3]", ns);
                node.Attributes["Name"].Value = "SP_HH";
                node = doc.SelectSingleNode("//ns:Access[21]//ns:ConstantValue", ns);//Cfg_HiHiDelay
                node.InnerText = "T#1s";
                node = doc.SelectSingleNode("//ns:Access[22]//ns:ConstantValue", ns);//Cfg_HiHiDB
                node.InnerText = "0.0";
                node = doc.SelectSingleNode("//ns:Access[23]//ns:ConstantValue", ns);//Cfg_HiHiBypass
                node.InnerText = "false";
                node = doc.SelectSingleNode("//ns:Access[24]//ns:ConstantValue", ns);//Cfg_HiHiTripsUnit
                node.InnerText = "false";
                node = doc.SelectSingleNode("//ns:Access[25]//ns:ConstantValue", ns);//Cfg_HiHiResetRequired
                node.InnerText = "false";

                //-------------------------------------------------------------------------------------------------
                node = doc.SelectSingleNode("//ns:Access[26]//ns:Component[1]", ns);//Inp_HiAlmA
                node.Attributes["Name"].Value = signal.tagA;
                node = doc.SelectSingleNode("//ns:Access[26]//ns:Component[2]", ns);
                node.Attributes["Name"].Value = "Alm_Hi";
                node = doc.SelectSingleNode("//ns:Access[27]//ns:Component[1]", ns);//Inp_HiAlmB
                node.Attributes["Name"].Value = signal.tagB;
                node = doc.SelectSingleNode("//ns:Access[27]//ns:Component[2]", ns);
                node.Attributes["Name"].Value = "Alm_Hi";
                node = doc.SelectSingleNode("//ns:Access[28]//ns:Component[1]", ns);//Inp_HiAlmC
                node.Attributes["Name"].Value = signal.tagC;
                node = doc.SelectSingleNode("//ns:Access[28]//ns:Component[2]", ns);
                node.Attributes["Name"].Value = "Alm_Hi";
                node = doc.SelectSingleNode("//ns:Access[29]//ns:ConstantValue", ns);//Cfg_HasHiAlm
                node.InnerText = "false";
                node = doc.SelectSingleNode("//ns:Access[30]//ns:Component[1]", ns);//Oset_HiLim
                node.Attributes["Name"].Value = "SETTINGS";
                node = doc.SelectSingleNode("//ns:Access[30]//ns:Component[2]", ns);
                node.Attributes["Name"].Value = signal.tag;
                node = doc.SelectSingleNode("//ns:Access[30]//ns:Component[3]", ns);
                node.Attributes["Name"].Value = "SP_H";
                node = doc.SelectSingleNode("//ns:Access[31]//ns:ConstantValue", ns);//Cfg_HiDelay
                node.InnerText = "T#1s";
                node = doc.SelectSingleNode("//ns:Access[32]//ns:ConstantValue", ns);//Cfg_HiDB
                node.InnerText = "0.0";
                node = doc.SelectSingleNode("//ns:Access[33]//ns:ConstantValue", ns);//Cfg_HiBypass
                node.InnerText = "false";
                node = doc.SelectSingleNode("//ns:Access[34]//ns:ConstantValue", ns);//Cfg_HiResetRequired
                node.InnerText = "false";
                //-------------------------------------------------------------------------------------------------

                node = doc.SelectSingleNode("//ns:Access[35]//ns:Component[1]", ns);//Inp_LoAlmA
                node.Attributes["Name"].Value = signal.tagA;
                node = doc.SelectSingleNode("//ns:Access[35]//ns:Component[2]", ns);
                node.Attributes["Name"].Value = "Alm_Lo";
                node = doc.SelectSingleNode("//ns:Access[36]//ns:Component[1]", ns);//Inp_LoAlmB
                node.Attributes["Name"].Value = signal.tagB;
                node = doc.SelectSingleNode("//ns:Access[36]//ns:Component[2]", ns);
                node.Attributes["Name"].Value = "Alm_Lo";
                node = doc.SelectSingleNode("//ns:Access[37]//ns:Component[1]", ns);//Inp_LoAlmC
                node.Attributes["Name"].Value = signal.tagC;
                node = doc.SelectSingleNode("//ns:Access[37]//ns:Component[2]", ns);
                node.Attributes["Name"].Value = "Alm_Lo";
                node = doc.SelectSingleNode("//ns:Access[38]//ns:ConstantValue", ns);//Cfg_HasLoAlm
                node.InnerText = "false";
                node = doc.SelectSingleNode("//ns:Access[39]//ns:Component[1]", ns);//Oset_LoLim
                node.Attributes["Name"].Value = "SETTINGS";
                node = doc.SelectSingleNode("//ns:Access[39]//ns:Component[2]", ns);
                node.Attributes["Name"].Value = signal.tag;
                node = doc.SelectSingleNode("//ns:Access[39]//ns:Component[3]", ns);
                node.Attributes["Name"].Value = "SP_L";
                node = doc.SelectSingleNode("//ns:Access[40]//ns:ConstantValue", ns);//Cfg_LoDelay
                node.InnerText = "T#1s";
                node = doc.SelectSingleNode("//ns:Access[41]//ns:ConstantValue", ns);//Cfg_LoDB
                node.InnerText = "0.0";
                node = doc.SelectSingleNode("//ns:Access[42]//ns:ConstantValue", ns);//Cfg_LoBypass
                node.InnerText = "false";
                node = doc.SelectSingleNode("//ns:Access[43]//ns:ConstantValue", ns);//Cfg_LoResetRequired
                node.InnerText = "false";
                //-------------------------------------------------------------------------------------------------

                node = doc.SelectSingleNode("//ns:Access[44]//ns:Component[1]", ns);//Inp_LoLoAlmA
                node.Attributes["Name"].Value = signal.tagA;
                node = doc.SelectSingleNode("//ns:Access[44]//ns:Component[2]", ns);
                node.Attributes["Name"].Value = "Alm_LoLo";
                node = doc.SelectSingleNode("//ns:Access[45]//ns:Component[1]", ns);//Inp_LoLoAlmB
                node.Attributes["Name"].Value = signal.tagB;
                node = doc.SelectSingleNode("//ns:Access[45]//ns:Component[2]", ns);
                node.Attributes["Name"].Value = "Alm_LoLo";
                node = doc.SelectSingleNode("//ns:Access[46]//ns:Component[1]", ns);//Inp_LoLoAlmC
                node.Attributes["Name"].Value = signal.tagC;
                node = doc.SelectSingleNode("//ns:Access[46]//ns:Component[2]", ns);
                node.Attributes["Name"].Value = "Alm_LoLo";
                node = doc.SelectSingleNode("//ns:Access[47]//ns:ConstantValue", ns);//Cfg_HasLoLoAlm
                node.InnerText = "false";
                node = doc.SelectSingleNode("//ns:Access[48]//ns:Component[1]", ns);//Oset_LoLoLim
                node.Attributes["Name"].Value = "SETTINGS";
                node = doc.SelectSingleNode("//ns:Access[48]//ns:Component[2]", ns);
                node.Attributes["Name"].Value = signal.tag;
                node = doc.SelectSingleNode("//ns:Access[48]//ns:Component[3]", ns);
                node.Attributes["Name"].Value = "SP_LL";
                node = doc.SelectSingleNode("//ns:Access[49]//ns:ConstantValue", ns);//Cfg_LoLoDelay
                node.InnerText = "T#1s";
                node = doc.SelectSingleNode("//ns:Access[50]//ns:ConstantValue", ns);//Cfg_LoLoDB
                node.InnerText = "0.0";
                node = doc.SelectSingleNode("//ns:Access[51]//ns:ConstantValue", ns);//Cfg_LoLoBypass
                node.InnerText = "false";
                node = doc.SelectSingleNode("//ns:Access[52]//ns:ConstantValue", ns);//Cfg_LoLoTripsUnit
                node.InnerText = "false";
                node = doc.SelectSingleNode("//ns:Access[53]//ns:ConstantValue", ns);//Cfg_LoLoResetRequired
                node.InnerText = "false";
                //---------------------------------------------------------------------------------------------
                
                node = doc.SelectSingleNode("//ns:Access[54]//ns:ConstantValue", ns);//Cfg_CheckPercDev
                node.InnerText = "true";
                node = doc.SelectSingleNode("//ns:Access[55]//ns:ConstantValue", ns);//Cfg_CheckEUDev
                node.InnerText = "false";
                node = doc.SelectSingleNode("//ns:Access[56]//ns:ConstantValue", ns);//Cfg_EUDeviation
                node.InnerText = "0.0";
                node = doc.SelectSingleNode("//ns:Access[57]//ns:ConstantValue", ns);//Cfg_PercDeviation
                node.InnerText = "5.0";
                node = doc.SelectSingleNode("//ns:Access[58]//ns:Component[1]", ns);//Inp_Reset
                node.Attributes["Name"].Value = settings.tagReset;
                node = doc.SelectSingleNode("//ns:Access[59]//ns:ConstantValue", ns);//PCmd_MOS
                node.InnerText = "false";
                node = doc.SelectSingleNode("//ns:Access[60]//ns:ConstantValue", ns);//Cfg_UseDigitalAlarms
                node.InnerText = "true";
                node = doc.SelectSingleNode("//ns:Access[61]//ns:ConstantValue", ns);//Cfg_UseMedianValue
                node.InnerText = "false";
                node = doc.SelectSingleNode("//ns:Access[62]//ns:ConstantValue", ns);//Cfg_if1FailUse2oo2
                node.InnerText = "false";
                node = doc.SelectSingleNode("//ns:Access[63]//ns:ConstantValue", ns);//SpareIn1
                node.InnerText = "0.0";
                node = doc.SelectSingleNode("//ns:Access[64]//ns:ConstantValue", ns);//SpareIn2
                node.InnerText = "0.0";
                node = doc.SelectSingleNode("//ns:Access[65]//ns:Component[1]", ns);//CommonFirstOut
                node.Attributes["Name"].Value = settings.tagCmnFo;
                node = doc.SelectSingleNode("//ns:Access[66]//ns:Component[1]", ns);//IsaAlarmFlashing
                node.Attributes["Name"].Value = "UP";
                node = doc.SelectSingleNode("//ns:Access[66]//ns:Component[2]", ns);
                node.Attributes["Name"].Value = settings.tagAlmFlash;
                node = doc.SelectSingleNode("//ns:Access[67]//ns:Component[1]", ns);//IsaTripFlashing
                node.Attributes["Name"].Value = "UP";
                node = doc.SelectSingleNode("//ns:Access[67]//ns:Component[2]", ns);
                node.Attributes["Name"].Value = settings.tagTripFlash;
                //---------------------------------------------------------------------------------------------

                if (signal.hasHiHi == "true" || (signal.hasHi == "true" && signal.hasLoLo == "false"))
                {
                    node = doc.SelectSingleNode("//ns:Access[12]//ns:ConstantValue", ns);//Cfg_InFailUsePVEUMax
                    node.InnerText = "true";
                }

                if (!(signal.hasHiHi == "true" || (signal.hasHi == "true" && signal.hasLoLo == "false")))
                {
                    node = doc.SelectSingleNode("//ns:Access[13]//ns:ConstantValue", ns);//Cfg_InFailUsePVEUMax
                    node.InnerText = "true";
                }
                if (signal.description.ToLower().Contains("temperature"))
                {
                    node = doc.SelectSingleNode("//ns:Access[21]//ns:ConstantValue", ns);//cfg_HiHiDelay
                    node.InnerText = "T#5s";
                    node = doc.SelectSingleNode("//ns:Access[31]//ns:ConstantValue", ns);//cfg_HiDelay
                    node.InnerText = "T#5s";
                    node = doc.SelectSingleNode("//ns:Access[40]//ns:ConstantValue", ns);//cfg_LoDelay
                    node.InnerText = "T#5s";
                    node = doc.SelectSingleNode("//ns:Access[49]//ns:ConstantValue", ns);//cfg_LoLoDelay
                    node.InnerText = "T#5s";
                }
                if (signal.FailTrips == "true")
                {
                    node = doc.SelectSingleNode("//ns:Access[10]//ns:ConstantValue", ns);//cfg_FailTripsUnit
                    node.InnerText = "true";
                }
                if (signal.HiHiTrips == "true")
                {
                    node = doc.SelectSingleNode("//ns:Access[24]//ns:ConstantValue", ns);//cfg_HiHiTripsUnit
                    node.InnerText = "true";
                }
                if (signal.LoLoTrips == "true")
                {
                    node = doc.SelectSingleNode("//ns:Access[52]//ns:ConstantValue", ns);//cfg_LoLoTripsUnit
                    node.InnerText = "true";
                }
                if (signal.hasHiHi == "true")
                {
                    node = doc.SelectSingleNode("//ns:Access[19]//ns:ConstantValue", ns);//cfg_HasHiHiAlm
                    node.InnerText = "true";
                }
                if (signal.hasHi == "true")
                {
                    node = doc.SelectSingleNode("//ns:Access[29]//ns:ConstantValue", ns);//cfg_HasHiAlm
                    node.InnerText = "true";
                }
                if (signal.hasLo == "true")
                {
                    node = doc.SelectSingleNode("//ns:Access[38]//ns:ConstantValue", ns);//cfg_HasLoAlm
                    node.InnerText = "true";
                }
                if (signal.hasLoLo == "true")
                {
                    node = doc.SelectSingleNode("//ns:Access[47]//ns:ConstantValue", ns);//cfg_HasLoLoAlm
                    node.InnerText = "true";
                }

                //NETWORK FOOTER
                node = doc.SelectSingleNode("//ns:Call//ns:Component", ns);
                node.Attributes["Name"].Value = signal.tag;
                node = doc.SelectSingleNode("//SW.Blocks.CompileUnit//MultilingualText[1]");
                node.Attributes["ID"].Value = "A" + ID.ToString();
                node = doc.SelectSingleNode("//SW.Blocks.CompileUnit//MultilingualText[1]//MultilingualTextItem");
                node.Attributes["ID"].Value = "B" + ID.ToString();
                node = doc.SelectSingleNode("//SW.Blocks.CompileUnit//MultilingualText[2]");
                node.Attributes["ID"].Value = "C" + ID.ToString();
                node = doc.SelectSingleNode("//SW.Blocks.CompileUnit//MultilingualText[2]//MultilingualTextItem");
                node.Attributes["ID"].Value = "D" + ID.ToString();
                node = doc.SelectSingleNode("//SW.Blocks.CompileUnit//MultilingualText[2]//MultilingualTextItem//Text");
                node.InnerText = signal.description;
            }
            xml += "\n" + doc.OuterXml;
        }
    }
}

