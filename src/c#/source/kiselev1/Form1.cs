using System;
using System.Collections;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;

namespace kiselev1
{
    public partial class Form1 : Form
    {
        //--------------------------------------------------------

        //-----------------------------------------------------------------
        ArrayList arrRTB = new ArrayList();
        private Error err = new Error();
        private Game ourGame = Game.Instance;

        public Form1()
        {
            InitializeComponent();
        }

        //--------------------------------------------------------------------------
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            //GUI функция
            //обработчик для ввода в текстовые поля только одной цифры
            if (sender is TextBox)
            {
                if ((((TextBox)sender).Text.Length > 0) && e.KeyChar != 8)
                    e.Handled = true;
                else
                    if ((e.KeyChar != 8) && (e.KeyChar < 49 || e.KeyChar > 54))
                        e.Handled = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label2.Text = "";
            Stopwatch testStopwatch = new Stopwatch();
            testStopwatch.Start();
            button2.Enabled = false;
            panel2.Visible = false;
            //GUI функция 
            //обработчик алгоритма подсчета
            clearGUIMatrix();

            if (GUIToAlgorithm() == 0)
                MessageBox.Show(err.errGood.Item2);

            testStopwatch.Stop();
            label2.Text = ((double)testStopwatch.ElapsedMilliseconds / 1000).ToString() + " с";
            ourGame.clearArrays();
            panel2.Visible = true;
            button2.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //выход
            Close();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            clearGUIMatrix();
            ourGame.clearArrays();
        }
        //--------------------------------------------------------------------------

        private void topGUI()
        {
            //GUI to algorithm функция прослойка подготовки входных данных
            /*Заполним TOP вектор условий*/
            try
            {
                if (textBox1.Text.ToString() != "")
                {
                    byte.TryParse(textBox1.Text.ToString(), out ourGame.restrictions.top[0]);
                }
                if (textBox2.Text.ToString() != "")
                {
                    byte.TryParse(textBox2.Text.ToString(), out ourGame.restrictions.top[1]);
                }
                if (textBox3.Text.ToString() != "")
                {
                    byte.TryParse(textBox3.Text.ToString(), out ourGame.restrictions.top[2]);
                }
                if (textBox4.Text.ToString() != "")
                {
                    byte.TryParse(textBox4.Text.ToString(), out ourGame.restrictions.top[3]);
                }
                if (textBox8.Text.ToString() != "")
                {
                    byte.TryParse(textBox8.Text.ToString(), out ourGame.restrictions.top[4]);
                }
                if (textBox7.Text.ToString() != "")
                {
                    byte.TryParse(textBox7.Text.ToString(), out ourGame.restrictions.top[5]);
                }
                if (textBox6.Text.ToString() != "")
                {
                    byte.TryParse(textBox6.Text.ToString(), out ourGame.restrictions.top[6]);
                }
                if (textBox5.Text.ToString() != "")
                {
                    byte.TryParse(textBox5.Text.ToString(), out ourGame.restrictions.top[7]);
                }
            }
            catch
            {
                throw;
            }
        }

        private void rightGUI()
        {
            //GUI to algorithm функция прослойка подготовки входных данных
            /*заполним RIGHT вектор условий*/
            try
            {
                if (textBox24.Text.ToString() != "")
                {
                    byte.TryParse(textBox24.Text.ToString(), out ourGame.restrictions.right[0]);
                }
                if (textBox23.Text.ToString() != "")
                {
                    byte.TryParse(textBox23.Text.ToString(), out ourGame.restrictions.right[1]);
                }
                if (textBox22.Text.ToString() != "")
                {
                    byte.TryParse(textBox22.Text.ToString(), out ourGame.restrictions.right[2]);
                }
                if (textBox21.Text.ToString() != "")
                {
                    byte.TryParse(textBox21.Text.ToString(), out ourGame.restrictions.right[3]);
                }
                if (textBox20.Text.ToString() != "")
                {
                    byte.TryParse(textBox20.Text.ToString(), out ourGame.restrictions.right[4]);
                }
                if (textBox19.Text.ToString() != "")
                {
                    byte.TryParse(textBox19.Text.ToString(), out ourGame.restrictions.right[5]);
                }
                if (textBox18.Text.ToString() != "")
                {
                    byte.TryParse(textBox18.Text.ToString(), out ourGame.restrictions.right[6]);
                }
                if (textBox17.Text.ToString() != "")
                {
                    byte.TryParse(textBox17.Text.ToString(), out ourGame.restrictions.right[7]);
                }
            }
            catch
            {
                throw;
            }
        }

        private void bottomGUI()
        {
            //GUI to algorithm функция прослойка подготовки входных данных
            /*заполним BOTTOM вектор условий*/
            try
            {
                if (textBox32.Text.ToString() != "")
                {
                    byte.TryParse(textBox32.Text.ToString(), out ourGame.restrictions.bottom[0]);
                }
                if (textBox31.Text.ToString() != "")
                {
                    byte.TryParse(textBox31.Text.ToString(), out ourGame.restrictions.bottom[1]);
                }
                if (textBox30.Text.ToString() != "")
                {
                    byte.TryParse(textBox30.Text.ToString(), out ourGame.restrictions.bottom[2]);
                }
                if (textBox29.Text.ToString() != "")
                {
                    byte.TryParse(textBox29.Text.ToString(), out ourGame.restrictions.bottom[3]);
                }
                if (textBox28.Text.ToString() != "")
                {
                    byte.TryParse(textBox28.Text.ToString(), out ourGame.restrictions.bottom[4]);
                }
                if (textBox27.Text.ToString() != "")
                {
                    byte.TryParse(textBox27.Text.ToString(), out ourGame.restrictions.bottom[5]);
                }
                if (textBox26.Text.ToString() != "")
                {
                    byte.TryParse(textBox26.Text.ToString(), out ourGame.restrictions.bottom[6]);
                }
                if (textBox25.Text.ToString() != "")
                {
                    byte.TryParse(textBox25.Text.ToString(), out ourGame.restrictions.bottom[7]);
                }
            }
            catch
            {
                throw;
            }
        }

        private void leftGUI()
        {
            //GUI to algorithm функция прослойка подготовки входных данных
            /*заполним LEFT вектор условий*/
            try
            {
                if (textBox16.Text.ToString() != "")
                {
                    byte.TryParse(textBox16.Text.ToString(), out ourGame.restrictions.left[0]);
                }
                if (textBox15.Text.ToString() != "")
                {
                    byte.TryParse(textBox15.Text.ToString(), out ourGame.restrictions.left[1]);
                }
                if (textBox14.Text.ToString() != "")
                {
                    byte.TryParse(textBox14.Text.ToString(), out ourGame.restrictions.left[2]);
                }
                if (textBox13.Text.ToString() != "")
                {
                    byte.TryParse(textBox13.Text.ToString(), out ourGame.restrictions.left[3]);
                }
                if (textBox12.Text.ToString() != "")
                {
                    byte.TryParse(textBox12.Text.ToString(), out ourGame.restrictions.left[4]);
                }
                if (textBox11.Text.ToString() != "")
                {
                    byte.TryParse(textBox11.Text.ToString(), out ourGame.restrictions.left[5]);
                }
                if (textBox10.Text.ToString() != "")
                {
                    byte.TryParse(textBox10.Text.ToString(), out ourGame.restrictions.left[6]);
                }
                if (textBox9.Text.ToString() != "")
                {
                    byte.TryParse(textBox9.Text.ToString(), out ourGame.restrictions.left[7]);
                }
            }
            catch
            {
                throw;
            }
        }

        private int GUIToAlgorithm()
        {
            //GUI to algorithm функция прослойка, заполняет все входные данные от пользователя
            //manager функций заолнения внешнихограничений
            //запуск алгоритма: прослойки между алгоритмов и GUI
            //заполнить внешние условия
            try
            {
                topGUI();

                rightGUI();

                bottomGUI();

                leftGUI();

            }
            catch
            {
                throw;
            }

            //после заполнения выполняем алгоритм с проверками и заполнением и выводом матрицы
            if (doneTask().Item1 == err.err0.Item1)
            {
                printGUI();
                return 0;
            }
            else
            {
                MessageBox.Show(err.errBad.Item2);
                ourGame.clearArrays();
                return 1;
            }
        }

        private void clearGUIAll()
        {
            ;
        }

        private void clearGUIMatrix()
        {
            //GUI очистка матрицы
            foreach (RichTextBox c in arrRTB)
            {
                c.Clear();
            }
            arrRTB.Clear();
        }

        private void printGUI()
        {
            //GUI печать данных на форму
            //вывод в текстбоксы результирующей или первоначальной матрицы
            clearGUIMatrix();
            string spaceTab = "\t"; //расстояние между ячейками
            string spaceSp = " "; //расстояние между еллементами в ячейке
            int nEnter = 3; //перевод еллементов в ячейке на следующую строку

            //заполнение массива матрицей
            arrRTB.Add(richTextBox1); arrRTB.Add(richTextBox2); arrRTB.Add(richTextBox3); arrRTB.Add(richTextBox4);
            arrRTB.Add(richTextBox5); arrRTB.Add(richTextBox6); arrRTB.Add(richTextBox7); arrRTB.Add(richTextBox8);
            arrRTB.Add(richTextBox9); arrRTB.Add(richTextBox10); arrRTB.Add(richTextBox11); arrRTB.Add(richTextBox12);
            arrRTB.Add(richTextBox13); arrRTB.Add(richTextBox14); arrRTB.Add(richTextBox15); arrRTB.Add(richTextBox16);

            arrRTB.Add(richTextBox17); arrRTB.Add(richTextBox18); arrRTB.Add(richTextBox19); arrRTB.Add(richTextBox20);
            arrRTB.Add(richTextBox21); arrRTB.Add(richTextBox22); arrRTB.Add(richTextBox23); arrRTB.Add(richTextBox24);
            arrRTB.Add(richTextBox25); arrRTB.Add(richTextBox26); arrRTB.Add(richTextBox27); arrRTB.Add(richTextBox28);
            arrRTB.Add(richTextBox29); arrRTB.Add(richTextBox30); arrRTB.Add(richTextBox31); arrRTB.Add(richTextBox32);

            arrRTB.Add(richTextBox33); arrRTB.Add(richTextBox34); arrRTB.Add(richTextBox35); arrRTB.Add(richTextBox36);
            arrRTB.Add(richTextBox37); arrRTB.Add(richTextBox38); arrRTB.Add(richTextBox39); arrRTB.Add(richTextBox40);
            arrRTB.Add(richTextBox41); arrRTB.Add(richTextBox42); arrRTB.Add(richTextBox43); arrRTB.Add(richTextBox44);
            arrRTB.Add(richTextBox45); arrRTB.Add(richTextBox46); arrRTB.Add(richTextBox47); arrRTB.Add(richTextBox48);

            arrRTB.Add(richTextBox49); arrRTB.Add(richTextBox50); arrRTB.Add(richTextBox51); arrRTB.Add(richTextBox52);
            arrRTB.Add(richTextBox53); arrRTB.Add(richTextBox54); arrRTB.Add(richTextBox55); arrRTB.Add(richTextBox56);
            arrRTB.Add(richTextBox57); arrRTB.Add(richTextBox58); arrRTB.Add(richTextBox59); arrRTB.Add(richTextBox60);
            arrRTB.Add(richTextBox61); arrRTB.Add(richTextBox62); arrRTB.Add(richTextBox63); arrRTB.Add(richTextBox64);

            for (int i = 0; i < ourGame.nRows; ++i)
                for (int j = 0; j < ourGame.nColms; ++j)
                {
                    RichTextBox a = new RichTextBox();
                    a = (RichTextBox)arrRTB[j + i * ourGame.nColms];
                    for (int k = 0; k < ourGame.arr[i, j].Count; ++k)
                    {
                        int x = ourGame.arr[i, j][k];
                        a.Text += x.ToString() + spaceSp;
                        //if(x != ourGame.notN)
                        //    a.Text += x.ToString() + spaceSp;
                        if ((k + 1) % nEnter == 0)
                            a.Text += "\n";
                    }
                }
        }

        private Tuple<byte, string> doneTask()
        {
            //Прослойка между GUI и алгоритмом
            //manager представления данных от алгоритма к GUI
            //выполнить алгоритм
            Tuple<byte, string> flag;
            flag = ourGame.doneAlgorithmTask();
            if (flag.Item1 != err.err0.Item1 && flag.Item1 != err.err00.Item1)
            {
                MessageBox.Show(flag.Item2);
                return flag;
            }
            return err.err0;
        }
    }
}

