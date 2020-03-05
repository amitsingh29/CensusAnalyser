using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace CensusAnalyser
{
    public class StateCensusAnalyser
    {
        public string ReadData()
        {
            int numberOfRecords = 0;
            string filePath = @"C:\Users\ye10397\Desktop\Amit\StateCensusData.csv";
            List<string> lines = File.ReadAllLines(filePath).ToList();
            foreach (string line in lines)
            {
                numberOfRecords++;
            }
            Console.WriteLine("No of lines are: "+ numberOfRecords);
            return numberOfRecords.ToString();
        }
    }
}
