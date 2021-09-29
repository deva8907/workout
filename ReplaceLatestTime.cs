using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace workout
{
    public class ReplaceLatestTime
    {
        public static string MaximumTime2(string time)
        {
            char[] t = time.ToCharArray();
            if (t[0] == '?')
                t[0] = t[1] == '?' ? '2' : t[1] > '3' ? '1' : '2';

            if (t[1] == '?')
                t[1] = t[0] == '2' ? '3' : '9';

            if (t[3] == '?')
                t[3] = '5';

            if (t[4] == '?')
                t[4] = '9';

            return new string(t);
        }

        public static string MaximumTime1(string time)
        {
            var temp = time.Select(t => t.ToString()).ToArray();
            int[] max = new int[] { 2, 9, 0, 5, 9 };
            string[] hh = new string[] { temp[0], temp[1] };
            string[] mm = new string[] { temp[3], temp[4] };
            int iteration = 0, h1Val = 0, h2Val = -1;
            int result;
            while (true)
            {
                if (iteration >= 10)
                {
                    h1Val++;
                    h2Val = iteration - 10;
                }
                else
                {
                    h1Val = 0;
                    h2Val++;
                }
                var h1 = hh[0] == "?" ? (max[0] - h1Val).ToString() : hh[0];
                var h2 = hh[1] == "?" ? (max[1] - h2Val).ToString() : hh[1];

                result = Convert.ToInt32($"{h1}{h2}");
                if (result > 23)
                {
                    iteration++;
                    continue;
                }
                break;
            }
            for (int i = 0; i < mm.Length; i++)
            {
                if (mm[i] == "?")
                {
                    mm[i] = max[3 + i].ToString();
                }
            }
            return $"{result.ToString().PadLeft(2, '0')}:{mm[0]}{mm[1]}";
        }
    }
}
