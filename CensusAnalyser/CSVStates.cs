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
    public class CSVStates
    {
        /// <summary>
        /// The delimiter
        /// </summary>
        private char delimiter = ',';

        /// <summary>
        /// The path
        /// </summary>
        private string path;

        /// <summary>
        /// The header
        /// </summary>
        private string header = "SrNo,State,Name,TIN,StateCode,";

        /// <summary>
        /// count the numberOfRecords 
        /// </summary>
        private int numberOfRecords = 0;

        /// <summary>
        /// Initializes a new instance of the <see cref="CSVStates"/> class.
        /// </summary>
        public CSVStates()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CSVStates"/> class.
        /// </summary>
        /// <param name="path">The path</param>
        public CSVStates(string path)
        {
            this.path = path;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CSVStates"/> class.
        /// </summary>
        /// <param name="path">The path</param>
        /// <param name="delimiter">The delimiter</param>
        public CSVStates(string path, char delimiter)
        {
            this.path = path;
            this.delimiter = delimiter;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CSVStates"/> class.
        /// </summary>
        /// <param name="path">The path</param>
        /// <param name="header">The header</param>
        public CSVStates(string path, string header)
        {
            this.path = path;
            this.header = header;
        }

        /// <summary>
        /// delegate named Data
        /// </summary>
        /// <returns>reference of GetData()</returns>
        public delegate string Data();

        /// <summary>
        /// Number Of Records
        /// </summary>
        /// <returns>Returns the number of lines</returns>
        public string GetData()
        {
            try
            {
                if (Path.GetExtension(this.path) != ".csv")
                {
                    throw new CustomException(CustomException.Exception_Type.IncorrectTypeException, "IncorrectTypeException");
                }

                string[] str = File.ReadAllLines(this.path);
                IEnumerable<string> getLines = str;
                Console.WriteLine(str[0]);
                foreach (string line in getLines)
                {
                    if (!line.Contains(this.delimiter))
                    {
                        throw new CustomException(CustomException.Exception_Type.IncorrectDelimiterException, "IncorrectDelimiterException");
                    }
                }

                if (str[0] != this.header)
                {
                    throw new CustomException(CustomException.Exception_Type.IncorrectHeaderException, "IncorrectHeaderException");
                }

                foreach (var lines in getLines)
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
