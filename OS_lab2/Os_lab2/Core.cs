using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Os_lab2
{
    class Core
    {
        Random rnd = new Random();
        Queue<Process> WithBlockingQueue = new Queue<Process>();
        Queue<Process> WithoutBlockingQueue = new Queue<Process>();

        public Core()
        {
            CreateProcess();
        }
        private void CreateProcess()
        {
            for (int i = 1; i <= 3; i++)
            {
                int workBeforeDevice = rnd.Next(15, 26);
                int workDevice = rnd.Next(1, 6);
                int workAfterDevice = rnd.Next(15, 26);
                Boolean workWithDevice = false;
                if (rnd.Next(0, 2) == 1 || i == 1)
                {
                    workWithDevice = true;
                }
                WithBlockingQueue.Enqueue(new Process(i, workWithDevice, workBeforeDevice, workDevice, workAfterDevice));
                WithoutBlockingQueue.Enqueue(new Process(i, workWithDevice, workBeforeDevice, workDevice, workAfterDevice));
            }
        }
        public void PrintBlockingTime(RichTextBox richTextBox)
        {
            for (int i = 1; i <= WithBlockingQueue.Count; i++)
            {
                Process process = WithBlockingQueue.Dequeue();
                if (process.GetWorkDevice() != 0)
                {
                    richTextBox.Text += "Процесс" + i + "работает с устройствами ввода/вывода" + process.GetWorkDevice() + "мс \n \n";
                    WithBlockingQueue.Enqueue(process);
                }             
            }
        }
        public void PlanningWithoutBlocking(RichTextBox richTextBox, TextBox textBox)
        {
            int executionTime = 0;
            while (WithoutBlockingQueue.Count != 0)
            {
                Process process = WithoutBlockingQueue.Dequeue();
                if (!process.ExecutionWithoutBlocking(richTextBox))
                {
                    WithoutBlockingQueue.Enqueue(process);
                }
                executionTime += process.GetTotalTime();
            }
            textBox.AppendText(executionTime + "мс");
        }
        public void PlanningWithBlocking(RichTextBox richTextBox, TextBox textBox)
        {
            int executionTime = 0;
            while (WithBlockingQueue.Count != 0)
            {
                Process process = WithBlockingQueue.Dequeue();
                int result = process.ExecutionWithBlocking(richTextBox);

                if (result == 0)
                {
                    if(WithBlockingQueue.Count != 0)
                    {
                        executionTime += process.GetWorkDevice();
                        Process newProcess = WithBlockingQueue.Peek();
                        if(newProcess.ExecuteProcessInterruptBreaking(richTextBox, process.GetWorkDevice()))
                        {
                            WithBlockingQueue.Dequeue();
                        }
                        process.SetWorkDevice();
                        if (!process.ContinutExecuteProcessWithBlock(richTextBox))
                        {
                            WithBlockingQueue.Enqueue(process);
                        }
                        else {
                            process.ExecutionWithoutBlocking(richTextBox);
                        }
                    }
                }
                if(result == -1)
                {
                    WithBlockingQueue.Enqueue(process);
                }
                executionTime += process.GetTotalTime();
            }
            textBox.AppendText(executionTime + "мс"); 
        }
    }
}
