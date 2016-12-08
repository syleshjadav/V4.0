using ATP.DataModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinTester {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) {
            string Plate = string.Empty;
            string Phone = string.Empty;
            string Email = "sasi@ibc.com";
            try {

                //var mx = new ATP.Services.Data.Person().FindCustomerByPhPlateEmail(Plate, Phone, Email);

                //var xx = mx
                //     .Select(m =>
                //     new ATPCustomerDetailsByGuid {

                //         DealerFamilyId = "5",
                //         DealerId = m.DealerId.ToString(),
                //         DealerName = m.DealerName,
                //         // DealerPersonGroupId = m.DealerPersonGroupId,
                //         EmailAddress = m.EmailAddress,
                //         FirstName = m.FirstName,
                //         GoogleGuid = m.GoogleGuid,
                //         //  GroupName = m.GroupName,
                //         //  IsValid = m.IsValid.ToString(),
                //         LastName = m.LastName,
                //         MiddleName = m.MiddleName,
                //         //  NextInspectionDate = m.NextInspectionDate,
                //         //  NextServiceDate = m.NextServiceDate,
                //         PersonGuid = m.PersonGuid.ToString(),
                //         PhoneNumber = m.PhoneNumber,
                //         Plate = m.Plate,
                //         //  NextSvcInfo = m.NextSvcInfo,
                //         VehicleGuid = m.VehicleGuid.ToString(),
                //         VehicleMake = m.VehicleMake,
                //         VehicleModel = m.VehicleModel,
                //         VehicleName = m.VehicleName,
                //         VehicleTrim = m.VehicleTrim,
                //         VehicleYear = m.VehicleYear != null ? m.VehicleYear.ToString() : "",
                //         VehicleYrMkMod = m.VehicleYrMkMod,
                //         VIN = m.VIN,
                //         VehicleId = m.VehicleId.ToString(),
                //         VehPhId = m.VehPhId
                //     }).ToList();

            }
            catch (Exception ex) {

                // TraceLog("FindCustomerByPhPlateEmail", string.Format("{0} -  Error while FindCustomerByPhPlateEmail  - {1}", Email, ex.Message));
                MessageBox.Show(ex.Message);
            }

            // return new List<ATPCustomerDetailsByGuid>();

        }
    }
}

