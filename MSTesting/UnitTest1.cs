using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoodAnalyzerProblems;

namespace MSTesting
{
    [TestClass]
    public class UnitTest1  //here performed the unit testing for class
    {
        [TestMethod]
        public void AnalyseHappyMood() //here performed the unit testing for method
        {
        
            //Arrange
            string message = "I am in sad mood";
            string expected = "SAD";

            //Act
            ModeAnalyzer modeAnalyzer = new ModeAnalyzer(message);
            string actual = modeAnalyzer.AnalyzeMood();

            //Assert
            Assert.AreEqual(expected, actual);

        }
    }
}
