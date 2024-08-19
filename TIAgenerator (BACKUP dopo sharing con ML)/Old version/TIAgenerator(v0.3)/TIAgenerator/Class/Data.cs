using Newtonsoft.Json;
using Siemens.Engineering.SW.Blocks;
using System;
using System.Collections.Generic;
using System.IO;
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
                node = doc.SelectSingleNode("//ns:Access[1]//ns:Component[1]", ns);
                node.Attributes["Name"].Value = signal.PVIO;

                node = doc.SelectSingleNode("//ns:Access[2]//ns:Component[1]", ns);
                node.Attributes["Name"].Value = settings.settingsDBAddr;
                node = doc.SelectSingleNode("//ns:Access[2]//ns:Component[2]", ns);
                node.Attributes["Name"].Value = signal.tag;
                node = doc.SelectSingleNode("//ns:Access[2]//ns:Component[3]", ns);
                node.Attributes["Name"].Value = signal.minRange;
                node = doc.SelectSingleNode("//ns:Access[3]//ns:Component[1]", ns);
                node.Attributes["Name"].Value = settings.settingsDBAddr;
                node = doc.SelectSingleNode("//ns:Access[3]//ns:Component[2]", ns);
                node.Attributes["Name"].Value = signal.tag;
                node = doc.SelectSingleNode("//ns:Access[3]//ns:Component[3]", ns);
                node.Attributes["Name"].Value = signal.maxRange;
                node = doc.SelectSingleNode("//ns:Access[18]//ns:Component[1]", ns);
                node.Attributes["Name"].Value = settings.settingsDBAddr;
                node = doc.SelectSingleNode("//ns:Access[18]//ns:Component[2]", ns);
                node.Attributes["Name"].Value = signal.tag;
                node = doc.SelectSingleNode("//ns:Access[18]//ns:Component[3]", ns);
                node.Attributes["Name"].Value = signal.HiHiSP;
                node = doc.SelectSingleNode("//ns:Access[25]//ns:Component[1]", ns);
                node.Attributes["Name"].Value = settings.settingsDBAddr;
                node = doc.SelectSingleNode("//ns:Access[25]//ns:Component[2]", ns);
                node.Attributes["Name"].Value = signal.tag;
                node = doc.SelectSingleNode("//ns:Access[25]//ns:Component[3]", ns);
                node.Attributes["Name"].Value = signal.HiSP;
                node = doc.SelectSingleNode("//ns:Access[31]//ns:Component[1]", ns);
                node.Attributes["Name"].Value = settings.settingsDBAddr;
                node = doc.SelectSingleNode("//ns:Access[31]//ns:Component[2]", ns);
                node.Attributes["Name"].Value = signal.tag;
                node = doc.SelectSingleNode("//ns:Access[31]//ns:Component[3]", ns);
                node.Attributes["Name"].Value = signal.LoSP;
                node = doc.SelectSingleNode("//ns:Access[37]//ns:Component[1]", ns);
                node.Attributes["Name"].Value = settings.settingsDBAddr;
                node = doc.SelectSingleNode("//ns:Access[37]//ns:Component[2]", ns);
                node.Attributes["Name"].Value = signal.tag;
                node = doc.SelectSingleNode("//ns:Access[37]//ns:Component[3]", ns);
                node.Attributes["Name"].Value = signal.LoLoSP;

                node = doc.SelectSingleNode("//ns:Access[4]//ns:ConstantValue", ns);
                node.InnerText = "0";
                node = doc.SelectSingleNode("//ns:Access[5]//ns:ConstantValue", ns);
                node.InnerText = "27648";
                node = doc.SelectSingleNode("//ns:Access[6]//ns:ConstantValue", ns);
                node.InnerText = "29376";
                node = doc.SelectSingleNode("//ns:Access[7]//ns:ConstantValue", ns);
                node.InnerText = "-691";

                node = doc.SelectSingleNode("//ns:Access[10]//ns:ConstantValue", ns);
                node.InnerText = signal.FailTrips;


                node = doc.SelectSingleNode("//ns:Access[12]//ns:ConstantValue", ns);
                if(signal.hasHiHi == "true" || (signal.hasHi == "true" && signal.hasLoLo == "false"))
                {
                    node.InnerText = "true";
                }
                else
                {
                    node.InnerText = "false";
                }
                node = doc.SelectSingleNode("//ns:Access[13]//ns:ConstantValue", ns);
                if (!(signal.hasHiHi == "true" || (signal.hasHi == "true" && signal.hasLoLo == "false")))
                {
                    node.InnerText = "true";
                }
                else
                {
                    node.InnerText = "false";
                }
                node = doc.SelectSingleNode("//ns:Access[14]//ns:ConstantValue", ns);
                node.InnerText = "false";
                node = doc.SelectSingleNode("//ns:Access[15]//ns:ConstantValue", ns);
                node.InnerText = "0.0";






                if (signal.is1oo2Member == "true" || signal.is2oo2Member == "true" || signal.is2oo3Member == "true")
                {
                    node = doc.SelectSingleNode("//ns:Access[12]//ns:ConstantValue", ns);
                    node.InnerText = signal.GroupDB + ".Cfg_InFailUsePVEUMax";
                    node = doc.SelectSingleNode("//ns:Access[13]//ns:ConstantValue", ns);
                    node.InnerText = signal.GroupDB + ".Cfg_InFailUsePVEUMin";
                    node = doc.SelectSingleNode("//ns:Access[14]//ns:ConstantValue", ns);
                    node.InnerText = signal.GroupDB + ".Cfg_InFailUseValSub";
                    node = doc.SelectSingleNode("//ns:Access[15]//ns:ConstantValue", ns);
                    node.InnerText = signal.GroupDB + ".Cfg_ValSub";
                    if (signal.is2oo2Member == "true" || signal.is2oo3Member == "true")
                    {
                        node = doc.SelectSingleNode("//ns:Access[10]//ns:ConstantValue", ns);
                        node.InnerText = "false";
                    }
                    if (signal.is1oo2Member == "true")
                    {
                        node = doc.SelectSingleNode("//ns:Access[2]//ns:Component[1]", ns);
                        node.Attributes["Name"].Value = settings.settingsDBAddr;
                        node = doc.SelectSingleNode("//ns:Access[2]//ns:Component[2]", ns);
                        node.Attributes["Name"].Value = signal.tag;
                        node = doc.SelectSingleNode("//ns:Access[2]//ns:Component[3]", ns);
                        node.Attributes["Name"].Value = signal.minRange;
                        node = doc.SelectSingleNode("//ns:Access[3]//ns:Component[1]", ns);
                        node.Attributes["Name"].Value = settings.settingsDBAddr;
                        node = doc.SelectSingleNode("//ns:Access[3]//ns:Component[2]", ns);
                        node.Attributes["Name"].Value = signal.tag;
                        node = doc.SelectSingleNode("//ns:Access[3]//ns:Component[3]", ns);
                        node.Attributes["Name"].Value = signal.maxRange;
                        node = doc.SelectSingleNode("//ns:Access[18]//ns:Component[1]", ns);
                        node.Attributes["Name"].Value = settings.settingsDBAddr;
                        node = doc.SelectSingleNode("//ns:Access[18]//ns:Component[2]", ns);
                        node.Attributes["Name"].Value = signal.tag;
                        node = doc.SelectSingleNode("//ns:Access[18]//ns:Component[3]", ns);
                        node.Attributes["Name"].Value = signal.HiHiSP;
                        node = doc.SelectSingleNode("//ns:Access[25]//ns:Component[1]", ns);
                        node.Attributes["Name"].Value = settings.settingsDBAddr;
                        node = doc.SelectSingleNode("//ns:Access[25]//ns:Component[2]", ns);
                        node.Attributes["Name"].Value = signal.tag;
                        node = doc.SelectSingleNode("//ns:Access[25]//ns:Component[3]", ns);
                        node.Attributes["Name"].Value = signal.HiSP;
                        node = doc.SelectSingleNode("//ns:Access[31]//ns:Component[1]", ns);
                        node.Attributes["Name"].Value = settings.settingsDBAddr;
                        node = doc.SelectSingleNode("//ns:Access[31]//ns:Component[2]", ns);
                        node.Attributes["Name"].Value = signal.tag;
                        node = doc.SelectSingleNode("//ns:Access[31]//ns:Component[3]", ns);
                        node.Attributes["Name"].Value = signal.LoSP;
                        node = doc.SelectSingleNode("//ns:Access[37]//ns:Component[1]", ns);
                        node.Attributes["Name"].Value = settings.settingsDBAddr;
                        node = doc.SelectSingleNode("//ns:Access[37]//ns:Component[2]", ns);
                        node.Attributes["Name"].Value = signal.tag;
                        node = doc.SelectSingleNode("//ns:Access[37]//ns:Component[3]", ns);
                        node.Attributes["Name"].Value = signal.LoLoSP;
                    }
                    if (signal.is2oo2Member == "true")
                    {

                    }
                    if (signal.is2oo3Member == "true")
                    {

                    }
                }
                else
                {

                }
            }
        }
    }
}
