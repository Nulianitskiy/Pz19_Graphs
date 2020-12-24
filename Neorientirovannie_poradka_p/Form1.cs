using System;
using System.IO;
using System.Windows.Forms;

namespace Pz19_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        struct Edge//Структура Ребро
        {
            public int first;
            public int second;
        }

        static bool NextCombobj(int[] Razm, int n, int k)//Сочетание из n по k
        {

            for (int i = k - 1; i >= 0; --i)//начинаем идти с конца в начало
                if (Razm[i] < n - k + i)
                {
                    Razm[i]++;//берем следующий элемент

                    for (int j = i + 1; j < k; j++)//следующий элемент меняем на предыдущий + 1
                        Razm[j] = Razm[j - 1] + 1;

                    return true;

                }
            return false;
        }
        static public void Reset(ref int[,] arr, int n, int m) //Обнуление массива
        {
            for (int i = 0; i < n; i++)
                for (int j = 0; j < m; j++)
                    arr[i, j] = 0;
        }
        static public void PrintArray(int[,] arr, char[] A, int n, int m, StreamWriter sw)//Вывод массива
        {
            sw.Write("  ");
            for (int i = 0; i < n; i++)
                sw.Write(A[i] + " ");
            sw.WriteLine();

            for (int i = 0; i < n; i++)
            {
                sw.Write(A[i] + " ");

                for (int j = 0; j < m; j++)
                    sw.Write(arr[i, j] + " ");

                sw.WriteLine();
            }
            sw.WriteLine("---------------------------------");
        }

        private void Calculation_Click(object sender, EventArgs e)
        {
            rtb.Text = ("");

            int p = (tb_p.Text != "") ? Convert.ToInt32(tb_p.Text) : 0;
            int k = 2;
            int[] Soch2 = new int[k];

            for (int i = 0; i < k; i++)
                Soch2[i] = i;

            char[] A = new char[p];
            for (int i = 0; i < p; i++)
                A[i] = (char)((char)97 + i);//Хочу, чтобы были буквы

            int m = 0;//счетчик ребер

            Edge[] edge = new Edge[50];//Массив ребер

            edge[m].first = Soch2[0];
            edge[m].second = Soch2[1];
            m++;
            if (p > k)
            {
                //Построения всех возможных ребер в заданном графе
                while (NextCombobj(Soch2, p, k))
                {
                    edge[m].first = Soch2[0];
                    edge[m].second = Soch2[1];
                    m++;
                }
            }
            else rtb.Text = ("Условие не выполняется");

            rtb.Text += m + " - максимальное количество ребер";

            FileInfo output = new FileInfo("Out.txt");
            StreamWriter sw = output.CreateText();

            int count_pq = 0;//Счетчик числа p,q графов

            int[,] Matrix = new int[p, p];

            for (int q = 0; q <= m; q++)
            {
                Reset(ref Matrix, p, p);

                int[] Soch_q = new int[q];

                for (int i = 0; i < q; i++)
                {

                    Soch_q[i] = i;       //Заполняем таблицу смежности
                    Matrix[edge[Soch_q[i]].first, edge[Soch_q[i]].second] = 1;
                    Matrix[edge[Soch_q[i]].second, edge[Soch_q[i]].first] = 1;
                }

                count_pq++;
                PrintArray(Matrix, A, p, p, sw);
                Reset(ref Matrix, p, p);


                if (p == m) rtb.Text += "\n1 граф";
                else
                {

                    //Строим сочетания из ребер
                    while (NextCombobj(Soch_q, m, q))
                    {
                        for (int i = 0; i < q; i++)
                        {                            //Заполняем таблицу смежности
                            Matrix[edge[Soch_q[i]].first, edge[Soch_q[i]].second] = 1;
                            Matrix[edge[Soch_q[i]].second, edge[Soch_q[i]].first] = 1;

                        }

                        PrintArray(Matrix, A, p, p, sw); //выводим в файл
                        Reset(ref Matrix, p, p); //обнуляем
                        count_pq++;
                    }

                }
            }
            rtb.Text += "\nКоличество графов - " + count_pq;
            sw.Close();
        }
    }
}
