using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using TIAgenerator.Class;

namespace TIAgenerator
{
    //Common Methods
    internal class Methods
    {
        //return relative path combined with folderName and fileName. If the target is nested inside more than one folder, remember to include @"\" between eachone
        public static string GetRelativePath(string folderName, string fileName)
        {
            return Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\TIAgenerator\" + folderName + @"\" + fileName));
        }

        //return relative path combined with fileName
        public static string GetRelativePath(string fileName)
        {
            return Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\TIAgenerator\" + fileName));
        }

        //return a List of objects of the required type from a Json file using JsonData Class
        public static List<T> JsonToList<T>(string jsonPath)
        {
            JsonData<T> myJson = new JsonData<T>(Methods.GetRelativePath(jsonPath));            
            myJson.GetJson();            
            return myJson.objectList;
        }

        //return a List of objects of the required type from a Json file using JsonData Class
        //this function overloading convert can manage Json files without "[]" around the objects
        public static List<T> JsonToList<T>(string jsonPath, bool toFix)
        {
            JsonData<T> myJson = new JsonData<T>(Methods.GetRelativePath(jsonPath));
            myJson.GetFixedJson(); //get deserialized from the "fixed" json
            return myJson.objectList;
        }

        //Append an event in the log file --> log.txt
        public static void UpdateLog(string txt)
        {
            File.AppendAllText(GetRelativePath("Services", "log.txt"), txt + Environment.NewLine);
        }
    }
}
