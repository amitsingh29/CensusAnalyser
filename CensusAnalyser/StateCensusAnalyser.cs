using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace CensusAnalyser
{
    public class StateCensusAnalyser
    {
        public string ReadData(string filePath)
        {
            if (Path.GetExtension(filePath) != ".csv")
            {
                throw new CustomException(CustomException.Exception_Type.IncorrectTypeException, "IncorrectTypeException");
            }

            try
            {
                string[] lines = File.ReadAllLines(filePath);
                return lines.Length.ToString();
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
