using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace CensusAnalyser
{ }
    public class StateCensusAnalyser
    {
        private string filePath;
        public StateCensusAnalyser()
        {
        }
        
        public StateCensusAnalyser(string filePath)
        {
            this.filePath = filePath;
        }

        public string ReadFileData()
        {
            string[] lines = File.ReadAllLines(filePath);
            return lines.Length.ToString();
        }
    }
}
