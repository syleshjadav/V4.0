using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;

using System.Runtime.Serialization;
using ATP.DataModel;


namespace ATP.Rest {
    [System.ServiceModel.ServiceContract(Name = "IRestSvs", Namespace = "http://www.adamkiosks.com/ATPRestServices/RestSvs")]
    public interface IRestSvs {

        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json, UriTemplate = "LoginDealerEmployeeTest/{dealerid}/{empEmail}/{empPassword}", BodyStyle = WebMessageBodyStyle.Wrapped)]
        ATPLoginDealerEmp LoginDealerEmployeeTest(string dealerId, string empEmail, string empPassword);

        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json, UriTemplate = "SelMPIRedYellowByPersonGuid/{dealerid}/{pGuid}/{VehPhId}", BodyStyle = WebMessageBodyStyle.Wrapped)]
        List<ATPDataMPIRedYellow> SelMPIRedYellowByPersonGuid(string dealerId, string pGuid, string VehPhId);



        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json, UriTemplate = "SelCustomerDetailsByGuid/{dealerid}/{pGuid}/{vehicleId}", BodyStyle = WebMessageBodyStyle.Wrapped)]
        List<ATPCustomerDetailsByGuid> SelCustomerDetailsByGuid(string dealerId, string pGuid, string vehicleId);



        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json, UriTemplate = "VerifyOTP/{pGuid}/{OTP}", BodyStyle = WebMessageBodyStyle.Wrapped)]
        List<ATPCustomerDetailsByGuid> VerifyOTP(string pGuid, string OTP);

        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json, UriTemplate = "DeleteCustomer/{pGuid}", BodyStyle = WebMessageBodyStyle.Wrapped)]
        ATPData DeleteCustomer(string pGuid);

        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json, UriTemplate = "FindCustomerByPhPlateEmail/{plate}/{phone}/{email}", BodyStyle = WebMessageBodyStyle.Wrapped)]

        List<ATPCustomerDetailsByGuid> FindCustomerByPhPlateEmail(string plate, string phone, string email);


        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json, UriTemplate = "SendOTPEmail/{pGuid}/{vGuid}/{Email}", BodyStyle = WebMessageBodyStyle.Wrapped)]
        ATPData SendOTPEmail(string pGuid, string vGuid, string Email);

        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "UpdateMPIRedYellow")]
        ATPData UpdateMPIRedYellow(ATPDataMPIRedYellow updateMPI);


        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json, UriTemplate = "GetDealerGroups", BodyStyle = WebMessageBodyStyle.Wrapped)]
        List<ATPData> GetDealerGroups();

        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json, UriTemplate = "GetAllLogs", BodyStyle = WebMessageBodyStyle.Wrapped)]
        List<ATPErrorLog> GetAllLogs();

        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json, UriTemplate = "GetDealers/{dealerGroupId}", BodyStyle = WebMessageBodyStyle.Wrapped)]
        List<ATPData> GetDealers(string dealerGroupId);

        //[OperationContract]
        //[WebGet(ResponseFormat = WebMessageFormat.Json, UriTemplate = "GetVinDetails/{vin}", BodyStyle = WebMessageBodyStyle.Wrapped)]
        //string GetVinDetails(string vin);

        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json, UriTemplate = "GetDealerDetails/{dealerId}", BodyStyle = WebMessageBodyStyle.Wrapped)]
        List<ATPDealerDetails> GetDealerDetails(string dealerId);

        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "GetAlerts/{dealerid}/{vin}/{lastname}/{miles}")]
        ATPAlertData GetAlerts(string dealerId, string vin, string lastName, string miles);

        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "GetChatMessages/{dealerid}/{vin}/{firstname}/{lastname}")]
        List<ATPAlertData> GetChatMessages(string dealerId, string vin, string firstName, string lastName);




        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "GetChatMessagesLite/{dealerid}/{pGuid}/{firstname}/{lastname}")]
        List<ATPAlertData> GetChatMessagesLite(string dealerId, string pGuid, string firstName, string lastName);


        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "GetChatMsgLite/{dealerid}/{pGuid}/{firstname}/{lastname}")]
        List<ATPAlertDataNew> GetChatMsgLite(string dealerId, string pGuid, string firstName, string lastName);





        [System.ServiceModel.OperationContract]
        [System.ServiceModel.Web.WebGet(UriTemplate = "GetAlertDuration", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        string GetAlertDuration();


        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json, UriTemplate = "GetYears", BodyStyle = WebMessageBodyStyle.Wrapped)]
        List<ATPData> GetYears();

        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "GetMakes/{year}/{dealerId}")]
        List<ATPData> GetMakes(string year, string dealerId);

        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "GetModels/{year}/{makeId}")]
        List<ATPData> GetModels(string year, string makeId);

        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "GetTrims/{year}/{makeId}/{modelId}")]
        List<ATPData> GetTrims(string year, string makeId, string modelId);

        [WebInvoke(RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "ValidateCustomer/{FirstName}/{LastName}/{VIN}/{DealerId}/{DealerFamilyId}")]
        ATPData ValidateCustomer(string FirstName, string LastName, string VIN, string DealerId, string DealerFamilyId);

        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "RegisterCustomer")]
        ATPData RegisterCustomer(CustomerForRestSvc jSonCustomer);

        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "RegisterCustomerLite")]
        ATPData RegisterCustomerLite(CustomerForRestSvcLite jSonCust);


        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "RegisterCustomerMyShopAuto")]
        MyShopRegisterCustomerData RegisterCustomerMyShopAuto(ATPCustomerDetailsByGuid jsonCust);

        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "GetServiceTypes/{dealerId}/{VIN}")]
        List<ATPServiceData> GetServiceTypes(string dealerId, string VIN);

        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "VerifyService")]
        ATPServiceDataMaster VerifyService(ATPServiceDataMaster ServiceDataMasterlist);

        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "ScheduleService")]
        ATPData ScheduleService(ATPServiceDataMaster ServiceDataMasterlist);

        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "DropKeys")]
        ATPData DropKeys(ATPServiceDataKeyDrop ServiceDataMasterlist);

        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "PickUpKeys")]
        ATPData PickUpKeys(ATPGetPickUpPin m);

        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "LoginDealerEmployee")]

        ATPLoginDealerEmp LoginDealerEmployee(ATPLoginDealerEmployee m);

        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "ScheduleServiceWithDt")]
        ATPData ScheduleServiceWithDt(ATPServiceDataMasterWithDt ServiceDataMasterlist);

        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
                  UriTemplate = "RegisterDeviceId")]
        ATPData RegisterDeviceId(ATPRegisterDeviceId registerDevice);

        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "GetDeviceId/{FirstName}/{LastName}/{VIN}")]
        ATPData GetDeviceId(string FirstName, string LastName, string VIN);

        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
                   UriTemplate = "SendMessageToDealer")]
        ATPData SendMessageToDealer(ATPChatMessage chatMessage);

        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
                  UriTemplate = "SendMsgToDealer")]
        ATPData SendMsgToDealer(ATPChatMessageNew chatMessage);

        [System.ServiceModel.OperationContract]
        [System.ServiceModel.Web.WebGet(UriTemplate = "Ping?test={message}", ResponseFormat = WebMessageFormat.Json)]
        string Ping(string message);
    }

}
