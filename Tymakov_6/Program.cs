using System;
using System.Collections.Generic;
using System.Linq;

namespace Tymakov_6
{
    internal class Program
    {

        /// <summary>
        /// Метод для умножения двух матриц
        /// </summary>
        /// <param name="matrixA"></param>
        /// <param name="matrixB"></param>
        /// <returns></returns>
        static int[,] MultiplyMatrices(int[,] matrixA, int[,] matrixB)
        {
            int rowsA = matrixA.GetLength(0); // Количество строк в матрице A
            int colsA = matrixA.GetLength(1); // Количество столбцов в матрице A
            int colsB = matrixB.GetLength(1); // Количество столбцов в матрице B

            int[,] result = new int[rowsA, colsB]; // Создание результирующей матрицы

            // Умножение матриц
            for (int i = 0; i < rowsA; i++)
            {
                for (int j = 0; j < colsB; j++)
                {
                    for (int k = 0; k < colsA; k++)
                    {
                        result[i, j] += matrixA[i, k] * matrixB[k, j];
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// Метод для печати матрицы
        /// </summary>
        /// <param name="matrix"></param>
        static void PrintMatrix(int[,] matrix)
        {
            int rows = matrix.GetLength(0); // Количество строк в матрице
            int cols = matrix.GetLength(1); // Количество столбцов в матрице

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }

                Console.WriteLine();
            }

            Console.WriteLine();
        }

        /// <summary>
        /// Метод генерации рандомной температуры
        /// </summary>
        /// <returns></returns>
        static double[,] GenerateRandomTemperatures()
        {
            Random random = new Random();
            double[,] temperatures = new double[12, 30];

            for (int month = 0; month < 12; month++)
            {
                for (int day = 0; day < 30; day++)
                {
                    temperatures[month, day] = random.Next(-30, 40); // Генерация случайной температуры от -30 до 40 градусов
                }
            }

            return temperatures;
        }


        /// <summary>
        /// Находит среднею температуру месяца 
        /// </summary>
        /// <param name="temperatures"></param>
        /// <returns></returns>
        static double[] AverageTemperatures(double[,] temperatures)
        {
            double[] averageTemperatures = new double[12];

            for (int month = 0; month < 12; month++)
            {
                double sum = 0;
                for (int day = 0; day < 30; day++)
                {
                    sum += temperatures[month, day];
                }

                averageTemperatures[month] = sum / 30;
            }

            return averageTemperatures;
        }

        static string[] GetMonthNames()
        {
            string[] monthNames = new string[12]
            {
            "Январь", "Февраль", "Март", "Апрель", "Май", "Июнь",
            "Июль", "Август", "Сентябрь", "Октябрь", "Ноябрь", "Декабрь"
            };

            return monthNames;
        }


        /// <summary>
        /// Создаёт матрицу с помощью List
        /// </summary>
        /// <param name="rows"></param>
        /// <param name="cols"></param>
        /// <param name="matrixName"></param>
        /// <returns></returns>
        static LinkedList<LinkedList<int>> CreateMatrix(int rows, int cols, string matrixName)
        {
            LinkedList<LinkedList<int>> matrix = new LinkedList<LinkedList<int>>();

            Console.WriteLine($"Введите элементы матрицы {matrixName}:");

            for (int i = 0; i < rows; i++)
            {
                LinkedList<int> row = new LinkedList<int>();

                for (int j = 0; j < cols; j++)
                {
                    Console.Write($"Элемент [{i}, {j}]: ");
                    int element = int.Parse(Console.ReadLine());
                    row.AddLast(element);
                }

                matrix.AddLast(row);
            }

            return matrix;
        }

        /// <summary>
        /// Перемножение матриц при помощи List
        /// </summary>
        /// <param name="matrixA"></param>
        /// <param name="matrixB"></param>
        /// <returns></returns>
        static LinkedList<LinkedList<int>> MultiplyMatrices(LinkedList<LinkedList<int>> matrixA, LinkedList<LinkedList<int>> matrixB)
        {
            int rowsA = matrixA.Count; // Количество строк в матрице A
            int colsA = matrixA.First?.Value.Count ?? 0; // Количество столбцов в матрице A
            int colsB = matrixB.First?.Value.Count ?? 0; // Количество столбцов в матрице B

            LinkedList<LinkedList<int>> result = new LinkedList<LinkedList<int>>(); // Создание результирующей матрицы

            // Проверка возможности умножения матриц
            if (colsA == 0 || colsB == 0)
                return result;

            // Умножение матриц
            foreach (var rowA in matrixA)
            {
                LinkedList<int> resultRow = new LinkedList<int>();

                for (int j = 0; j < colsB; j++)
                {
                    int sum = 0;

                    for (int k = 0; k < colsA; k++)
                    {
                        int elementA = rowA.ElementAtOrDefault(k);
                        int elementB = matrixB.ElementAtOrDefault(k)?.ElementAtOrDefault(j) ?? 0;

                        sum += elementA * elementB;
                    }

                    resultRow.AddLast(sum);
                }

                result.AddLast(resultRow);
            }

            return result;
        }

        /// <summary>
        /// Метод для печати матрицы
        /// </summary>
        /// <param name="matrix"></param>
        static void PrintMatrix(LinkedList<LinkedList<int>> matrix)
        {
            foreach (var row in matrix)
            {
                foreach (var element in row)
                {
                    Console.Write(element + " ");
                }

                Console.WriteLine();
            }

            Console.WriteLine();
        }
    
        static void Main()
        {
            try
            {
                Console.WriteLine("Упр 6.2");
                Console.WriteLine("Умнажение двух матриц");
                // Ввод размерности матрицы A
                Console.Write("Введите количество строк матрицы A: ");
                int rowsA = int.Parse(Console.ReadLine());

                Console.Write("Введите количество столбцов матрицы A: ");
                int colsA = int.Parse(Console.ReadLine());

                // Ввод размерности матрицы B
                Console.Write("Введите количество строк матрицы B: ");
                int rowsB = int.Parse(Console.ReadLine());

                Console.Write("Введите количество столбцов матрицы B: ");
                int colsB = int.Parse(Console.ReadLine());

                // Проверка возможности умножения матриц
                if (colsA != rowsB)
                {
                    Console.WriteLine("Умножение матриц невозможно. Количество столбцов матрицы A должно быть равно количеству строк матрицы B.");
                    return;
                }

                // Создание и инициализация матрицы A
                int[,] matrixA = new int[rowsA, colsA];
                Console.WriteLine("Введите элементы матрицы A:");

                for (int i = 0; i < rowsA; i++)
                {
                    for (int j = 0; j < colsA; j++)
                    {
                        Console.Write($"Элемент [{i + 1}, {j + 1}]: ");
                        matrixA[i, j] = int.Parse(Console.ReadLine());
                    }
                }

                // Создание и инициализация матрицы B
                int[,] matrixB = new int[rowsB, colsB];
                Console.WriteLine("Введите элементы матрицы B:");

                for (int i = 0; i < rowsB; i++)
                {
                    for (int j = 0; j < colsB; j++)
                    {
                        Console.Write($"Элемент [{i + 1}, {j + 1}]: ");
                        matrixB[i, j] = int.Parse(Console.ReadLine());
                    }
                }

                // Вычисление результирующей матрицы C
                int[,] matrixC = MultiplyMatrices(matrixA, matrixB);

                // Вывод матрицы A
                Console.WriteLine("Матрица A:");
                PrintMatrix(matrixA);

                // Вывод матрицы B
                Console.WriteLine("Матрица B:");
                PrintMatrix(matrixB);

                // Вывод результирующей матрицы C
                Console.WriteLine("Результирующая матрица C:");
                PrintMatrix(matrixC);
                Console.WriteLine();


                Console.WriteLine("Упр 6.3");
                Console.WriteLine("Средняя температура за год");
                double[,] temperatures = GenerateRandomTemperatures();
                double[] averageTemperatures = AverageTemperatures(temperatures);
                string[] monthNames = GetMonthNames();

                Array.Sort(averageTemperatures, monthNames); // Сортировка массивов averageTemperatures и monthNames вместе

                Console.WriteLine("Средние температуры по месяцам (в градусах Цельсия):");
                for (int i = 0; i < averageTemperatures.Length; i++)
                {
                    Console.WriteLine($"{monthNames[i]}: {averageTemperatures[i]}");
                }
                Console.WriteLine();

                Console.WriteLine("Дз 6.2");
                Console.WriteLine("Умножение матриц через List");
                Console.Write("Введите количество строк матрицы A: ");
                int rowsA_list = int.Parse(Console.ReadLine());

                Console.Write("Введите количество столбцов матрицы A: ");
                int colsA_list = int.Parse(Console.ReadLine());

                // Ввод размерности матрицы B
                Console.Write("Введите количество строк матрицы B: ");
                int rowsB_list = int.Parse(Console.ReadLine());

                Console.Write("Введите количество столбцов матрицы B: ");
                int colsB_list = int.Parse(Console.ReadLine());

                // Проверка возможности умножения матриц
                if (colsA != rowsB)
                {
                    Console.WriteLine("Умножение матриц невозможно. Количество столбцов матрицы A должно быть равно количеству строк матрицы B.");
                    return;
                }

                // Создание и инициализация матрицы A
                LinkedList<LinkedList<int>> matrixA_list = CreateMatrix(rowsA, colsA, "A");

                // Создание и инициализация матрицы B
                LinkedList<LinkedList<int>> matrixB_list = CreateMatrix(rowsB, colsB, "B");

                // Вычисление результирующей матрицы C
                LinkedList<LinkedList<int>> matrixC_list = MultiplyMatrices(matrixA_list, matrixB_list);

                // Вывод матрицы A
                Console.WriteLine("Матрица A:");
                PrintMatrix(matrixA);

                // Вывод матрицы B
                Console.WriteLine("Матрица B:");
                PrintMatrix(matrixB);

                // Вывод результирующей матрицы C
                Console.WriteLine("Результирующая матрица C:");
                PrintMatrix(matrixC);
                Console.ReadKey();
            }
            catch (FormatException)
            {
                Console.WriteLine("Неккоректно введено число");
                Console.ReadKey();
            }
            Console.WriteLine();
        }
    }
}
