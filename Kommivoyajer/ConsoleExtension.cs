using System;

namespace Kommivoyajer
{
    public class ConsoleExtension
    {
        public static void EndOfCase()
        {
            Console.WriteLine("\nНажмите любую кнопку, чтобы продолжить.");
            Console.ReadKey();
        }

        public static void ShowArray(int[,] matrix)
        {
            Console.WriteLine("\nМатрица:");
            for (var i = 0; i < matrix.GetLength(0); i++)
            {
                for (var j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(i == j ? "\t- " : $"\t{matrix[i, j]} ");
                }

                Console.WriteLine();
            }
        }
    }
}
