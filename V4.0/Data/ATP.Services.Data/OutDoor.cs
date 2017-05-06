using ATP.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATP.Services.Data {
    public class OutDoor {

        public List<uspVerifyPinGetCustInfo_Result> VerifyPinGetCustInfo(Nullable<int> dealerId, Nullable<bool> isPickUpOrDrop, string keyLockerPin) {

            using (var entity = new ATP.DataModel.Entities()) {

                var xx = entity.uspVerifyPinGetCustInfo(dealerId, isPickUpOrDrop, keyLockerPin).ToList();

                return xx;
            }
        }

        public List<uspVerifyPinGetCustInfoExpress_Result> VerifyPinGetCustInfoExpress(Nullable<int> dealerId,  string keyLockerPin)
        {

            using (var entity = new ATP.DataModel.Entities())
            {

                var xx = entity.uspVerifyPinGetCustInfoExpress(dealerId, keyLockerPin).ToList();

                return xx;
            }
        }

        public List<uspGetKeyLockerSteps_Result> GetKeyLockerSteps(int? dealerId, byte? keyLockerId, bool? IsDropOrPickUp) {

            using (var entity = new ATP.DataModel.Entities()) {

                var xx = entity.uspGetKeyLockerSteps(dealerId, keyLockerId, IsDropOrPickUp).ToList();

                return xx;
            }
        }

        public List<uspSelVehicleServiceDetails_Result> SelVehicleServiceDetails(int? dealerId, Guid? vehicleServiceGuid, Guid? vehicleGuid, Guid? personGuid, string svcFromDt, string svcToDt) {

            using (var entity = new ATP.DataModel.Entities()) {

                var xx = entity.uspSelVehicleServiceDetails(dealerId, vehicleServiceGuid, vehicleGuid, personGuid,svcFromDt,svcFromDt).ToList();

                return xx;
            }
        }


        public List<uspSelAllKeyDropPegByDealerId_Result> SelAllKeyDropPegByDealerId(int? dealerId) {

            using (var entity = new ATP.DataModel.Entities()) {

                var xx = entity.uspSelAllKeyDropPegByDealerId(dealerId).ToList();

                return xx;
            }
        }


        public int CreateSeviceAndKeyLockerBucket_TowTruck(int? dealerId, string firstName, string phone, string svcInfo, byte? serviceStatusId, 
            byte? assignedKeyLockerBucketId, byte? outdoorKeyDroppedBy) {

            using (var entity = new ATP.DataModel.CustomEntities()) {

                var xx = entity.uspCreateSeviceAndKeyLockerBucket_TowTruck(dealerId, firstName, phone, svcInfo, serviceStatusId, assignedKeyLockerBucketId, outdoorKeyDroppedBy,null);

                return xx;
            }
        }

        public int CreateSeviceAndKeyLockerBucket_TowTruckAndNoApp(int? dealerId, string firstName, string phone, string svcInfo, byte? serviceStatusId,
            byte? assignedKeyLockerBucketId, byte? outdoorKeyDroppedBy, List<ATPServiceData> serviceDataList)
        {

            using (var entity = new ATP.DataModel.CustomEntities())
            {

                var xx = entity.uspCreateSeviceAndKeyLockerBucket_TowTruck(dealerId, firstName, phone, svcInfo, serviceStatusId, assignedKeyLockerBucketId, outdoorKeyDroppedBy, serviceDataList);

                return xx;
            }
        }


        public int CreateSeviceForSTO(int? dealerId, Guid? personGuid, Guid? svcGuid, string firstName, string phone, string svcInfo, byte? serviceStatusId,List<ATPServiceData> serviceDataList,int expressNumber)
        {

            using (var entity = new ATP.DataModel.CustomEntities())
            {

                var xx = entity.CreateSeviceForSTO(dealerId, firstName, phone, svcInfo, serviceStatusId, personGuid, svcGuid, serviceDataList, expressNumber);

                return xx;
            }
        }


        public List<String> UpdtVehicleServiceAndKeyLockerBucket_PhoneCustomer(int? dealerId, Guid? vehicleServiceGuid, Guid? vehicleGuid, string svcInfo, byte? serviceStatusId,  byte? assignedKeyLockerBucketId
            , byte? outdoorKeyDroppedBy) {

            using (var entity = new ATP.DataModel.Entities()) {

                var xx = entity.uspUpdtVehicleServiceAndKeyLockerBucket_PhoneCustomer(dealerId, vehicleServiceGuid, vehicleGuid, svcInfo, serviceStatusId, assignedKeyLockerBucketId,outdoorKeyDroppedBy).ToList();

                return xx;
            }
        }



        public int UpdtVehSvcAndKeyLocker_AppAndNoApp(int? dealerId, Guid? vehicleServiceGuid, Guid? vehicleGuid, string svcInfo, int serviceStatusId, byte? assignedKeyLockerBucketId
          , byte? outdoorKeyDroppedBy,List<ATPServiceData> serviceDataList)
        {

            int? dealid = Convert.ToInt32(dealerId);
             var vehGuid = new Guid(vehicleGuid.ToString());


            var rtnValue = new uspAssignKeylockerPinForExpressCheckIn_Result();
            try
            {
                
                var vehicleServicesDataTable = new VehicleServicesDataTable
                {
                    ADAM = false,
                    Amount = 0,
                    Date = DateTime.Now,
                    DealerId = dealid,
                    EnteredBy = vehGuid,
                    ExpressNumber = 0,
                    KioskId = 1,
                    Mileage = 1,
                    PackageCost = 1,
                    Paid = false,
                    ServiceCost = 1,
                    StatusId = serviceStatusId,
                    VehicleGUID = vehGuid,
                    Reason = svcInfo
                };

                    
                    List<VehicleServicesDataTable> vehsvcs = new List<VehicleServicesDataTable>();
                    vehsvcs.Add(vehicleServicesDataTable);

                    var ss = new ATP.Services.Data.VehicleService().SaveVehicleServices(vehsvcs, serviceDataList);

                return ss;

                //return new ATPData { Id = rtnValue.KeyLockerPin, Value = rtnValue.Comments };
            }
            catch (Exception ex)
            {
                return -1;
            };

        }



        public List<uspSelKioskInUSE_Result> SelKioskInUSE(int? dealerId) {

            using (var entity = new ATP.DataModel.Entities()) {

                var xx = entity.uspSelKioskInUSE(dealerId).ToList();

                return xx;
            }
        }


        public int UpsertKioskInUSE(int? dealerId, string usedBy, Guid? lastUsedB) {

            using (var entity = new ATP.DataModel.Entities()) {

                var xx = entity.uspUpsertKioskInUSE(dealerId, usedBy,lastUsedB);

                return xx;
            }
        }


        public List<uspSelNextExpressNumber_Result> SelNextExpressNumber(int dealerId, DateTime scheduleDate)
        {
            return new ATP.Services.Data.Dealer().SelNextExpressNumber(dealerId, scheduleDate);
        }



    }
}
