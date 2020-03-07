using System;

namespace CensusAnalyser
{
    class Program
    {
        static void Main(string[] args)
        {
            CSVStateCensus cSVStateCensus = new CSVStateCensus(@"C:\Users\ye10397\Desktop\Amit\StateCensusData.csv");
            string data = cSVStateCensus.ReadData();
            Console.WriteLine(data);
        }
    }
}
