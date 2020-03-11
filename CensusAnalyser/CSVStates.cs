//-----------------------------------------------------------------------
// <copyright file="CSVStates.cs" company="BridgeLabz">
//     Copyright © 2020
// </copyright>
// <creator name="Amit Singh"/>
//-----------------------------------------------------------------------

namespace CensusAnalyser
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;

    /// <summary>
    /// CSVStates class
    /// </summary>
    public class CSVStates : ICSVBuilder
    {
        int numberOfRecords = 0;
        /// <summary>
        /// delegate named Data
        /// </summary>
        /// <returns>reference of GetData()</returns>
        public delegate string Data(string path, char delimiter = ',', string header = "");

        /// <summary>
        /// Number Of Records
        /// </summary>
        /// <returns>Returns the number of lines</returns>
        public string GetData(string path ,char delimiter=',', string header="")
        {
            try
            {
                if (Path.GetExtension(path) != ".csv")
                {
                    throw new CustomException(CustomException.Exception_Type.IncorrectTypeException, "IncorrectTypeException");
                }

                string[] str = File.ReadAllLines(path);
                IEnumerable<string> getLines = str;
                //Console.WriteLine(str[0]);
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

                Console.WriteLine("Number of records are: " + this.numberOfRecords);
                return this.numberOfRecords.ToString();
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
