//-----------------------------------------------------------------------
// <copyright file="Tests.cs" company="BridgeLabz">
//     Copyright © 2020
// </copyright>
// <creator name="Amit Singh"/>
//-----------------------------------------------------------------------

namespace Testing
{
    using CensusAnalyser;
    using NUnit.Framework;
    using static CensusAnalyser.CSVStates;

    /// <summary>
    /// Tests class
    /// </summary>
    public class Tests
    {
        /// <summary>
        /// StateCensusData file path
        /// </summary>
        private string path = @"C:\Users\ye10397\Desktop\Amit\StateCensusData.csv";

        /// <summary>
        /// StateCensusData file wrong path
        /// </summary>
        private string wrongPath = @"C:\Users\ye10397\Desktop\Amit\StateCensusDat.csv";

        /// <summary>
        /// StateCensusData file wrongtype
        /// </summary>
        private string wrongType = @"C:\Users\ye10397\Desktop\Amit\StateCensusData.jpg";

        /// <summary>
        /// Statecode file path
        /// </summary>
        private string filePath = @"C:\Users\ye10397\Desktop\Amit\StateCode.csv";

        /// <summary>
        /// Statecode file wrong path
        /// </summary>
        private string wrongPath1 = @"C:\Users\ye10397\Desktop\Amit\StateCodes.csv";

        /// <summary>
        /// Statecode file wrong type
        /// </summary>
        private string wrongType1 = @"C:\Users\ye10397\Desktop\Amit\StateCode.jpg";

        /// <summary>
        /// StateCensusData file header
        /// </summary>
        private string header = "State,Population,AreaInSqKm,DensityPerSqKm";

        /// <summary>
        /// Statecode file header
        /// </summary>
        private string header1 = "SrNo,State,Name,TIN,StateCode,";

        /// <summary>
        /// Given the state census CSV file when analyze number of record matches.
        /// </summary>
        /// Test Case 1.1
        [Test]
        public void GivenTheStatesCensusCSVFile_CheckToEnsureTheNumberOfRecordMatches()
        {
            CSVBuilder cSVBuilder = new CSVBuilder(this.path, ',', header);
            StateCensusAnalyser stateCensus = new StateCensusAnalyser(this.path);
            CSVStateCensus cSVState = (CSVStateCensus)CSVFactory.Factory("CSVStateCensus");
            ReadData read = new ReadData(cSVState.GetData);
            string value = read();
            string value1 = stateCensus.ReadFileData();
            Assert.AreEqual(value, value1);
        }
    }
}