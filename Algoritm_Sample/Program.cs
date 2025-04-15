using System;

class BinarySearchRecursiveExample
{
    // Рекурсивный метод бинарного поиска  - Сложность O(log n) 
    public static int BinarySearch(int[] array, int target, int left, int right)
    {
        if (left > right)
            return -1; // Базовый случай: элемент не найден

        int mid = left + (right - left) / 2;

        if (array[mid] == target)
            return mid; // Элемент найден
        else if (array[mid] < target)
            return BinarySearch(array, target, mid + 1, right); // Ищем справа
        else
            return BinarySearch(array, target, left, mid - 1); // Ищем слева
    }

    static void Main()
    {
        int[] sortedArray = { 1, 3, 5, 7, 9, 11, 13, 15 };
        int target = 13;

        int result = BinarySearch(sortedArray, target, 0, sortedArray.Length - 1);

        if (result != -1)
            Console.WriteLine($"Элемент {target} найден на позиции {result}.");
        else
            Console.WriteLine($"Элемент {target} не найден в массиве.");
    }
}