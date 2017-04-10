using ATP.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ATP.WCF.Svcs {
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IOutDoor" in both code and config file together.
    [ServiceContract]
    public interface IOutDoor {


        [OperationContract]
        List<uspVerifyPinGetCustInfo_Result> VerifyPinGetCustInfo(int? dealerId, bool? isPickUpOrDrop, string keyLockerPin);

        [OperationContract]
        List<uspVerifyPinGetCustInfoExpress_Result> VerifyPinGetCustInfoExpress(Nullable<int> dealerId, string keyLockerPin);

        [OperationContract]
        List<uspSelVehicleMakes_Result> GetMakes(string year, string dealerId);

        [OperationContract]
        int InsDealerMsg(uspSelDealerMsg_Result x);

        [OperationContract]
        List<uspGetKeyLockerSteps_Result> GetKeyLockerSteps(int? dealerId, byte? keyLockerId, bool? IsDropOrPickUp);

        [OperationContract]
        List<uspSelAllKeyDropPegByDealerId_Result> SelAllKeyDropPegByDealerId(int? dealerId);

        [OperationContract]
        List<string> UpdateVehiceServiceStatus(int? dealerId, Guid? vehicleServiceGUID, Guid? vehicleGUID, Guid? personGUID, Nullable<byte> statusId, Nullable<System.Guid> updatedBy);

        [OperationContract]
        List<uspCreateSeviceAndKeyLockerBucket_TowTruck_Result> CreateSeviceAndKeyLockerBucket_TowTruck(int? dealerId, string firstName, string phone, string svcInfo, byte? serviceStatusId, 
            byte? assignedKeyLockerBucketId, byte? outdoorKeyDroppedBy);
        [OperationContract]
        List<String> UpdtVehicleServiceAndKeyLockerBucket_PhoneCustomer(int? dealerId, Guid? vehicleServiceGuid, Guid? vehicleGuid, string svcInfo, byte? serviceStatusId,
            byte? assignedKeyLockerBucketId, byte? outdoorKeyDroppedBy);

        [OperationContract]
        List<uspSelVehicleServiceDetails_Result> SelVehicleServiceDetails(int? dealerId, Guid? vehicleServiceGuid, Guid? vehicleGuid, Guid? personGuid, string svcFromDt, string svcToDt);


        [OperationContract]
         List<uspSelKioskInUSE_Result> SelKioskInUSE(int? dealerId);
        [OperationContract]
        int UpsertKioskInUSE(int? dealerId, string usedBy, Guid? lastUsedBy);

        [OperationContract]
        List<uspSelSvcTypeByDealerId_Result> GetServiceTypes(string dealerId);

        [OperationContract]
        bool LogError(string msg);
        [OperationContract]
        bool LogInformation(string msg);


        [OperationContract]
        string PingMe(string s);

    }

}
