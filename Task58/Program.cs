Console.Clear();

/*Задайте две матрицы. Напишите программу, которая будет находить произведение двух матриц.*/

int rows1 = GetNumberFromUser("Введите число строк матрицы 1: ", "Введено неверное число");
int columns1 = GetNumberFromUser("Введите число столбцов матрицы 1: ", "Введено неверное число");

int[,] array1 = InitArray(rows1, columns1, 0, 10);
PrintArray(array1);

int rows2 = GetNumberFromUser("Введите число строк матрицы 2: ", "Введено неверное число");
int columns2 = GetNumberFromUser("Введите число столбцов матрицы 2: ", "Введено неверное число");

int[,] array2 = InitArray(rows2, columns2, 0, 10);
PrintArray(array2);

if (columns1 == rows2)
{
    int[,] result = MatrixMultiplication(array1, array2);
    PrintArray(result);
}
else
{
    Console.WriteLine("Умножение матриц невожможно, проверьте размерность.");
}

int GetNumberFromUser(string message, string errorMessage)
{
    while (true)
    {
        Console.Write(message);
        bool isCorrect = int.TryParse(Console.ReadLine(), out int userNumber);
        if (isCorrect && userNumber > 1)
            return userNumber;
        Console.WriteLine(errorMessage);
    }
}

int[,] InitArray(int m, int n, int minValue, int maxValue)
{
    int[,] result = new int[m, n];
    for (int i = 0; i < m; i++)
    {
        for (int j = 0; j < n; j++)
        {
            result[i, j] = new Random().Next(minValue, maxValue);
        }
    }
    return result;
}

void PrintArray(int[,] inArray)
{
    for (int i = 0; i < inArray.GetLength(0); i++)
    {
        for (int j = 0; j < inArray.GetLength(1); j++)
        {
            Console.Write($"{inArray[i, j]} ");
        }
        Console.WriteLine();
    }
    Console.WriteLine();
}

int[,] MatrixMultiplication(int[,] array1, int[,] array2)
{
    int[,] result = new int[array1.GetLength(0), array2.GetLength(1)];
    for (int i = 0; i < array1.GetLength(0); i++)
    {
        for (int j = 0; j < array2.GetLength(1); j++)
        {
            result[i, j] = 0;
            for (int count = 0; count < array2.GetLength(1); count++)
            {
                result[i, j] += array1[i, count] * array2[count, j];
            }
        }
    }
    return result;
}
