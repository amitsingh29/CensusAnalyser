using System;

namespace CensusAnalyser
{
    class Program
    {
        static void Main(string[] args)
        {
            StateCensusAnalyser censusAnalyser = new StateCensusAnalyser();
            censusAnalyser.readData();
        }
    }
}
