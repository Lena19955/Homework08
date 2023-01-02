Main();

void Main()
{
	bool isWorking = true;
	while (isWorking)
	{
		Console.Write("Input command: ");
		switch (Console.ReadLine())
		{
			case "Task54": Task54(); break;
			case "Task56": Task56(); break;
      case "Task58": Task58(); break;
      case "Task60": Task60(); break;
      case "Task62": Task62(); break;
			case "exit": isWorking = false; break;
		}
		Console.WriteLine();
	}
}

// Задача 54: Задайте двумерный массив. Напишите программу, которая упорядочит по убыванию элементы каждой строки двумерного массива.
void Task54()
{
    int firstLength = ReadInt("firstLength");
    int secondLength = ReadInt("secondLength");
    int [,] array = GetArray(firstLength, secondLength);
    PrintArray(array);
    MinDescending(array);
    Console.WriteLine();
    PrintArray(array);

}
Task54();

int ReadInt(string argument)
{
	Console.Write($"Input {argument}: ");
	return int.Parse(Console.ReadLine());
}

int [,] GetArray (int length, int secondLength)
{
    int [,] array = new int[length, secondLength]; 
    Random random = new Random();
    for (int i = 0; i < length; i++)
    {
        for (int j = 0; j < secondLength; j++)
        {
            array[i, j] = random.Next(10);
        }
    }
    return array;
}

void PrintArray (int [,] array)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            Console.Write($"{array[i, j]}  ");
        }
        Console.WriteLine();
    }
}

void MinDescending(int [,] array)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {   
        for (int j = 0; j < array.GetLength(1); j++)
        {
            for (int k = 0; k < array.GetLength(1) - 1; k++){ //??
           if (array[i,k] < array[i, k + 1]) 
           {
                int temp = array[i, k + 1];
                array[i, k + 1] = array[i, k];
                array[i, k] = temp;
           }
        }
    }   
}}
//Задача 56: Задайте прямоугольный двумерный массив. Напишите программу, которая будет находить строку с наименьшей суммой элементов.
void Task56()
{
    int firstLength = ReadInt("firstLength");
    int secondLength = ReadInt("secondLength");
    int [,] array = GetArray(firstLength, secondLength);
    PrintArray(array);
    Console.WriteLine();
    SumMinElement(array);

}
Task56();
void SumMinElement(int [,] array){
int minString = 0;
int sumString = SumElement(array, 0);
for (int i = 1; i < array.GetLength(0); i++)
{
  int tempSumString = SumElement(array, i);
  if (sumString > tempSumString)
  {
    sumString = tempSumString;
   minString = i;
  }
}

Console.WriteLine($"строка {minString+1} с наименьшей суммой элементов равной {sumString} ");
}

int SumElement(int [,] array, int i)
{   
    int sumString = array[i,0];
    for (int j = 1; j < array.GetLength(1); j++)
    {
        sumString = sumString + array[i,j];
    }
    return sumString;
}
//Задача 58: Задайте две матрицы. Напишите программу, которая будет находить произведение двух матриц.
void Task58()
{
    int firstLength = ReadInt("firstLength");
    int secondLength = ReadInt("secondLength");
    int [,] firstArray = GetArray(firstLength, secondLength);
    int firstTwoLength = ReadInt("firstTwoLength");
    int secondTwoLength = ReadInt("secondTwoLength");
    int [,] secondArray = GetArray(firstLength, secondLength);
    PrintArray(firstArray);
    Console.WriteLine();
    PrintArray(secondArray);
    int [,] result = ProductMatrix (firstArray, secondArray);
    Console.WriteLine("Произведение матриц:");
    PrintArray(result);
}
Task58();

int [,] ProductMatrix (int [,] firstArray, int [,] secondArray)
{   int [,] ProdArray = new int [firstArray.GetLength(0), secondArray.GetLength(1)];
    if (firstArray.GetLength(1) != secondArray.GetLength(0))
     {
        Console.WriteLine("Умножение невозможно");
     }
   for (int i = 0; i < firstArray.GetLength(0); i++)
    {
        for (int j = 0; j < secondArray.GetLength(1); j++)
       { int sum = 0;
         
         for (int k = 0; k < firstArray.GetLength(1); k++)
            
            {
                sum = sum + firstArray[i, k] * secondArray[k,j]; 
            
            }
         ProdArray[i,j] = sum;
       }
    }
    return ProdArray;
}
//Задача 60. ...Сформируйте трёхмерный массив из неповторяющихся двузначных чисел. 
//Напишите программу, которая будет построчно выводить массив, добавляя индексы каждого элемента.

void Task60()
{
    int [,,] array = GetNewArray(ReadInt("firstLength"), ReadInt("secondLength"), ReadInt("thirdLength"));
    PrintNewArray(array);
}
Task60();

int [,,] GetNewArray (int firstLength, int secondLength, int thirdLength)
{
    int [,,] array = new int[firstLength, secondLength, thirdLength]; 
    Random random = new Random();
    for (int i = 0; i < firstLength; i++)
    {
        for (int j = 0; j < secondLength; j++)
        {
              for (int k = 0; k < thirdLength; k++)
              { 
                  int value = random.Next(100000);
                  if (!HasValueINThreeDimensionArray(array, value))
                  array[i, j, k] = value;
                  else
                    {
                      k--;
                    }
              }
        }
    }
    return array;
}

void PrintNewArray (int [,,] array)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            for (int k = 0; k < array.GetLength(2); k++)
          {
              Console.WriteLine($"{i}-{j}-{k}: {array[i, j, k]}");
    
          }
        }
        Console.WriteLine();
    }
}
bool HasValueINThreeDimensionArray(int [,,] array, int value)
{
  foreach (int item in array)
  {
    if (item == value)
      {
        return true;
      }
  }
  return false;
}
//Задача 62. Напишите программу, которая заполнит спирально массив 4 на 4.
void Task62(){
Console.WriteLine($"Заполнить спирально массив 4 на 4.");
int n = 4;
int[,] Matrix = new int[n, n];
int temp = 1;
int i = 0;
int j = 0;

while (temp <= Matrix.GetLength(0) * Matrix.GetLength(1))
{
  
  Matrix[i, j] = temp;
  temp++;
  if (i <= j + 1 && i + j < Matrix.GetLength(1) - 1)
    j++;
  else if (i < j && i + j >= Matrix.GetLength(0) - 1)
    i++;
  else if (i >= j && i + j > Matrix.GetLength(1) - 1)
    j--;
  else
    i--;
}

WriteArray(Matrix);
}
Task62();

void WriteArray (int[,] array)
{
  for (int i = 0; i < array.GetLength(0); i++)
  {
    for (int j = 0; j < array.GetLength(1); j++)
    {
      Console.Write($"{array[i,j]}  ");

    }
    Console.WriteLine();
  }
}