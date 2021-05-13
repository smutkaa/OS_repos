using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Os_lab2
{
    class Process
    {
        //Random rnd = new Random();
        private int ID;
        private int maxTime = 20;
        private Boolean workWithDevice;
        private int workBeforeDevice;
        private int workDevice;
        private int workAfterDevice;
        private int totalTime;
        public Process(int ID, Boolean workWithDevice, int workBeforeDevice, int workDevice, int workAfterDevice)
        {
            this.ID = ID;
            this.workWithDevice = workWithDevice;
            this.workBeforeDevice = workBeforeDevice;
            this.workDevice = workDevice;
            this.workAfterDevice = workAfterDevice;
        }
        public Boolean ExecutionWithoutBlocking(RichTextBox richTextBox)
        {
            totalTime = 0;
            richTextBox.Text += "Процесс" + ID + "начинает работу \n";
            if (workBeforeDevice > maxTime)
            {
                workBeforeDevice -= maxTime;
                totalTime = maxTime;
                richTextBox.Text += "Процесс" + ID + "приостановлен после" + totalTime + "мс \n";
                return false;
            }
            else
            {
                totalTime += workBeforeDevice;
                workBeforeDevice = 0;
            }
            if (workWithDevice)
            {
                if (workDevice > maxTime - totalTime)
                {
                    workDevice -= maxTime - totalTime;
                    totalTime = maxTime;
                    richTextBox.Text += "Процесс" + ID + "приостановлен после" + totalTime + "мс \n";
                    return false;
                }
                else
                {
                    totalTime += workDevice;
                    workDevice = 0;
                }
            }
            if (workAfterDevice > maxTime - totalTime)
            {
                workAfterDevice -= maxTime - totalTime;
                totalTime = maxTime;
                richTextBox.Text += "Процесс" + ID + "приостановлен после" + totalTime + "мс \n";
                return false;
            }
            else
            {
                totalTime += workAfterDevice;
                workAfterDevice = 0;
            }
            richTextBox.Text += "Процесс" + ID + "выполнен после" + totalTime + "мс \n";
            return true;
        }
        public int ExecutionWithBlocking(RichTextBox richTextBox)
        {
            totalTime = 0;
            richTextBox.Text += "Процесс" + ID + "начинает работу \n";
            if (workBeforeDevice > maxTime - totalTime)
            {
                workBeforeDevice -= maxTime - totalTime;
                totalTime = maxTime;
                richTextBox.Text += "Процесс" + ID + "приостановлен после" + totalTime + "мс \n";
                return -1;
            }
            else
            {
                totalTime += workBeforeDevice;
                workBeforeDevice = 0;
            }
            if (workWithDevice && workDevice != 0)
            {
                richTextBox.Text += "Процесс" + ID + "заблокирован после" + totalTime + "мс \n";
                return 0;
            }
            if (workAfterDevice > maxTime - totalTime)
            {
                workAfterDevice -= maxTime - totalTime;
                totalTime = maxTime;
                richTextBox.Text += "Процесс" + ID + "приостановлен после" + totalTime + "мс \n";
                return -1;
            }
            else
            {
                totalTime += workAfterDevice;
                workAfterDevice = 0;
            }
            richTextBox.Text += "Процесс" + ID + "выполнен после" + totalTime + "мс \n";
            return 1;
        }
        public Boolean ExecuteProcessInterruptBreaking(RichTextBox richTextBox, int workTimeBeforeInterrupt)
        {
            totalTime = 0;
            richTextBox.Text += "Процесс" + ID + "начинает работу \n";
            if (workBeforeDevice > workTimeBeforeInterrupt - totalTime)
            {
                workBeforeDevice -= workTimeBeforeInterrupt - totalTime;
                totalTime = workTimeBeforeInterrupt;
                richTextBox.Text += "Процесс" + ID + "приостановлен после" + totalTime + "мс \n";
                return false;
            }
            else
            {
                totalTime += workBeforeDevice;
                workBeforeDevice = 0;
            }
            if (workWithDevice)
            {
                if (workDevice > workTimeBeforeInterrupt - totalTime)
                {
                    workDevice -= workTimeBeforeInterrupt - totalTime;
                    totalTime = workTimeBeforeInterrupt;
                    richTextBox.Text += "Процесс" + ID + "приостановлен после" + totalTime + "мс \n";
                    return false;
                }
                else
                {
                    totalTime += workDevice;
                    workDevice = 0;
                }
            }
            if (workAfterDevice > workTimeBeforeInterrupt - totalTime)
            {
                workAfterDevice -= workTimeBeforeInterrupt - totalTime;
                totalTime = workTimeBeforeInterrupt;
                richTextBox.Text += "Процесс" + ID + "приостановлен после" + totalTime + "мс \n";
                return false;
            }
            else
            {
                totalTime += workAfterDevice;
                workAfterDevice = 0;
            }
            richTextBox.Text += "Процесс" + ID + "выполнен после" + totalTime + "мс \n";
            return true;
        }
        public Boolean ContinutExecuteProcessWithBlock(RichTextBox richTextBox)
        {
            if (totalTime == maxTime)
            {
                return false;
            }
            int realTime = 0;
            richTextBox.Text += "Процесс" + ID + "возобновляет работу \n";

            if (workAfterDevice > maxTime - totalTime)
            {
                workAfterDevice -= maxTime - totalTime;
                realTime = maxTime - totalTime;
                totalTime = maxTime;
                richTextBox.Text += "Процесс" + ID + "приостановлен после еще" + realTime + "мс \n";
                return false;
            }
            else
            {
                realTime = workAfterDevice;
                totalTime = workAfterDevice;
                workAfterDevice = 0;
            }
            richTextBox.Text += "Процесс" + ID + "выполнен после еще" + realTime + "мс \n";
            return true;
        }
        public int GetTotalTime()
        {
            return totalTime;
        }
        public void SetWorkDevice()
        {
            workDevice = 0;
        }
        public int GetWorkDevice()
        {
            if (workWithDevice)
            {
                return workDevice;
            }
            return 0;
        }
    }
}