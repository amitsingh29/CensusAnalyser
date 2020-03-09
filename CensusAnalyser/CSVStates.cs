using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CensusAnalyser
{
    public class CSVStates
    {
        int numberOfLines = 0;
        public int getData(string path)
        {
            string[] str = File.ReadAllLines(path);
            IEnumerable<string> getLines = str;
            foreach(var lines in getLines)
            {
                numberOfLines++;
            }
            return numberOfLines;
        }
    }
}
