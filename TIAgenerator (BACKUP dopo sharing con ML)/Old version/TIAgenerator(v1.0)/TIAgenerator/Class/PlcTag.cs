using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TIAgenerator
{
    //Class of Symbols
    public class PlcTag
    {
        public string tag { get; set; }
        public string description { get; set; }
        public string address { get; set; }
        public string type { get; set; }

        public void Print()
        {            
            foreach (PropertyDescriptor descriptor in TypeDescriptor.GetProperties(this))
            {
                string name = descriptor.Name;
                object value = descriptor.GetValue(this);
                Console.WriteLine("{0} = {1}", name, value);
                
            }
            Console.WriteLine();
        }
        static public void PrintList<T>(List<T> list)
        {
            bool[] arr = new bool[list.Count];
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
