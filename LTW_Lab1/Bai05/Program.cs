using System;

namespace Bai05
{
    class Program
    {
        static void Main(string[] args)
        {
            int day = int.Parse(Console.ReadLine());
            int month = int.Parse(Console.ReadLine());
            int year = int.Parse(Console.ReadLine());
            if (!IsValidDate(day, month, year))
                Console.WriteLine("Thoi gian khong hop le");
            else
                Console.WriteLine(GetDayOfWeek(day, month, year));
        }

        // Kiểm tra ngày tháng năm có hợp lệ không
        static bool IsValidDate(int day, int month, int year)
        {
            if (year <= 0 || month < 1 || month > 12 || day < 1)
                return false;
            int[] daysInMonth = { 31, IsLeapYear(year) ? 29 : 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
            if (day > daysInMonth[month - 1])
                return false;
            return true;
        }

        // Kiểm tra năm nhuận
        static bool IsLeapYear(int year)
        {
            return (year % 4 == 0 && year % 100 != 0) || (year % 400 == 0);
        }

        // Trả về thứ trong tuần của ngày tháng năm (Chủ nhật, Thứ hai, ...)
        static string GetDayOfWeek(int day, int month, int year)
        {
            // Zeller's Congruence
            if (month < 3)
            {
                month += 12;
                year--;
            }
            int k = year % 100;
            int j = year / 100;
            int h = (day + 13 * (month + 1) / 5 + k + k / 4 + j / 4 + 5 * j) % 7;
            string[] days = { "Saturday", "Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday" };
            return days[h];
        }
    }
}
