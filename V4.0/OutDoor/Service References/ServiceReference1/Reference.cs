﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MyShopOutDoor.ServiceReference1 {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference1.IOutDoor")]
    public interface IOutDoor {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IOutDoor/VerifyPinGetCustInfo", ReplyAction="http://tempuri.org/IOutDoor/VerifyPinGetCustInfoResponse")]
        ATP.DataModel.uspVerifyPinGetCustInfo_Result[] VerifyPinGetCustInfo(System.Nullable<int> dealerId, System.Nullable<bool> isPickUpOrDrop, string keyLockerPin);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IOutDoor/VerifyPinGetCustInfo", ReplyAction="http://tempuri.org/IOutDoor/VerifyPinGetCustInfoResponse")]
        System.Threading.Tasks.Task<ATP.DataModel.uspVerifyPinGetCustInfo_Result[]> VerifyPinGetCustInfoAsync(System.Nullable<int> dealerId, System.Nullable<bool> isPickUpOrDrop, string keyLockerPin);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IOutDoor/VerifyPinGetCustInfoExpress", ReplyAction="http://tempuri.org/IOutDoor/VerifyPinGetCustInfoExpressResponse")]
        ATP.DataModel.uspVerifyPinGetCustInfoExpress_Result[] VerifyPinGetCustInfoExpress(System.Nullable<int> dealerId, string keyLockerPin);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IOutDoor/VerifyPinGetCustInfoExpress", ReplyAction="http://tempuri.org/IOutDoor/VerifyPinGetCustInfoExpressResponse")]
        System.Threading.Tasks.Task<ATP.DataModel.uspVerifyPinGetCustInfoExpress_Result[]> VerifyPinGetCustInfoExpressAsync(System.Nullable<int> dealerId, string keyLockerPin);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IOutDoor/GetMakes", ReplyAction="http://tempuri.org/IOutDoor/GetMakesResponse")]
        ATP.DataModel.uspSelVehicleMakes_Result[] GetMakes(string year, string dealerId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IOutDoor/GetMakes", ReplyAction="http://tempuri.org/IOutDoor/GetMakesResponse")]
        System.Threading.Tasks.Task<ATP.DataModel.uspSelVehicleMakes_Result[]> GetMakesAsync(string year, string dealerId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IOutDoor/InsDealerMsg", ReplyAction="http://tempuri.org/IOutDoor/InsDealerMsgResponse")]
        int InsDealerMsg(ATP.DataModel.uspSelDealerMsg_Result x);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IOutDoor/InsDealerMsg", ReplyAction="http://tempuri.org/IOutDoor/InsDealerMsgResponse")]
        System.Threading.Tasks.Task<int> InsDealerMsgAsync(ATP.DataModel.uspSelDealerMsg_Result x);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IOutDoor/GetKeyLockerSteps", ReplyAction="http://tempuri.org/IOutDoor/GetKeyLockerStepsResponse")]
        ATP.DataModel.uspGetKeyLockerSteps_Result[] GetKeyLockerSteps(System.Nullable<int> dealerId, System.Nullable<byte> keyLockerId, System.Nullable<bool> IsDropOrPickUp);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IOutDoor/GetKeyLockerSteps", ReplyAction="http://tempuri.org/IOutDoor/GetKeyLockerStepsResponse")]
        System.Threading.Tasks.Task<ATP.DataModel.uspGetKeyLockerSteps_Result[]> GetKeyLockerStepsAsync(System.Nullable<int> dealerId, System.Nullable<byte> keyLockerId, System.Nullable<bool> IsDropOrPickUp);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IOutDoor/SelAllKeyDropPegByDealerId", ReplyAction="http://tempuri.org/IOutDoor/SelAllKeyDropPegByDealerIdResponse")]
        ATP.DataModel.uspSelAllKeyDropPegByDealerId_Result[] SelAllKeyDropPegByDealerId(System.Nullable<int> dealerId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IOutDoor/SelAllKeyDropPegByDealerId", ReplyAction="http://tempuri.org/IOutDoor/SelAllKeyDropPegByDealerIdResponse")]
        System.Threading.Tasks.Task<ATP.DataModel.uspSelAllKeyDropPegByDealerId_Result[]> SelAllKeyDropPegByDealerIdAsync(System.Nullable<int> dealerId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IOutDoor/UpdateVehiceServiceStatus", ReplyAction="http://tempuri.org/IOutDoor/UpdateVehiceServiceStatusResponse")]
        string[] UpdateVehiceServiceStatus(System.Nullable<int> dealerId, System.Nullable<System.Guid> vehicleServiceGUID, System.Nullable<System.Guid> vehicleGUID, System.Nullable<System.Guid> personGUID, System.Nullable<byte> statusId, System.Nullable<System.Guid> updatedBy);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IOutDoor/UpdateVehiceServiceStatus", ReplyAction="http://tempuri.org/IOutDoor/UpdateVehiceServiceStatusResponse")]
        System.Threading.Tasks.Task<string[]> UpdateVehiceServiceStatusAsync(System.Nullable<int> dealerId, System.Nullable<System.Guid> vehicleServiceGUID, System.Nullable<System.Guid> vehicleGUID, System.Nullable<System.Guid> personGUID, System.Nullable<byte> statusId, System.Nullable<System.Guid> updatedBy);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IOutDoor/CreateSeviceAndKeyLockerBucket_TowTruck", ReplyAction="http://tempuri.org/IOutDoor/CreateSeviceAndKeyLockerBucket_TowTruckResponse")]
        ATP.DataModel.uspCreateSeviceAndKeyLockerBucket_TowTruck_Result[] CreateSeviceAndKeyLockerBucket_TowTruck(System.Nullable<int> dealerId, string firstName, string phone, string svcInfo, System.Nullable<byte> serviceStatusId, System.Nullable<byte> assignedKeyLockerBucketId, System.Nullable<byte> outdoorKeyDroppedBy);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IOutDoor/CreateSeviceAndKeyLockerBucket_TowTruck", ReplyAction="http://tempuri.org/IOutDoor/CreateSeviceAndKeyLockerBucket_TowTruckResponse")]
        System.Threading.Tasks.Task<ATP.DataModel.uspCreateSeviceAndKeyLockerBucket_TowTruck_Result[]> CreateSeviceAndKeyLockerBucket_TowTruckAsync(System.Nullable<int> dealerId, string firstName, string phone, string svcInfo, System.Nullable<byte> serviceStatusId, System.Nullable<byte> assignedKeyLockerBucketId, System.Nullable<byte> outdoorKeyDroppedBy);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IOutDoor/UpdtVehicleServiceAndKeyLockerBucket_PhoneCustomer", ReplyAction="http://tempuri.org/IOutDoor/UpdtVehicleServiceAndKeyLockerBucket_PhoneCustomerRes" +
            "ponse")]
        string[] UpdtVehicleServiceAndKeyLockerBucket_PhoneCustomer(System.Nullable<int> dealerId, System.Nullable<System.Guid> vehicleServiceGuid, System.Nullable<System.Guid> vehicleGuid, string svcInfo, System.Nullable<byte> serviceStatusId, System.Nullable<byte> assignedKeyLockerBucketId, System.Nullable<byte> outdoorKeyDroppedBy);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IOutDoor/UpdtVehicleServiceAndKeyLockerBucket_PhoneCustomer", ReplyAction="http://tempuri.org/IOutDoor/UpdtVehicleServiceAndKeyLockerBucket_PhoneCustomerRes" +
            "ponse")]
        System.Threading.Tasks.Task<string[]> UpdtVehicleServiceAndKeyLockerBucket_PhoneCustomerAsync(System.Nullable<int> dealerId, System.Nullable<System.Guid> vehicleServiceGuid, System.Nullable<System.Guid> vehicleGuid, string svcInfo, System.Nullable<byte> serviceStatusId, System.Nullable<byte> assignedKeyLockerBucketId, System.Nullable<byte> outdoorKeyDroppedBy);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IOutDoor/SelVehicleServiceDetails", ReplyAction="http://tempuri.org/IOutDoor/SelVehicleServiceDetailsResponse")]
        ATP.DataModel.uspSelVehicleServiceDetails_Result[] SelVehicleServiceDetails(System.Nullable<int> dealerId, System.Nullable<System.Guid> vehicleServiceGuid, System.Nullable<System.Guid> vehicleGuid, System.Nullable<System.Guid> personGuid, string svcFromDt, string svcToDt);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IOutDoor/SelVehicleServiceDetails", ReplyAction="http://tempuri.org/IOutDoor/SelVehicleServiceDetailsResponse")]
        System.Threading.Tasks.Task<ATP.DataModel.uspSelVehicleServiceDetails_Result[]> SelVehicleServiceDetailsAsync(System.Nullable<int> dealerId, System.Nullable<System.Guid> vehicleServiceGuid, System.Nullable<System.Guid> vehicleGuid, System.Nullable<System.Guid> personGuid, string svcFromDt, string svcToDt);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IOutDoor/SelKioskInUSE", ReplyAction="http://tempuri.org/IOutDoor/SelKioskInUSEResponse")]
        ATP.DataModel.uspSelKioskInUSE_Result[] SelKioskInUSE(System.Nullable<int> dealerId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IOutDoor/SelKioskInUSE", ReplyAction="http://tempuri.org/IOutDoor/SelKioskInUSEResponse")]
        System.Threading.Tasks.Task<ATP.DataModel.uspSelKioskInUSE_Result[]> SelKioskInUSEAsync(System.Nullable<int> dealerId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IOutDoor/UpsertKioskInUSE", ReplyAction="http://tempuri.org/IOutDoor/UpsertKioskInUSEResponse")]
        int UpsertKioskInUSE(System.Nullable<int> dealerId, string usedBy, System.Nullable<System.Guid> lastUsedBy);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IOutDoor/UpsertKioskInUSE", ReplyAction="http://tempuri.org/IOutDoor/UpsertKioskInUSEResponse")]
        System.Threading.Tasks.Task<int> UpsertKioskInUSEAsync(System.Nullable<int> dealerId, string usedBy, System.Nullable<System.Guid> lastUsedBy);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IOutDoor/GetServiceTypes", ReplyAction="http://tempuri.org/IOutDoor/GetServiceTypesResponse")]
        ATP.DataModel.uspSelSvcTypeByDealerId_Result[] GetServiceTypes(string dealerId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IOutDoor/GetServiceTypes", ReplyAction="http://tempuri.org/IOutDoor/GetServiceTypesResponse")]
        System.Threading.Tasks.Task<ATP.DataModel.uspSelSvcTypeByDealerId_Result[]> GetServiceTypesAsync(string dealerId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IOutDoor/SelNextExpressNumber", ReplyAction="http://tempuri.org/IOutDoor/SelNextExpressNumberResponse")]
        ATP.DataModel.uspSelNextExpressNumber_Result[] SelNextExpressNumber(int dealerId, System.DateTime scheduleDate);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IOutDoor/SelNextExpressNumber", ReplyAction="http://tempuri.org/IOutDoor/SelNextExpressNumberResponse")]
        System.Threading.Tasks.Task<ATP.DataModel.uspSelNextExpressNumber_Result[]> SelNextExpressNumberAsync(int dealerId, System.DateTime scheduleDate);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IOutDoor/ScheduleService", ReplyAction="http://tempuri.org/IOutDoor/ScheduleServiceResponse")]
        ATP.DataModel.ATPData ScheduleService(ATP.DataModel.ATPServiceDataMasterKiosk serviceDataMasterlist);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IOutDoor/ScheduleService", ReplyAction="http://tempuri.org/IOutDoor/ScheduleServiceResponse")]
        System.Threading.Tasks.Task<ATP.DataModel.ATPData> ScheduleServiceAsync(ATP.DataModel.ATPServiceDataMasterKiosk serviceDataMasterlist);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IOutDoor/SelDealerDetailsById", ReplyAction="http://tempuri.org/IOutDoor/SelDealerDetailsByIdResponse")]
        ATP.DataModel.uspSelDealerDetailsById_Result[] SelDealerDetailsById(int dealerId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IOutDoor/SelDealerDetailsById", ReplyAction="http://tempuri.org/IOutDoor/SelDealerDetailsByIdResponse")]
        System.Threading.Tasks.Task<ATP.DataModel.uspSelDealerDetailsById_Result[]> SelDealerDetailsByIdAsync(int dealerId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IOutDoor/LogError", ReplyAction="http://tempuri.org/IOutDoor/LogErrorResponse")]
        bool LogError(string msg);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IOutDoor/LogError", ReplyAction="http://tempuri.org/IOutDoor/LogErrorResponse")]
        System.Threading.Tasks.Task<bool> LogErrorAsync(string msg);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IOutDoor/LogInformation", ReplyAction="http://tempuri.org/IOutDoor/LogInformationResponse")]
        bool LogInformation(string msg);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IOutDoor/LogInformation", ReplyAction="http://tempuri.org/IOutDoor/LogInformationResponse")]
        System.Threading.Tasks.Task<bool> LogInformationAsync(string msg);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IOutDoor/PingMe", ReplyAction="http://tempuri.org/IOutDoor/PingMeResponse")]
        string PingMe(string s);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IOutDoor/PingMe", ReplyAction="http://tempuri.org/IOutDoor/PingMeResponse")]
        System.Threading.Tasks.Task<string> PingMeAsync(string s);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IOutDoorChannel : MyShopOutDoor.ServiceReference1.IOutDoor, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class OutDoorClient : System.ServiceModel.ClientBase<MyShopOutDoor.ServiceReference1.IOutDoor>, MyShopOutDoor.ServiceReference1.IOutDoor {
        
        public OutDoorClient() {
        }
        
        public OutDoorClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public OutDoorClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public OutDoorClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public OutDoorClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public ATP.DataModel.uspVerifyPinGetCustInfo_Result[] VerifyPinGetCustInfo(System.Nullable<int> dealerId, System.Nullable<bool> isPickUpOrDrop, string keyLockerPin) {
            return base.Channel.VerifyPinGetCustInfo(dealerId, isPickUpOrDrop, keyLockerPin);
        }
        
        public System.Threading.Tasks.Task<ATP.DataModel.uspVerifyPinGetCustInfo_Result[]> VerifyPinGetCustInfoAsync(System.Nullable<int> dealerId, System.Nullable<bool> isPickUpOrDrop, string keyLockerPin) {
            return base.Channel.VerifyPinGetCustInfoAsync(dealerId, isPickUpOrDrop, keyLockerPin);
        }
        
        public ATP.DataModel.uspVerifyPinGetCustInfoExpress_Result[] VerifyPinGetCustInfoExpress(System.Nullable<int> dealerId, string keyLockerPin) {
            return base.Channel.VerifyPinGetCustInfoExpress(dealerId, keyLockerPin);
        }
        
        public System.Threading.Tasks.Task<ATP.DataModel.uspVerifyPinGetCustInfoExpress_Result[]> VerifyPinGetCustInfoExpressAsync(System.Nullable<int> dealerId, string keyLockerPin) {
            return base.Channel.VerifyPinGetCustInfoExpressAsync(dealerId, keyLockerPin);
        }
        
        public ATP.DataModel.uspSelVehicleMakes_Result[] GetMakes(string year, string dealerId) {
            return base.Channel.GetMakes(year, dealerId);
        }
        
        public System.Threading.Tasks.Task<ATP.DataModel.uspSelVehicleMakes_Result[]> GetMakesAsync(string year, string dealerId) {
            return base.Channel.GetMakesAsync(year, dealerId);
        }
        
        public int InsDealerMsg(ATP.DataModel.uspSelDealerMsg_Result x) {
            return base.Channel.InsDealerMsg(x);
        }
        
        public System.Threading.Tasks.Task<int> InsDealerMsgAsync(ATP.DataModel.uspSelDealerMsg_Result x) {
            return base.Channel.InsDealerMsgAsync(x);
        }
        
        public ATP.DataModel.uspGetKeyLockerSteps_Result[] GetKeyLockerSteps(System.Nullable<int> dealerId, System.Nullable<byte> keyLockerId, System.Nullable<bool> IsDropOrPickUp) {
            return base.Channel.GetKeyLockerSteps(dealerId, keyLockerId, IsDropOrPickUp);
        }
        
        public System.Threading.Tasks.Task<ATP.DataModel.uspGetKeyLockerSteps_Result[]> GetKeyLockerStepsAsync(System.Nullable<int> dealerId, System.Nullable<byte> keyLockerId, System.Nullable<bool> IsDropOrPickUp) {
            return base.Channel.GetKeyLockerStepsAsync(dealerId, keyLockerId, IsDropOrPickUp);
        }
        
        public ATP.DataModel.uspSelAllKeyDropPegByDealerId_Result[] SelAllKeyDropPegByDealerId(System.Nullable<int> dealerId) {
            return base.Channel.SelAllKeyDropPegByDealerId(dealerId);
        }
        
        public System.Threading.Tasks.Task<ATP.DataModel.uspSelAllKeyDropPegByDealerId_Result[]> SelAllKeyDropPegByDealerIdAsync(System.Nullable<int> dealerId) {
            return base.Channel.SelAllKeyDropPegByDealerIdAsync(dealerId);
        }
        
        public string[] UpdateVehiceServiceStatus(System.Nullable<int> dealerId, System.Nullable<System.Guid> vehicleServiceGUID, System.Nullable<System.Guid> vehicleGUID, System.Nullable<System.Guid> personGUID, System.Nullable<byte> statusId, System.Nullable<System.Guid> updatedBy) {
            return base.Channel.UpdateVehiceServiceStatus(dealerId, vehicleServiceGUID, vehicleGUID, personGUID, statusId, updatedBy);
        }
        
        public System.Threading.Tasks.Task<string[]> UpdateVehiceServiceStatusAsync(System.Nullable<int> dealerId, System.Nullable<System.Guid> vehicleServiceGUID, System.Nullable<System.Guid> vehicleGUID, System.Nullable<System.Guid> personGUID, System.Nullable<byte> statusId, System.Nullable<System.Guid> updatedBy) {
            return base.Channel.UpdateVehiceServiceStatusAsync(dealerId, vehicleServiceGUID, vehicleGUID, personGUID, statusId, updatedBy);
        }
        
        public ATP.DataModel.uspCreateSeviceAndKeyLockerBucket_TowTruck_Result[] CreateSeviceAndKeyLockerBucket_TowTruck(System.Nullable<int> dealerId, string firstName, string phone, string svcInfo, System.Nullable<byte> serviceStatusId, System.Nullable<byte> assignedKeyLockerBucketId, System.Nullable<byte> outdoorKeyDroppedBy) {
            return base.Channel.CreateSeviceAndKeyLockerBucket_TowTruck(dealerId, firstName, phone, svcInfo, serviceStatusId, assignedKeyLockerBucketId, outdoorKeyDroppedBy);
        }
        
        public System.Threading.Tasks.Task<ATP.DataModel.uspCreateSeviceAndKeyLockerBucket_TowTruck_Result[]> CreateSeviceAndKeyLockerBucket_TowTruckAsync(System.Nullable<int> dealerId, string firstName, string phone, string svcInfo, System.Nullable<byte> serviceStatusId, System.Nullable<byte> assignedKeyLockerBucketId, System.Nullable<byte> outdoorKeyDroppedBy) {
            return base.Channel.CreateSeviceAndKeyLockerBucket_TowTruckAsync(dealerId, firstName, phone, svcInfo, serviceStatusId, assignedKeyLockerBucketId, outdoorKeyDroppedBy);
        }
        
        public string[] UpdtVehicleServiceAndKeyLockerBucket_PhoneCustomer(System.Nullable<int> dealerId, System.Nullable<System.Guid> vehicleServiceGuid, System.Nullable<System.Guid> vehicleGuid, string svcInfo, System.Nullable<byte> serviceStatusId, System.Nullable<byte> assignedKeyLockerBucketId, System.Nullable<byte> outdoorKeyDroppedBy) {
            return base.Channel.UpdtVehicleServiceAndKeyLockerBucket_PhoneCustomer(dealerId, vehicleServiceGuid, vehicleGuid, svcInfo, serviceStatusId, assignedKeyLockerBucketId, outdoorKeyDroppedBy);
        }
        
        public System.Threading.Tasks.Task<string[]> UpdtVehicleServiceAndKeyLockerBucket_PhoneCustomerAsync(System.Nullable<int> dealerId, System.Nullable<System.Guid> vehicleServiceGuid, System.Nullable<System.Guid> vehicleGuid, string svcInfo, System.Nullable<byte> serviceStatusId, System.Nullable<byte> assignedKeyLockerBucketId, System.Nullable<byte> outdoorKeyDroppedBy) {
            return base.Channel.UpdtVehicleServiceAndKeyLockerBucket_PhoneCustomerAsync(dealerId, vehicleServiceGuid, vehicleGuid, svcInfo, serviceStatusId, assignedKeyLockerBucketId, outdoorKeyDroppedBy);
        }
        
        public ATP.DataModel.uspSelVehicleServiceDetails_Result[] SelVehicleServiceDetails(System.Nullable<int> dealerId, System.Nullable<System.Guid> vehicleServiceGuid, System.Nullable<System.Guid> vehicleGuid, System.Nullable<System.Guid> personGuid, string svcFromDt, string svcToDt) {
            return base.Channel.SelVehicleServiceDetails(dealerId, vehicleServiceGuid, vehicleGuid, personGuid, svcFromDt, svcToDt);
        }
        
        public System.Threading.Tasks.Task<ATP.DataModel.uspSelVehicleServiceDetails_Result[]> SelVehicleServiceDetailsAsync(System.Nullable<int> dealerId, System.Nullable<System.Guid> vehicleServiceGuid, System.Nullable<System.Guid> vehicleGuid, System.Nullable<System.Guid> personGuid, string svcFromDt, string svcToDt) {
            return base.Channel.SelVehicleServiceDetailsAsync(dealerId, vehicleServiceGuid, vehicleGuid, personGuid, svcFromDt, svcToDt);
        }
        
        public ATP.DataModel.uspSelKioskInUSE_Result[] SelKioskInUSE(System.Nullable<int> dealerId) {
            return base.Channel.SelKioskInUSE(dealerId);
        }
        
        public System.Threading.Tasks.Task<ATP.DataModel.uspSelKioskInUSE_Result[]> SelKioskInUSEAsync(System.Nullable<int> dealerId) {
            return base.Channel.SelKioskInUSEAsync(dealerId);
        }
        
        public int UpsertKioskInUSE(System.Nullable<int> dealerId, string usedBy, System.Nullable<System.Guid> lastUsedBy) {
            return base.Channel.UpsertKioskInUSE(dealerId, usedBy, lastUsedBy);
        }
        
        public System.Threading.Tasks.Task<int> UpsertKioskInUSEAsync(System.Nullable<int> dealerId, string usedBy, System.Nullable<System.Guid> lastUsedBy) {
            return base.Channel.UpsertKioskInUSEAsync(dealerId, usedBy, lastUsedBy);
        }
        
        public ATP.DataModel.uspSelSvcTypeByDealerId_Result[] GetServiceTypes(string dealerId) {
            return base.Channel.GetServiceTypes(dealerId);
        }
        
        public System.Threading.Tasks.Task<ATP.DataModel.uspSelSvcTypeByDealerId_Result[]> GetServiceTypesAsync(string dealerId) {
            return base.Channel.GetServiceTypesAsync(dealerId);
        }
        
        public ATP.DataModel.uspSelNextExpressNumber_Result[] SelNextExpressNumber(int dealerId, System.DateTime scheduleDate) {
            return base.Channel.SelNextExpressNumber(dealerId, scheduleDate);
        }
        
        public System.Threading.Tasks.Task<ATP.DataModel.uspSelNextExpressNumber_Result[]> SelNextExpressNumberAsync(int dealerId, System.DateTime scheduleDate) {
            return base.Channel.SelNextExpressNumberAsync(dealerId, scheduleDate);
        }
        
        public ATP.DataModel.ATPData ScheduleService(ATP.DataModel.ATPServiceDataMasterKiosk serviceDataMasterlist) {
            return base.Channel.ScheduleService(serviceDataMasterlist);
        }
        
        public System.Threading.Tasks.Task<ATP.DataModel.ATPData> ScheduleServiceAsync(ATP.DataModel.ATPServiceDataMasterKiosk serviceDataMasterlist) {
            return base.Channel.ScheduleServiceAsync(serviceDataMasterlist);
        }
        
        public ATP.DataModel.uspSelDealerDetailsById_Result[] SelDealerDetailsById(int dealerId) {
            return base.Channel.SelDealerDetailsById(dealerId);
        }
        
        public System.Threading.Tasks.Task<ATP.DataModel.uspSelDealerDetailsById_Result[]> SelDealerDetailsByIdAsync(int dealerId) {
            return base.Channel.SelDealerDetailsByIdAsync(dealerId);
        }
        
        public bool LogError(string msg) {
            return base.Channel.LogError(msg);
        }
        
        public System.Threading.Tasks.Task<bool> LogErrorAsync(string msg) {
            return base.Channel.LogErrorAsync(msg);
        }
        
        public bool LogInformation(string msg) {
            return base.Channel.LogInformation(msg);
        }
        
        public System.Threading.Tasks.Task<bool> LogInformationAsync(string msg) {
            return base.Channel.LogInformationAsync(msg);
        }
        
        public string PingMe(string s) {
            return base.Channel.PingMe(s);
        }
        
        public System.Threading.Tasks.Task<string> PingMeAsync(string s) {
            return base.Channel.PingMeAsync(s);
        }
    }
}
