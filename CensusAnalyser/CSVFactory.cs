//-----------------------------------------------------------------------
// <copyright file="CSVFactory.cs" company="BridgeLabz">
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
    /// CSVFactory class
    /// </summary>
    public class CSVFactory 
    {
        /// <summary>
        /// Interface ICSVBuilder
        /// </summary>
        /// <param name="className">The className</param>
        /// <returns>starting className or ending className</returns>
        public static ICSVBuilder Factory(string className)
        {
            switch (className)
            {
                case "CSVStates":
                    return new CSVStates();
                case "CSVStateCensus":
                    return new CSVStateCensus();
            }

            return null;
        }
    }
}
