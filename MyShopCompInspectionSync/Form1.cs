using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyShopCompInspectionSync
{
    public partial class Form1 : Form
    {
       // private System.Windows.Forms.Timer timer1;
        private int counter = 60;
        private int servicePollInterval;

        public Form1()
        {
            InitializeComponent();

            // timer1.Tick += new EventHandler(timer1_Tick);

            //timer1.Interval
            servicePollInterval = MyShopCompInspectionSync.Properties.Settings.Default.servicePollInterval;
            counter = servicePollInterval;
          //  timer1.Start();
            lblCountDown.Text = counter.ToString();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            counter--;
            lblCountDown.Text = counter.ToString();
            if (counter == 0)
            {
                // timer1.Stop();

                counter = servicePollInterval;
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
          
        }

    

        private void Form1_Enter(object sender, EventArgs e)
        {
           
           
        }
    }
}
