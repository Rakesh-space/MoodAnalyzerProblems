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

        /// <summary>
        /// Creates the mood analyser object.
        /// </summary>
        /// <param name="className">Name of the class.</param>
        /// <param name="constructor">The constructor.</param>
        /// <returns></returns>
        /// UC4 
        /// default constructor         
        /// </exception>
        public object createMoodAnalyserObject(string className, String constructor)
        {
            string pattern = @"." + constructor + "$";
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

        /// <summary>
        /// Reflection UC5 using parameter constructor
        /// Creates the mood analyser parameter object.
        /// </summary>
        /// <param name="className">Name of the class.</param>
        /// <param name="constructor">The constructor.</param>
        /// <param name="message">The message.</param>

        public object CreateMoodAnalyserParameterObject(string className, string constructor, string message)
        {
            try
            {
                Type tyep = typeof(ModeAnalyzer);
                if (tyep.Name.Equals(className) || tyep.FullName.Equals(className))
                {
                    if (tyep.Name.Equals(constructor))
                    {
                        ConstructorInfo constructorInfo = tyep.GetConstructor(new[] { typeof(string) });
                        var obj = constructorInfo.Invoke(new object[] { message });
                        return obj;
                    }
                    else
                    {
                        throw new CustomException(CustomException.ExceptionType.CONSTRUCTOR_NOT_FOUND, "constructor not found");
                    }
                }
                else
                {
                    throw new CustomException(CustomException.ExceptionType.Class_Not_Found, "class not found");

                }


            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        /// <summary>
        /// Invokes the analyser method.
        /// UC6
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="methodName">Name of the method.</param>
        /// <returns></returns>
        /// <exception cref="MoodAnalyzarProblem.CustomException">method not found</exception>
        public string InvokeAnalyserMethod(string message, string methodName)
        {
            try
            {
                Type type = typeof(ModeAnalyzer);
                MethodInfo methodInfo = type.GetMethod(methodName);
                ModeAnalyserFactory factory = new ModeAnalyserFactory();
                object moodAnalyserObject = factory.CreateMoodAnalyserParameterObject("MoodAnalyzarProblem.ModeAnalyzer", "ModeAnalyzer", message);
                object info = methodInfo.Invoke(moodAnalyserObject, null);
                return info.ToString();
            }
            catch (NullReferenceException ex)
            {
                throw new CustomException(CustomException.ExceptionType.No_Such_Method, "method not found");
            }
        }

    }
}
