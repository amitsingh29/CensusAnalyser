using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace CensusAnalyser
{
    public class CSVStateCensus
    {
        private string filePath;
        private char delimiter = ',';
        private string header = "State,Population,AreaInSqKm,DensityPerSqKm";
        int numberOfRecords = 0;
        public CSVStateCensus()
        {
        }

        public CSVStateCensus(string filePath)
        {
            this.filePath = filePath;
        }

        public CSVStateCensus(string filePath, char delimiter)
        {
            this.filePath = filePath;
            this.delimiter = delimiter;
        }

        public CSVStateCensus(string filePath, string header)
        {
            this.filePath = filePath;
            this.header = header;
        }


        public string ReadData()
        {
            try
            {
                if (Path.GetExtension(filePath) != ".csv")
                {
                    throw new CustomException(CustomException.Exception_Type.IncorrectTypeException, "IncorrectTypeException");
                }
                string [] str = File.ReadAllLines(filePath);
                IEnumerable<string> AllLines = str;

                foreach (string line in AllLines)
                {
                    if (!line.Contains(delimiter))
                    {
                        throw new CustomException(CustomException.Exception_Type.IncorrectDelimiterException, "IncorrectDelimiterException");
                    }
                }

                if ( str[0]!= header)
                {
                    throw new CustomException(CustomException.Exception_Type.IncorrectHeaderException, "IncorrectHeaderException");
                }

                foreach (var lines in AllLines)
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
