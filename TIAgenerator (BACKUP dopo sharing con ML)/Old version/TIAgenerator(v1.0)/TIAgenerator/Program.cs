/****************************** Module Header ******************************\

 * Project:     <TIAgenerator>
 * Module Name: <Program.cs>
 * Autor:       <M. Martinelli>
 * Version:     <1.0>
 * Date:        <13/05/2024>
 * Update:      
            //aggiunta interfaccia grafica per un basilare utilizzo del generatore
 * TO DO:
            //ricordarsi di gestire i namespace, se non si vuole scrivere CLASS.METHOD(); includere.CLASS dopo using (e.g. using TIAgenerator.Gen)
            //commentare il codice

\***************************************************************************/

using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Windows.Forms;
using TIAgenerator.Class;


namespace TIAgenerator
{
    public class Program
    {
        public static MainForm mainForm;

        //MAIN
        public static void Main(string[] args)
        {
            Methods.UpdateLog(DateTime.Now + " | " + WindowsIdentity.GetCurrent().Name + ": " + "Start Application");
            //Start Main GUI
            Application.Run(GetForm());
        }

        //Get the MainForm instance
        public static MainForm GetForm()
        {
            MainForm form = new MainForm();
            
            mainForm = form; //in case you need to have access to the Form parameter (e.g. mainForm.Opacity)
            return mainForm;
        }

        //Export block from TIA PORTAL project
        public static void ExportBlock(string blockName, int station, int cpu)
        {
            TIAMethods.ExportBlock(station, cpu, blockName, Methods.GetRelativePath(@"\Files\Xml\" + blockName + ".xml"));
        }
        
        //Main function to generate and import data from Json to the TIAportal project
        public static void StartProgram(ref TraceWriter _writer, int station, int cpu)
        {
            //settings
            string tagTableName = "Main Tag Table";
            string FB255_Name = "SEID_DigitalAlarm";
            string FB301_Name = "SEID_AIn";
            string FB302_Name = "SEID_AIn2oo3";
            string FB304_Name = "SEID_Val";
            List<ConfigSettings> settingsList = new List<ConfigSettings>();
            List<PlcTag> plcTagList = new List<PlcTag>();
            List<DigitalSignal> digitalSignalsList = new List<DigitalSignal>();
            List<AnalogInput> analogInputsList = new List<AnalogInput>();
            List<AnalogVals> analogValsList = new List<AnalogVals>();
            List<AnalogInput1oo2> analogInputs1oo2List = new List<AnalogInput1oo2>();
            List<AnalogInput2oo2> analogInputs2oo2List = new List<AnalogInput2oo2>();
            List<AnalogInput2oo3> analogInputs2oo3List = new List<AnalogInput2oo3>();
            List<AnalogCFC> analogCFCsList = new List<AnalogCFC>();
            List<AnalogBN> analogBNsList = new List<AnalogBN>();
            ConfigSettings settings = new ConfigSettings();
            bool[] preset = MainForm.GetPreset();
            int i = 0;
            //end_settings

            //LIST GENERATIONS from JSON
            _writer.Write("Sarting program..");
            _writer.Write("Setting: Station number " + station + " | cpu number " + cpu);
            if (preset[i++])
            {
                settingsList = Methods.JsonToList<ConfigSettings>(@"\Files\Json\ConfigSettings.json", true);
                settings = settingsList[0];
                plcTagList = Methods.JsonToList<PlcTag>(@"\Files\Json\Symbols.json");
                digitalSignalsList = Methods.JsonToList<DigitalSignal>(@"\Files\Json\DigitalSignals.json");
                analogInputsList = Methods.JsonToList<AnalogInput>(@"\Files\Json\AnalogInputs.json");
                analogValsList = Methods.JsonToList<AnalogVals>(@"\Files\Json\AnalogVals.json");
                analogInputs1oo2List = Methods.JsonToList<AnalogInput1oo2>(@"\Files\Json\AnalogInputs1oo2.json");
                analogInputs2oo2List = Methods.JsonToList<AnalogInput2oo2>(@"\Files\Json\AnalogInputs2oo2.json");
                analogInputs2oo3List = Methods.JsonToList<AnalogInput2oo3>(@"\Files\Json\AnalogInputs2oo3.json");
                analogCFCsList = Methods.JsonToList<AnalogCFC>(@"\Files\Json\AnalogCFCs.json");
                analogBNsList = Methods.JsonToList<AnalogBN>(@"\Files\Json\AnalogBNs.json");
                _writer.Write("Lists Generated");
            }

            //PLC TAG LIST (Symbols)
            if (preset[i++])
            {
                TIAMethods.GenerateTagTable(station, cpu, tagTableName);
                TIAMethods.CompileTagTable(station, cpu, tagTableName, plcTagList);
                _writer.Write("Tag Table done");
            }

            //GENERATE DB_DI
            if (preset[i++])
            {
                Gen.GenerateDB_DI(digitalSignalsList, settings.NormalDIDBAddr);
                _writer.Write("DB_DI done");
            }

            //GENERATE FC_DI
            if (preset[i++])
            {
                Gen.GenerateFC_DI(digitalSignalsList, settings);
                TIAMethods.ImportBlock(station, cpu, Methods.GetRelativePath(@"\Files\Xml\FC_DI.xml"));
                _writer.Write("FC_DI done");
            }

            //IMPORT BLOCK (UP, SEID_DigitalAlarm)
            if (preset[i++])
            {
                //TIAMethods.NewBlockFolder(0, 1, "folder"); //create folder
                TIAMethods.ImportBlock(station, cpu, Methods.GetRelativePath(@"\Files\Xml\DB_UP.xml")); //UP inside folder
                _writer.Write("DB_UP done");
            }

            //GENERATE ISTANCE_DB DIGITAL ALARMS
            if (preset[i++])
            {
                TIAMethods.NewBlockFolder(station, cpu, "DigitalAlarms"); //create folder
                Gen.GenerateIstanceDB_DI(station, cpu, digitalSignalsList, FB255_Name, "DigitalAlarms");
                _writer.Write("Istance DB DigitalAlarms done");
            }

            //GENERATE ISTANCE_DB ANALOG SIGNALS
            if (preset[i++])
            {
                TIAMethods.NewBlockFolder(station, cpu, "AnalogInput"); //create folder
                Gen.GenerateIstanceDB_AI(station, cpu, analogInputsList.ConvertAll(b => (AnalogSignal)b), FB301_Name, "AnalogInput");
                TIAMethods.NewBlockFolder(station, cpu, "AnalogVal"); //create folder
                Gen.GenerateIstanceDB_AI(station, cpu, analogValsList.ConvertAll(b => (AnalogSignal)b), FB304_Name, "AnalogVal");
                TIAMethods.NewBlockFolder(station, cpu, "Analog1oo2"); //create folder
                Gen.GenerateIstanceDB_AI(station, cpu, analogInputs1oo2List.ConvertAll(b => (AnalogSignal)b), FB302_Name, "Analog1oo2");
                TIAMethods.NewBlockFolder(station, cpu, "Analog2oo2"); //create folder
                Gen.GenerateIstanceDB_AI(station, cpu, analogInputs2oo2List.ConvertAll(b => (AnalogSignal)b), FB302_Name, "Analog2oo2");
                TIAMethods.NewBlockFolder(station, cpu, "Analog2oo3"); //create folder
                Gen.GenerateIstanceDB_AI(station, cpu, analogInputs2oo3List.ConvertAll(b => (AnalogSignal)b), FB302_Name, "Analog2oo3");
                _writer.Write("Istance DB AnalogSignals done");
            }

            //GENERATE DB_SETTINGS
            if (preset[i++])
            {
                Gen.GenerateDB_Settings(analogInputsList, analogValsList, analogInputs1oo2List, analogInputs2oo2List, analogInputs2oo3List, analogCFCsList, analogBNsList, settings);
                TIAMethods.ImportBlock(station, cpu, Methods.GetRelativePath(@"\Files\Xml\DB_SETTINGS.xml"));
                _writer.Write("DB_SETTINGS done");
            }

            //GENERATE FC14_AI
            if (preset[i++])
            {
                Gen.GenerateFC_AIn(analogInputsList, settings);
                TIAMethods.ImportBlock(station, cpu, Methods.GetRelativePath(@"\Files\Xml\FC_AIn.xml"));
                _writer.Write("FC14_AI done");
            }

            //GENERATE FCs Voting
            if (preset[i++])
            {
                Gen.GenerateFC_AIn2oo3(analogInputs2oo3List, settings);
                TIAMethods.ImportBlock(station, cpu, Methods.GetRelativePath(@"\Files\Xml\FC_AIn2oo3.xml"));
                _writer.Write("FC31_AI2oo3 done");
            }

            //GENERATE FC_FDIn
            if (preset[i++])
            {
                SafetyGen.GenerateFC_FDIn(digitalSignalsList, settings);
                TIAMethods.ImportBlock(station, cpu, Methods.GetRelativePath(@"\Files\Xml\FC_FDIn.xml"));
                _writer.Write("FC_DIn done");
            }
        }
    }
}
