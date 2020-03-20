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
    public class StateCensusAnalyser : IAdapter
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
            return (lines.Length-1).ToString();
        }

        /// <summary>
        /// Method for sorting on the population basis
        /// </summary>
        public void SortPopulation()
        {
            string[] lines = File.ReadAllLines(@"C:\Users\ye10397\Desktop\Amit\StateCensusData.csv");
            var data = lines.Skip(1);

            IEnumerable<string> query =
                                        from line in data
                                        let x = line.Split(',')
                                        orderby x[1].ToInt32()
                                        select line;
            File.WriteAllLines(@"C:\Users\ye10397\Desktop\Amit\SortPopulation.csv", lines.Take(1).Concat(query.ToArray()));
        }

        /// <summary>
        /// Method for sorting on the state basis
        /// </summary>
        public void SortState()
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

        /// <summary>
        /// Converting data in SortedData csv file to json format
        /// </summary>
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

        /// <summary>
        /// Converting data in StateCode csv file to json format
        /// </summary>
        public void JsonConversion1()
        {
            string re = File.ReadAllText(@"C:\Users\ye10397\Desktop\Amit\StateCode.csv");
            StringBuilder sb = new StringBuilder();

            using (var p = ChoCSVReader.LoadText(re).WithFirstLineHeader())
            {
                using (var w = new ChoJSONWriter(sb))
                    w.Write(p);
            }
            File.WriteAllText(@"C:\Users\ye10397\Desktop\Amit\IndianStatesCensusAnalyserProblem\CensusAnalyser\ReadStateCode1.json", sb.ToString());
            string[] arr = File.ReadAllLines(@"C:\Users\ye10397\Desktop\Amit\StateCode.csv");
            foreach (string output in arr)
            {
                Console.WriteLine(output);
            }
        }

        /// <summary>
        /// Converting sorted Population data in  SortPopulation file to SortPopulation json file
        /// </summary>
        public void JsonConversion2()
        {
            string read = File.ReadAllText(@"C:\Users\ye10397\Desktop\Amit\SortPopulation.csv");
            StringBuilder stringBuilder = new StringBuilder();

            using (var x = ChoCSVReader.LoadText(read).WithFirstLineHeader())
            {
                using (var y = new ChoJSONWriter(stringBuilder))
                    y.Write(x);
            }
            File.WriteAllText(@"C:\Users\ye10397\Desktop\Amit\IndianStatesCensusAnalyserProblem\CensusAnalyser\SortPopulation.json", stringBuilder.ToString());
            string[] arr = File.ReadAllLines(@"C:\Users\ye10397\Desktop\Amit\SortPopulation.csv");
            foreach (string output in arr)
            {
                Console.WriteLine(output);
            }
        }


        /// <summary>
        /// Sorting string data
        /// </summary>
        /// <param name="path">The path</param>
        /// <param name="key">The key</param>
        public void SortingByString(string path, int key)
        {
            int count = Convert.ToInt32(ReadFileData());
            string[] temp;
            string[] record = new string[count + 1];
            string[] lines = File.ReadAllLines(path);
            int k = 0;
            int value = 0;
            foreach (var i in lines)
            {
                temp = i.Split(',');
                record[k] = temp[key];
                k++;
            }
            for (var i = 1; i < lines.Length; i++)
            {
                for (var j = i + 1; j < lines.Length; j++)
                {
                    if (record[i].CompareTo(record[j]) > 0)
                    {
                        string t = record[i];
                        record[i] = record[j];
                        record[j] = t;
                        value++;
                    }
                }
            }

            foreach (var i in record)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine(value);
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
                record[k] = (int)(temp[key]).ToInt32();
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


        /// <summary>
        /// Returns the first stateName or last stateName
        /// </summary>
        /// <param name="path">The path</param>
        /// <param name="stateName">The stateName</param>
        /// <param name="key">The key</param>
        /// <returns></returns>
        public string ReturnState(string path,int stateName, string key)
        {
            string record = File.ReadAllText(path);
            var data = JArray.Parse(record);
            if (stateName == 0)
                return data[data.Count - 1][key].ToString();
            if (stateName == 1)
                return data[0][key].ToString();
            return null;
        }

        public void Merge_CSV()
        {
            List<string> list1 = Method(@"C:\Users\ye10397\Desktop\Amit\StateCode.csv");
            
            List<string> list2 = Method(@"C:\Users\ye10397\Desktop\Amit\StateCensusData.csv");
            List<string[]> result1 = new List<string[]>();
            List<string[]> result2 = new List<string[]>();
            List<string> result3 = new List<string>();
            string[] arr1;
            string header = "SrNo,StateName,TIN,StateCode,Population,AreaInSqKm,DensityPerSqKm";
            for (int i = 1; i < list1.Count; i++)
            {
                string str1 = (string)list1[i];
                arr1 = str1.Split(',');
                result1.Add(arr1);
            }

            for (int i = 1; i < list2.Count; i++)
            {
                string str1 = (string)list2[i];
                arr1 = str1.Split(',');

                result2.Add(arr1);
            }

            result3.Add(header);
            for (int i = 0; i < result2.Count; i++)
            {
                StringBuilder temp = new StringBuilder();
                int flag = 0;
                for (int j = 0; j < result1.Count; j++)
                {
                    if (result2[i].GetValue(1).Equals(result1[j].GetValue(0)))
                    {
                        int k = 0;
                        while (k < result2[i].Length)
                        {
                            temp = temp.Append(result2[i].GetValue(k) + ",");
                            k++;
                        }
                        int l = 1;
                        while (l < result1[j].Length)
                        {
                            temp = temp.Append(result1[j].GetValue(l) + ",");
                            l++;
                        }
                        temp = temp.Remove(temp.Length - 1, 1);
                        result3.Add(temp.ToString());
                        flag = 1;
                        break;
                    }
                }

                if (flag == 0)
                {
                    int k = 0;
                    while (k < result2[i].Length)
                    {
                        temp = temp.Append(result2[i].GetValue(k) + ",");
                        k++;
                    }
                    temp = temp.Remove(temp.Length - 1, 1);
                    result3.Add(temp.ToString());
                }
            }

            File.WriteAllLines(@"C:\Users\ye10409\Desktop\CensusAnalyzer\Census_Analyser\CensusAnalyser_Project\Data\Sorted.csv", result3);

            foreach (var i in result3)
            {
                foreach (var j in i)
                {
                    Console.Write(j);
                }
                Console.WriteLine();
            }
            Console.ReadKey();
        }

        public static List<string> Method(string path)
        {
            string[] records = File.ReadAllLines(path);
            List<string> list = new List<string>();
            foreach (var i in records)
            {
                list.Add(i);
            }
            return list;
        }
    } 
}

