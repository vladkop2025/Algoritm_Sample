using System;

class BinarySearchExample
{
    // Метод бинарного поиска - итеративная версия Сложность O(log n)
    //Итеративный vs рекурсивный – итеративный вариант обычно предпочтительнее из-за отсутствия накладных расходов на вызовы функций.
    public static int BinarySearch(int[] array, int target)
    {
        int left = 0;
        int right = array.Length - 1;

        while (left <= right)
        {
            int mid = left + (right - left) / 2; // Предотвращает переполнение

            if (array[mid] == target)
                return mid; // Элемент найден
            else if (array[mid] < target)
                left = mid + 1; // Ищем в правой половине
            else
                right = mid - 1; // Ищем в левой половине
        }

        return -1; // Элемент не найден
    }

    static void Main()
    {
        int[] sortedArray = { 1, 3, 5, 7, 9, 11, 13, 15 };
        int target = 13;

        int result = BinarySearch(sortedArray, target);

        if (result != -1)
            Console.WriteLine($"Элемент {target} найден на позиции {result}.");
        else
            Console.WriteLine($"Элемент {target} не найден в массиве.");
    }
}