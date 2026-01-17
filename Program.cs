using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.Intrinsics.Arm;
Stopwatch SW = new Stopwatch();
Console.WriteLine("Choose a sorting algorithm (1 for Bubble Sort, 2 for Selection Sort, 3 for Insertion Sort, 4 for Merg sort, 5 for Quick sort) : ");
int choice = int.Parse(Console.ReadLine());


int number = 10;
Random random = new Random();

List<int> kevin = new List<int>();
for (int i = 0; i < number; i++)
{
    
    kevin.Add(random.Next(1, 100000000));
   
}

void Bubblesort()
{
for(int i = 0; i < kevin.Count -1; i++)
{
    for(int j = 0; j < kevin.Count -1 - i; j++)
    {
        if(kevin[j] > kevin[j + 1])
        {
            int temp = kevin[j];
            kevin[j] = kevin[j + 1];
            kevin[j + 1] = temp;
        }
    }
}

}

void SelectionSort() {

    for (int i = 0; i < kevin.Count; i++) {

        int smallestIndex = i;
        for (int j = i + 1; j < kevin.Count; j++) {
            if (kevin[j] < kevin[smallestIndex]) {
                smallestIndex = j;
            }
        }

        int tmp = kevin[smallestIndex];
        kevin[smallestIndex] = kevin[i];
        kevin[i] = tmp;
    }
}

void InsertionSort()
{
     for (int i = 0; i < kevin.Count - 1; i++)
         {
             for (int j = i + 1; j > 0; j--)

            {if (kevin[j - 1] > kevin[j])
                {                        int temp = kevin[j - 1];
                    kevin[j - 1] = kevin[j];
                    
                    kevin[j] = temp;
            }
        }
    }
}

void Mergsort()
{
    for(int i = 0; i < kevin.Count -1; i++)
    {
        for(int j = 0; j < kevin.Count -1 - i; j++)
        {
            if(kevin[j] > kevin[j + 1])
            {
                int temp = kevin[j];
                kevin[j] = kevin[j + 1];
                kevin[j + 1] = temp;
            }
        }
    }
}

void Quicksort()
{
    { List<int> QuickSort(List<int> list)
        {
            if (list.Count <= 1)
            {
                return list;
            }

            int pivot = list[list.Count / 2];
            List<int> left = new List<int>();
            List<int> right = new List<int>();
            List<int> equal = new List<int>();

            foreach (int item in list)
            {
                if (item < pivot)
                {
                    left.Add(item);
                }
                else if (item > pivot)
                {
                    right.Add(item);
                }
                else
                {
                    equal.Add(item);
                }
            }

            List<int> sortedLeft = QuickSort(left);
            List<int> sortedRight = QuickSort(right);

            List<int> result = new List<int>();
            result.AddRange(sortedLeft);
            result.AddRange(equal);
            result.AddRange(sortedRight);

            return result;
        }
    }
}

void Kevinlist()
{
    for(int i  = 0; i < kevin.Count; i++ ) 
    {
        Console.WriteLine(kevin[i]); 
    }
        TimeSpan elapsed = SW.Elapsed;
        Console.WriteLine($"sorting  {elapsed} and the median is {elapsed.TotalMilliseconds / 2} milliseconds");
        
}
if (choice == 1)
{
    SW.Start();
    Bubblesort();
    Kevinlist();
    SW.Stop();
}
else if (choice == 2)
{
    SW.Start();
    SelectionSort();
    Kevinlist();
    SW.Stop();
}
else  if(choice == 3)
{
    SW.Start();
    InsertionSort();
    Kevinlist();
    SW.Stop();
}
else if (choice == 4)
{
    SW.Start();
    Mergsort();
    Kevinlist();
    SW.Stop();
}
else if (choice == 5)
{
    SW.Start();
    Quicksort();
    Kevinlist();
    SW.Stop();
}
else
{
    Console.WriteLine("Invalid choice.");
}
Bubblesort();
SelectionSort();
