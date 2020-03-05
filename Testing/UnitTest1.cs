using CensusAnalyser;
using NUnit.Framework;

namespace Testing
{
    public class Tests
    {
        [Test]
        public void GivenTheStatesCensusCSVFile_CheckToEnsureTheNumberOfRecordMatches()
        {
            StateCensusAnalyser stateCensus = new StateCensusAnalyser();
            int value = stateCensus.ReadData(@"C:\Users\ye10397\Desktop\Amit\StateCensusData.csv");
            Assert.AreEqual(value, 30 );
        }

        /*[Test]
        public void GivenTheStateCensusCSVFile_IfIncorrect_ReturnsACustomException()
        {
            StateCensusAnalyser stateCensusAnalyser = new StateCensusAnalyser();
            var value = Assert.Throws<CustomException>(()=>stateCensusAnalyser.ReadData(@"C:\Users\ye10397\Desktop\Amit\StateCensus.csv"));
            Assert.AreEqual("file not found", value.GetMessage);
        }*/


        
    }
}