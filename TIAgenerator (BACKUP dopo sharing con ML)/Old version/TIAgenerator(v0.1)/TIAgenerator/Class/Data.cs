using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;

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
            Console.WriteLine(data);
            string text = "[\n" + data + "\n]";
            Console.WriteLine(text);
            objectList = JsonConvert.DeserializeObject<List<T>>(text);
        }
    }

    internal class ConfigSettings
    {
        public string digitalFCAddr { get; set; }
        public string NormalDIDBAddr { get; set; }
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

        public static string xmlHeader_FC_DI = "<?xml version=\"1.0\" encoding=\"utf-8\"?>\r\n<Document>\r\n  <Engineering version=\"V17\" />\r\n  <DocumentInfo>\r\n    <Created>2023-03-14T10:07:27.1633666Z</Created>\r\n    <ExportSetting>None</ExportSetting>\r\n    <InstalledProducts>\r\n      <Product>\r\n        <DisplayName>Totally Integrated Automation Portal</DisplayName>\r\n        <DisplayVersion>V17 Update 4</DisplayVersion>\r\n      </Product>\r\n      <OptionPackage>\r\n        <DisplayName>TIA Portal Openness</DisplayName>\r\n        <DisplayVersion>V17 Update 4</DisplayVersion>\r\n      </OptionPackage>\r\n      <OptionPackage>\r\n        <DisplayName>TIA Portal Version Control Interface</DisplayName>\r\n        <DisplayVersion>V17</DisplayVersion>\r\n      </OptionPackage>\r\n      <Product>\r\n        <DisplayName>STEP 7 Professional</DisplayName>\r\n        <DisplayVersion>V17 Update 4</DisplayVersion>\r\n      </Product>\r\n      <OptionPackage>\r\n        <DisplayName>STEP 7 Safety</DisplayName>\r\n        <DisplayVersion>V17</DisplayVersion>\r\n      </OptionPackage>\r\n      <Product>\r\n        <DisplayName>WinCC Advanced / Unified PC</DisplayName>\r\n        <DisplayVersion>V17 Update 4</DisplayVersion>\r\n      </Product>\r\n    </InstalledProducts>\r\n  </DocumentInfo>\r\n  <SW.Blocks.FC ID=\"0\">\r\n    <AttributeList>\r\n      <Interface><Sections xmlns=\"http://www.siemens.com/automation/Openness/SW/Interface/v5\">\r\n  <Section Name=\"Input\" />\r\n  <Section Name=\"Output\" />\r\n  <Section Name=\"InOut\" />\r\n  <Section Name=\"Temp\" />\r\n  <Section Name=\"Constant\" />\r\n  <Section Name=\"Return\">\r\n    <Member Name=\"Ret_Val\" Datatype=\"Void\" />\r\n  </Section>\r\n</Sections></Interface>\r\n      <MemoryLayout>Optimized</MemoryLayout>\r\n      <Name>FC_PROVA</Name>\r\n      <Number>1</Number>\r\n      <ProgrammingLanguage>LAD</ProgrammingLanguage>\r\n      <SetENOAutomatically>false</SetENOAutomatically>\r\n    </AttributeList>\r\n    <ObjectList>\r\n      <MultilingualText ID=\"1\" CompositionName=\"Comment\">\r\n        <ObjectList>\r\n          <MultilingualTextItem ID=\"2\" CompositionName=\"Items\">\r\n            <AttributeList>\r\n              <Culture>en-US</Culture>\r\n              <Text />\r\n            </AttributeList>\r\n          </MultilingualTextItem>\r\n        </ObjectList>\r\n      </MultilingualText>";
        public static string xmlBody_FC_DI = "";
        public static string xmlFooter_FC_DI = "\t\t<SW.Blocks.CompileUnit ID=\"D\" CompositionName=\"CompileUnits\">\r\n        <AttributeList>\r\n          <NetworkSource />\r\n          <ProgrammingLanguage>LAD</ProgrammingLanguage>\r\n        </AttributeList>\r\n        <ObjectList>\r\n          <MultilingualText ID=\"E\" CompositionName=\"Comment\">\r\n            <ObjectList>\r\n              <MultilingualTextItem ID=\"F\" CompositionName=\"Items\">\r\n                <AttributeList>\r\n                  <Culture>en-US</Culture>\r\n                  <Text />\r\n                </AttributeList>\r\n              </MultilingualTextItem>\r\n            </ObjectList>\r\n          </MultilingualText>\r\n          <MultilingualText ID=\"10\" CompositionName=\"Title\">\r\n            <ObjectList>\r\n              <MultilingualTextItem ID=\"11\" CompositionName=\"Items\">\r\n                <AttributeList>\r\n                  <Culture>en-US</Culture>\r\n                  <Text />\r\n                </AttributeList>\r\n              </MultilingualTextItem>\r\n            </ObjectList>\r\n          </MultilingualText>\t\t\t\r\n        </ObjectList>\r\n      </SW.Blocks.CompileUnit>\r\n      <MultilingualText ID=\"12\" CompositionName=\"Title\">\r\n        <ObjectList>\r\n          <MultilingualTextItem ID=\"13\" CompositionName=\"Items\">\r\n            <AttributeList>\r\n              <Culture>en-US</Culture>\r\n              <Text />\r\n            </AttributeList>\r\n          </MultilingualTextItem>\r\n        </ObjectList>\r\n      </MultilingualText>\r\n    </ObjectList>\r\n  </SW.Blocks.FC>\r\n</Document>";

        public string CreateNetwork_FC_DI(string ID, string tag, string tagDB, string nameDB)
        {
            string xml = "\t  <SW.Blocks.CompileUnit ID=\"";
            xml += ID;
            xml += "\" CompositionName=\"CompileUnits\">\r\n        <AttributeList>\r\n          <NetworkSource><FlgNet xmlns=\"http://www.siemens.com/automation/Openness/SW/NetworkSource/FlgNet/v4\">\r\n  <Parts>\r\n    <Access Scope=\"GlobalVariable\" UId=\"21\">\r\n      <Symbol>\r\n        <Component Name=\"";
            xml += tag;
            xml += "\" />\r\n      </Symbol>\r\n    </Access>\r\n    <Access Scope=\"GlobalVariable\" UId=\"22\">\r\n      <Symbol>\r\n        <Component Name=\"";
            xml += nameDB;
            xml += "\" />\r\n        <Component Name=\"";
            xml += tagDB;
            xml += "\" />\r\n      </Symbol>\r\n    </Access>\r\n    <Part Name=\"Contact\" UId=\"23\" />\r\n    <Part Name=\"Coil\" UId=\"24\" />\r\n  </Parts>\r\n  <Wires>\r\n    <Wire UId=\"25\">\r\n      <Powerrail />\r\n      <NameCon UId=\"23\" Name=\"in\" />\r\n    </Wire>\r\n    <Wire UId=\"26\">\r\n      <IdentCon UId=\"21\" />\r\n      <NameCon UId=\"23\" Name=\"operand\" />\r\n    </Wire>\r\n    <Wire UId=\"27\">\r\n      <NameCon UId=\"23\" Name=\"out\" />\r\n      <NameCon UId=\"24\" Name=\"in\" />\r\n    </Wire>\r\n    <Wire UId=\"28\">\r\n      <IdentCon UId=\"22\" />\r\n      <NameCon UId=\"24\" Name=\"operand\" />\r\n    </Wire>\r\n  </Wires>\r\n</FlgNet></NetworkSource>\r\n          <ProgrammingLanguage>LAD</ProgrammingLanguage>\r\n        </AttributeList>\r\n        <ObjectList>\r\n          <MultilingualText ID=\"";
            xml += "A" + ID;
            xml += "\" CompositionName=\"Comment\">\r\n            <ObjectList>\r\n              <MultilingualTextItem ID=\"";
            xml += "B" + ID;
            xml += "\" CompositionName=\"Items\">\r\n                <AttributeList>\r\n                  <Culture>en-US</Culture>\r\n                  <Text />\r\n                </AttributeList>\r\n              </MultilingualTextItem>\r\n            </ObjectList>\r\n          </MultilingualText>\r\n          <MultilingualText ID=\"";
            xml += "C" + ID;
            xml += "\" CompositionName=\"Title\">\r\n            <ObjectList>\r\n              <MultilingualTextItem ID=\"";
            xml += "D" + ID;
            xml += "\" CompositionName=\"Items\">\r\n                <AttributeList>\r\n                  <Culture>en-US</Culture>\r\n                  <Text>TEMPERATURE SWITCH</Text>\r\n                </AttributeList>\r\n              </MultilingualTextItem>\r\n            </ObjectList>\r\n          </MultilingualText>\r\n        </ObjectList>\r\n      </SW.Blocks.CompileUnit>";
            return xml;
        }





    }
}
