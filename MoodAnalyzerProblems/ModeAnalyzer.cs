using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoodAnalyzerProblems
{
    public class ModeAnalyzer
    {
        public string message;

        public ModeAnalyzer(string message)
        {
            this.message = message;
        }
        public string AnalyzeMood()
        {
            try
            {
                if (message.ToLower().Contains("sad"))
                {
                    return "SAD";
                }
                else
                    return "HAPPY";
            }
            catch (NullReferenceException ex)
            {
                //return "happy";
                throw new CustomException(CustomException.ExceptionType.NUll_Type_Exception, "Message Should Not Be Null");
            }
        }

    }
}
