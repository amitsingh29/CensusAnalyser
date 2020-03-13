//-----------------------------------------------------------------------
// <copyright file="CSVBuilder.cs" company="BridgeLabz">
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
    /// CSVBuilder class
    /// </summary>
    public class CSVBuilder
    {
        /// <summary>
        /// The path
        /// </summary>
        private static string path;

        /// <summary>
        /// The header
        /// </summary>
        private static string header = "";

        /// <summary>
        /// The delimiter
        /// </summary>
        private static char delimiter = ',';

        /// <summary>
        /// The record
        /// </summary>
        private static string[] record;

        /// <summary>
        ///  Initializes a new instance of the <see cref="CSVBuilder"/> class.
        /// </summary>
        public CSVBuilder()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CSVBuilder"/> class.
        /// </summary>
        /// <param name="_path">_path</param>
        /// <param name="_delimiter">_path</param>
        /// <param name="_header">_path</param>
        public CSVBuilder(string _path, char _delimiter=',', string _header="")
        {
            path = _path;
            delimiter = _delimiter;
            header = _header;
        }

        /// <summary>
        /// Gets filepath
        /// </summary>
        public string FilePath
        {
            get
            {
                if (Path.GetExtension(path) != ".csv")
                {
                    throw new CustomException(CustomException.Exception_Type.IncorrectTypeException, "IncorrectTypeException");
                }

                if (path != @"C:\Users\ye10397\Desktop\Amit\StateCensusData.csv" && path != @"C:\Users\ye10397\Desktop\Amit\StateCode.csv")
                {
                    throw new CustomException(CustomException.Exception_Type.FileNotFoundException, "file not found");
                }
                record = File.ReadAllLines(path); 
                return path;
            }
        }   
            
        /// <summary>
        /// Gets record
        /// </summary>
        public string[] Record
        {
            get
            {
                return record;
            }
        }

        /// <summary>
        /// Gets header
        /// </summary>
        public string Header
        {
            get
            {
                try
                {

                    if (record[0] != header)
                    {
                        throw new CustomException(CustomException.Exception_Type.IncorrectHeaderException, "IncorrectHeaderException");
                    }
                }
                catch (Exception)
                {

                    throw;
                }
                return header;
            }
        }
        
        /// <summary>
        /// Gets delimiter
        /// </summary>
        public object Delimiter
        {
            get
            {
                try
                {
                    foreach (string line in record)
                    {
                        if (!line.Contains(delimiter))
                        {
                            throw new CustomException(CustomException.Exception_Type.IncorrectDelimiterException, "IncorrectDelimiterException");
                        }
                    }
                    return delimiter;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
    }
}
