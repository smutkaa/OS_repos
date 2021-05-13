using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OS_lab1
{
    class Core
    {
        Random rnd = new Random();
        private List<Process> processes = new List<Process>();
        FormPlanner formPlanner;
        public Core(FormPlanner formPlanner)
        {
            this.formPlanner = formPlanner;
            processes = new List<Process>();
        }
        public void Generate()
        {
            for (int i = 0; i < rnd.Next(3, 5); i++)
            {
                CreateProcesses();
            }
            toPlane();
        }
        public void CreateProcesses()
        {
            processes.Add(new Process(processes.Count(), rnd.Next(2,6), formPlanner));
        }
        public void toPlane()
        {
            int temp = 0;
            while (true)
            {
                for (int i = 0; i < processes.Count(); i++)
                {
                    processes[i].toPlane();
                    temp += processes[i].OneIteration;
                    processes[i].SubstractProcessExecutionTime();
                    if (processes[i].ProcessExecutionTime < 0)
                    {
                        processes.Remove(processes[i]);
                        i--;
                    }
                    int maxProcessTime = 200;
                    if (temp > maxProcessTime)
                    {
                        return;
                    }
                }
                if (processes.Count() == 0)
                {
                    return;
                }
            }
        }
    }
}
