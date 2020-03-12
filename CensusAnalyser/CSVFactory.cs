using System;
using System.Collections.Generic;
using System.Text;

namespace CensusAnalyser
{
    public class CSVFactory 
    {
        public static ICSVBuilder Factory(string className)
        {
            switch(className)
            {
                case "CSVStates":
                    return new CSVStates();
                case "CSVStateCensus":
                    return new CSVStateCensus();
            }
            return null;
        }
    }
}

