using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;

namespace CensusAnalyser
{
    public class StateCensusAnalyser
    {
        public string ReadData()
        {
            StreamReader sr = new StreamReader(@"C:\Users\ye10397\Desktop\Amit\StateCensusData.csv");
            sr.BaseStream.Seek(0, SeekOrigin.Begin);
            string str = sr.ReadLine();
            int numberOfRecords = 0;
            while (str != null)
            {
                str = sr.ReadLine();
                numberOfRecords++;
            }
            Console.WriteLine("Number of records are: "+ numberOfRecords);
            return numberOfRecords.ToString();

        }
    }
}
