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
            string value = stateCensus.ReadData();
            Assert.AreEqual(value, "30" );
        }

        [Test]
        public void GivenTheStateCensusCSVFile_IfIncorrect_ReturnsACustomException()
        {
            StateCensusAnalyser stateCensusAnalyser = new StateCensusAnalyser(@"C:\Users\ye10397\Desktop\Amit\StateCensus.csv");
            CustomException value = Assert.Throws<CustomException>(() => stateCensusAnalyser.ReadData());
            Assert.AreEqual("file not found", value.Message);
        }

        [Test]
        public void GivenTheStateCensusCSVFile_IfCorrectButTypeIncorrect_ReturnsACustomException()
        {
            StateCensusAnalyser stateCensusAnalyser = new StateCensusAnalyser(@"C:\Users\ye10397\Desktop\Amit\StateCensusData.jpg");
            string value = stateCensusAnalyser.ReadData();
            Assert.AreEqual("IncorrectTypeException", value);
        }

        [Test]
        public void GivenTheStateCensusCSVFile_WhenCorrectButDelimiterIncorrect_ReturnsACustomException()
        {
            StateCensusAnalyser stateCensusAnalyser = new StateCensusAnalyser(@"C:\Users\ye10397\Desktop\Amit\StateCensusData.csv", '.');
            string value = stateCensusAnalyser.ReadData();
            Assert.AreEqual("IncorrectDelimiterException", value);
        }

        [Test]
        public void GivenTheStateCensusCSVFile_WhenCorrectButCSVHeaderIncorrect_ReturnsACustomException()
        {
            StateCensusAnalyser stateCensusAnalyser = new StateCensusAnalyser(@"C:\Users\ye10397\Desktop\Amit\StateCensusData.csv", "lhs");
            string value = stateCensusAnalyser.ReadData();
            Assert.AreEqual("IncorrectHeaderException", value);
        }
    }
}