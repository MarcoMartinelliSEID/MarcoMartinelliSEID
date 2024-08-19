/****************************** Module Header ******************************\

 * Project:     <TIAgenerator>
 * Module Name: <Program.cs>
 * Autor:       <M. Martinelli>
 * TO DO:
            //creazione classi segnali e settings (dati SEID) letti con json o similare --> in corso
            //creazioni di funzioni "openness Explorer"
            //creazione di classi/funzioni per compilare i dati nel TIA
            //generatori DB/FC
            //settings TIA
            //interfaccia grafica
            //abbellimenti e predisposizioni per xxxxxxxxx..

\***************************************************************************/

using Siemens.Engineering.HW.Features;
using Siemens.Engineering.HW;
using Siemens.Engineering.SW.Tags;
using Siemens.Engineering.SW;
using Siemens.Engineering;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TIAgenerator.Class;
using Siemens.Engineering.Hmi.Tag;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Dynamic;
using System.Xml;
using static System.Net.Mime.MediaTypeNames;
using System.Xml.Linq;

namespace TIAgenerator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //settings
            int station = 0;
            int cpu = 1;
            String tagTableName = "Main Tag Table";
            //end_settings

            if (true)
            {
                //Settings fetch
                List<ConfigSettings> settings = Methods.JsonToList<ConfigSettings>(@"exportedJsons\ConfigSettings.json", true);
                //generate and compile TAG LIST
                List<PlcTag> PlcTagList = Methods.JsonToList<PlcTag>(@"exportedJsons\Symbols.json");
                TIAMethods.GenerateTagTable(station, cpu, tagTableName);
                TIAMethods.CompileTagTable(station, cpu, tagTableName, PlcTagList);

                //generate DB_DI
                List<DigitalSignal> DigitalSignalsList = Methods.JsonToList<DigitalSignal>(@"exportedJsons\DigitalSignals.json");
                Methods.GenerateDB12(DigitalSignalsList, 12);
            }












        }


    }
}
