using System;

namespace Roman_to_Integer
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = Console.ReadLine();
            Console.WriteLine(RomanToInt(s));
        }
        public static int RomanToInt(string s)
        {
            int result = 0;
            int maxV = 0;
            for (int i = s.Length - 1; i >= 0; i--)
            {
                int v = RomanToInt(s[i]);
                if (v >= maxV)
                {
                    result += v;
                    maxV = v;
                }
                else
                {
                    result -= v;
                }
            }

            return result;
        }
        public static int RomanToInt(char letter)
        {
            switch (letter)
            {
                case 'I': return 1;
                case 'V': return 5;
                case 'X': return 10;
                case 'L': return 50;
                case 'C': return 100;
                case 'D': return 500;
                case 'M': return 1000;
                default:
                    return 0;
            }

        }

    }
}
