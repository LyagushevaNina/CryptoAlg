using System.Numerics;
internal static class Program
{
    private static void Main()
    {
        // Тест возведение целого числа в степень в кольце вычетов
        Console.WriteLine(ModularExp(12, 5, 1000)); // 832
        Console.WriteLine(ModularExp(34, 11, 500)); // 384
        Console.WriteLine(ModularExp(56, 3, 97));   // 46

        Console.WriteLine();

        // Тест алгоритм Евклида
        Console.WriteLine(NOD(144, 60)); // 12
        Console.WriteLine(NOD(240, 180)); // 60
        Console.WriteLine(NOD(150, 35)); // 5

        Console.WriteLine();

        // Тест расширенный алгоритм Евклида
        Console.WriteLine(ReverseEvk(5, 14)); // 3
        Console.WriteLine(ReverseEvk(8, 19)); // 12
        Console.WriteLine(ReverseEvk(3, 11)); // 4

        Console.WriteLine();

        // Тест Рабина-Миллера
        Console.WriteLine(RabinMillerTest(61, 5)); // true - простое
        Console.WriteLine(RabinMillerTest(73, 5)); // true - простое
        Console.WriteLine(RabinMillerTest(91, 5)); // false - составное

    }

    // Возведение целого числа в степень в кольце вычетов
    private static BigInteger ModularExp(BigInteger a, BigInteger e, BigInteger m)
    {
        BigInteger result = 1;
        a %= m;
        while (e > 0)
        {
            if (e % 2 == 1)
            {
                result = result * a % m;
            }

            e >>= 1;
            a = a * a % m;
        }

        return result;
    }

    // Алгоритм Евклида
    static BigInteger NOD(BigInteger a, BigInteger b)
    {
        while (b != 0)
        {
            BigInteger temp = b;
            b = a % b;
            a = temp;
        }

        return a;
    }

    // Расширенный алгоритм Евклида
    private static BigInteger ReverseEvk(BigInteger a, BigInteger m)
    {
        BigInteger m0 = m, t, q;
        BigInteger x0 = 0, x1 = 1;

        if (m == 1)
        {
            return 0;
        }

        while (a > 1)
        {
            q = a / m;
            t = m;

            m = a % m;
            a = t;

            t = x0;

            x0 = x1 - (q * x0);
            x1 = t;
        }

        if (x1 < 0)
        {
            x1 += m0;
        }

        return x1;
    }

    // Тест Рабина-Миллера
    private static bool RabinMillerTest(BigInteger n, int k)
    {
        if (n <= 1)
        {
            return false;
        }

        if (n == 2)
        {
            return true;
        }

        if (n % 2 == 0)
        {
            return false;
        }

        BigInteger s = 0, t = n - 1;
        while (t % 2 == 0)
        {
            t /= 2;
            s++;
        }

        Random rand = new();

        for (int i = 0; i < k; i++)
        {
            BigInteger a = rand.Next(2, (int)n - 1);
            BigInteger x = ModularExp(a, t, n);

            if (x == 1 || x == n - 1)
            {
                continue;
            }

            for (BigInteger j = 0; j < s - 1; j++)
            {
                x = x * x % n;
                if (x == 1)
                {
                    return false;
                }

                if (x == n - 1)
                {
                    break;
                }
            }

            if (x != n - 1)
            {
                return false;
            }
        }

        return true;
    }
}
