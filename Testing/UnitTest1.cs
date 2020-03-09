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
            CSVStateCensus stateCensus = new CSVStateCensus(@"C:\Users\ye10397\Desktop\Amit\StateCensusData.jpg");
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

        /// <summary>
        /// Given the state code CSV file when analyze number of record matches.
        /// </summary>
        [Test]
        public void GivenTheStatesCodeCSVFile_CheckToEnsureTheNumberOfRecordMatches()
        {
            StateCensusAnalyser stateCensus = new StateCensusAnalyser(@"C:\Users\ye10397\Desktop\Amit\StateCode.csv");
            CSVStates states = new CSVStates(@"C:\Users\ye10397\Desktop\Amit\StateCode.csv");
            string value1 = states.GetData();
            string value = stateCensus.ReadFileData();
            Assert.AreEqual(value, value1);
        }

        /// <summary>
        ///  Given the state code CSV file incorrect when analyze returns custom exception.
        /// </summary>
        [Test]
        public void GivenTheStateCodeCSVFile_IfIncorrect_ReturnsACustomException()
        {
            CSVStates state = new CSVStates(@"C:\Users\ye10397\Desktop\Amit\StateCensus.csv");
            CustomException value = Assert.Throws<CustomException>(() => state.GetData());
            Assert.AreEqual("file not found", value.Message);
        }

        /// <summary>
        /// Given the state code CSV file correct type incorrect when analyze returns custom exception.
        /// </summary>
        [Test]
        public void GivenTheStateCodeCSVFile_IfCorrectButTypeIncorrect_ReturnsACustomException()
        {
            CSVStates state = new CSVStates(@"C:\Users\ye10397\Desktop\Amit\StateCode.jpg");
            string value = state.GetData();
            Assert.AreEqual("IncorrectTypeException", value);
        }

        /// <summary>
        ///  Given the state code CSV file correct delimiter incorrect when analyze returns custom exception.
        /// </summary>
        [Test]
        public void GivenTheStateCodeCSVFile_WhenCorrectButDelimiterIncorrect_ReturnsACustomException()
        {
            CSVStates state = new CSVStates(@"C:\Users\ye10397\Desktop\Amit\StateCode.csv", '.');
            string value = state.GetData();
            Assert.AreEqual("IncorrectDelimiterException", value);
        }

        /// <summary>
        /// Given the state code CSV file correct CSV header incorrect when analyze returns custom exception.
        /// </summary>
        [Test]
        public void GivenTheStateCodeCSVFile_WhenCorrectButCSVHeaderIncorrect_ReturnsACustomException()
        {
            CSVStates state = new CSVStates(@"C:\Users\ye10397\Desktop\Amit\StateCode.csv", "rhs");
            string value = state.GetData();
            Assert.AreEqual("IncorrectHeaderException", value);
        }
    }
}