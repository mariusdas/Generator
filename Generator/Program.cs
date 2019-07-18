using System;
using System.Collections.Generic;

namespace Generator
{
    public class Program
    {
        const int aCofficient = 16807;
        const int bCofficient = 48271;
        const int devideMod = 2147483647;

        static void Main(string[] args)
        {
            Console.WriteLine("Generatorius A");
            var a = 0.0;
            if (!double.TryParse(Console.ReadLine(), out a))
            {
                Console.WriteLine("Parametras turi būti skaičius!");
                Console.ReadLine();
                return;
            }

            Console.WriteLine("Generatorius B");
            var b = 0.0;
            if (!double.TryParse(Console.ReadLine(), out b))
            {
                Console.WriteLine("Parametras turi būti skaičius!");
                Console.ReadLine();
                return;
            }

            Console.WriteLine("Kiek kartų sugeneruoti rezultatą?");
            var n = 0.0;
            if (!double.TryParse(Console.ReadLine(), out n))
            {
                Console.WriteLine("Parametras turi būti skaičius!");
                Console.ReadLine();
                return;
            }

            var aResult = new List<double>();
            var bResult = new List<double>();

            GenerateData(a, b, n, aResult, bResult);

            var equalLastNumber = 0;

            equalLastNumber = CalculateByLastNumberBits(n, aResult, bResult, equalLastNumber);

            Console.WriteLine(string.Format("Parametrai {0} ir {1}, rezultatas {2}", a, b, equalLastNumber));

            Console.ReadLine();
        }

        public static int CalculateByLastNumberBits(double n, List<double> aResult, List<double> bResult, int equalLastNumber)
        {
            Console.WriteLine("Generatorius A | B");
            for (var i = 0; i < n; i++)
            {
                Console.WriteLine(aResult[i] + " | " + bResult[i]);

                string binary1 = Convert.ToString(int.Parse(aResult[i].ToString()), 2);
                string binary2 = Convert.ToString(int.Parse(bResult[i].ToString()), 2);

                if (binary1.Length >= 8 && binary2.Length >= 8 && binary1.Substring(binary1.Length - 8) == binary2.Substring(binary2.Length - 8))
                    equalLastNumber++;
            }

            return equalLastNumber;
        }

        public static void GenerateData(double a, double b, double n, List<double> aResult, List<double> bResult)
        {
            for (var i = 0; i < n; i++)
            {
                if (i == 0)
                {
                    aResult.Add(a * aCofficient);
                    bResult.Add(b * bCofficient);
                }
                else
                {
                    aResult.Add(aResult[i - 1] * aCofficient % devideMod);
                    bResult.Add(bResult[i - 1] * bCofficient % devideMod);
                }
            }
        }
    }
}
