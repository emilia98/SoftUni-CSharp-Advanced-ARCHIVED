using System;

namespace EI
{
    class Program
    {
        static void Main(string[] args)
        {
            double kw = 10;
            Console.Write("D1 = ");
            double D1 = double.Parse(Console.ReadLine());
            Console.Write("D2 = ");
            double D2 = double.Parse(Console.ReadLine());
            // Console.Write("D3 = ");
            // double D3 = double.Parse(Console.ReadLine());

            double p = kw * Math.Sqrt(3) * (D1 + D2); 

            Console.WriteLine($"p = {p}");
        }

        public static double CalculateSum(int n)
        {
            double sum = 0;

            for (int i = 1; i <= n; i++)
            {
                sum += (1.0 / i);
            }

            return sum;
            
        }
    }
}
