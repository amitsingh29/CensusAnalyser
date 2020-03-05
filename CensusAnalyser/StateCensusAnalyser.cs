using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace CensusAnalyser
{
    public class StateCensusAnalyser
    {
        public int ReadData(string filePath)
        {
            try
            {
                string[] lines = File.ReadAllLines(filePath);
                return lines.Length;
            }
            catch (FileNotFoundException)
            { 
                throw new CustomException(CustomException.Exception_Type.FileNotFoundException, "file not found");
            }
        }
    }
}
