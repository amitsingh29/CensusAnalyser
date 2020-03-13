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
    using static CensusAnalyser.CSVStateCensus;
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

        [Test]
        public void GivenInCorrectFilePath_InCsvStateCensus_WhenAnalyse_ReturnFileNotFoundException()
        {
            CSVStateCensus obj = (CSVStateCensus)CSVFactory.Factory("CSVStateCensus");
            CSVBuilder cSVBuilder = new CSVBuilder(wrongPath);
            ReadData read = new ReadData(obj.GetData);
            string actual = read();
            string expected = "file not found";
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Givens the in correct file extension in CSV state census when analyse return incorrect file extension exception.
        /// </summary>
        [Test]
        public void GivenInCorrectFileExtension_InCsvStateCensus_WhenAnalyse_ReturnIncorrectFileExtensionException()
        {
            CSVStateCensus obj = (CSVStateCensus)CSVFactory.Factory("CSVStateCensus");
            CSVBuilder cSVBuilder = new CSVBuilder(wrongType);
            ReadData read = new ReadData(obj.GetData);
            string actual = read();
            string expected = "IncorrectTypeException";
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Givens the wrong delimiter in file when analyse return incorrect delimiter exception.
        /// </summary>
        [Test]
        public void GivenWrongDelimiterInFile_WhenAnalyse_ReturnIncorrectDelimiterException()
        {
            char delimiter = '.';
            CSVStateCensus obj = (CSVStateCensus)CSVFactory.Factory("CSVStateCensus");
            CSVBuilder cSVBuilder = new CSVBuilder(path, delimiter, header);
            ReadData read = new ReadData(obj.GetData);
            string expected = "IncorrectDelimiterException";
            string actual = read();
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Chekings the header of file when analyse return correct header.
        /// </summary>
        [Test]
        public void ChekingHeaderOfFile_WhenAnalyse_ReturnCorrectHeader()
        {
            CSVStateCensus obj = (CSVStateCensus)CSVFactory.Factory("CSVStateCensus");
            CSVBuilder cSVBuilder = new CSVBuilder(path, ',', "wrong header");
            ReadData read = new ReadData(obj.GetData);
            string expected = "IncorrectHeaderException";
            string actual = read();
            Assert.AreEqual(expected, actual);

        }

        /// <summary>
        /// Comparings the state census data with CSV states when analyse return correct count.
        /// </summary>
        [Test]
        public void Comparing_StateCensusData_With_CSVStates_WhenAnalyse_ReturnCorrectCount()
        {
            StateCensusAnalyser s = new StateCensusAnalyser(filePath);
            CSVStates obj = (CSVStates)CSVFactory.Factory("CSVStates");
            CSVBuilder cSVBuilder = new CSVBuilder(filePath, ',', header1);
            ReadData1 read = new ReadData1(obj.GetData);
            string expected = s.ReadFileData().ToString();
            string actual = read();
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Givens the in correct file path in CSV states when analyse return file not found exception.
        /// </summary>
        [Test]
        public void GivenInCorrectFilePath_InCsvStates_WhenAnalyse_ReturnFileNotFoundException()
        {
            CSVStates obj = (CSVStates)CSVFactory.Factory("CSVStates");
            ReadData1 read = new ReadData1(obj.GetData);
            CSVBuilder cSVBuilder = new CSVBuilder(wrongPath1);
            string expected = "file not found";
            string actual = read();
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Givens the in correct file extension in CSV states when analyse return incorrect file extension exception.
        /// </summary>
        [Test]
        public void GivenInCorrectFileExtension_InCsvStates_WhenAnalyse_ReturnIncorrectFileExtensionException()
        {
            CSVStates obj = (CSVStates)CSVFactory.Factory("CSVStates");
            ReadData1 read = new ReadData1(obj.GetData);
            CSVBuilder cSVBuilder = new CSVBuilder(wrongType1);
            string actual = read();
            string expected = "IncorrectTypeException";
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Given the wrong delimiter in file in csv states when analyse return incorrect delimiter exception.
        /// </summary>
        [Test]
        public void GivenWrongDelimiterInFile_inCSVStates_WhenAnalyse_ReturnIncorrectDelimiterException()
        {
            char delimiter = '.';
            CSVStates obj = (CSVStates)CSVFactory.Factory("CSVStates");
            CSVBuilder cSVBuilder = new CSVBuilder(filePath, delimiter, header1);
            ReadData1 read = new ReadData1(obj.GetData);
            string actual = read();
            string expected = "IncorrectDelimiterException";
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Chekings the header of file in CSV states when analyse return correct header.
        /// </summary>
        [Test]
        public void ChekingHeaderOfFile_InCsvStates_WhenAnalyse_ReturnCorrectHeader()
        {
            string header = "SrNo,State,Name,TIN,State";
            CSVStates obj = (CSVStates)CSVFactory.Factory("CSVStates");
            CSVBuilder cSVBuilder = new CSVBuilder(filePath, ',', header);
            ReadData1 read = new ReadData1(obj.GetData);
            string actual = read();
            string expected = "IncorrectHeaderException";
            Assert.AreEqual(expected, actual);
        }
    }
}
