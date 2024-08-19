﻿using Newtonsoft.Json;
using Siemens.Engineering.SW.Blocks;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Xml;
using TIAgenerator.Class;

namespace TIAgenerator.Class
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

    //Data collection of each Header and Footer of the .XML files
    public class Data
    {
        public static string xmlHeader_DB_DI = "<?xml version=\"1.0\" encoding=\"utf-8\"?>\r\n<Document>\r\n  <Engineering version=\"V17\" />\r\n  <DocumentInfo>\r\n    <Created>2023-03-08T16:44:23.1874801Z</Created>\r\n    <ExportSetting>None</ExportSetting>\r\n    <InstalledProducts>\r\n      <Product>\r\n        <DisplayName>Totally Integrated Automation Portal</DisplayName>\r\n        <DisplayVersion>V17 Update 4</DisplayVersion>\r\n      </Product>\r\n      <OptionPackage>\r\n        <DisplayName>TIA Portal Openness</DisplayName>\r\n        <DisplayVersion>V17 Update 4</DisplayVersion>\r\n      </OptionPackage>\r\n      <OptionPackage>\r\n        <DisplayName>TIA Portal Version Control Interface</DisplayName>\r\n        <DisplayVersion>V17</DisplayVersion>\r\n      </OptionPackage>\r\n      <Product>\r\n        <DisplayName>STEP 7 Professional</DisplayName>\r\n        <DisplayVersion>V17 Update 4</DisplayVersion>\r\n      </Product>\r\n      <OptionPackage>\r\n        <DisplayName>STEP 7 Safety</DisplayName>\r\n        <DisplayVersion>V17</DisplayVersion>\r\n      </OptionPackage>\r\n      <Product>\r\n        <DisplayName>WinCC Advanced / Unified PC</DisplayName>\r\n        <DisplayVersion>V17 Update 4</DisplayVersion>\r\n      </Product>\r\n    </InstalledProducts>\r\n  </DocumentInfo>\r\n  <SW.Blocks.GlobalDB ID=\"0\">\r\n    <AttributeList>\r\n      <AutoNumber>false</AutoNumber>\r\n      <Interface><Sections xmlns=\"http://www.siemens.com/automation/Openness/SW/Interface/v5\">\r\n  <Section Name=\"Static\">\n";
        public static string xmlFooter_DB_DI = "      <ProgrammingLanguage>DB</ProgrammingLanguage>\r\n    </AttributeList>\r\n    <ObjectList>\r\n      <MultilingualText ID=\"1\" CompositionName=\"Comment\">\r\n        <ObjectList>\r\n          <MultilingualTextItem ID=\"2\" CompositionName=\"Items\">\r\n            <AttributeList>\r\n              <Culture>en-US</Culture>\r\n              <Text />\r\n            </AttributeList>\r\n          </MultilingualTextItem>\r\n        </ObjectList>\r\n      </MultilingualText>\r\n      <MultilingualText ID=\"3\" CompositionName=\"Title\">\r\n        <ObjectList>\r\n          <MultilingualTextItem ID=\"4\" CompositionName=\"Items\">\r\n            <AttributeList>\r\n              <Culture>en-US</Culture>\r\n              <Text />\r\n            </AttributeList>\r\n          </MultilingualTextItem>\r\n        </ObjectList>\r\n      </MultilingualText>\r\n    </ObjectList>\r\n  </SW.Blocks.GlobalDB>\r\n</Document>";
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
        public static string xmlHeader_FC_FDIn = "<?xml version=\"1.0\" encoding=\"utf-8\"?>\r\n<Document>\r\n  <Engineering version=\"V17\" />\r\n  <DocumentInfo>\r\n    <Created>2024-01-16T10:06:36.9177276Z</Created>\r\n    <ExportSetting>None</ExportSetting>\r\n    <InstalledProducts>\r\n      <Product>\r\n        <DisplayName>Totally Integrated Automation Portal</DisplayName>\r\n        <DisplayVersion>V17 Update 4</DisplayVersion>\r\n      </Product>\r\n      <OptionPackage>\r\n        <DisplayName>TIA Portal Openness</DisplayName>\r\n        <DisplayVersion>V17 Update 4</DisplayVersion>\r\n      </OptionPackage>\r\n      <OptionPackage>\r\n        <DisplayName>TIA Portal Version Control Interface</DisplayName>\r\n        <DisplayVersion>V17</DisplayVersion>\r\n      </OptionPackage>\r\n      <Product>\r\n        <DisplayName>STEP 7 Professional</DisplayName>\r\n        <DisplayVersion>V17 Update 4</DisplayVersion>\r\n      </Product>\r\n      <OptionPackage>\r\n        <DisplayName>STEP 7 Safety</DisplayName>\r\n        <DisplayVersion>V17</DisplayVersion>\r\n      </OptionPackage>\r\n      <Product>\r\n        <DisplayName>WinCC Advanced / Unified PC</DisplayName>\r\n        <DisplayVersion>V17 Update 4</DisplayVersion>\r\n      </Product>\r\n    </InstalledProducts>\r\n  </DocumentInfo>\r\n  <SW.Blocks.FC ID=\"0\">\r\n    <AttributeList>\r\n      <AutoNumber>false</AutoNumber>\r\n      <Interface><Sections xmlns=\"http://www.siemens.com/automation/Openness/SW/Interface/v5\">\r\n  <Section Name=\"Input\" />\r\n  <Section Name=\"Output\" />\r\n  <Section Name=\"InOut\" />\r\n  <Section Name=\"Temp\" />\r\n  <Section Name=\"Constant\" />\r\n  <Section Name=\"Return\">\r\n    <Member Name=\"Ret_Val\" Datatype=\"Void\" />\r\n  </Section>\r\n</Sections></Interface>\r\n      <Name>FC1012_FDIn</Name>\r\n      <Number>1012</Number>\r\n      <ProgrammingLanguage>F_LAD</ProgrammingLanguage>\r\n    </AttributeList>\r\n    <ObjectList>\r\n      <MultilingualText ID=\"1\" CompositionName=\"Comment\">\r\n        <ObjectList>\r\n          <MultilingualTextItem ID=\"2\" CompositionName=\"Items\">\r\n            <AttributeList>\r\n              <Culture>en-US</Culture>\r\n              <Text />\r\n            </AttributeList>\r\n          </MultilingualTextItem>\r\n        </ObjectList>\r\n      </MultilingualText>";
        public static string xmlFooter_FC_FDIn = "      <MultilingualText ID=\"19\" CompositionName=\"Title\">\r\n        <ObjectList>\r\n          <MultilingualTextItem ID=\"20\" CompositionName=\"Items\">\r\n            <AttributeList>\r\n              <Culture>en-US</Culture>\r\n              <Text />\r\n            </AttributeList>\r\n          </MultilingualTextItem>\r\n        </ObjectList>\r\n      </MultilingualText>\r\n    </ObjectList>\r\n  </SW.Blocks.FC>\r\n</Document>";

        //Adding element with component to a XML document
        internal static XmlNode AddChildXML(XmlDocument doc, XmlNamespaceManager ns, string targetNodeName, string newElementName, string newAttributeName, string newAttributeValue)
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
    }
}

