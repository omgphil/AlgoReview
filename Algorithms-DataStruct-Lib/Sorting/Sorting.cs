using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview_Review.Algorithms.Sorting
{
    public class Sorting
    {
        public static void BubbleSort(int[] array)
        {
            for (int partIndex = array.Length - 1; partIndex > 0; partIndex--)
            {
                for (int i = 0; i < partIndex; i++)
                {
                    if (array[i] > array[i + 1])
                    {
                        Swap(array, i, i + 1);
                    }
                }
            }
        }

        public static void SelectionSort(int[] array)
        {
            for (int partIndex = array.Length - 1; partIndex > 0; partIndex--)
            {
                // Index of largest number
                int largestAt = 0;

                for (int i = 1; i <= partIndex; i++)
                {
                    if (array[i] > array[largestAt])
                    {
                        largestAt = i;
                    }
                }
                Swap(array, largestAt, partIndex);
            }
        }

        public static void InsertionSort(int[] array)
        {
            for (int partIndex = 1; partIndex < array.Length; partIndex++)
            {
                int currUnsorted = array[partIndex];
                int i = 0;
                for (i = partIndex; i > 0 && array[i - 1] > currUnsorted; i--)
                {
                    array[i] = array[i - 1];
                }
                array[i] = currUnsorted;
            }
        }

        public static void ShellSort(int[] array)
        {
            // calc Gap
            int gap = 1;
            while (gap < array.Length / 3)
            {
                gap = 3 * gap + 1;
            }

            while (gap >= 1)
            {
                for (int i = gap; i < array.Length; i++)
                {
                    for (int j = i; j >= gap && array[j] < array[j - gap]; j -= gap)
                    {
                        Swap(array, j, j - gap);
                    }
                }
                gap /= 3;
            }
        }

        public static void MergeSort(int[] array)
        {
            // Need to create and aux array
            int[] aux = new int[array.Length];
            Sort(0, array.Length - 1);

            // C# Allows you to create local functions inside other functions
            void Sort(int low, int high)
            {
                if(high <= low) { return; }
                
                int mid = (high + low) / 2;

                Sort(low, mid);
                Sort(mid + 1, high);
                Merge(low, mid, high);
            }           
            
            void Merge(int low, int mid, int high)
            {
                if(array[mid] <= array[mid + 1])
                {
                    return;
                }
                int i = low; // Points to first element of left Array
                int j = mid + 1; // Point to first element of right Array

                Array.Copy(array, low, aux, low, high - low + 1);

                // Dont forget the incrementation is done after assignation.
                for(int k = low; k <=high; k++)
                {
                    if(i > mid)
                    {
                        array[k] = aux[j++];
                    }else if (j > high)
                    {
                        array[k] = aux[i++];
                    } else if(aux[j] < aux[i])
                    {
                        array[k] = aux[j++];
                    }
                    else
                    {
                        array[k] = aux[i++];
                    }
                }
            }
        }

        public static void QuickSort(int[] array)
        {
            Sort(0, array.Length - 1);

            void Sort(int low, int high)
            {
                if(high <= low)
                {
                    return;
                }

                int j = Partition(low, high);

                Sort(low, j - 1);
                Sort(j + 1, high);
            }

            int Partition(int low, int high)
            {
                int i = low;
                int j = high + 1;

                int pivot = array[low];

                while (true)
                {
                    while(array[++i] < pivot)
                    {
                        if (i == high)
                        {
                            break;
                        }
                    }

                    while ( pivot < array[--j])
                    {
                        if (j == low)
                        {
                            break;
                        }
                    }

                    if(i >= j)
                    {
                        break;
                    }

                    Swap(array, i, j);
                }

                Swap(array, low, j);
                return j;
            }
        }

        private static void Swap(int[] array, int i, int j)
        {
            if (i == j)
            {
                return;
            }
            int temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }
    }
}
