using System;

namespace workout
{
    public class DetectBlobs
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
                    var output = Traverse(data, i, j);
                    if (output) result += 1;
                }
            }
            return result;
        }

        private static bool Traverse(bool[][] data, int i, int j)
        {
            if (i < 0 || i >= data.Length || j < 0 || j >= data[i].Length)
            {
                return false;
            }

            Traverse(data, i + 1, j);
            Traverse(data, i - 1, j);
            Traverse(data, i, j + 1);
            Traverse(data, i, j - 1);

            data[i][j] = true;

            return true;
        }
    }
}