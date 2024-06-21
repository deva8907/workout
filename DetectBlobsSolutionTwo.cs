using System;

namespace workout
{
    public class DetectBlobsSolutionTwo
    {
        public static int Solution(string[] message, int maxCount)
        {
            var data = new bool[message.Length][];
            for (int i = 0; i < message.Length; i++)
            {
                data[i] = new bool[message[i].Length];
            }

            int result = 0;
            for (int i = 0; i < data.Length; i++)
            {
                for (int j = 0; j < data[i].Length; j++)
                {
                    if (Traverse(message, data, i, j) >= maxCount) result += 1;
                }
            }
            Console.WriteLine($"result: {result}");
            return result;
        }

        private static int Traverse(string[] message, bool[][] data, int i, int j)
        {
            if (i < 0 || i >= data.Length || j < 0 || j >= data[i].Length || data[i][j] || message[i].ToCharArray()[j] == '0')
            {
                return 0;
            }
            
            data[i][j] = true;
            int result = 1;
            result += Traverse(message, data, i + 1, j);
            result += Traverse(message, data, i - 1, j);
            result += Traverse(message, data, i, j + 1);
            result += Traverse(message, data, i, j - 1);
            return result;
        }
    }
}