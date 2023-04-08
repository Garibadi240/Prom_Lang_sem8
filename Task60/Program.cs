Console.Clear();

/*.Сформируйте трёхмерный массив из неповторяющихся двузначных чисел.
Напишите программу, которая будет построчно выводить массив, добавляя индексы каждого элемента.*/

int row = GetNumberFromUser("Введите число строк матрицы: ","Введите число от 1 до 4 включительно");
int column = GetNumberFromUser("Введите число столбцов матрицы: ","Введите число от 1 до 4 включительно");
int hight = GetNumberFromUser("Введите число глубины матрицы: ","Введите число от 1 до 4 включительно");
Console.WriteLine();

int[,,] arrayWork = new int[row, column, hight];

ArraySort(arrayWork);
PrintArray(arrayWork);




int GetNumberFromUser(string message, string errorMessage)
{
    while (true)
    {
        Console.Write(message);
        bool isCorrect = int.TryParse(Console.ReadLine(), out int userNumber);
        if (isCorrect && userNumber > 1 && userNumber < 5)
            return userNumber;
        Console.WriteLine(errorMessage);
    }
}

void PrintArray(int[,,] array)
{
    int count = 0;
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            for (int k = 0; k < array.GetLength(2); k++)
            {
                if (count == array.GetLength(0))
                {
                    Console.WriteLine();
                    count = 0;
                }
                Console.Write($"{array[i, j, k]}({i},{j},{k}) ");
                count++;
            }
        }
    }
}

void ArraySort(int[,,] array)
{
    int arraySize = array.GetLength(0) * array.GetLength(1) * array.GetLength(2);
    int[] sortArray = new int[arraySize];
    int count = 10;
    int num = 0;

    for (int i = 0; i < arraySize; i++) // Заполнение одномерного массива без дубликатов последовательностью от 10 до (arraySize < 100).
    {
        sortArray[i] = count;
        count++;
    }

    for (int j = 0; j < sortArray.GetLength(0) / 2; j++) // Сортировка заполненого массива так, чтобы числа в массиве были расположены в случайном порядке.
    {
        int b = new Random().Next(sortArray.GetLength(0) / 2, sortArray.GetLength(0) - 1);
        Swap(sortArray, j, b);
    }

    for (int i = 0; i < array.GetLength(0); i++)   // Заполнение трехмерного массива значениями из отсортированного одномерного массива.
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            for (int k = 0; k < array.GetLength(2); k++)
            {
                if(num < arraySize){
                    array[i, j, k] = sortArray[num];
                    num = num + 1;
                }
            }
        }
    }
}

void Swap(int[] array, int a, int b)
{
    int swap;
    swap = array[a];
    array[a] = array[b];
    array[b] = swap;
}
