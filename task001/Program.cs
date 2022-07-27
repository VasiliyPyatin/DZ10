// Задача 59: Из двумерного массива целых чисел удалить строку и столбец, на пересечении которых расположен наименьший элемент.

using System;
using static System.Console;

Clear();

Write("Введите размер матрицы через пробел: ");

string[] sizeS = ReadLine().Split(' ',StringSplitOptions.RemoveEmptyEntries);
int rows = int.Parse(sizeS[0]);
int columns = int.Parse(sizeS[1]);
int[,] ar = GetRandomArray(rows, columns);
PrintArray(ar);

int[,] positionSmallElement = new int[1, 2];
positionSmallElement = FindPositionSmallElement(ar, positionSmallElement);
Write($"Позиция элемента: \n");
PrintArray(positionSmallElement);

int[,] arrayWithoutLines = new int[ar.GetLength(0) - 1, ar.GetLength(1) - 1];
DeleteLines(ar, positionSmallElement, arrayWithoutLines);
WriteLine($"\nПолучившийся массив:");
PrintArray(arrayWithoutLines);

int[,] GetRandomArray(int row, int column)
{
    int [,] result = new int [row, column];
    for (int i = 0; i<result.GetLength(0); i++) 
    {
        for(int j = 0; j<result.GetLength(1); j++)
        {
            result [i,j] = new Random().Next(0,10);
        }
    }
    
    return result;
}

void PrintArray(int [,] array)
{
    for (int i = 0; i<array.GetLength(0); i++) 
    {
        for(int j = 0; j<array.GetLength(1); j++)
        {
            Write($"{array [i,j]} ");
        }
        WriteLine();
    }
}

int[,] FindPositionSmallElement(int[,] arrayi, int[,] position)
{
  int temp = arrayi[0, 0];
  for (int i = 0; i < arrayi.GetLength(0); i++)
  {
    for (int j = 0; j < arrayi.GetLength(1); j++)
    {
      if (arrayi[i, j] <= temp)
      {
        position[0, 0] = i;
        position[0, 1] = j;
        temp = arrayi[i, j];
      }
    }
  }
  WriteLine($"\nMинимальный элемент: {temp}");
  return position;
}

void DeleteLines(int[,] ray, int[,] positionSmallElement, int[,] arrayWithoutLines)
{
  int k = 0, l = 0;
  for (int i = 0; i < ray.GetLength(0); i++)
  {
    for (int j = 0; j < ray.GetLength(1); j++)
    {
      if (positionSmallElement[0, 0] != i && positionSmallElement[0, 1] != j)
      {
        arrayWithoutLines[k, l] = ray[i, j];
        l++;
      }
    }
    l = 0;
    if (positionSmallElement[0, 0] != i)
    {
      k++;
    }
  }
}