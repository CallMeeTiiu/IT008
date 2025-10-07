using System;

namespace Bai02
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine(SumOfPrimesLessThanN(n));
        }

        // Tính tổng các số nguyên tố nhỏ hơn n
        static int SumOfPrimesLessThanN(int n)
        {
            int sum = 0;
            for (int i = 2; i < n; i++)
            {
                if (IsPrime(i))
                    sum += i;
            }
            return sum;
        }

        // Kiểm tra một số có phải là số nguyên tố không
        static bool IsPrime(int num)
        {
            if (num < 2) return false;
            for (int i = 2; i <= Math.Sqrt(num); i++)
            {
                if (num % i == 0)
                    return false;
            }
            return true;
        }
    }
}
