//-----------------------------------------------------------------------
// <copyright file="IAdapter.cs" company="BridgeLabz">
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
    /// IAdapter interface
    /// </summary>
    public interface IAdapter
    {
        public int SortingByInt(string path, int key);
    }
}
