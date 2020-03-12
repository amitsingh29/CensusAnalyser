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
            StateCensusAnalyser stateCensus = new StateCensusAnalyser(this.path);
            string value = stateCensus.ReadFileData();
            CSVStateCensus census = new CSVStateCensus();
            string value1 = census.GetData(this.path);
            Assert.AreEqual(value, value1);
        }

        /// <summary>
        /// Given the state census CSV file incorrect when analyze returns custom exception.
        /// </summary>
        /// Test Case 1.2
        [Test]
        public void GivenTheStateCensusCSVFile_IfIncorrect_ReturnsACustomException()
        {
            CSVStateCensus stateCensus = new CSVStateCensus();
            CustomException value = Assert.Throws<CustomException>(() => stateCensus.GetData(this.wrongPath));
            Assert.AreEqual("file not found", value.Message);
        }

        /// <summary>
        /// Given the state census CSV file correct type incorrect when analyze returns custom exception.
        /// </summary>
        /// Test Case 1.3
        [Test]
        public void GivenTheStateCensusCSVFile_IfCorrectButTypeIncorrect_ReturnsACustomException()
        {
            CSVStateCensus stateCensus = new CSVStateCensus();
            string value = stateCensus.GetData(this.wrongType);
            Assert.AreEqual("IncorrectTypeException", value);
        }

        /// <summary>
        /// Given the state census CSV file correct delimiter incorrect when analyze returns custom exception.
        /// </summary>
        /// Test Case 1.4
        [Test]
        public void GivenTheStateCensusCSVFile_WhenCorrectButDelimiterIncorrect_ReturnsACustomException()
        {
            CSVStateCensus stateCensus = new CSVStateCensus();
            string value = stateCensus.GetData(this.path, '.');
            Assert.AreEqual("IncorrectDelimiterException", value);
        }

        /// <summary>
        /// Given the state census CSV file correct CSV header incorrect when analyze returns custom exception.
        /// </summary>
        /// Test Case 1.5
        [Test]
        public void GivenTheStateCensusCSVFile_WhenCorrectButCSVHeaderIncorrect_ReturnsACustomException()
        {
            CSVStateCensus stateCensus = new CSVStateCensus();
            string value = stateCensus.GetData(this.path, ',', "lhs");
            Assert.AreEqual("IncorrectHeaderException", value);
        }

        /// <summary>
        /// Given the state code CSV file when analyze number of record matches using delegate.
        /// </summary>
        /// Test Case 2.1
        [Test]
        public void GivenTheStatesCodeCSVFile_CheckToEnsureTheNumberOfRecordMatches()
        {
            StateCensusAnalyser stateCensus = new StateCensusAnalyser(this.filePath);
            CSVStates census = new CSVStates();
            Data delegate_obj = new Data(census.GetData);
            string value = delegate_obj(this.filePath, ',', this.header1);
            string actual = stateCensus.ReadFileData();
            Assert.AreEqual(value, actual);
        }

        /// <summary>
        ///  Given the state code CSV file incorrect when analyze returns custom exception using delegate.
        /// </summary>
        /// Test Case 2.2
        [Test]
        public void GivenTheStateCodeCSVFile_IfIncorrect_ReturnsACustomException()
        {
            CSVStates state = new CSVStates();
            CustomException value = Assert.Throws<CustomException>(() => state.GetData(this.wrongPath1));
            Assert.AreEqual("file not found", value.Message);
        }

        /// <summary>
        /// Given the state code CSV file correct type incorrect when analyze returns custom exception using delegate.
        /// </summary>
        /// Test Case 2.3
        [Test]
        public void GivenTheStateCodeCSVFile_IfCorrectButTypeIncorrect_ReturnsACustomException()
        {
            CSVStates state = new CSVStates();
            Data delegate_obj = new Data(state.GetData);
            string actual = delegate_obj(this.wrongType1);
            Assert.AreEqual("IncorrectTypeException", actual);
        }

        /// <summary>
        ///  Given the state code CSV file correct delimiter incorrect when analyze returns custom exception using delegate.
        /// </summary>
        /// Test Case 2.4
        [Test]
        public void GivenTheStateCodeCSVFile_WhenCorrectButDelimiterIncorrect_ReturnsACustomException()
        {
            CSVStates state = new CSVStates();
            Data delegate_obj = new Data(state.GetData);
            string actual = delegate_obj(this.filePath, '.');
            Assert.AreEqual("IncorrectDelimiterException", actual);
        }

        /// <summary>
        /// Given the state code CSV file correct CSV header incorrect when analyze returns custom exception using delegate.
        /// </summary>
        /// Test Case 2.5
        [Test]
        public void GivenTheStateCodeCSVFile_WhenCorrectButCSVHeaderIncorrect_ReturnsACustomException()
        {
            CSVStates state = new CSVStates();
            Data delegate_obj = new Data(state.GetData);
            string actual = delegate_obj(this.filePath, ',', "wrong header");
            Assert.AreEqual("IncorrectHeaderException", actual);
        }   
    }
}