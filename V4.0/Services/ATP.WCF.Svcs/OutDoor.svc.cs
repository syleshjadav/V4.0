using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using ATP.DataModel;

namespace ATP.WCF.Svcs {
    [ServiceErrorBehaviour(typeof(HttpErrorHandler))]
    public class OutDoor : IOutDoor {
        public List<uspVerifyPinGetCustInfo_Result> VerifyPinGetCustInfo(Nullable<int> dealerId, Nullable<bool> isPickUpOrDrop, string keyLockerPin) {
            return new ATP.Services.Data.OutDoor().VerifyPinGetCustInfo(dealerId, isPickUpOrDrop, keyLockerPin).ToList();
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

        public List<uspCreateSeviceAndKeyLockerBucket_TowTruck_Result> CreateSeviceAndKeyLockerBucket_TowTruck(int? dealerId, string firstName, string phone, string svcInfo, byte? serviceStatusId, byte? assignedKeyLockerBucketId) {
            return new ATP.Services.Data.OutDoor().CreateSeviceAndKeyLockerBucket_TowTruck(dealerId, firstName, phone, svcInfo, serviceStatusId, assignedKeyLockerBucketId);

        }
    }
}
