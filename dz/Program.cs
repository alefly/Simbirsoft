using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dz
{
    class Program
    {
        private static int[,] mas;
        private static int n;
        private static int indexI, indexJ, value;

        static void Main(string[] args)
        {
            inputStartInfo();
            mas = new int[n, n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    mas[i, j] = -1;
                }
            }
            while (true)
            {
                inputInfoAboutElement();
                mas[indexI - 1, indexJ - 1] = value;
                if (checkMas())
                {
                    break;
                }
                printMas();
            }
            Console.ReadKey();
        }

        private static void inputStartInfo()
        {
            while (true)
            {
                try
                {
                    Console.WriteLine("Введите число - размер квадратной матрицы.");
                    String s = Console.ReadLine();
                    n = Convert.ToInt32(s);
                    break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message + "Попробуйте снова.");
                }
            }
        }

        private static void inputInfoAboutElement()
        {
            while (true)
            {
                try
                {
                    Console.WriteLine("Для замены элемента массива введите индексы по вертикали и по горизонтали через пробел (нумерация с единицы)");
                    String s = Console.ReadLine();
                    indexI = Convert.ToInt32(s.Split(' ')[0]);
                    indexJ = Convert.ToInt32(s.Split(' ')[1]);
                    if (indexI > n || indexI < 1 || indexJ > n || indexJ < 1)
                    {
                        Console.WriteLine("Индексы выходят за границы массива. Попробуйте снова.");
                    }
                    else
                    {
                        Console.WriteLine("Введите значение (0 или 1)");
                        s = Console.ReadLine();
                        value = Convert.ToInt32(s);
                        if (value != 0 && value != 1)
                        {
                            Console.WriteLine("Недопустимое значение элемента массива. Попробуйте снова.");
                        }
                        else
                        {
                            if (mas[indexI - 1, indexJ - 1] != -1){
                                Console.WriteLine("Ячейка матрицы занята. Попробуйте снова.");
                            }
                            break;
                        }
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message + "Попробуйте снова.");
                }
            }
        }

        private static void printMas()
        {
            Console.WriteLine("Массив:");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(mas[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        private static Boolean checkMas()
        {
            Boolean check = true;
            for (int i = 0; i < n; i++)
            {
                check = true;
                for (int j = 1; j < n; j++)
                {
                    if (mas[i, j] != mas[i, j - 1] || mas[i, j] == -1)
                    {
                        check = false;
                    }
                }
                if (check)
                {
                    Console.WriteLine("Найдена строка с одинаковыми элементами. Алгоритм выполнен.");
                    return true;
                }
            }

            for (int i = 0; i < n; i++)
            {
                check = true;
                for (int j = 1; j < n; j++)
                {
                    if (mas[j, i] != mas[j - 1, i] || mas[j, i] == -1)
                    {
                        check = false;
                    }
                }
                if (check)
                {
                    Console.WriteLine("Найден столбец с одинаковыми элементами. Алгоритм выполнен.");
                    return true;
                }
            }

            check = true;
            for (int i = 1; i < n; i++)
            {
                if (mas[i, i] != mas[i - 1, i - 1] || mas[i, i] == -1)
                {
                    check = false;
                }
            }
            if (check)
            {
                Console.WriteLine("В главной диагонали все элементы равны. Алгоритм выполнен.");
                return true;
            }

            check = true;
            for (int i = 1; i < n; i++)
            {
                if (mas[i, n - i - 1] != mas[i - 1, n - i] || mas[i - 1, n - i] == -1)
                {
                    check = false;
                }
            }
            if (check)
            {
                Console.WriteLine("В побочной диагонали все элементы равны. Алгоритм выполнен.");
                return true;
            }

            check = true;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (mas[i, j] == -1)
                    {
                        check = false;
                    }
                }
            }
            if (check) {
                Console.WriteLine("Матрица заполнена. Строк, столбцов и диагоналей с одинаковыми элементами не найдено. Алгоритм выполнен.");
                return true;
            }

            return false;
        }
    }


}
