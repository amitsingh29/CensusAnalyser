using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace CensusAnalyser
{
    public class StateCensusAnalyser
    {
        private string filePath;
        private char delimiter = ',';

        public StateCensusAnalyser()
        {
        }
        
        public StateCensusAnalyser(string filePath)
        {
            this.filePath = filePath;
        }

        public StateCensusAnalyser(string filePath, char delimiter)
        {
            this.filePath = filePath;
            this.delimiter = delimiter;
        }

        public string ReadData()
        {
            try
            {
                if (Path.GetExtension(filePath) != ".csv")
                {
                    throw new CustomException(CustomException.Exception_Type.IncorrectTypeException, "IncorrectTypeException");
                }
                string[] lines = File.ReadAllLines(filePath);

                foreach (string line in lines)
                {
                    if (!line.Contains(delimiter))
                    {
                        throw new CustomException(CustomException.Exception_Type.IncorrectDelimiterException, "IncorrectDelimiterException");
                    }
                }

                return lines.Length.ToString();
            }

            catch (FileNotFoundException)
            {
                throw new CustomException(CustomException.Exception_Type.FileNotFoundException, "file not found");
            }

            catch (CustomException ex)
            {
                return ex.Message;
            }
        }
    }
}
