using System;

namespace CensusAnalyser
{
    class Program
    {
        static void Main(string[] args)
        {
            /*CSVStates cSV = new CSVStates(@"C:\Users\ye10397\Desktop\Amit\StateCode.csv");
            string record = cSV.GetData();
         */
            // Console.WriteLine("The number of lines are: " + record);
            StateCensusAnalyser stateCensusAnalyser = new StateCensusAnalyser(@"C:\Users\ye10397\Desktop\Amit\StateCode.csv");
            stateCensusAnalyser.JsonConversion1();
            
        }
    }
}
