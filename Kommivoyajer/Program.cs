using System;
using System.Text;

namespace Kommivoyajer
{
    internal class Program
    {
        private static void Main()
        {
            while (true)
            {
                Console.Write("1) Ввести данные с клавиуатуры\n" +
                              "2) Заполнить стандартными значениями\n" +
                              "3) Информация\n" +
                              "0) Выход\n" +
                              "\nВвод: ");
                int num;
                while (!int.TryParse(Console.ReadLine(), out num))
                {
                    Console.Write("Ошибка ввода! Введите целое число:");
                }
                 
                switch (num)
                {
                    case 1:
                        Console.Write("Введите количество городов n:");
                        int n;
                        while (!int.TryParse(Console.ReadLine(), out n))
                        {
                            Console.Write("Ошибка ввода! Введите целое число:");
                        }
                        var matrix = new int[n, n];
                        for (var i = 0; i < n; i++)
                        for (var j = 0; j < n; j++)
                            if (i == j)
                            {
                                matrix[i, j] = int.MaxValue;
                            }
                            else
                            {
                                Console.Write($"Путь между городами [{i+1}->{j+1}]:");
                                
                                while (!int.TryParse(Console.ReadLine(), out matrix[i,j]))
                                {
                                    Console.Write("Ошибка ввода! Введите целое число:");
                                }
                            }
                        Console.WriteLine();
                        var graph = new Graph(matrix);
                        graph.SearchGm();
                        ConsoleExtension.ShowArray(matrix);
                        ConsoleExtension.EndOfCase();
                        break;
                    case 2:
                        int[,] defaultArray =
                        {
                            { int.MaxValue, 4, 39, 22, 10, 47 },
                            { 58, int.MaxValue, 56, 18, 4, 35 },
                            { 57, 85, int.MaxValue, 24, 38, 52 },
                            { 30, 50, 44, int.MaxValue, 9, 31 },
                            { 18, 42, 24, 31, int.MaxValue, 30 },
                            { 1, 38, 31, 19, 32, int.MaxValue }
                        };
                        graph = new Graph(defaultArray);
                        graph.SearchGm();
                        ConsoleExtension.ShowArray(defaultArray);

                        ConsoleExtension.EndOfCase();
                        break;
                    case 3:
                        Console.WriteLine("\tПрограмма для решения задачи Коммивояжера перебором\n" +
                                          "\tПри помощи цикла Гамильтона\n" +
                                          "\t---------\n" +
                                          "\tРазработчик: Титова Ксения Олеговна\n" +
                                          "\tГруппа: А01ИСТ2\n");
                        ConsoleExtension.EndOfCase();
                        break;
                    case 0:
                        return;
                    default:
                        Console.WriteLine("Введите число, которое есть в меню.\n");
                        ConsoleExtension.EndOfCase();
                        break;
                }

                Console.Clear();
            }
        }
    }
}