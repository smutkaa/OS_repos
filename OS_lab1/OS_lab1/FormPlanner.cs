using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections.ObjectModel;

namespace OS_lab1
{
    public partial class FormPlanner : Form
    {
        private Bitmap bmp;
        
        public Graphics gr;

        private int height; // высота 1 линии разметки
        private int countBefore; 

        private Pen[] color = {
            new Pen(Color.Aqua),
            new Pen(Color.Red),
            new Pen(Color.Magenta),
            new Pen(Color.Pink),
            new Pen(Color.Purple),
            new Pen(Color.Magenta),
            new Pen(Color.Lime),
            new Pen(Color.Salmon),
            new Pen(Color.Indigo),
            new Pen(Color.Gold)
        };
       
        public List<Thread> Threads;

        private void Initial()
        {
            Threads = new List<Thread>();
            bmp = new Bitmap(pictureBox.Width, pictureBox.Height);
            gr = Graphics.FromImage(bmp);
            DrawMarking(gr);
        }

        public FormPlanner()
        {
            InitializeComponent();
            height = pictureBox.Height / 6;
            countBefore = 0;
            Initial();
        }

        private void DrawMarking(Graphics g)
        {
            Pen pen = new Pen(Color.White);
            for (int i = 0; i < pictureBox.Height / height; i++)
            {
                g.DrawLine(pen, 0, (i + 1) * height, pictureBox.Width, (i + 1) * height);
            }
            g.DrawLine(pen, pictureBox.Width - 2, 0, pictureBox.Width - 2, pictureBox.Height);
        }

        public void DrawThread(Graphics g)
        {
            int tempWidth = 0;
            int tempHeight = 15;

            Pen mark = new Pen(Color.Magenta, 2);

            foreach (var thread in Threads)
            {
                int h = thread.TID * 18 + tempHeight; // регулируем высоту переменной
        
                if (thread.Status == StatusEnum.Stop)
                {
                    g.DrawLine(color[thread.PID], tempWidth * 10 + 2, h, (tempWidth + thread.OneIteration) * 10, h);
                    g.DrawLine(color[thread.PID], (tempWidth + thread.OneIteration) * 10, h + 10, (tempWidth + thread.OneIteration - 2) * 10, h - 10);
                    g.DrawLine(color[thread.PID], (tempWidth + thread.OneIteration) * 10, h - 10, (tempWidth + thread.OneIteration - 2) * 10, h + 10);

                }
                else if (thread.Status == StatusEnum.Pause)
                {
                    g.DrawLine(color[thread.PID], tempWidth * 10 + 2, h, (tempWidth + thread.OneIteration) * 10, h);
                    g.DrawLine(color[thread.PID], (tempWidth + thread.OneIteration) * 10, h, (tempWidth + thread.OneIteration - 2) * 10, h - 10);
                    g.DrawLine(color[thread.PID], (tempWidth + thread.OneIteration) * 10, h, (tempWidth + thread.OneIteration - 2) * 10, h + 10);
                }
                else
                {
                    g.DrawLine(color[thread.PID], tempWidth * 10 + 2, h, (tempWidth + thread.OneIteration) * 10, h);
   
                }

                tempWidth += thread.OneIteration;
                if (tempWidth + 10 > pictureBox.Width / 10)
                {
                    tempWidth = 0;
                    tempHeight += height;
                }
            }

            g.DrawLine(mark, tempWidth * 10, tempHeight - 10, tempWidth * 10, tempHeight + 60); //окончание процесса 

            pictureBox.Image = bmp;
        }

        public void AddMark()
        {
            int tempWidth = 0;

            int tempHeight = 20;

            foreach (var thread in Threads)
            {
                tempWidth += thread.OneIteration;

                if (tempWidth + 10 > pictureBox.Width / 10)
                {
                    tempWidth = 0;
                    tempHeight += height;
                }
            }
        }

        private void ToMarkup()
        {
            int n = Threads.Count;
            for (int i = countBefore; i < n; ++i)
            {
                var thread = Threads[i];
                if (i == n - 1)
                {
                    Threads[i].Status = StatusEnum.Stop;
                }
                else if (Threads[i].PID != Threads[i + 1].PID)
                {
                    bool flag = true;
                    for (int j = i + 1; j < n; ++j)
                    {
                        if (Threads[i].PID == Threads[j].PID)
                        {
                            Threads[i].Status = StatusEnum.Pause;
                            flag = false;
                            break;
                        }
                    }
                    if (flag) { thread.Status = StatusEnum.Stop; }
                }
            }
            countBefore = Threads.Count();
        }
        private void buttonStart_Click(object sender, EventArgs e)
        {
            Core systemCore = new Core(this);
            systemCore.Generate();

            ToMarkup();
            DrawThread(gr);
        }
        private void ButtonClean_Click(object sender, EventArgs e)
        {
            pictureBox.Image = null;
            Initial();
        }
    }
}
