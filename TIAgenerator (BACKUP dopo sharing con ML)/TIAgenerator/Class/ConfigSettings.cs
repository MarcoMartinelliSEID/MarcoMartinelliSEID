using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TIAgenerator.Class
{
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
}
