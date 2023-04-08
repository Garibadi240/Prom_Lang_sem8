

//Напишите программу, которая заполнит спирально массив 4 на 4.

Console.Clear();

int row = GetNumberFromUser("Введите число строк матрицы: ", "Введено неверное число");
int column = GetNumberFromUser("Введите число столбцов матрицы: ", "Введено неверное число");

int[,] arrayWork = new int[row, column];

ArraySort(arrayWork);
PrintArray(arrayWork);



int GetNumberFromUser(string message, string errorMessage)
{
    while (true)
    {
        Console.Write(message);
        bool isCorrect = int.TryParse(Console.ReadLine(), out int userNumber);
        if (isCorrect && userNumber > 1 && userNumber < 10)
            return userNumber;
        Console.WriteLine(errorMessage);
    }
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


void ArraySort(int[,] array)
{
    int countСircle = 0;
    int count = 11;
    int arraySize = array.GetLength(0) * array.GetLength(1) + 10;


while (count<arraySize)
{
    int row_L = 0 + countСircle;
    int row_R = array.GetLength(1) - 1 - countСircle;
    int column_T = 0 + countСircle;
    int column_B = array.GetLength(0) - 1 - countСircle;


    for (int i = row_L; i < row_R; i++)  
    {
        array[column_T,i] = count;
        count++;
    }
    for (int j = column_T; j < column_B; j++)
    {
        array[j, row_R] =count;
        count ++;
    }
    for (int i = row_R; i > row_L; i--)
    {
        array[column_B, i] =count;
        count ++;
    }
    for (int j = column_B; j > column_T; j--)
    {
        array[ j, row_L] =count;
        count ++;
    }
    if (count == arraySize)
    {
        array[column_T+1,row_L+1] = count;
    }
    countСircle++;
}
}
