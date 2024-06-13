using System;
using System.Collections.Generic;
using System.Text;

namespace workout
{
    public class StringTruncate
    {
        public static string Solution(string message, int K)
        {
            if (message.Length <= K)
            {
                return message;
            }

            var words = message.Split(' ');
            int allowedLength = K - 4;
            StringBuilder stringBuilder = new StringBuilder();
            foreach (var word in words)
            {
                if (allowedLength - (1 + word.Length) > -2)
                {
                    allowedLength = allowedLength - 1 - word.Length;
                    stringBuilder.Append(word);
                    stringBuilder.Append(" ");
                    continue;
                }
                break;
            }
            stringBuilder.Append("...");

            return stringBuilder.ToString();
        }
    }
}
