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

using System;
using System.Collections.Generic;
using TIAgenerator.Class;


namespace TIAgenerator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //settings
            int station = 0;
            int cpu = 1;
            string tagTableName = "Main Tag Table";
            string FB255_Name = "SEID_DigitalAlarm";
            string FB301_Name = "SEID_AIn";
            string FB302_Name = "SEID_AIn2oo3";
            string FB304_Name = "SEID_Val";
            List<ConfigSettings> settingsList;            
            List<PlcTag> plcTagList;
            List<DigitalSignal> digitalSignalsList;
            List<AnalogInput> analogInputsList;
            List<AnalogVals> analogValsList;
            List<AnalogInput1oo2> analogInputs1oo2List;
            List<AnalogInput2oo2> analogInputs2oo2List;
            List<AnalogInput2oo3> analogInputs2oo3List;
            List<AnalogCFC> analogCFCsList;
            List<AnalogBN> analogBNsList;
            ConfigSettings settings;
            //end_settings


            //LIST GENERATIONS
            if (true)
            {
                settingsList = Methods.JsonToList<ConfigSettings>(@"exportedJsons\ConfigSettings.json", true);
                settings = settingsList[0];
                plcTagList = Methods.JsonToList<PlcTag>(@"exportedJsons\Symbols.json");
                digitalSignalsList = Methods.JsonToList<DigitalSignal>(@"exportedJsons\DigitalSignals.json");
                analogInputsList = Methods.JsonToList<AnalogInput>(@"exportedJsons\AnalogInputs.json");
                analogValsList = Methods.JsonToList<AnalogVals>(@"exportedJsons\AnalogVals.json");
                analogInputs1oo2List = Methods.JsonToList<AnalogInput1oo2>(@"exportedJsons\AnalogInputs1oo2.json");
                analogInputs2oo2List = Methods.JsonToList<AnalogInput2oo2>(@"exportedJsons\AnalogInputs2oo2.json");
                analogInputs2oo3List = Methods.JsonToList<AnalogInput2oo3>(@"exportedJsons\AnalogInputs2oo3.json");
                analogCFCsList = Methods.JsonToList<AnalogCFC>(@"exportedJsons\AnalogCFCs.json");
                analogBNsList = Methods.JsonToList<AnalogBN>(@"exportedJsons\AnalogBNs.json");
            }

            //PLC TAG LIST
            if (true)
            {
                TIAMethods.GenerateTagTable(station, cpu, tagTableName);
                TIAMethods.CompileTagTable(station, cpu, tagTableName, plcTagList);
                Console.WriteLine("Tag Table done");
            }

            //GENERATE DB_DI
            if (true)
            {
                Methods.GenerateDB_DI(digitalSignalsList, settings.NormalDIDBAddr);
                Console.WriteLine("DB_DI done");
            }

            //GENERATE DB_Settings
            if (true)
            {
                Methods.GenerateDB_Settings(analogInputsList, analogValsList, analogInputs1oo2List, analogInputs2oo2List, analogInputs2oo3List, analogCFCsList, analogBNsList, settings);
                Console.WriteLine("DB_SETTINGS done");
            }

            //IMPORT BLOCK (UP, SEID_DigitalAlarm)
            if (true)
            {
                //TIAMethods.NewBlockFolder(0, 1, "folder"); //create folder
                TIAMethods.ImportBlock(0, 1, Methods.GetRelativePath(@"\Xml\DB_UP.xml")); //UP inside folder
                Console.WriteLine("DB_UP done");
            }
            //GENERATE FC_DI
            if (true)
            {
                Methods.GenerateFC_DI(digitalSignalsList, settings);
                TIAMethods.ImportBlock(0, 1, Methods.GetRelativePath(@"\Xml\FC_DI.xml"));
                Console.WriteLine("FC_DI done");
            }

            

            //EXPORT BLOCK
            if (false)
            {
                string blockName = "FC_AIn";
                TIAMethods.ExportBlock(0, 1, blockName, Methods.GetRelativePath(@"\Xml\" + blockName + ".xml"));
            }

            //GENERATE ISTANCE_DB DIGITAL ALARMS
            if (true)
            {
                TIAMethods.NewBlockFolder(0, 1, "DigitalAlarms"); //create folder
                Methods.GenerateIstanceDB_DI(0, 1, digitalSignalsList, FB255_Name, "DigitalAlarms");
                Console.WriteLine("DIGITAL ALARMS INSTANCES DONE");
            }

            //GENERATE ISTANCE_DB ANALOG SIGNALS
            if (true)
            {
                TIAMethods.NewBlockFolder(0, 1, "AnalogInput"); //create folder
                Methods.GenerateIstanceDB_AI(0, 1, analogInputsList.ConvertAll(b => (AnalogSignal)b), FB301_Name, "AnalogInput");
                Console.WriteLine("AnalogInput INSTANCES DONE");
                TIAMethods.NewBlockFolder(0, 1, "AnalogVal"); //create folder
                Methods.GenerateIstanceDB_AI(0, 1, analogValsList.ConvertAll(b => (AnalogSignal)b), FB304_Name, "AnalogVal");
                Console.WriteLine("AnalogVals INSTANCES DONE");
                /*
                TIAMethods.NewBlockFolder(0, 1, "Analog1oo2"); //create folder
                Methods.GenerateIstanceDB_AI(0, 1, analogInputs1oo2List.ConvertAll(b => (AnalogSignal)b), FB302_Name, "Analog1oo2");
                TIAMethods.NewBlockFolder(0, 1, "Analog2oo2"); //create folder
                Methods.GenerateIstanceDB_AI(0, 1, analogInputs2oo2List.ConvertAll(b => (AnalogSignal)b), FB302_Name, "Analog2oo2");
                
                TIAMethods.NewBlockFolder(0, 1, "Analog2oo3"); //create folder
                Methods.GenerateIstanceDB_AI(0, 1, analogInputs2oo3List.ConvertAll(b => (AnalogSignal)b), FB302_Name, "Analog2oo3");*/
            }

            







        }
    }
}
