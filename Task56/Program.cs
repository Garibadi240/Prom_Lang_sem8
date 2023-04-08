Console.Clear();

/*Задайте прямоугольный двумерный массив. Напишите программу, которая будет находить строку с наименьшей суммой элементов.*/

int rows = GetNumberFromUser("Введите число строк массива: ", "Введено неверное число");
int columns = GetNumberFromUser("Введите число столбцов массива: ", "Введено неверное число"); //Отсчет сторок идет с единицы, а не с нуля.
Console.WriteLine();

int[,] array = InitArray(rows, columns, 0, 10);

Console.WriteLine("Двумерный массив:");
PrintArray(array);

SmallestRowSum(array);

Console.WriteLine($"Cтрока с наименьшей суммой элементов: {SmallestRowSum(array)}");



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

int SmallestRowSum(int[,] array)
{
    int min = 999999;
    int maxCount = 0;
    int sum = 0;

    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            sum = sum + array[i, j];
        }
            if (min > sum)
            {
                min = sum;
                maxCount = i;
            }
        sum = 0;
    }
    return maxCount + 1;
}
