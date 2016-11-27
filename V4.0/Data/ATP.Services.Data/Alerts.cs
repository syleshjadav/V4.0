using System;
using System.Collections.Generic;
using System.Linq;
using ATP.DataModel;



    namespace ATP.Services.Data
{
    public class Alerts
    {
      
        public List<uspSelVehAlertByVehSvcGuid_Result> SelVehAlertByVehGuid(string Token, Guid vehicleServiceGuid)
        {

            try
            {
                using (var entity = new ATP.DataModel.Entities())
                {
                    return entity.uspSelVehAlertByVehSvcGuid(vehicleServiceGuid).ToList();
                }
            }
            catch (Exception ex)
            {

            }

            return new List<uspSelVehAlertByVehSvcGuid_Result>();
        }




        public int InsVehAlert(string Token, uspSelVehAlertByVehSvcGuid_Result alert)
        {

            try
            {
                using (var entity = new ATP.DataModel.Entities())
                {
                    return entity.uspInsVehAlert(alert.AlertId, alert.VehicleGUID, alert.VehicleServiceGuid, null, alert.ResponseRequested, DateTime.Now, alert.Retrieved, alert.Response, alert.ResponseSource, alert.ResponseReceived, alert.Text, alert.Entered);
                }

            }
            catch (Exception ex)
            {

            }

            return 0;
        }
         
    }
}
