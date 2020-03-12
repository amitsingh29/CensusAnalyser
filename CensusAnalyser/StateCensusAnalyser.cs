//-----------------------------------------------------------------------
// <copyright file="StateCensusAnalyser.cs" company="BridgeLabz">
//     Copyright © 2020
// </copyright>
// <creator name="Amit Singh"/>
//-----------------------------------------------------------------------

namespace CensusAnalyser
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

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
    }
}
