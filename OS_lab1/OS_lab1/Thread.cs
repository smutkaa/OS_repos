using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OS_lab1
{
    public class Thread
    {
        readonly Random rnd = new Random();
        public int TID { get; private set; }
        public int PID { get; private set; }
        public int ThreadExecutionTime { get; private set; }
        public int OneIteration { get; private set; }
        public StatusEnum? Status { get; set; }

        FormPlanner formPlanner;
        public Thread(int TID, int PID, int ExecutionTime, FormPlanner formPlanner)
        {
            this.TID = TID;
            this.PID = PID;
            this.ThreadExecutionTime = ExecutionTime;
            this.formPlanner = formPlanner;

            OneIteration = ThreadExecutionTime / rnd.Next(10, 18);
        }
       
        public void SubstractThreadExecutionTime()
        {
            ThreadExecutionTime -= OneIteration;
        }

        public void toStart ()
        {
            formPlanner.Threads.Add(new Thread(TID, PID, ThreadExecutionTime, formPlanner)
            {
                OneIteration = this.OneIteration,
                Status = this.Status
            });
            formPlanner.AddMark();
            formPlanner.Refresh();
        }
    }
}
