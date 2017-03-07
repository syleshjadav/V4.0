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
        private int counter = 120;
        private int servicePollInterval=120;

        public Form1()
        {
            InitializeComponent();


            servicePollInterval = MyShopCompInspectionSync.Properties.Settings.Default.ServicePollInterval;
            counter = servicePollInterval;
            lblCountDown.Text = counter.ToString();

          

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            counter--;
            lblCountDown.Text = counter.ToString();
            if (counter == 0)
            {
                 timer1.Stop();

                if (MyShopCompInspectionSync.Properties.Settings.Default.IsShowForm == false)
                {
                    this.Visible = false;
                }


                counter = servicePollInterval;
                timer1.Start();
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
          
        }

    

       
    }
}
