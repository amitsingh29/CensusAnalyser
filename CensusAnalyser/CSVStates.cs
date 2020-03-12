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
                return records.Length.ToString();
            }
            catch (Exception exception)
            {

                return exception.Message;
            }
        }
    }
}
