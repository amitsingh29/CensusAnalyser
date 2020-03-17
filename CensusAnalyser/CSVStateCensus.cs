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
        /// Count number of lines
        /// </summary>
        private int count = 0;

        /// <summary>
        /// CSVBuilder object
        /// </summary>
        private CSVBuilder cSVBuilder = new CSVBuilder();

        /// <summary>
        ///  GetData delegate
        /// </summary>
        /// <returns>GetData reference</returns>
        public delegate string ReadData();

        /// <summary>
        /// The number of lines
        /// </summary>
        /// <returns>Counts the number of lines</returns>
        public string GetData()
        {
            try
            {
                string filePath = this.cSVBuilder.FilePath;
                string header = this.cSVBuilder.Header;
                char delimiter = (char)this.cSVBuilder.Delimiter;
                string[] records = this.cSVBuilder.Record;
                int k = 0;
                Dictionary<int, Dictionary<string, string>> keyValuePairs = new Dictionary<int, Dictionary<string, string>>();
                string[] record = records[0].Split(',');
                Dictionary<string, string> pairs;
                for (int i = 1; i < records.Length; i++)
                {
                    this.count++;
                    string[] value = records[i].Split(',');
                    pairs = new Dictionary<string, string>();
                    for (int j = 0; j < value.Length; j++)
                    {
                        pairs.Add(record[j], value[j]);
                    }

                    keyValuePairs.Add(k, pairs);
                    k++;
                }

                return this.count.ToString();
            }
            catch (Exception exception)
            { 
                return exception.Message;
            }
        }
    }
}
