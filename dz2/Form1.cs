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
        public Form1()
        {
            InitializeComponent();
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
                                if (Game.mas[i - 1, j - 1] != -1)
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
                    if (Game.mas[i, j] == 0)
                    {
                        e.Graphics.DrawEllipse(Pens.Purple, y + 5, x + 5, sizeBit - 10, sizeBit - 10);
                    }
                    else {
                        if (Game.mas[i, j] == 1) {
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
                    pictureBox.Refresh();
                }
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private bool checkEnd(){
            if (game.checkVert()) {
                MessageBox.Show("Вертикаль заполнена. Игра окончена");
                return true;
            }
            if (game.checkGoriz())
            {
                MessageBox.Show("Горизонталь заполнена. Игра окончена");
                return true;
            }
            if (game.checkDiag())
            {
                MessageBox.Show("Диагональ заполнена. Игра окончена");
                return true;
            }
            if (Game.status == "Окончена")
            {
                MessageBox.Show("Игра окончена");
                return true;
            }
            return false;
        } 
    }
}