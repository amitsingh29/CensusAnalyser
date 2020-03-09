using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CensusAnalyser
{
    public class CSVStates
    {
        private char delimiter = ',';
        private string path;
        string header = "SrNo,State,Name,TIN,StateCode,";
        public delegate string data();
        public CSVStates()
        {
        }

        public CSVStates(string path)
        {
            this.path = path;
        }
        int numberOfRecords = 0;

        public CSVStates(string path, char delimiter)
        {
            this.path = path;
            this.delimiter = delimiter;
        }

        public CSVStates(string path, string header)
        {
            this.path = path;
            this.header = header;
        }

        public string GetData()
        {
            try
            {
                if (Path.GetExtension(path) != ".csv")
                {
                    throw new CustomException(CustomException.Exception_Type.IncorrectTypeException, "IncorrectTypeException");
                }
                string[] str = File.ReadAllLines(path);
                IEnumerable<string> getLines = str;
                Console.WriteLine(str[0]);
                foreach (string line in getLines)
                {
                    if (!line.Contains(delimiter))
                    {
                        throw new CustomException(CustomException.Exception_Type.IncorrectDelimiterException, "IncorrectDelimiterException");
                    }
                }

                if (str[0] != header)
                {
                    throw new CustomException(CustomException.Exception_Type.IncorrectHeaderException, "IncorrectHeaderException");
                }

                foreach (var lines in getLines)
                {
                    numberOfRecords++;
                }
                Console.WriteLine("Number of records are: " + numberOfRecords);
                return numberOfRecords.ToString();
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
