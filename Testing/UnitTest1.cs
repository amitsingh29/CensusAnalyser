using NUnit.Framework;
using CensusAnalyser;

namespace Testing
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void GivenTheStatesCensusCSVFile_CheckToEnsureTheNumberOfRecordMatches()
        {
            StateCensusAnalyser censusAnalyser = new StateCensusAnalyser();
            string value = censusAnalyser.ReadData();
            Assert.AreEqual(value, "30");
        }
    }
}