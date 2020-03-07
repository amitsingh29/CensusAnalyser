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
    public class CSVStateCensus
    {
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
        private string header = "State,Population,AreaInSqKm,DensityPerSqKm";

        /// <summary>
        /// Count the numberOfRecords
        /// </summary>
        int numberOfRecords = 0;

        /// <summary>
        /// Initializes a new instance of the <see cref="CSVStateCensus"/> class.
        /// </summary>
        public CSVStateCensus()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CSVStateCensus"/> class.
        /// </summary>
        /// <param name="filePath"></param>
        public CSVStateCensus(string filePath)
        {
            this.filePath = filePath;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CSVStateCensus"/> class.
        /// </summary>
        /// <param name="filePath">The path</param>
        /// <param name="delimiter">The delimiter</param>
        public CSVStateCensus(string filePath, char delimiter)
        {
            this.filePath = filePath;
            this.delimiter = delimiter;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CSVStateCensus"/> class.
        /// </summary>
        /// <param name="filePath">The path</param>
        /// <param name="header">The header</param>
        public CSVStateCensus(string filePath, string header)
        {
            this.filePath = filePath;
            this.header = header;
        }

        /// <summary>
        /// Number Of Records
        /// </summary>
        /// <returns>Returns the number of lines</returns>
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
