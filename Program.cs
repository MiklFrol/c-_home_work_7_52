// Задайте двумерный массив из целых чисел. Найдите среднее арифметическое элементов 
// в каждом столбце.
// Например, задан массив:
// 1 4 7 2
// 5 9 2 3
// 8 4 2 4
// Среднее арифметическое каждого столбца: 4,6; 5,6; 3,6; 3.

Console.Clear();

int getDataFromUser(string message)
{
    Console.ForegroundColor = ConsoleColor.DarkBlue;
    Console.WriteLine(message);
    Console.ResetColor();
    int array = int.Parse(Console.ReadLine()!);
    return array;
}

int[,] get2DArray(int colLenght, int rowLenght, int start, int finish)
{
    int[,] array = new int[colLenght, rowLenght];
    for (int i = 0; i < colLenght; i++)
    {
        for (int j = 0; j < rowLenght; j++)
        {
            array[i,j] = new Random().Next(start, finish + 1);
        }
    }
    return array;
}

void printInColor(string data)
{
    Console.ForegroundColor = ConsoleColor.Magenta;
    Console.Write(data);
    Console.ResetColor();
}

void print2DArray(int[,] array)
{
     Console.Write(" \t");
    for (int j=0; j<array.GetLength(1); j++)
    {
         printInColor(j + "\t");
    }
    Console.WriteLine();

    for (int i=0; i<array.GetLength(0); i++)
    {
        printInColor( i + "\t");
        for (int j=0; j<array.GetLength(1); j++)
        {       
            Console.Write(array[i,j] + "\t"); 
        }
        Console.WriteLine();
    }
}

double[] getAverageArifm(int[,] array)
{
    double[] result = new double[array.GetLength(1)];
    double[] temp = new double[array.GetLength(1)];
    for (int j = 0; j < array.GetLength(1); j++)
    {
        temp[j] = array[0, j];
        for (int i = 1; i < array.GetLength(0); i++)
        {
            temp[j] = temp[j] + array[i, j];

            if (i == (array.GetLength(0) - 1))
            {
                result[j] = temp[j] / (array.GetLength(0));
            }
        }
    }
    return result;
}

void printArray(double[] result)
{
    for (int i = 0; i < result.Length; i++)
    {
        Console.Write(result[i]);
        if (i < result.Length - 1)
        {
            Console.Write("; ");
        }
    }
    Console.WriteLine(".");
}

int n = getDataFromUser("Введите количество строк:");
int m = getDataFromUser("Введите количество столбцов:");
int[,] array = get2DArray(n, m, 0, 10);
print2DArray(array);
double[] result = getAverageArifm(array);
Console.ForegroundColor = ConsoleColor.DarkGreen;
Console.Write("Среднее арифмитическое = ");
Console.ResetColor();
printArray(result);