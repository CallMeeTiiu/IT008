using System;

namespace Bai05
{
    class Program
    {
        static void Main(string[] args)
        {
            int month = int.Parse(Console.ReadLine());
            int year = int.Parse(Console.ReadLine());
            int days = GetDaysInMonth(month, year);
            if (days == -1)
                Console.WriteLine("Thoi gian khong hop le");
            else
                Console.WriteLine(days);
        }

        // Trả về số ngày của tháng trong năm, nếu không hợp lệ trả về -1
        static int GetDaysInMonth(int month, int year)
        {
            if (year <= 0 || month < 1 || month > 12)
                return -1;

            int[] daysInMonth = { 31, IsLeapYear(year) ? 29 : 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
            return daysInMonth[month - 1];
        }

        // Kiểm tra năm nhuận
        static bool IsLeapYear(int year)
        {
            return (year % 4 == 0 && year % 100 != 0) || (year % 400 == 0);
        }
    }
}
