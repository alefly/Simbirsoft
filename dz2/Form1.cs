using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dz2
{
    public partial class Form1 : Form
    {
        private int sizeBit;
        private int n;
        private Game game;
        static public GameDatabase context;
        public Form1()
        {
            InitializeComponent();
            context = new GameDatabase();
        }

        private void buttonStep_Click(object sender, EventArgs e)
        {
            if (textBoxN.Text.Length < 1) {
                n = 3;
                sizeBit = (int)(pictureBox.Width / n);
                game = new Game(n);
            }
            int i, j, v;
            try {
                if (textBoxX.Text.Length < 1 || textBoxY.Text.Length < 1 || textBoxValue.Text.Length < 1)
                {
                    MessageBox.Show("Одно из полей не было заполнено");
                }
                else
                {
                    j = Convert.ToInt32(textBoxY.Text);
                    i = Convert.ToInt32(textBoxX.Text);
                    if (textBoxValue.Text != "0" && textBoxValue.Text != "x")
                    {
                        MessageBox.Show("В поле значения ячейки ожидались символы x или 0");
                    }
                    else
                    {
                        if (textBoxValue.Text == "0")
                        {
                            v = 0;
                        }
                        else
                        {
                            v = 1;
                        }

                        if (i > n || i < 1 || j > n || j < 1)
                        {
                            MessageBox.Show("Индексы выходят за границы массива. Попробуйте снова.");
                        }
                        else
                        {

                            if (v != 0 && v != 1)
                            {
                                Console.WriteLine("Недопустимое значение элемента массива. Попробуйте снова.");
                            }
                            else
                            {
                                if (game.Mas[i - 1, j - 1] != -1)
                                {
                                    MessageBox.Show("Ячейка игрового поля занята. Попробуйте снова.");
                                }
                                else {
                                    game.nextStep(i,j,v);
                                    pictureBox.Refresh();
                                    if (checkEnd()) {
                                        Close();
                                    }

                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + "Попробуйте снова.");
            }

        }

        private void pictureBox_Paint(object sender, PaintEventArgs e)
        {
            int x = 0,y = sizeBit;
            for (int i = 0; i < n - 1; i++) {
                e.Graphics.DrawLine(Pens.Black, x, y, pictureBox.Width, y);
                y += sizeBit;
            }
            x = sizeBit;
            y = 0;
            for (int i = 0; i < n - 1; i++)
            {
                e.Graphics.DrawLine(Pens.Black, x, y, x, pictureBox.Height);
                x += sizeBit;
            }
            x = 0;
            y = 0;

            for (int i = 0; i < n; i++) {
                for (int j = 0; j < n; j++) {
                    if (game.Mas[i, j] == 0)
                    {
                        e.Graphics.DrawEllipse(Pens.Purple, y + 5, x + 5, sizeBit - 10, sizeBit - 10);
                    }
                    else {
                        if (game.Mas[i, j] == 1) {
                            e.Graphics.DrawLine(Pens.RoyalBlue, y + 5, x + 5, y + sizeBit - 5, x + sizeBit - 5);
                            e.Graphics.DrawLine(Pens.RoyalBlue, y + 5, x + sizeBit - 5, y + sizeBit - 5, x + 5);
                        }
                    }
                    x += sizeBit;
                }
                x = 0;
                y += sizeBit;
            }
            
        }

        private void buttonField_Click(object sender, EventArgs e)
        {
            try
            {
                n = Convert.ToInt32(textBoxN.Text);
                sizeBit = (int)(pictureBox.Width / n);
                if (n > 20)
                {
                    MessageBox.Show("Слишком жестко. Сделайте размер поменьше");
                }
                else {
                    game = new Game(n);
                    //context.Games.Add(game);
                    //context.SaveChanges();
                    pictureBox.Refresh();
                }
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private bool checkEnd(){
            if (game.CheckVert() || game.CheckGoriz() || game.CheckDiag() || game.Status == "Окончена")
            {
                MessageBox.Show(game.Status);
                game.Date = DateTime.Now;
                context.Games.Add(game);
                context.SaveChanges();
                return true;
            }
            return false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "_dz2_GameDatabaseDataSet.Games". При необходимости она может быть перемещена или удалена.
            this.gamesTableAdapter.Fill(this._dz2_GameDatabaseDataSet.Games);

        }
    }
}