internal class Program
{
    private static void Main(string[] args)
    {
        Task3();
        Task10();
        Task29();
        Task66();
        Task127();
    }
    /// <summary>
    /// 3) Заполнить массив из пятнадцати элементов случайным образом:
    ///     а) вещественными значениями, лежащими в диапазоне от 0 до 1;
    ///     б) вещественными значениями х(22 ≤ х< 23);
    ///     в) вещественными значениями х(0 ≤ х< 10);
    ///     г) вещественными значениями х(–50 ≤ х< 50);
    ///     д) целыми значениями, лежащими в диапазоне от 0 до 10 включительно.
    /// </summary>
    static void Task3()
    {
        Console.WriteLine("3) Заполнить массив из пятнадцати элементов случайным образом:\n\tа) вещественными значениями, лежащими в диапазоне от 0 до 1;\n\tб) вещественными значениями х (22 ≤ х < 23);\n\tв) вещественными значениями х (0 ≤ х < 10);\n\tг) вещественными значениями х (–50 ≤ х < 50);\n\tд) целыми значениями, лежащими в диапазоне от 0 до 10 включительно.");
        
        int length = 15;

        double[] arrayA = GenerateRandomDoubleArray(length, 0, 1);
        double[] arrayB = GenerateRandomDoubleArray(length, 22, 23);
        double[] arrayC = GenerateRandomDoubleArray(length, 0, 10);
        double[] arrayD = GenerateRandomDoubleArray(length, -50, 50);
        int[] arrayE = GenerateRandomIntArray(length, 0, 11);

        WritingArray("а) Массив вещественных чисел от 0 до 1:", arrayA);
        WritingArray("б) Массив вещественных чисел от 22 до 23:", arrayB);
        WritingArray("в) Массив вещественных чисел от 0 до 10:", arrayC);
        WritingArray("г) Массив вещественных чисел от -50 до 50:", arrayD);
        WritingArray("д)Массив целых чисел от 0 до 10:", arrayE);    
    }

    /// <summary>
    /// 10) Дано натуральное число n ≤ 999999.
    /// Заполнить массив его цифрами, расположенными в обратном порядке(первый элемент равен последней цифре, второй — предпоследней и т.д.).
    /// Элементы массива, являющиеся цифрами числа n, вывести на экран.
    /// </summary>
    static void Task10()
    {
        Console.WriteLine("\n\n\n10) Дано натуральное число n ≤ 999999. Заполнить массив его цифрами, расположенными в\r\nобратном порядке (первый элемент равен последней цифре, второй — предпоследней и т. д.).\r\nЭлементы массива, являющиеся цифрами числа n, вывести на экран.");

        int answer, n = 0, min = 1, max = 999999;
        do
        {
            Console.WriteLine("\nВыберете способ введения данных:\n\t0 - автоматически \n\t1 - вручную");
            answer = Convert.ToInt32(Console.ReadLine());
            
        } while (answer != 0 && answer != 1);
        
        if (answer == 1)
        {
            do
            {
                Console.Write($"\nВведите значение (n ≤ {max}): ");
                n = Convert.ToInt32(Console.ReadLine());
            } while (n > max || n < min);
        }

        else{
            Random random = new Random();
            n = random.Next(min, max+1);
        }
        Console.WriteLine("Значение n: " + n);
        int[] array = new int[n.ToString().Length];

        for (int i=0; i<array.Length; i++)
        {
            array[i] = n%10;
            n /= 10;
        }
        WritingArray("Массив: \n", array);
    }

    /// <summary>
    /// 29) Дана последовательность вещественных чисел а1, а2, ..., an. 
    /// Выяснить, является ли она возрастающей.
    /// </summary>
    static void Task29()
    {
        Console.WriteLine("\n\n\n29) Дана последовательность вещественных чисел а1, а2, ..., an. Выяснить, является ли она возрастающей.");
        
        int answer, length = 0;
        bool isIncreasing = true;

        do
        {
            Console.WriteLine("\nВыберете способ введения данных:\n\t0 - автоматически \n\t1 - вручную");
            answer = Convert.ToInt32(Console.ReadLine());
            
        } while (answer != 0 && answer != 1);

        Console.Write("\nВведите значение length: ");
        length = Convert.ToInt32(Console.ReadLine());
        double[] numbers = new double[length];

        if (answer == 1)
        {
            for (int i = 0; i < length; i++)
            {
                Console.Write($"a{i + 1}: ");
                numbers[i] = Convert.ToDouble(Console.ReadLine());
            }

        }
        else
        {
            double min, max;

            do {
                Console.Write("\nВведите минимальное и максимальное значение в формате double, (не забывайте что максимальное значение должно быть больше минимального)\n\tmin: ");
                min = Convert.ToDouble(Console.ReadLine());
                Console.Write("\tmax: ");
                max = Convert.ToDouble(Console.ReadLine());
            } while(min > max);
            numbers = GenerateRandomDoubleArray(length, min, max);
            WritingArray("Массив: ", numbers);

        }
        for (int i = 1; i<length; i++)
        {
            if (numbers[i] < numbers[i - 1])
            {
                isIncreasing = false;
                break;
            }
        }
        if (isIncreasing)
        {
            Console.WriteLine("\nПоследовательность является возрастающей.");
        }
        else
        {
            Console.WriteLine("\nПоследовательность не является возрастающей.");
        }

    }

    /// <summary>
    /// 66) Найти произведение всех элементов массива целых чисел, меньших 0.
    /// </summary>
    static void Task66()
    {
        Console.WriteLine("\n\n\n66) Найти произведение всех элементов массива целых чисел, меньших 0.");

        Random random = new Random();
        int min=-10, max=10, length = random.Next(5,30), sum = 0;
        int[] array = GenerateRandomIntArray(length,min, max);

        WritingArray("Массив: ", array);

        Console.WriteLine("\n\nЧисла которые будут суммироваться:");
        for (int i = 0; i < length; i++)
        {
            if (array[i] < 0)
            {
                Console.Write($"\t({array[i]})");
                sum += array[i];
            }
        }
        Console.WriteLine("\nСумма: " + sum);
    }

    /// <summary>
    /// 127. В последовательности вещественных чисел а1, а2, ..., an есть только положительные и отрицательные элементы.
    /// Вычислить произведение отрицательных элементов P1 и произведение положительных элементов Р2.
    /// Сравнить модуль Р2 с модулем P1, указать, какое из произведений по модулю больше.
    /// </summary>
    static void Task127()
    {
        Console.WriteLine("\n\n\n127) В последовательности вещественных чисел а1, а2, ..., an есть только положительные и отрицательные элементы. Вычислить произведение отрицательных элементов P1 и произведение положительных элементов Р2. Сравнить модуль Р2 с модулем P1, указать, какое из произведений по модулю больше.");

        Random random = new Random();
        double min = -20, max = 20, positiveSum = 0, negativeSum = 0;
        int length = random.Next(5, 30);
        double[] array = GenerateRandomDoubleArray(length, min, max);
        WritingArray("Массив: ", array);

        for (int i = 0; i < array.Length; i++)
        {
            if (array[i] < 0)
            {
                negativeSum += array[i];
            }
            else
            {
                positiveSum += array[i];
            }
        }
        Console.WriteLine($"\n\nСумма положительных P2: {positiveSum}\nСумма отрицательных P1: {negativeSum}\n");

        if( positiveSum > -negativeSum)
        {
            Console.WriteLine("Сумма положительных чисел больше модуля отрицательных\n\t(P2 > P1)");
        }
        else if( positiveSum < -negativeSum)
        {
            Console.WriteLine("Сумма положительных чисел меньше модуля отрицательных\n\t(P2 < P1)");
        }
        else
        {
            Console.WriteLine("Сумма положительных чисел и модуля отрицательных равны\n\t(P2 = P1)");
        }
    }

    /// <summary>
    /// Функция выводит массив из чисел с предварительным текстом
    /// </summary>
    /// <param name="text">Текст</param>
    /// <param name="array">Массив в формате double</param>
    static void WritingArray(string text, double[] array)
    {
        Console.WriteLine("\n\n" + text);
        foreach (double num in array)
        {
            Console.Write("\t" + num);
        }
    }

    /// <summary>
    /// Функция выводит массив из чисел с предварительным текстом
    /// </summary>
    /// <param name="text">Текст</param>
    /// <param name="array">Массив в формате int</param>
    static void WritingArray(string text, int[] array)
    {
        Console.WriteLine("\n\n" + text);
        foreach (int num in array)
        {
            Console.Write("\t" + num);
        }
    }

    /// <summary>
    /// Функция генерирует массив длинной length из чисел формата double
    /// </summary>
    /// <param name="length">Длина в формате int</param>
    /// <param name="minValue">Минимальное значение в формате double</param>
    /// <param name="maxValue">Максимальное значение в формате double</param>
    /// <returns>Массив в формате double</returns>
    static double[] GenerateRandomDoubleArray(int length, double minValue, double maxValue)
    {
        Random random = new Random();

        double[] array = new double[length];

        for (int i = 0; i < length; i++)
        {
            array[i] = random.NextDouble() * (maxValue - minValue) + minValue;
        }
        return array;
    }

    /// <summary>
    /// Функция генерирует массив длинной length из чисел формата int
    /// </summary>
    /// <param name="length">Длина в формате int</param>
    /// <param name="minValue">Минимальное значение в формате int</param>
    /// <param name="maxValue">Максимальное значение в формате int</param>
    /// <returns>Массив в формате int</returns>
    static int[] GenerateRandomIntArray(int length, int minValue, int maxValue)
    {
        Random random = new Random();

        int[] array = new int[length];
        for (int i = 0; i < length; i++)
        {
            array[i] = random.Next((int)minValue, (int)maxValue);
        }
        return array;
    }
}