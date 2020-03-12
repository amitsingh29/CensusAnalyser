//-----------------------------------------------------------------------
// <copyright file="CSVStateCensus.cs" company="BridgeLabz">
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
    /// CSVStateCensus class
    /// </summary>
    public class CSVStateCensus : ICSVBuilder
    {
        /// <summary>
        /// Count the number of records
        /// </summary>
        private int numberOfRecords = 0;

        /// <summary>
        /// Act as reference to Datas method
        /// </summary>
        /// <param name="filePath">The filePath</param>
        /// <param name="delimiter">The delimiter</param>
        /// <param name="header">The header</param>
        /// <returns>string filePath, char delimiter = ',', string header = "State,Population,AreaInSqKm,DensityPerSqKm"</returns>
        public delegate string Datas(string filePath, char delimiter = ',', string header = "State,Population,AreaInSqKm,DensityPerSqKm");

        /// <summary>
        /// Returns the records
        /// </summary>
        /// <param name="filePath">The filePath</param>
        /// <param name="delimiter">The delimiter</param>
        /// <param name="header">The header</param>
        /// <returns>string filePath, char delimiter = ',', string header = "State,Population,AreaInSqKm,DensityPerSqKm"</returns>
        public string GetData(string filePath, char delimiter = ',', string header = "State,Population,AreaInSqKm,DensityPerSqKm")
        {
            try
            {
                if (Path.GetExtension(filePath) != ".csv")
                {
                    throw new CustomException(CustomException.Exception_Type.IncorrectTypeException, "IncorrectTypeException");
                }

                string[] str = File.ReadAllLines(filePath);
                IEnumerable<string> allLines = str;

                foreach (string line in allLines)
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

                foreach (var lines in allLines)
                {
                    this.numberOfRecords++;
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
