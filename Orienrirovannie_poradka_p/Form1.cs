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
        static void swap(int[] Razm, int i, int j)
        {
            int t = Razm[i];
            Razm[i] = Razm[j];
            Razm[j] = t;
        }

        static bool Sochetanie(int[] Razm, int n, int k)//Сочетание из n по k
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
        static bool Razmeshenie(int[] Razm, int n, int k)
        {
            int j;
            do  // повторяем пока j не попадет в границы k
            {
                j = n - 2;
                while (j != -1 && Razm[j] >= Razm[j + 1]) j--;
                if (j == -1)
                    return false; // больше размещений нет
                int m = n - 1;
                while (Razm[j] >= Razm[m]) m--;
                swap(Razm, j, m);
                int l = j + 1, r = n - 1; // сортируем оставшуюся часть последовательности
                while (l < r)
                    swap(Razm, l++, r--);
            }
            while (j > k - 1);
            return true;
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
            int[] Razm = new int[p + 1];

            for (int i = 0; i < p; i++)
                Razm[i] = i;

            char[] A = new char[p];
            for (int i = 0; i < p; i++)
                A[i] = (char)((char)97 + i);//Хочу, чтобы были буквы

            int m = 0;//счетчик ребер

            Edge[] edge = new Edge[500];//Массив ребер

            edge[m].first = Razm[0];
            edge[m].second = Razm[1];
            m++;


            //Построения всех возможных ребер в заданном графе
            while (Razmeshenie(Razm, p, k))
            {
                edge[m].first = Razm[0];
                edge[m].second = Razm[1];
                m++;
            }

            rtb.Text += m + " - максимальное количество дуг";

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
                }

                count_pq++;
                PrintArray(Matrix, A, p, p, sw);
                Reset(ref Matrix, p, p);


                if (p == m) rtb.Text += "\n1 граф";
                else
                {

                    //Строим сочетания из ребер
                    while (Sochetanie(Soch_q, m, q))
                    {
                        for (int i = 0; i < q; i++)
                        {                            //Заполняем таблицу смежности
                            Matrix[edge[Soch_q[i]].first, edge[Soch_q[i]].second] = 1;
                        }

                        PrintArray(Matrix, A, p, p, sw); //выводим в файл
                        Reset(ref Matrix, p, p); //обнуляем
                        count_pq++;
                    }
                }
            }
            rtb.Text += "\nКоличество орграфов - " + count_pq;
            sw.Close();
        }
    }
}
