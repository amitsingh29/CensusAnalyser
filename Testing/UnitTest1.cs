using CensusAnalyser;
using NUnit.Framework;

namespace Testing
{
    public class Tests
    {
        [Test]
        public void GivenTheStatesCensusCSVFile_CheckToEnsureTheNumberOfRecordMatches()
        {
            StateCensusAnalyser stateCensus = new StateCensusAnalyser(@"C:\Users\ye10397\Desktop\Amit\StateCensusData.csv");
            CSVStateCensus census = new CSVStateCensus(@"C:\Users\ye10397\Desktop\Amit\StateCensusData.csv");
            string value = stateCensus.ReadFileData();
            string value1 = census.ReadData();
            Assert.AreEqual(value, value1);
        }

        [Test]
        public void GivenTheStateCensusCSVFile_IfIncorrect_ReturnsACustomException()
        {
            CSVStateCensus stateCensus = new CSVStateCensus(@"C:\Users\ye10397\Desktop\Amit\StateCensus.csv");
            CustomException value = Assert.Throws<CustomException>(() => stateCensus.ReadData());
            Assert.AreEqual("file not found", value.Message);
        }

        [Test]
        public void GivenTheStateCensusCSVFile_IfCorrectButTypeIncorrect_ReturnsACustomException()
        {
            CSVStateCensus stateCensus = new CSVStateCensus();
            string value = stateCensus.ReadData();
            Assert.AreEqual("IncorrectTypeException", value);
        }

        [Test]
        public void GivenTheStateCensusCSVFile_WhenCorrectButDelimiterIncorrect_ReturnsACustomException()
        {
            CSVStateCensus stateCensus = new CSVStateCensus(@"C:\Users\ye10397\Desktop\Amit\StateCensusData.csv", '.');
            string value = stateCensus.ReadData();
            Assert.AreEqual("IncorrectDelimiterException", value);
        }

        [Test]
        public void GivenTheStateCensusCSVFile_WhenCorrectButCSVHeaderIncorrect_ReturnsACustomException()
        {
            CSVStateCensus stateCensus = new CSVStateCensus(@"C:\Users\ye10397\Desktop\Amit\StateCensusData.csv", "lhs");
            string value = stateCensus.ReadData();
            Assert.AreEqual("IncorrectHeaderException", value);
        }
    }
}