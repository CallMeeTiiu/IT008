using System;

namespace LTW_Lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] arr = new int[n];
            Random rand = new Random();

            // Khởi tạo mảng với các số ngẫu nhiên từ 1 đến 100 và in mảng để kiểm tra
            for (int i = 0; i < n; i++)
            {
                arr[i] = rand.Next(1, 100);
                Console.Write(arr[i] + " ");
            }

            Console.WriteLine();
            Console.WriteLine(SumOfOddNumbers(arr));
            Console.WriteLine(CountOfPrimeNumbers(arr));
            Console.WriteLine(SmallestPerfectSquare(arr));
            Console.ReadLine();
        }

        // Tính tổng các số lẻ trong mảng
        static int SumOfOddNumbers(int[] arr)
        {
            int sum = 0;
            foreach (int num in arr)
            {
                if (num % 2 != 0)
                    sum += num;
            }
            return sum;
        }

        // Đếm số lượng số nguyên tố trong mảng
        static int CountOfPrimeNumbers(int[] arr)
        {
            int count = 0;
            foreach (int num in arr)
            {
                if (IsPrime(num))
                    count++;
            }
            return count;
        }

        // Kiểm tra số nguyên tố
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

        // Tìm số chính phương nhỏ nhất trong mảng
        static int SmallestPerfectSquare(int[] arr)
        {
            int min = int.MaxValue;
            foreach (int num in arr)
            {
                int sqrt = (int)Math.Sqrt(num);
                if (sqrt * sqrt == num && num < min)
                {
                    min = num;
                }
            }
            return min == int.MaxValue ? -1 : min;
        }
    }
}
