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
    using NUnit.Framework.Internal;
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
        /// StateCensusData file wrongType
        /// </summary>
        private string wrongType = @"C:\Users\ye10397\Desktop\Amit\StateCensusData.jpg";

        /// <summary>
        /// Statecode filePath
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
        private string header1 = "SrNo,StateName,TIN,StateCode";

        /// <summary>
        /// ReadData json
        /// </summary>
        private string jsonPath = @"C:\Users\ye10397\Desktop\Amit\IndianStatesCensusAnalyserProblem\CensusAnalyser\ReadData.json";

        /// <summary>
        /// ReadStateCode1 json
        /// </summary>
        private string jsonPath1 = @"C:\Users\ye10397\Desktop\Amit\IndianStatesCensusAnalyserProblem\CensusAnalyser\ReadStateCode1.json";

        /// <summary>
        /// Given the state census CSV file when analyze number of record matches.
        /// </summary>
        //// Test Case 1.1
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

        /// <summary>
        /// Given the state census CSV file incorrect when analyze returns custom exception.
        /// </summary>
        //// Test Case 1.2
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
        public void GivenInCorrectFilePath_InCsvStateCensus_WhenAnalyse_ReturnFileNotFoundException1()
        {
            StateCensusAnalyser stateCensusAnalyser = new StateCensusAnalyser(path);
            stateCensusAnalyser.
        }
        /// <summary>
        /// Givens the in correct file extension in CSV state census when analyse return incorrect file extension exception.
        /// </summary>
         //// Test Case 1.3
        [Test]
        public void GivenInCorrectFileExtension_InCsvStateCensus_WhenAnalyse_ReturnIncorrectFileExtensionException()
        {
            CSVStateCensus obj = (CSVStateCensus)CSVFactory.Factory("CSVStateCensus");
            CSVBuilder cSVBuilder = new CSVBuilder(this.wrongType);
            ReadData read = new ReadData(obj.GetData);
            string actual = read();
            string expected = "IncorrectTypeException";
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Givens the wrong delimiter in file when analyse return incorrect delimiter exception.
        /// </summary>
        /// Test Case 1.4
        [Test]
        public void GivenWrongDelimiterInFile_WhenAnalyse_ReturnIncorrectDelimiterException()
        {
            char delimiter = '.';
            CSVStateCensus obj = (CSVStateCensus)CSVFactory.Factory("CSVStateCensus");
            CSVBuilder cSVBuilder = new CSVBuilder(this.path, delimiter, this.header);
            ReadData read = new ReadData(obj.GetData);
            string expected = "IncorrectDelimiterException";
            string actual = read();
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Chekings the header of file when analyse return correct header.
        /// </summary>
        /// Test Case 1.5
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
        /// Test Case 2.1
        [Test]
        public void Comparing_StateCensusData_With_CSVStates_WhenAnalyse_ReturnCorrectCount()
        {
            StateCensusAnalyser s = new StateCensusAnalyser(this.filePath);
            CSVStates obj = (CSVStates)CSVFactory.Factory("CSVStates");
            CSVBuilder cSVBuilder = new CSVBuilder(this.filePath, ',', this.header1);
            ReadData1 read = new ReadData1(obj.GetData);
            string expected = s.ReadFileData().ToString();
            string actual = read();
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Givens the in correct file path in CSV states when analyse return file not found exception.
        /// </summary>
        /// Test Case 2.2
        [Test]
        public void GivenInCorrectFilePath_InCsvStates_WhenAnalyse_ReturnFileNotFoundException()
        {
            CSVStates obj = (CSVStates)CSVFactory.Factory("CSVStates");
            ReadData1 read = new ReadData1(obj.GetData);
            CSVBuilder cSVBuilder = new CSVBuilder(this.wrongPath1);
            string expected = "file not found";
            string actual = read();
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Givens the in correct file extension in CSV states when analyse return incorrect file extension exception.
        /// </summary>
        /// Test Case 2.3
        [Test]
        public void GivenInCorrectFileExtension_InCsvStates_WhenAnalyse_ReturnIncorrectFileExtensionException()
        {
            CSVStates obj = (CSVStates)CSVFactory.Factory("CSVStates");
            ReadData1 read = new ReadData1(obj.GetData);
            CSVBuilder cSVBuilder = new CSVBuilder(this.wrongType1);
            string actual = read();
            string expected = "IncorrectTypeException";
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Given the wrong delimiter in file in csv states when analyse return incorrect delimiter exception.
        /// </summary>
        /// Test Case 2.4
        [Test]
        public void GivenWrongDelimiterInFile_inCSVStates_WhenAnalyse_ReturnIncorrectDelimiterException()
        {
            char delimiter = '.';
            CSVStates obj = (CSVStates)CSVFactory.Factory("CSVStates");
            CSVBuilder cSVBuilder = new CSVBuilder(this.filePath, delimiter, this.header1);
            ReadData1 read = new ReadData1(obj.GetData);
            string actual = read();
            string expected = "IncorrectDelimiterException";
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Chekings the header of file in CSV states when analyse return correct header.
        /// </summary>
        /// Test Case 2.5
        [Test]
        public void ChekingHeaderOfFile_InCsvStates_WhenAnalyse_ReturnCorrectHeader()
        {
            //string header = "SrNo,State,Name,TIN,State";
            CSVStates obj = (CSVStates)CSVFactory.Factory("CSVStates");
            CSVBuilder cSVBuilder = new CSVBuilder(this.filePath, ',', this.header);
            ReadData1 read = new ReadData1(obj.GetData);
            string actual = read();
            string expected = "IncorrectHeaderException";
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Checkings the start state in state census when analyse return correct match.
        /// </summary>
        [Test]
        public void CheckingStartState_InStateCensus_WhenAnalyse_ReturnCorrectMatch()
        {
            StateCensusAnalyser stateCensusAnalyser = new StateCensusAnalyser();
            string actual = stateCensusAnalyser.ReturnState(jsonPath, 1,"State");
            Assert.AreEqual("Andhra Pradesh", actual);
        }

        /// <summary>
        /// Checkings the end state in state census when analyse return correct match.
        /// </summary>
        [Test]
        public void CheckingEndState_InStateCensus_WhenAnalyse_ReturnCorrectMatch()
        {
            StateCensusAnalyser stateCensusAnalyser = new StateCensusAnalyser();
            string actual = stateCensusAnalyser.ReturnState(this.jsonPath, 0, "State");
            Assert.AreEqual("West Bengal", actual);
        }

        /// <summary>
        /// Checkings the start state in state code when analyse return correct match.
        /// </summary>
        [Test]
        public void CheckingStartState_InStateCensusAsPerStateCode_WhenAnalyse_ReturnCorrectMatch()
        {
            StateCensusAnalyser stateCensusAnalyser = new StateCensusAnalyser();
            string actual = stateCensusAnalyser.ReturnState(this.jsonPath1, 1, "StateCode");
            Assert.AreEqual("AN", actual);
        }

        /// <summary>
        /// Checkings the end state in state code when analyse return correct match.
        /// </summary>
        [Test]
        public void CheckingEndState_InStateCensus_WhenAnalyseAsPerStateCode_ReturnCorrectMatch()
        {
            StateCensusAnalyser stateCensusAnalyser = new StateCensusAnalyser();
            string actual = stateCensusAnalyser.ReturnState(jsonPath1, 0, "StateCode");
            Assert.AreEqual("WB", actual);
        }

        [Test]
        public void CheckingEndState_InStateCensus_WhenAnalyseAsPerStateCode_ReturnCorrectMatch1()
        {
            StateCensusAnalyser stateCensusAnalyser = new StateCensusAnalyser();
            string actual = stateCensusAnalyser.ReturnState(jsonPath1, 0, "StateCode");
            Assert.AreEqual("WB", actual);
        }
      /*  [Test]
        public void Number_of_IterationsFor_Sorting_by_Population()
        {
            StateCensusAnalyser stateCensusAnalyser = new StateCensusAnalyser(@"C:\Bridgelabz\IndianState_CensusAnalyser\IndianState_CensusAnalyser\DataFile\Sorted.csv");
            int actual = stateCensusAnalyser.SortingByInt(@"C:\Bridgelabz\IndianState_CensusAnalyser\IndianState_CensusAnalyser\DataFile\Sorted.csv", 1);
            int expected = 186;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Number_of_IterationsFor_Sorting_by_Area()
        {
            StateCensusAnalyser stateCensusAnalyser = new StateCensusAnalyser(@"C:\Bridgelabz\IndianState_CensusAnalyser\IndianState_CensusAnalyser\DataFile\Sorted.csv");
            int actual = stateCensusAnalyser.SortingByInt(@"C:\Bridgelabz\IndianState_CensusAnalyser\IndianState_CensusAnalyser\DataFile\Sorted.csv", 2);
            int expected = 204;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Number_of_IterationsFor_Sorting_by_Density()
        {
            StateCensusAnalyser stateCensusAnalyser = new StateCensusAnalyser(@"C:\Bridgelabz\IndianState_CensusAnalyser\IndianState_CensusAnalyser\DataFile\Sorted.csv");
            int actual = stateCensusAnalyser.SortingByInt(@"C:\Bridgelabz\IndianState_CensusAnalyser\IndianState_CensusAnalyser\DataFile\Sorted.csv", 3);
            int expected = 193;
            Assert.AreEqual(expected, actual);
        }*/

    }
}
