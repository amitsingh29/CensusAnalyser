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
        public int count = 0;
        public CSVBuilder cSVBuilder = new CSVBuilder();
        public delegate string ReadData();
        public string GetData()
        {
            try
            {
                string filePath = cSVBuilder.FilePath;
                string header = cSVBuilder.Header;
                char delimiter = (char)cSVBuilder.Delimiter;
                string[] records = cSVBuilder.Record;
                int k = 0;
                Dictionary<int, Dictionary<string, string>> keyValuePairs = new Dictionary<int, Dictionary<string, string>>();
                string[] record = records[0].Split(',');
                Dictionary<string, string> pairs;
                for (int i=1;i<records.Length;i++)
                {
                    count++;
                    string[] value = records[i].Split(',');
                    pairs = new Dictionary<string, string>();
                    for (int j=0;j<value.Length;j++)
                    {
                        pairs.Add(record[j],value[j]);
                    }
                    keyValuePairs.Add(k,pairs);
                    k++;
                }

                return count.ToString();
            }
            catch (Exception exception)
            { 
                return exception.Message;
            }
        }
    }
}
