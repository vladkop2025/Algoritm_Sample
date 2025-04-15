using System;

class OptimizedBubbleSortExample
{
    // Метод пузырьковой сортировки
    //Добавление флага swapped позволяет завершить сортировку досрочно, если на очередной итерации не было ни одного обмена (значит, массив уже упорядочен).

    public static void BubbleSort(int[] array)
    {
        int n = array.Length;
        bool swapped;

        for (int i = 0; i < n - 1; i++)
        {
            swapped = false;

            for (int j = 0; j < n - i - 1; j++)
            {
                if (array[j] > array[j + 1])
                {
                    // Меняем элементы местами
                    int temp = array[j];
                    array[j] = array[j + 1];
                    array[j + 1] = temp;
                    swapped = true;
                }
            }

            // Если на этой итерации не было обменов, массив уже отсортирован
            if (!swapped)
                break;
        }
    }

    static void Main()
    {
        int[] array = { 64, 34, 25, 12, 22, 11, 90 };

        Console.WriteLine("Несортированный массив:");
        Console.WriteLine(string.Join(", ", array));

        BubbleSort(array);

        Console.WriteLine("\nОтсортированный массив:");
        Console.WriteLine(string.Join(", ", array));
    }
}