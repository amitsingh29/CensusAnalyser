using System;
using System.Collections.Generic;
using System.Text;

namespace CensusAnalyser
{
    interface ICSVBuilder
    {
        string GetData(string path, char delimiter = ',', string header = "shhtrytgh");
    }
}
