using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TIAgenerator.Class
{
    public class AnalogSignal
    {
        public string tag { get; set; }
        public string description { get; set; }
        public string tagPnID { get; set; }
        public string description2 { get; set; }
        public string description3 { get; set; }
        public string PVIO { get; set; }
        public string PVIO_R { get; set; }
        public string PVFault { get; set; }
        public string PVFault_R { get; set; }
        public string hasHiHi { get; set; }
        public string hasHi { get; set; }
        public string hasLo { get; set; }
        public string hasLoLo { get; set; }
        public string is2oo3Member { get; set; }
        public string is2oo2Member { get; set; }
        public string is1oo2Member { get; set; }
        public string tagVooting { get; set; }
        public string minRange { get; set; }
        public string minRangeIsValid { get; set; }
        public string maxRange { get; set; }
        public string maxRangeIsValid { get; set; }
        public string engUn { get; set; }
        public string HiHiTrips { get; set; }
        public string LoLoTrips { get; set; }
        public string FailTrips { get; set; }
        public string HiHiSP { get; set; }
        public string HiHiSPIsValid { get; set; }
        public string HiSP { get; set; }
        public string HiSPIsValid { get; set; }
        public string LoSP { get; set; }
        public string LoSPIsValid { get; set; }
        public string LoLoSP { get; set; }
        public string LoLoSPIsValid { get; set; }
        public string DB { get; set; }
        public string DBNumber { get; set; }
        public string GroupDB { get; set; }
        public string ModbusAnalogAdd { get; set; }
        public string HMIModbusParamStructAdd { get; set; }
        public string HMIModbusStructAdd { get; set; }
        public string isRedundant { get; set; }
    }

    public class AnalogVals : AnalogSignal
    {

    }

    public class AnalogInput : AnalogSignal 
    {
        
    }

    public class AnalogInput1oo2 : AnalogSignal
    {
        public string is1oo2 { get; set; }
        public string is2oo2 { get; set; }
        public string is2oo3 { get; set; }
        public string idsInitialized { get; set; }
        public string isGroupOfVals { get; set; }
        public string isGroupOfCFCs { get; set; }
        public string isGroupOfBNs { get; set; }
        public string isGroupOfAIns { get; set; }
        public string tagA { get; set; }
        public string tagB { get; set; }
        public string tagC { get; set; }
        public string IndexA { get; set; }
        public string IndexB { get; set; }
        public string IndexC { get; set; }
    }

    public class AnalogInput2oo2 : AnalogSignal
    {
        public string is1oo2 { get; set; }
        public string is2oo2 { get; set; }
        public string is2oo3 { get; set; }
        public string idsInitialized { get; set; }
        public string isGroupOfVals { get; set; }
        public string isGroupOfCFCs { get; set; }
        public string isGroupOfBNs { get; set; }
        public string isGroupOfAIns { get; set; }
        public string tagA { get; set; }
        public string tagB { get; set; }
        public string tagC { get; set; }
        public string IndexA { get; set; }
        public string IndexB { get; set; }
        public string IndexC { get; set; }
    }

    public class AnalogInput2oo3 : AnalogSignal
    {
        public string is1oo2 { get; set; }
        public string is2oo2 { get; set; }
        public string is2oo3 { get; set; }
        public string idsInitialized { get; set; }
        public string isGroupOfVals { get; set; }
        public string isGroupOfCFCs { get; set; }
        public string isGroupOfBNs { get; set; }
        public string isGroupOfAIns { get; set; }
        public string tagA { get; set; }
        public string tagB { get; set; }
        public string tagC { get; set; }
        public string IndexA { get; set; }
        public string IndexB { get; set; }
        public string IndexC { get; set; }
    }

    public class AnalogCFC : AnalogSignal
    {

    }

    public class AnalogBN : AnalogSignal
    {

    }
}
