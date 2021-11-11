using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MoodAnalyzerProblems
{
    public class ModeAnalyserFactory
    {
        public object createMoodAnalyserObject(string className, String constructor)
        {
            string pattern = "." + constructor + "$";
            Match result = Regex.Match(className, pattern);

            if (result.Success)
            {
                try
                {
                    Assembly assembly = Assembly.GetExecutingAssembly();
                    Type moodAnalyserType = assembly.GetType(className);
                    var res = Activator.CreateInstance(moodAnalyserType);
                    return res;
                }
                catch (Exception ex)
                {
                    throw new CustomException(CustomException.ExceptionType.Class_Not_Found, "class not found");

                }
            }
            else
            {
                throw new CustomException(CustomException.ExceptionType.CONSTRUCTOR_NOT_FOUND, "constructor not found");
            }
        }
    }
}
