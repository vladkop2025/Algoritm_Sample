using System;

//рандомизированная версия QuickSort
//опорный элемент(pivot) выбирается случайным образом, чтобы избежать худшего случая (O(n²)) на уже отсортированных или частично отсортированных массивах:
class RandomizedQuickSortExample
{
    public static void QuickSort(int[] array)
    {
        QuickSort(array, 0, array.Length - 1);
    }

    private static void QuickSort(int[] array, int left, int right)
    {
        if (left < right)
        {
            // Рандомизированное разделение
            int pivotIndex = RandomizedPartition(array, left, right);

            // Рекурсивная сортировка левой и правой части
            QuickSort(array, left, pivotIndex - 1);
            QuickSort(array, pivotIndex + 1, right);
        }
    }

    // Рандомизированный выбор опорного элемента
    private static int RandomizedPartition(int[] array, int left, int right)
    {
        Random rand = new Random();
        int randomIndex = rand.Next(left, right); // Случайный индекс между left и right
        Swap(ref array[randomIndex], ref array[right]); // Помещаем случайный элемент в конец
        return Partition(array, left, right); // Стандартное разделение
    }

    // Обычное разделение (как в классическом QuickSort)
    private static int Partition(int[] array, int left, int right)
    {
        int pivot = array[right]; // Опорный элемент (после рандомизации это случайный элемент)
        int i = left - 1;

        for (int j = left; j < right; j++)
        {
            if (array[j] <= pivot)
            {
                i++;
                Swap(ref array[i], ref array[j]);
            }
        }

        Swap(ref array[i + 1], ref array[right]);
        return i + 1;
    }

    private static void Swap(ref int a, ref int b)
    {
        int temp = a;
        a = b;
        b = temp;
    }

    static void Main()
    {
        int[] array = { 10, 7, 8, 9, 1, 5, 3, 6, 4, 2 };

        Console.WriteLine("Несортированный массив:");
        Console.WriteLine(string.Join(", ", array));

        QuickSort(array);

        Console.WriteLine("\nОтсортированный массив:");
        Console.WriteLine(string.Join(", ", array));
    }
}

/* 
    Рандомизация выбора pivot:

Случайный элемент выбирается в диапазоне [left, right] и перемещается в конец (array[right]), после чего применяется стандартное разделение.

Это предотвращает худший случай O(n²) на уже отсортированных данных.

    Преимущества:

Средняя сложность: O(n log n).

Худший случай становится крайне маловероятным (но теоретически возможным).

    Когда использовать:

Для больших массивов, где важна средняя производительность.

Если входные данные могут быть частично отсортированы.

    Дополнительные оптимизации (по желанию):

При небольшом размере подмассива (например, < 10 элементов) можно переключиться на сортировку вставками.
*/

