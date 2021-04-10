using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChurchDatabaseAPI.Model
{
    public class Utility
    {
        public string EnCryptKey1(string Str2EnCode)
        {
            try
            {
                return Convert.ToBase64String(Encoding.UTF8.GetBytes(Str2EnCode));
            }
            catch
            {
                Exception ex = new Exception();
                return "";
            }

        }
        public string DeCryptKey1(string Str2Decode)
        {
            String fNames = (DateTime.Now.ToString("yyyy-MM-dd")) + ".txt";
            String FilePathGen = AppDomain.CurrentDomain.BaseDirectory + "TransTracker\\TransLog-" + fNames;
            try
            {
                return Encoding.UTF8.GetString(Convert.FromBase64String(Str2Decode));
            }
            catch (Exception ex)
            {

                using (StreamWriter writer = new StreamWriter(FilePathGen, true))
                {
                    writer.WriteLine(ex.Message + DateTime.Now.ToString());
                }
                return "";
            }

        }

    }
}
