﻿using ATP.DataModel;
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


        public List<uspCreateSeviceAndKeyLockerBucket_TowTruck_Result> CreateSeviceAndKeyLockerBucket_TowTruck(int? dealerId, string firstName, string phone, string svcInfo, byte? serviceStatusId, 
            byte? assignedKeyLockerBucketId, byte? outdoorKeyDroppedBy) {

            using (var entity = new ATP.DataModel.Entities()) {

                var xx = entity.uspCreateSeviceAndKeyLockerBucket_TowTruck( dealerId, firstName, phone, svcInfo, serviceStatusId, assignedKeyLockerBucketId, outdoorKeyDroppedBy).ToList();

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
