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
            // Test Case 1
            //Arrange
            string message = "I am in sad mood";
            string expected = "SAD";

            //Act
            ModeAnalyzer modeAnalyzer = new ModeAnalyzer();
            string actual = modeAnalyzer.AnalyzeMood(message);

            //Assert
            Assert.AreEqual(expected, actual);

        }
    }
}
