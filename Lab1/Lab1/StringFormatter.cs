using System;

namespace Lab1
{
    public class StringFormatter
    {
        public string SafeString(string s)
        {
            if (s == null)
            {
                throw new ArgumentNullException("s", "String can not be null");
            }
            if (s == String.Empty)
            {
                throw new ArgumentException("String can not be empty", "s");
            }
            var tmpString = s.Replace("'", "\"");
            return tmpString;
        }
    }
}