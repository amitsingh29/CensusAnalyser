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
        /// <summary>
        /// Counts the number of lines
        /// </summary>
        private int count = 0;

        /// <summary>
        /// CSVBuilder object
        /// </summary>
        private CSVBuilder cSVBuilder = new CSVBuilder();

       /// <summary>
       /// GetData delegate
       /// </summary>
       /// <returns>GetData reference</returns>
        public delegate string ReadData1();
      
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
                 List<string> list = new List<string>();
                 foreach (var l in records)
                 {
                     list.Add(l);
                     this.count++;
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
