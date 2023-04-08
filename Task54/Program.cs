Console.Clear();

/*Задайте двумерный массив. Напишите программу, которая упорядочит по убыванию элементы каждой строки двумерного массива.*/

int rows = GetNumberFromUser("Введите число строк массива: ", "Введено неверное число");
int columns = GetNumberFromUser("Введите число столбцов массива: ", "Введено неверное число");

int[,] array = InitArray(rows, columns, 0, 10);

Console.WriteLine("Изначальный двумерный массив:");
PrintArray(array);

SortinReductionArray(array);

Console.WriteLine("Отсортированный двумерный массив:");
PrintArray(array);



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

void SortinReductionArray(int[,] array)
{
    int count = 0;

    for (int i = 0; i < array.GetLength(0); i++)
    {
        while (count != array.GetLength(1) - 1)
        {
            for (int j = 0; j < array.GetLength(1) - 1; j++)
            {
                if (array[i, j] < array[i, j + 1])
                {
                    int min = array[i, j];
                    array[i, j] = array[i, j + 1];
                    array[i, j + 1] = min;
                }
            }
            count++;
        }
        count = 0;
    }
}
