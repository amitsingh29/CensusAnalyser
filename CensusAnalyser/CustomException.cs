//-----------------------------------------------------------------------
// <copyright file="CustomException.cs" company="BridgeLabz">
//     Copyright © 2020
// </copyright>
// <creator name="Amit Singh"/>
//-----------------------------------------------------------------------

namespace CensusAnalyser
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// CustomException
    /// </summary>
    public class CustomException : Exception
    {
        /// <summary>
        /// The message
        /// </summary>
        private string message;

        /// <summary>
        /// The Exception_Type type
        /// </summary>
        private Exception_Type type;

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomException"/> class.
        /// </summary>
        /// <param name="type">The type</param>
        /// <param name="message">The message</param>
        public CustomException(Exception_Type type, string message)
        {
            this.message = message;
            this.type = type;
        }

        /// <summary>
        /// Exception type enum
        /// </summary>
        public enum Exception_Type
        {
            /// <summary>
            /// The wrong file
            /// </summary>
            FileNotFoundException,

            /// <summary>
            /// The Incorrect type
            /// </summary>
            IncorrectTypeException,

            /// <summary>
            /// The incorrect delimiter
            /// </summary>
            IncorrectDelimiterException,

            /// <summary>
            /// The Incorrect Exception
            /// </summary>
            IncorrectHeaderException
        }

        /// <summary>
        /// Gives Exception Type Message
        /// </summary>
        public override string Message
        {
            get
            {
                return this.message;
            }
        }
    }
}
