using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OS_lab1
{
    class Process
    {
        Random rnd = new Random(); 

        List<int> ExecutionTimeForThread = new List<int>();
        public int PID { get; private set; }
        public int ProcessExecutionTime { get; private set; }
        public FormPlanner formPlanner { get; private set; }
        public int OneIteration { get; private set; }
        public List<Thread> Threads { get; private set; }
        public Process(int Pid, int ThreadCount, FormPlanner form)
        {
            PID = Pid;
            Threads = new List<Thread>();
            formPlanner = form;
            Threads = new List<Thread>();
            ProcessExecutionTime = 250;

            int tmp = 0;
            int contrastTime = ProcessExecutionTime / 15; 
            int arrangeTime = ProcessExecutionTime / ThreadCount;

            for (int i = 0; i < ThreadCount - 1; ++i)
            {
                int time = rnd.Next(arrangeTime - contrastTime, arrangeTime + contrastTime);
                ExecutionTimeForThread.Add(time);
                tmp += time;
            }
            ExecutionTimeForThread.Add(ProcessExecutionTime - tmp);

            for (int i = 0; i < ThreadCount; ++i)
            {
                Threads.Add(new Thread(i, PID, ExecutionTimeForThread[i], formPlanner));
            }
        }
 
        public void SubstractProcessExecutionTime()
        {
            ProcessExecutionTime -= OneIteration;
        }
        public void toPlane()
        {
            int temp = 0;
            while (true)
            {
                for (int i = 0;  i < Threads.Count(); i++)
                {
                    Threads[i].toStart();
                    temp += Threads[i].OneIteration;
                    Threads[i].SubstractThreadExecutionTime();
                    if (Threads[i].ThreadExecutionTime < 0)
                    {
                        Threads.Remove(Threads[i]);
                        i--;
                    }
                    int maximumTimeForThreads = 30;
                    if (temp > maximumTimeForThreads)
                    {
                        OneIteration = temp;
                        return;
                    }
                }
                if (Threads.Count() == 0)
                {
                    OneIteration = temp;
                    return;
                }
            }
        }
    }
}

