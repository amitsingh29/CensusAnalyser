using CensusAnalyser;
using NUnit.Framework;

namespace Testing
{
    public class Tests
    {
        [Test]
        public void GivenTheStatesCensusCSVFile_CheckToEnsureTheNumberOfRecordMatches()
        {
            StateCensusAnalyser censusAnalyser = new StateCensusAnalyser();
            string value = censusAnalyser.ReadData();
            Assert.AreEqual(value, "30");
        }

        [Test]
        public void GivenIfCensusCSVFile_IfIncorrect_ReturnsCustomException()
        {
            StateCensusAnalyser stateCensus = new StateCensusAnalyser();
            
        }
    }
}