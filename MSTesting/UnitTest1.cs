using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoodAnalyzerProblems;


namespace MSTesting
{
    [TestClass]
    public class UnitTest1  //here performed the unit testing for class
    {
        [TestMethod]
        public void AnalyseHappyMood()  //here performed the unit testing for method
        {
            // Test Case 1
            //Arrange
            string message = null;
            string expected = "happy";

            //Act
            ModeAnalyzer modeAnalyzer = new ModeAnalyzer(message);
            string actual = modeAnalyzer.AnalyzeMood();

            //Assert
            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void getCustomNullException()
        {
            //Arrange
            string expected = "Message Should Not Be Null";
            ModeAnalyzer modeAnalyzer = new ModeAnalyzer(null);

            try
            {
                //Act
                string actual = modeAnalyzer.AnalyzeMood();

            }
            catch (CustomException ex)
            {

                //Assart
                Assert.AreEqual(expected, ex.Message);
            }

        }
    }
}
