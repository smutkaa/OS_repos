using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Os_lab2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Core core = new Core();
            richTextBoxWith.Clear();
            richTextBoxWithout.Clear();
            textBoxWith.Clear();
            textBoxWithout.Clear();
            core.PlanningWithoutBlocking(richTextBoxWithout, textBoxWithout);
            core.PrintBlockingTime(richTextBoxWith);
            core.PlanningWithBlocking(richTextBoxWith, textBoxWith);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
