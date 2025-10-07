using System;
using System.Collections.Generic;
using System.Linq;

namespace Bai06
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());
            int[,] matrix = CreateMatrix(n, m);

            Console.WriteLine("Ma tran da tao:");
            PrintMatrix(matrix);

            int max = FindMax(matrix);
            int min = FindMin(matrix);
            Console.WriteLine("Phan tu lon nhat:");
            Console.WriteLine(max);
            Console.WriteLine("Phan tu nho nhat:");
            Console.WriteLine(min);

            int maxRowIndex = FindMaxRowSumIndex(matrix);
            Console.WriteLine("Dong co tong lon nhat:");
            Console.WriteLine(maxRowIndex);

            int sumNonPrime = SumNonPrime(matrix);
            Console.WriteLine("Tong cac so khong phai la so nguyen to:");
            Console.WriteLine(sumNonPrime);

            Console.WriteLine("Nhap so thu tu dong muon xoa:");
            int k = int.Parse(Console.ReadLine());
            int[,] matrixAfterRowDelete = DeleteRow(matrix, k);
            Console.WriteLine("Ma tran da xoa dong thu " + k + ":");
            PrintMatrix(matrixAfterRowDelete);

            List<int> colsWithMax = FindColsWithElement(matrix, max);
            int[,] matrixAfterColsDelete = DeleteCols(matrix, colsWithMax);
            Console.WriteLine("Ma tran da xoa cot chua phan tu lon nhat:");
            PrintMatrix(matrixAfterColsDelete);
        }

        // Tạo ma trận n dòng m cột với số nguyên ngẫu nhiên từ 1 đến 100
        static int[,] CreateMatrix(int n, int m)
        {
            int[,] mat = new int[n, m];
            Random rand = new Random();
            for (int i = 0; i < n; i++)
                for (int j = 0; j < m; j++)
                    mat[i, j] = rand.Next(1, 101);
            return mat;
        }

        // Xuất ma trận
        static void PrintMatrix(int[,] mat)
        {
            int n = mat.GetLength(0);
            int m = mat.GetLength(1);
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                    Console.Write(mat[i, j] + "\t");
                Console.WriteLine();
            }
        }

        // Tìm phần tử lớn nhất
        static int FindMax(int[,] mat)
        {
            int max = mat[0,0];
            foreach (int x in mat)
                if (x > max) max = x;
            return max;
        }

        // Tìm phần tử nhỏ nhất
        static int FindMin(int[,] mat)
        {
            int min = mat[0,0];
            foreach (int x in mat)
                if (x < min) min = x;
            return min;
        }

        // Tìm số thứ tự dòng có tổng lớn nhất (dòng đầu tiên là 0)
        static int FindMaxRowSumIndex(int[,] mat)
        {
            int n = mat.GetLength(0);
            int m = mat.GetLength(1);
            int maxSum = int.MinValue;
            int idx = 0;
            for (int i = 0; i < n; i++)
            {
                int sum = 0;
                for (int j = 0; j < m; j++)
                    sum += mat[i, j];
                if (sum > maxSum)
                {
                    maxSum = sum;
                    idx = i;
                }
            }
            return idx;
        }

        // Tính tổng các số không phải là số nguyên tố
        static int SumNonPrime(int[,] mat)
        {
            int sum = 0;
            foreach (int x in mat)
                if (!IsPrime(x)) sum += x;
            return sum;
        }

        // Kiểm tra số nguyên tố
        static bool IsPrime(int num)
        {
            if (num < 2) return false;
            for (int i = 2; i <= Math.Sqrt(num); i++)
                if (num % i == 0) return false;
            return true;
        }

        // Xóa dòng thứ k (dòng đầu tiên là 0)
        static int[,] DeleteRow(int[,] mat, int k)
        {
            int n = mat.GetLength(0);
            int m = mat.GetLength(1);
            if (k < 0 || k >= n) return mat;
            int[,] res = new int[n - 1, m];
            int r = 0;
            for (int i = 0; i < n; i++)
            {
                if (i == k) continue;
                for (int j = 0; j < m; j++)
                    res[r, j] = mat[i, j];
                r++;
            }
            return res;
        }

        // Tìm các cột chứa phần tử x
        static List<int> FindColsWithElement(int[,] mat, int x)
        {
            int n = mat.GetLength(0);
            int m = mat.GetLength(1);
            HashSet<int> cols = new HashSet<int>();
            for (int i = 0; i < n; i++)
                for (int j = 0; j < m; j++)
                    if (mat[i, j] == x)
                        cols.Add(j);
            return cols.OrderBy(c => c).ToList();
        }

        // Xóa các cột trong danh sách colsToDelete
        static int[,] DeleteCols(int[,] mat, List<int> colsToDelete)
        {
            int n = mat.GetLength(0);
            int m = mat.GetLength(1);
            int newM = m - colsToDelete.Count;
            int[,] res = new int[n, newM];
            for (int i = 0; i < n; i++)
            {
                int c = 0;
                for (int j = 0; j < m; j++)
                {
                    if (colsToDelete.Contains(j)) continue;
                    res[i, c] = mat[i, j];
                    c++;
                }
            }
            return res;
        }
    }
}
