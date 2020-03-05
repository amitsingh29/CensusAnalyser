using System;
using System.Collections.Generic;
using System.Text;

namespace CensusAnalyser
{
    public class CustomException : Exception
    {
        private string message;
        public CustomException(string message)
        {
            this.message = message;
        }

        public override string Message
        {
            get
            {
                return this.Message;
            }
        }

    }
}
