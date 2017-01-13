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

        public List<uspGetKeyLockerSteps_Result> GetKeyLockerSteps(int? dealerId, byte? keyLockerId, bool? IsDropOrPickUp) {

            using (var entity = new ATP.DataModel.Entities()) {

                var xx = entity.uspGetKeyLockerSteps(dealerId, keyLockerId, IsDropOrPickUp).ToList();

                return xx;
            }
        }


        public List<uspSelAllKeyDropPegByDealerId_Result> SelAllKeyDropPegByDealerId(int? dealerId) {

            using (var entity = new ATP.DataModel.Entities()) {

                var xx = entity.uspSelAllKeyDropPegByDealerId(dealerId).ToList();

                return xx;
            }
        }


        public List<uspCreateSeviceAndKeyLockerBucket_TowTruck_Result> CreateSeviceAndKeyLockerBucket_TowTruck(int? dealerId, string firstName, string phone, string svcInfo, byte? serviceStatusId, byte? assignedKeyLockerBucketId) {

            using (var entity = new ATP.DataModel.Entities()) {

                var xx = entity.uspCreateSeviceAndKeyLockerBucket_TowTruck( dealerId, firstName, phone, svcInfo, serviceStatusId, assignedKeyLockerBucketId).ToList();

                return xx;
            }
        }


        public List<String> UpdtVehicleServiceAndKeyLockerBucket_PhoneCustomer(int? dealerId, Guid? vehicleServiceGuid, Guid? vehicleGuid, string svcInfo, byte? serviceStatusId,  byte? assignedKeyLockerBucketId) {

            using (var entity = new ATP.DataModel.Entities()) {

                var xx = entity.uspUpdtVehicleServiceAndKeyLockerBucket_PhoneCustomer(dealerId, vehicleServiceGuid, vehicleGuid, svcInfo, serviceStatusId, assignedKeyLockerBucketId).ToList();

                return xx;
            }
        }


    }
}
