using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace CensusAnalyser
{
    public class CSVStateCensus
    {
        public int ReadData()
        {
            int numberOfRecords = 0;
            IEnumerable<string> AllLines = File.ReadLines(@"C:\Users\ye10397\Desktop\Amit\StateCensusData.csv");

            foreach(var lines in AllLines)
            {
                numberOfRecords++;
            }
            Console.WriteLine("Number of records are: "+ numberOfRecords);
            return numberOfRecords;
        }
    }
}
