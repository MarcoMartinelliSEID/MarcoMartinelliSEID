using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TIAgenerator.Class
{
    public class DigitalSignal
    {
        public string tag { get; set; }
        public string description { get; set; }
        public string tagPnID { get; set; }
        public string description2 { get; set; }
        public string description3 { get; set; }
        public string address { get; set; }
        public string PVIO_R { get; set; }
        public string isAlarm { get; set; }
        public string isTrip { get; set; }
        public string isCFC { get; set; }
        public string isHiHi { get; set; }
        public string isHi { get; set; }
        public string isLo { get; set; }
        public string isLoLo { get; set; }
        public string DB { get; set; }
        public string DBNumber { get; set; }
        public string HMIModbusStructAdd { get; set; }
        public string isRedundant { get; set; }

        public void Print()
        {
            foreach (PropertyDescriptor descriptor in TypeDescriptor.GetProperties(this))
            {
                string name = descriptor.Name;
                object value = descriptor.GetValue(this);
                System.Console.WriteLine("{0} = {1}", name, value);

            }
            Console.WriteLine();
        }
        static public void PrintList<T>(List<T> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                foreach (PropertyDescriptor descriptor in TypeDescriptor.GetProperties(list[i]))
                {
                    string name = descriptor.Name;
                    object value = descriptor.GetValue(list[i]);
                    Console.WriteLine("{0} = {1}", name, value);
                }
                Console.WriteLine();
            }
        }
    }
}
