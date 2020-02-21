using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Web;

namespace OpenIDSampleApp.Components {
    public class Common {
        protected static Regex htmlRegex = new Regex("<[^>]+>|\\&nbsp\\;|\\&lt\\;|\\&rt\\;", RegexOptions.IgnoreCase | RegexOptions.Compiled);
        protected static Regex pathRegex = new Regex("[^A-Za-z0-9\\-/]", RegexOptions.IgnoreCase | RegexOptions.Compiled);
        protected static Regex spacer = new Regex(@"\s{2,}");
        private readonly static Regex isWhitespace = new Regex("[^\\w&;#]", RegexOptions.Singleline | RegexOptions.Compiled);

        private static Random random = new Random(46258975); //just some number to seed it.

        /// <summary>
        /// 
        /// </summary>
        /// <param name="min">The inclusive minimum value for the random integer</param>
        /// <param name="max">The inclusive maximum value for the random integer</param>
        /// <returns></returns>
        public static int GetRandomInteger(int min, int max)
        {
            return random.Next(min, max+1);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="minLength">The inclusive minimum length of the string</param>
        /// <param name="maxLength">The inclusive maximum length of the string</param>
        /// <returns></returns>
        public static string GetRandomString(int minLength, int maxLength)
        {
            int strLength = GetRandomInteger(minLength, maxLength);

            StringBuilder builder = new StringBuilder();
            char ch;
            for (int i = 0; i < strLength; i++) {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }
            return builder.ToString().ToLower();
        }
    }
}
