using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Potoki.Deleagte
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public delegate void InvokeDelegate();
        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            int do1 = Convert.ToInt32(textBox1.Text);
            int do2 = Convert.ToInt32(textBox2.Text);
            Random random = new Random();
            //задержка
            int sleep1 = random.Next(90, 250);
            int sleep2 = random.Next(90, 250);
            // создаем новый поток
            Thread myThread = new Thread(Print1);
            Thread myThread2 = new Thread(Print2);
            // запускаем поток myThread
            myThread.Start();
            myThread2.Start();

            void Print1()
            {
                for (int i = 0; i < do1; i++)
                {
                    //listBox1.Items.Add($"Главный поток: {i}, Рандом: {sleep1}");
                    listBox1.Invoke(new Action(() => listBox1.Items.Add($"Главный поток: {i}, Рандомное число: {sleep1}"))); ;
                    Thread.Sleep(sleep1);
                }
            }
           
            void Print2()
            {
                // действия, выполняемые в главном потоке
                for (int i = 0; i < do2; i++)
                {
                    listBox2.Invoke(new Action(() => listBox2.Items.Add($"Второй поток: {i}, Рандомное число: {sleep2}"))); ;
                    Thread.Sleep(sleep2);
                }
            }
          



        }
    }
}

        