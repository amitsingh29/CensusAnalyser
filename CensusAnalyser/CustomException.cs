using System;
using System.Collections.Generic;
using System.Text;

namespace CensusAnalyser
{
  
    public class CustomException : Exception
    {
        private string message;
        private Exception_Type type;
        public CustomException(Exception_Type type, string message)
        {
            this.message = message;
            this.type = type;
        }

        public enum Exception_Type
        {
            FileNotFoundException,
            IncorrectTypeException,
            IncorrectDelimiterException,
            IncorrectHeaderException
        }

        public override string Message
        {
            get
            {
                return this.message;
            }
        }
    }
}
