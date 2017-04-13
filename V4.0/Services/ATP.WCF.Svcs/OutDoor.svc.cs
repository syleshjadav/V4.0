using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using ATP.DataModel;
using Elmah;

namespace ATP.WCF.Svcs {
    [ServiceErrorBehaviour(typeof(HttpErrorHandler))]
    public class OutDoor : IOutDoor {
        public List<uspVerifyPinGetCustInfo_Result> VerifyPinGetCustInfo(Nullable<int> dealerId, Nullable<bool> isPickUpOrDrop, string keyLockerPin) {
            return new ATP.Services.Data.OutDoor().VerifyPinGetCustInfo(dealerId, isPickUpOrDrop, keyLockerPin).ToList();
        }

        public List<uspVerifyPinGetCustInfoExpress_Result> VerifyPinGetCustInfoExpress(Nullable<int> dealerId, string keyLockerPin)
        {
            return new ATP.Services.Data.OutDoor().VerifyPinGetCustInfoExpress(dealerId, keyLockerPin).ToList();
        }



        public List<uspSelVehicleMakes_Result> GetMakes(string year, string dealerId) {
           var xx =new  ATP.Services.Data.VehicleService().GetMakes(year, dealerId);
            return xx;

        }

        public int InsDealerMsg(uspSelDealerMsg_Result x) {
            return new ATP.Services.Data.Dealer().InsDealerMsgWeb(x);
        }

        public List<uspGetKeyLockerSteps_Result> GetKeyLockerSteps(int? dealerId, byte? keyLockerId, bool? IsDropOrPickUp) {
            return new ATP.Services.Data.OutDoor().GetKeyLockerSteps(dealerId,keyLockerId,IsDropOrPickUp);
        }


        public List<uspSelAllKeyDropPegByDealerId_Result> SelAllKeyDropPegByDealerId(int? dealerId) {
            return new ATP.Services.Data.OutDoor().SelAllKeyDropPegByDealerId(dealerId);
        }

        public List<string> UpdateVehiceServiceStatus(int? dealerId, Guid? vehicleServiceGUID, Guid? vehicleGUID, Guid? personGUID, Nullable<byte> statusId, Nullable<System.Guid> updatedBy) {
            return new ATP.Services.Data.VehicleService().UpdateVehiceServiceStatus(dealerId, vehicleServiceGUID,vehicleGUID,personGUID, statusId, updatedBy);

        }

        public List<uspCreateSeviceAndKeyLockerBucket_TowTruck_Result> CreateSeviceAndKeyLockerBucket_TowTruck(int? dealerId, string firstName, string phone, string svcInfo, byte? serviceStatusId, byte? assignedKeyLockerBucketId, byte? outdoorKeyDroppedBy) {
            return new ATP.Services.Data.OutDoor().CreateSeviceAndKeyLockerBucket_TowTruck(dealerId, firstName, phone, svcInfo, serviceStatusId, assignedKeyLockerBucketId, outdoorKeyDroppedBy);

        }

        public List<String> UpdtVehicleServiceAndKeyLockerBucket_PhoneCustomer(int? dealerId, Guid? vehicleServiceGuid, Guid? vehicleGuid, string svcInfo, byte? serviceStatusId, byte? assignedKeyLockerBucketId, byte? outdoorKeyDroppedBy) {
            return new ATP.Services.Data.OutDoor().UpdtVehicleServiceAndKeyLockerBucket_PhoneCustomer(dealerId, vehicleServiceGuid, vehicleGuid, svcInfo, serviceStatusId, assignedKeyLockerBucketId, outdoorKeyDroppedBy);

        }

        public List<uspSelVehicleServiceDetails_Result> SelVehicleServiceDetails(int? dealerId, Guid? vehicleServiceGuid, Guid? vehicleGuid, Guid? personGuid, string svcFromDt, string svcToDt) {
            return new ATP.Services.Data.OutDoor().SelVehicleServiceDetails(dealerId, vehicleServiceGuid, vehicleGuid, personGuid, svcFromDt, svcFromDt);
        }


        public List<uspSelKioskInUSE_Result> SelKioskInUSE(int? dealerId) {

            return new ATP.Services.Data.OutDoor().SelKioskInUSE(dealerId);
        }



        public List<uspSelSvcTypeByDealerId_Result> GetServiceTypes(string dealerId)
        {
            return new ATP.Services.Data.VehicleService().GetServiceTypes(dealerId, null);
        }

        public List<uspSelNextExpressNumber_Result> SelNextExpressNumber(int dealerId, DateTime scheduleDate)
        {
            return new ATP.Services.Data.Dealer().SelNextExpressNumber(dealerId, scheduleDate);
        }

        public ATPData ScheduleService(ATPServiceDataMasterKiosk serviceDataMasterlist)
        {
            var msg = new ATPData { Id = "-1", Value = "Failure" };
            var dealerId = serviceDataMasterlist.DealerId;
 

            var serviceList = serviceDataMasterlist.ATPServiceDataList.ToList();


            if (serviceDataMasterlist.PersonGuid.ToString().Length > 10)
            {
                var vehicleServicesDataTable = new VehicleServicesDataTable
                {
                    ADAM = false,
                    Amount = (double)serviceDataMasterlist.Amount,
                    Date = DateTime.Now,
                    DealerId = serviceDataMasterlist.DealerId,
                    EnteredBy = serviceDataMasterlist.PersonGuid,
                    RONumber = serviceDataMasterlist.RONumber,
                    ExpressNumber = serviceDataMasterlist.ExpressNumber,
                    KioskId = serviceDataMasterlist.KioskId,
                    KeyTagBarCodeId = serviceDataMasterlist.KeyTagBarCodeId,
                    Mileage = serviceDataMasterlist.Mileage,
                    PackageCost = serviceDataMasterlist.PackageCost,
                    Paid = false,
                    ServiceCost = serviceDataMasterlist.ServiceCost,
                    StatusId = serviceDataMasterlist.StatusId,
                    VehicleGUID = serviceDataMasterlist.VehicleGuid,
                    Reason = serviceDataMasterlist.Reason

                };

                if (!String.IsNullOrEmpty(serviceDataMasterlist.EnteredBy))
                {
                    vehicleServicesDataTable.EnteredBy = new Guid(serviceDataMasterlist.EnteredBy);
                }

                List<VehicleServicesDataTable> vehsvcs = new List<VehicleServicesDataTable>();
                vehsvcs.Add(vehicleServicesDataTable);

                var ss = new ATP.Services.Data.VehicleService().SaveVehicleServices(vehsvcs, serviceList);

                msg.Id = "1";
                msg.Value = "Your Wait Time is 30 mts.";

            }
            else
            {
                msg.Id = "-1";
                msg.Value = "Failed due to Invalid Customer Vehicle Registration";

            }

            return msg;

        }


        public List<uspSelDealerDetailsById_Result> SelDealerDetailsById(int dealerId)
        {
            return new ATP.Services.Data.Dealer().SelDealerDetailsById(dealerId);
        }

        public int UpsertKioskInUSE(int? dealerId, string usedBy, Guid? lastUsedBy) {

            return new ATP.Services.Data.OutDoor().UpsertKioskInUSE(dealerId, usedBy, lastUsedBy);
        }

        public string PingMe(string s) {
            return s;
        }

        public bool LogError(string msg) {
            Elmah.ErrorLog.GetDefault(null).Log(new Error { Message = msg, Source = "Unknown", Type = "Exception", Time = DateTime.UtcNow });

            // throw new Exception(msg);
            return true;
        }

        public bool LogInformation(string msg) {
            Elmah.ErrorLog.GetDefault(null).Log(new Error { Message = msg, Source = "Unknown", Type = "Information", Time = DateTime.UtcNow });

            // throw new Exception(msg);
            return true;
        }
    }
}
