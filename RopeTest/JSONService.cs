using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RopeTest
{
    public class JsonService
    {
        public string jsonString;
        string pathSB = "@C://repos/files/InsertResultsSB.txt";
        string pathBL = "@C://repos/files/InsertResultsBL.txt";
        string pathR = "@C://repos/files/InsertResultsR.txt";

        public string GetJsonSB()
        {
            using (StreamReader reader = new StreamReader(pathSB))
            {
                jsonString = reader.ReadLine();
            }
            return jsonString;
        }
        public string GetJsonBL()
        {
            using (StreamReader reader = new StreamReader(pathBL))
            {
                jsonString = reader.ReadLine();
            }
            return jsonString;
        }
        public string GetJsonR()
        {
            using (StreamReader reader = new StreamReader(pathR))
            {
                jsonString = reader.ReadLine();
            }
            return jsonString;
        }
    }
}
