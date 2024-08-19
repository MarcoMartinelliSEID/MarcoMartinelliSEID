using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using TIAgenerator.Class;

namespace TIAgenerator
{
    //Methods for the generation of the Safety block and data
    internal class SafetyGen
    {
        //Generate the .XML file FC_FDIn
        public static void GenerateFC_FDIn(List<DigitalSignal> digitalInputsList, ConfigSettings settings)
        {
            int ID = 20;
            string path = Methods.GetRelativePath(@"\Files\Xml\FC_FDIn.xml");
            string xml = Data.xmlHeader_FC_FDIn;
            foreach (DigitalSignal signal in digitalInputsList) //AGGIUNGERE IF NON SAFETY!!!!!!
            {
                ID += 1;
                SafetyXmlGen.FC_FDIn_Network(settings, ID, ref xml, signal);
            }
            xml += "\n" + Data.xmlFooter_FC_FDIn;
            XmlDocument doc = new XmlDocument();
            XmlNode node;
            doc.LoadXml(xml);
            node = doc.SelectSingleNode("//SW.Blocks.FC//Name");
            node.InnerText = "FC_FDIn";
            node = doc.SelectSingleNode("//SW.Blocks.FC//Number");
            node.InnerText = settings.fcCFCSetAddr.Substring(3);
            xml = doc.OuterXml;
            File.WriteAllText(path, xml);
        }
    }
}
