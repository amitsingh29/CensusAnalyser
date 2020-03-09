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

    /// <summary>
    /// Tests class
    /// </summary>
    public class Tests
    {

        /// <summary>
        /// Given the state census CSV file when analyze number of record matches.
        /// </summary>
        [Test]
        public void GivenTheStatesCensusCSVFile_CheckToEnsureTheNumberOfRecordMatches()
        {
            StateCensusAnalyser stateCensus = new StateCensusAnalyser(@"C:\Users\ye10397\Desktop\Amit\StateCensusData.csv");
            CSVStateCensus census = new CSVStateCensus(@"C:\Users\ye10397\Desktop\Amit\StateCensusData.csv");
            string value = stateCensus.ReadFileData();
            string value1 = census.ReadData();
            Assert.AreEqual(value, value1);
        }

        /// <summary>
        /// Given the state census CSV file incorrect when analyze returns custom exception.
        /// </summary>
        [Test]
        public void GivenTheStateCensusCSVFile_IfIncorrect_ReturnsACustomException()
        {
            CSVStateCensus stateCensus = new CSVStateCensus(@"C:\Users\ye10397\Desktop\Amit\StateCensus.csv");
            CustomException value = Assert.Throws<CustomException>(() => stateCensus.ReadData());
            Assert.AreEqual("file not found", value.Message);
        }

        /// <summary>
        /// Given the state census CSV file correct type incorrect when analyze returns custom exception.
        /// </summary>
        [Test]
        public void GivenTheStateCensusCSVFile_IfCorrectButTypeIncorrect_ReturnsACustomException()
        {
            CSVStateCensus stateCensus = new CSVStateCensus();
            string value = stateCensus.ReadData();
            Assert.AreEqual("IncorrectTypeException", value);
        }

        /// <summary>
        /// Given the state census CSV file correct delimiter incorrect when analyze returns custom exception.
        /// </summary>
        [Test]
        public void GivenTheStateCensusCSVFile_WhenCorrectButDelimiterIncorrect_ReturnsACustomException()
        {
            CSVStateCensus stateCensus = new CSVStateCensus(@"C:\Users\ye10397\Desktop\Amit\StateCensusData.csv", '.');
            string value = stateCensus.ReadData();
            Assert.AreEqual("IncorrectDelimiterException", value);
        }

        /// <summary>
        /// Given the state census CSV file correct CSV header incorrect when analyze returns custom exception.
        /// </summary>
        [Test]
        public void GivenTheStateCensusCSVFile_WhenCorrectButCSVHeaderIncorrect_ReturnsACustomException()
        {
            CSVStateCensus stateCensus = new CSVStateCensus(@"C:\Users\ye10397\Desktop\Amit\StateCensusData.csv", "lhs");
            string value = stateCensus.ReadData();
            Assert.AreEqual("IncorrectHeaderException", value);
        }
    }
}