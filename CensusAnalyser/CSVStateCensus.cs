//-----------------------------------------------------------------------
// <copyright file="CSVStateCensus.cs" company="BridgeLabz">
//     Copyright © 2020
// </copyright>
// <creator name="Amit Singh"/>
//-----------------------------------------------------------------------

namespace CensusAnalyser
{
    using ChoETL;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;

    /// <summary>
    /// CSVStateCensus class
    /// </summary>
    public class CSVStateCensus : ICSVBuilder,IAdapter
    {
        IAdapter iAdapter;
        public CSVStateCensus()
        {

        }
        public CSVStateCensus(string filePath)
        {
            this.filePath = filePath;
        }

        public CSVStateCensus(IAdapter iAdapter)
        {
            this.iAdapter = iAdapter;
        }

        public int SortingByInt(string path, int key)
        {
            return iAdapter.SortingByInt(path,key);
        }
        private string filePath;

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
        /// Number Of Records
        /// </summary>
        /// <returns>The Number Of Lines</returns>
        public string ReadFileData()
        {
            string[] lines = File.ReadAllLines(this.filePath);
            return (lines.Length - 1).ToString();
        }

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
            /// <summary>
            /// Sorting int data
            /// </summary>
            /// <param name="path">The path</param>
            /// <param name="key">The key</param>
            /// <returns></returns>
            public int SortingByInt(string path, int key)
            {
                    int count = Convert.ToInt32(ReadFileData());
                    string[] temp;
                    int[] record = new int[count + 1];
                    string[] lines = File.ReadAllLines(path);
                    int k = 0;
                    int value = 0;
                    foreach (var i in lines)
                    {
                        temp = i.Split(',');
                        record[k] = (int)temp[key].ToInt32();
                        k++;
                    }
                    for (int i = 1; i < lines.Length; i++)
                    {
                        for (int j = i + 1; j < lines.Length; j++)
                        {
                            if (record[i] > record[j])
                            {
                                int t = record[i];
                                record[i] = record[j];
                                record[j] = t;
                                value++;
                            }
                        }
                    }

                    return value;
            }
    }
}
    
