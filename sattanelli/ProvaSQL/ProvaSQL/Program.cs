using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaSQL
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SqlConnection cnn = new SqlConnection(@"Data Source=fileserver2.seid.lan;Initial Catalog=Sbo_Seid;User ID=sa;Password=B1Admin");
            cnn.Open();
            Console.WriteLine("YEEE");
            
            string q = "update trimergo.planning SET status = '150-01' where project_number  like '1212CI%'";
            SqlCommand query = new SqlCommand(q, cnn);
            SqlDataReader reader = query.ExecuteReader();
            int i = 0;
            while (reader.Read())
            {
                Console.WriteLine(reader.GetString(0) + " - " + reader.GetValue(1));
                i++;
            }
            Console.WriteLine(i);

            reader.Close();
            query.Dispose();
            cnn.Close();


        }
    }
}
