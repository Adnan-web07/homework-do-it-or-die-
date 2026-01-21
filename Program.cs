using System;
using System.Collections.Generic;
using System.Diagnostics;

Stopwatch sw = new Stopwatch();
Console.WriteLine("Choose a sorting algorithm (1 for Bubble Sort, 2 for Selection Sort, 3 for Insertion Sort, 4 for Merge Sort, 5 for Quick Sort): ");

int choice;
try
{
    choice = int.Parse(Console.ReadLine());
}
catch (FormatException)
{
    Console.WriteLine("Invalid input. Please enter a number.");
    return;
}

int number = 10;
Random random = new Random();

List<int> numbers = new List<int>();
for (int i = 0; i < number; i++)
{
    numbers.Add(random.Next(1, 100)); 
}

void BubbleSort()
{
    for (int i = 0; i < numbers.Count - 1; i++)
    {
        for (int j = 0; j < numbers.Count - 1 - i; j++)
        {
            if (numbers[j] > numbers[j + 1])
            {
                int temp = numbers[j];
                numbers[j] = numbers[j + 1];
                numbers[j + 1] = temp;
            }
        }
    }
}

void SelectionSort()
{
    for (int i = 0; i < numbers.Count; i++)
    {
        int smallestIndex = i;
        for (int j = i + 1; j < numbers.Count; j++)
        {
            if (numbers[j] < numbers[smallestIndex])
            {
                smallestIndex = j;
            }
        }
        int temp = numbers[smallestIndex];
        numbers[smallestIndex] = numbers[i];
        numbers[i] = temp;
    }
}

void InsertionSort()
{
    for (int i = 1; i < numbers.Count; i++)
    {
        int key = numbers[i];
        int j = i - 1;
        while (j >= 0 && numbers[j] > key)
        {
            numbers[j + 1] = numbers[j];
            j--;
        }
        numbers[j + 1] = key;
    }
}

void MergeSort(List<int> list)
{
    if (list.Count <= 1) return;

    int mid = list.Count / 2;
    List<int> left = list.GetRange(0, mid);
    List<int> right = list.GetRange(mid, list.Count - mid);

    MergeSort(left);
    MergeSort(right);
    Merge(list, left, right);
}

void Merge(List<int> list, List<int> left, List<int> right)
{
    int i = 0, j = 0, k = 0;
    while (i < left.Count && j < right.Count)
    {
        if (left[i] <= right[j])
        {
            list[k++] = left[i++];
        }
        else
        {
            list[k++] = right[j++];
        }
    }
    while (i < left.Count) list[k++] = left[i++];
    while (j < right.Count) list[k++] = right[j++];
}
List<int> QuickSort(List<int> list)
{
    QuickSortRecursive(list, 0, list.Count - 1);
    return list;
}

void QuickSortRecursive(List<int> list, int low, int high)
{
    if (low < high)
    {
        int pivotIndex = Partition(list, low, high);
        QuickSortRecursive(list, low, pivotIndex - 1);
        QuickSortRecursive(list, pivotIndex + 1, high);
    }
}

int Partition(List<int> list, int low, int high)
{
    int pivot = list[high];
    int i = (low - 1);

    for (int j = low; j < high; j++)
    {
        if (list[j] <= pivot)
        {
            i++;
           
            int temp = list[i];
            list[i] = list[j];
            list[j] = temp;
        }
    }
    
   
    int tempPivot = list[i + 1];
    list[i + 1] = list[high];
    list[high] = tempPivot;
    
    return i + 1;
}


void PrintList()
{
    foreach (int num in numbers)
    {
        Console.WriteLine(num);
    }
    TimeSpan elapsed = sw.Elapsed;
    Console.WriteLine($"Sorting took {elapsed.TotalMilliseconds} milliseconds.");
}

if (choice == 1)
{
    sw.Start();
    BubbleSort();
    sw.Stop();
    PrintList();
}
else if (choice == 2)
{
    sw.Start();
    SelectionSort();
    sw.Stop();
    PrintList();
}
else if (choice == 3)
{
    sw.Start();
    InsertionSort();
    sw.Stop();
    PrintList();
}
else if (choice == 4)
{
    sw.Start();
    MergeSort(numbers);
    sw.Stop();
    PrintList();
}
else if (choice == 5)
{
    sw.Start();
    numbers = QuickSort(numbers);
    sw.Stop();
    PrintList();
}
else
{
    Console.WriteLine("Invalid choice.");
}