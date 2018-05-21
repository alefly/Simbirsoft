using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dz2
{

    class Game : IGame
    {
        public static int[,] mas;
        private static int n;
        public static string status { get; protected set; }

        public Game(int size) {
            status = "Не окончена";
            n = size;
            mas = new int[n, n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    mas[i, j] = -1;
                }
            }
        }

        public bool nextStep(int i, int j, int v) {
            try
            {
                if (i > n || i < 1 || j > n || j < 1)
                {
                    return false;
                }
                else
                {
                    
                    if (v != 0 && v != 1)
                    {
                        return false;
                    }
                    else
                    {
                        if (mas[i - 1, j - 1] != -1)
                        {
                            return false;
                        }
                        else
                        {
                            mas[i - 1, j - 1] = v;
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            return true;
        } 

        public bool checkVert() {
            bool check = true;
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
                    return true;
                }
            }
            return false;
        }

        public bool checkGoriz()
        {
            bool check = true; ;
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
                    return true;
                }
            }
            return false;
        }

        public bool checkDiag()
        {
            bool check = true;
            for (int i = 1; i < n; i++)
            {
                if (mas[i, i] != mas[i - 1, i - 1] || mas[i, i] == -1)
                {
                    check = false;
                }
            }
            if (check)
            {
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
                return true;
            }
            return false;
        }

        public void checkMas() {
            bool check = true;
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
            if (check)
            {
                status = "Окончена";
            }
        }
    }
}
