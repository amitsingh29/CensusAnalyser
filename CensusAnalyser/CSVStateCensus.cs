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
    using System.Text;
    using System.IO;

    /// <summary>
    /// CSVStateCensus class
    /// </summary>
    public class CSVStateCensus : ICSVBuilder
    {/*
        /// <summary>
        /// The Path
        /// </summary>
        private string filePath;

        /// <summary>
        /// The Delimiter
        /// </summary>
        private char delimiter = ',';

        /// <summary>
        /// The Header
        /// </summary>
        private string header = "State,Population,AreaInSqKm,DensityPerSqKm";*/

        /// <summary>
        /// Count the numberOfRecords
        /// </summary>
        int numberOfRecords = 0;

        public delegate string Datas(string filePath, char delimiter = ',', string header = "State,Population,AreaInSqKm,DensityPerSqKm");

        /// <summary>
        /// Number Of Records
        /// </summary>
        /// <returns>Returns the number of lines</returns>
        public string GetData(string filePath, char delimiter = ',', string header = "State,Population,AreaInSqKm,DensityPerSqKm")
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
