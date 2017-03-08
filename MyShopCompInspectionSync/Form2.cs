using MyShopCompInspectionSync.MyShopProxy;
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
    public partial class Form2 : System.Windows.Forms.Form
    {
        // private System.Windows.Forms.Timer timer1;
        private int counter = 120;
        private int servicePollInterval = 120;
        private int dealerId = 103;

        public Form2()
        {
            InitializeComponent();


            servicePollInterval = MyShopCompInspectionSync.Properties.Settings.Default.ServicePollInterval;
            dealerId = MyShopCompInspectionSync.Properties.Settings.Default.DealerId;

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


                var res1 = ATP.Common.ProxyHelper.Service<ICompInspection>.Use(svcs =>
                {
                    return svcs.SelAllCompInspectionExportData(dealerId);
                });


                MapMyShopDataToObject(res1);
                counter = servicePollInterval;
                timer1.Start();
            }

        }

        private void MapMyShopDataToObject(uspSelAllCompInspectionExportData_Result[] m)
        {
            if(m != null && m.Count() ==1)
            {

            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }




    }
}
