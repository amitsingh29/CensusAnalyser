//-----------------------------------------------------------------------
// <copyright file="StateCensusAnalyser.cs" company="BridgeLabz">
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
    using System.Linq;
    using System.Text;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

    /// <summary>
    /// StateCensusAnalyser class
    /// </summary>
    public class StateCensusAnalyser
    {
        /// <summary>
        /// File Path
        /// </summary>
        private string filePath;

        /// <summary>
        /// Initializes a new instance of the <see cref="StateCensusAnalyser"/> class.
        /// </summary>
        public StateCensusAnalyser()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="StateCensusAnalyser"/> class.
        /// </summary>
        /// <param name="filePath">The Path</param>
        public StateCensusAnalyser(string filePath)
        {
            this.filePath = filePath;
        }

        /// <summary>
        /// Number Of Records
        /// </summary>
        /// <returns>The Number Of Lines</returns>
        public string ReadFileData()
        {
            string[] lines = File.ReadAllLines(this.filePath);
            return lines.Length.ToString();
        }

        public void SortData()
        {
            string[] lines = System.IO.File.ReadAllLines(@"C:\Users\ye10397\Desktop\Amit\StateCensusData.csv");
            var data = lines.Skip(1);

            IEnumerable<string> query =
                                        from line in data
                                        let x = line.Split(',')
                                        orderby x[0]
                                        select line;

            File.WriteAllLines(@"C:\Users\ye10397\Desktop\Amit\SortedData.csv", lines.Take(1).Concat(query));
        }

        public void JsonConversion()
        {

            string re = File.ReadAllText(@"C:\Users\ye10397\Desktop\Amit\SortedData.csv");
            StringBuilder sb = new StringBuilder();

            using (var p = ChoCSVReader.LoadText(re).WithFirstLineHeader())
            {
                using (var w = new ChoJSONWriter(sb))
                    w.Write(p);
            }
            File.WriteAllText(@"C:\Users\ye10397\Desktop\Amit\IndianStatesCensusAnalyserProblem\CensusAnalyser\ReadData.json", sb.ToString());
            string[] arr = File.ReadAllLines(@"C:\Users\ye10397\Desktop\Amit\SortedData.csv");
            foreach (string output in arr)
            {
                Console.WriteLine(output);
            }
        }

        public string ReturnState(string path,string stateName, int key)
        {
            string record = File.ReadAllText(path);
            var data = JArray.Parse(record);
            if (key == 0)
                return data[data.Count - 1][key].ToString();
            if (key == 1)
                return data[0][key].ToString();
            return null;

        }
    } 
}

