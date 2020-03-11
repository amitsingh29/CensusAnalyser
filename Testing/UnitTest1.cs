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
        string path = @"C:\Users\ye10397\Desktop\Amit\StateCensusData.csv";
        string wrongPath = @"C:\Users\ye10397\Desktop\Amit\StateCensusDat.csv";
        string wrongType = @"C:\Users\ye10397\Desktop\Amit\StateCensusData.jpg";
        string filePath = @"C:\Users\ye10397\Desktop\Amit\StateCode.csv";
        string wrongPath1 = @"C:\Users\ye10397\Desktop\Amit\StateCodes.csv";
        string wrongType1 = @"C:\Users\ye10397\Desktop\Amit\StateCode.jpg";
        string header = "State,Population,AreaInSqKm,DensityPerSqKm";
        string header1 = "SrNo,State,Name,TIN,StateCode,";

        /// <summary>
        /// Given the state census CSV file when analyze number of record matches.
        /// </summary>
        /// Test Case 1.1
        [Test]
        public void GivenTheStatesCensusCSVFile_CheckToEnsureTheNumberOfRecordMatches()
        {
            StateCensusAnalyser stateCensus = new StateCensusAnalyser(path);
            string value = stateCensus.ReadFileData();
            CSVStateCensus census = new CSVStateCensus();
            string value1 = census.GetData(path);
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
            CustomException value = Assert.Throws<CustomException>(() => stateCensus.GetData(wrongPath));
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
            string value = stateCensus.GetData(wrongType);
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
            string value = stateCensus.GetData(path, '.');
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
            string value = stateCensus.GetData(path, ',', "lhs");
            Assert.AreEqual("IncorrectHeaderException", value);
        }

        /// <summary>
        /// Given the state code CSV file when analyze number of record matches using delegate.
        /// </summary>
        /// Test Case 2.1
        [Test]
        public void GivenTheStatesCodeCSVFile_CheckToEnsureTheNumberOfRecordMatches()
        {
            StateCensusAnalyser stateCensus = new StateCensusAnalyser(filePath);
            CSVStates census = new CSVStates();
            Data delegate_obj = new Data(census.GetData);
            string value = delegate_obj(filePath, ',', header1);
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
            CustomException value = Assert.Throws<CustomException>(() => state.GetData(wrongPath1));
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
            string actual = delegate_obj(wrongType1);
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
            string actual = delegate_obj(filePath, '.');
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
            string actual = delegate_obj(filePath, ',', "wrong header");
            Assert.AreEqual("IncorrectHeaderException", actual);
        }   
    }
}