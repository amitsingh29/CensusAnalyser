using System;
using System.IO;

namespace CensusAnalyser
{
    public class StateCensusAnalyser
    {
        public string ReadData()
        {
            try
            {
                StreamReader sr = new StreamReader(@"C:\Users\ye10397\Desktop\Amit\StateCensusAnalyser.csv");
                sr.BaseStream.Seek(0, SeekOrigin.Begin);
                string str = sr.ReadLine();
                int numberOfRecords = 0;
                while (str != null)
                {
                    str = sr.ReadLine();
                    numberOfRecords++;
                }
                Console.WriteLine("Number of records are: " + numberOfRecords);
                return numberOfRecords.ToString();
            }
            catch (Exception exception)
            {

                return exception.Message;
            }

        }
    }
}
