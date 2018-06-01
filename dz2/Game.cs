using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dz2
{

    public class Game : IGame
    {
        public int Id { get; protected set; }
        public int[,] Mas { get; set; }
        public int N { get; set; }
        public DateTime Date { get ; set; }
        public string Status { get; set; }
        public int Steps { get; set; }

        public Game(int size) {
            Date = DateTime.Now;
            Status = "Игра не окончена";
            N = size;
            Mas = new int[N, N];
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    Mas[i, j] = -1;
                }
            }
        }

        public bool nextStep(int i, int j, int v) {
            try
            {
                if (i > N || i < 1 || j > N || j < 1)
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
                        if (Mas[i - 1, j - 1] != -1)
                        {
                            return false;
                        }
                        else
                        {
                            Mas[i - 1, j - 1] = v;
                            Steps++;
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

        public bool CheckVert() {
            bool check = true;
            for (int i = 0; i < N; i++)
            {
                check = true;
                for (int j = 1; j < N; j++)
                {
                    if (Mas[i, j] != Mas[i, j - 1] || Mas[i, j] == -1)
                    {
                        check = false;
                    }
                }
                if (check)
                {
                    if (Mas[i, 0] == 1)
                    {
                        Status = "Игра окончена. Победили крестики";
                    }
                    else {
                        Status = "Игра окончена.Победили нолики";
                    }
                    return true;
                }
            }
            return false;
        }

        public bool CheckGoriz()
        {
            bool check = true; ;
            for (int i = 0; i < N; i++)
            {
                check = true;
                for (int j = 1; j < N; j++)
                {
                    if (Mas[j, i] != Mas[j - 1, i] || Mas[j, i] == -1)
                    {
                        check = false;
                    }
                }
                if (check)
                {
                    if (Mas[0, i] == 1)
                    {
                        Status = "Игра окончена. Победили крестики";
                    }
                    else
                    {
                        Status = "Игра окончена. Победили нолики";
                    }
                    return true;
                }
            }
            return false;
        }

        public bool CheckDiag()
        {
            bool check = true;
            for (int i = 1; i < N; i++)
            {
                if (Mas[i, i] != Mas[i - 1, i - 1] || Mas[i, i] == -1)
                {
                    check = false;
                }
            }
            if (check)
            {
                if (Mas[0, 0] == 1)
                {
                    Status = "Игра окончена. Победили крестики";
                }
                else
                {
                    Status = "Игра окончена. Победили нолики";
                }
                return true;
            }

            check = true;
            for (int i = 1; i < N; i++)
            {
                if (Mas[i, N - i - 1] != Mas[i - 1, N - i] || Mas[i - 1, N - i] == -1)
                {
                    check = false;
                }
            }
            if (check)
            {
                if (Mas[N-1, 0] == 1)
                {
                    Status = "Игра окончена. Победили крестики";
                }
                else
                {
                    Status = "Игра окончена. Победили нолики";
                }
                return true;
            }
            return false;
        }

        public void CheckMas() {
            bool check = true;
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    if (Mas[i, j] == -1)
                    {
                        check = false;
                    }
                }
            }
            if (check)
            {
                Status = "Игра окончена. Ничья";
            }
        }
    }
}
