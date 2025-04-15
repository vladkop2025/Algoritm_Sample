using System;

class QuickSortExample
{
    // Основной метод для вызова сортировки - Быстрая сортировка (рекурсивная реализация)
    public static void QuickSort(int[] array)
    {
        QuickSort(array, 0, array.Length - 1);
    }

    // Рекурсивный метод быстрой сортировки
    private static void QuickSort(int[] array, int left, int right)
    {
        if (left < right)
        {
            // Получаем индекс опорного элемента после разделения
            int pivotIndex = Partition(array, left, right);

            // Рекурсивно сортируем элементы до и после опорного
            QuickSort(array, left, pivotIndex - 1);
            QuickSort(array, pivotIndex + 1, right);
        }
    }

    // Метод для разделения массива
    private static int Partition(int[] array, int left, int right)
    {
        int pivot = array[right]; // Опорный элемент (можно выбирать по-разному)
        int i = left - 1; // Индекс меньшего элемента

        for (int j = left; j < right; j++)
        {
            // Если текущий элемент меньше или равен опорному
            if (array[j] <= pivot)
            {
                i++;
                // Меняем элементы местами
                Swap(ref array[i], ref array[j]);
            }
        }

        // Помещаем опорный элемент на правильную позицию
        Swap(ref array[i + 1], ref array[right]);
        return i + 1;
    }

    // Вспомогательный метод для обмена элементов
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

//Ключевые моменты:

    //Принцип работы:

//Алгоритм выбирает опорный элемент (pivot) и разделяет массив на две части: элементы меньше опорного и элементы больше опорного.

//Затем рекурсивно сортирует обе части.

    //Выбор опорного элемента:

//В данном примере pivot выбирается как последний элемент (array[right]), но можно использовать:

//Первый элемент(array[left])

//Средний элемент(array[(left + right) / 2])

//Случайный элемент(для защиты от худшего случая)

    //Сложность:

//Средний случай: O(n log n) — оптимальная производительность.

//Худший случай: O(n²) — если массив уже отсортирован, а pivot выбран неудачно (например, всегда минимальный или максимальный элемент).

    //Оптимизации:

//Для небольших подмассивов (например, меньше 10 элементов) можно переключаться на сортировку вставками.

//Рандомизированный выбор pivot для избежания худшего случая.

    //Преимущества:

//Один из самых быстрых алгоритмов сортировки на практике.

//Работает "на месте" (не требует дополнительной памяти, кроме стековых вызовов).