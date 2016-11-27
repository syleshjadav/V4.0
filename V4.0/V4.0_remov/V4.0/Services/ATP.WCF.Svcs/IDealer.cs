
using ATP.DataModel;
using ATP.DataModel.DataTables;
using System;
using System.Collections.Generic;
using System.ServiceModel;

namespace ATP.WCF.Svcs {
  [ServiceContract(Name = "IDealer", Namespace = "http://www.ADAMCentralUSA.com/ADAM/Service/Dealer")]

  public interface IDealer {
    [OperationContract]
    string PingMe(string s);
    #region "Dealer"

    [OperationContract]
    int CreateNewCustomer(uspSelVehSvcsForARCH_Result x);

    [OperationContract]
    List<uspSelMPISubmitHistory_Result> SelMPISubmitHistory(Guid? vehicleServiceGuid);

    [OperationContract]
    int? CloseVehicleSericeRO(Guid? vehicleServiceGuid, int? serviceTypeId, Guid? ROClosedBy);

    [OperationContract]
    List<uspSelVehicleServiceMPIStatus_Result> SelVehicleServiceMPIStatus(int? DealerId, Guid? vehicleGuid, Guid? vehicleServiceGuid, Guid? swGuid, Guid? techGuid, Guid? partGuid, int? serviceTypeId);

    [OperationContract]
    List<uspSelMPIVehicleServiceByDealerId_Result> SelMPIVehicleServiceByDealerId(int? DealerId, Guid? personGuid, Guid? vehicleGuid, Guid? vehicleServiceGuid, Guid? vehicleServiceMPIMasterGuid);


    [OperationContract]
    int? UpsertMPIByPersonGuid(uspSelMPIVehicleServiceByDealerId_Result m);

    [OperationContract]
    List<uspSelCustomerByGuid_Result> SelCustomerByGuid(Guid? personGuid);




    [OperationContract]
    int? CloseVehicleSericeTask(Guid? vehicleServiceMPIMasterGuid, int? serviceTypeId, Guid? taskClosedBy);

    [OperationContract]
    int? UpdateMPICost(Guid? vehicleServiceMPIMasterGuid, int? mPIItemId, decimal? cost, decimal? laborCost, decimal? totalCost, bool? IsSendToCust);

    [OperationContract]
    List<uspSelVehicleServicePricing_Result> SelVehicleServicePricing(int? DealerId, Guid? vehicleServiceGuid, Guid? SW, Guid? techGuid, Guid? partsGuid, int? ServiceTypeId);



    [OperationContract]
    List<uspSelVehicleServicePricingSW_Result> SelVehicleServicePricingSW(int? DealerId, Guid? vehicleServiceGuid, Guid? SW, Guid? techGuid, Guid? partsGuid, int? ServiceTypeId);

    [OperationContract]
    List<uspSelVehicleServicePricingTech_Result> SelVehicleServicePricingTech(int? DealerId, Guid? vehicleServiceGuid, Guid? SW, Guid? techGuid, Guid? partsGuid, int? ServiceTypeId);


    [OperationContract]
    List<uspSelVehicleServicePricingParts_Result> SelVehicleServicePricingParts(int? DealerId, Guid? vehicleServiceGuid, Guid? SW, Guid? techGuid, Guid? partsGuid, int? ServiceTypeId);




    [OperationContract]
    int? UPSertVehicleServicePricing(uspSelVehicleServicePricing_Result m);

    [OperationContract]
    List<uspSelVehicleServicesByDealerEmp_Result> SelVehicleServicesByDealerEmp(Guid? serviceWriterGuid, Guid? techGuid);
    [OperationContract]
    int? UpdateIsVehicleInShop(Guid? VehicleGuid, bool? isVehicleInShop);

    [OperationContract]
    List<uspSelMPIImages_Result> SelMPIImages(int dealerId, Guid? personGuid);


    [OperationContract]
    long? uspUpSertMPIImages(uspSelMPIImages_Result m);



    [OperationContract]
    List<uspSelPersonGroup_Result> SelPersonGroup(int dealerId);
    [OperationContract]
    int UpdateDealerMsg(int? dealerid, int? msgId, Guid? DealerEmployeeId);
    [OperationContract]
    int UpdateDealerMsgBell(int? dealerid, int? msgId, Guid? DealerEmployeeId);
    [OperationContract]
    int UpdatePersonVehicleLite(uspSelCustomerLite_Result m);
    [OperationContract]
    int UpsertDealerKiosk(uspSelDealerKiosks_Result m);

    [OperationContract]
    int UpsertDealerContacts(uspSelDealerDetailsById_Result m);
    [OperationContract]
    int UpsertDealerEmployee(uspSelDealerEmployees_Result m);
    [OperationContract]
    List<uspSelAdminMPIListByDealerId_Result> SelAdminMPIListByDealerId(int? dealerId);
    [OperationContract]
    List<uspSelDealerKiosks_Result> SelDealerKiosks(bool valid, int dealerId);
    [OperationContract]
    List<uspSelAllMPIGroups_Result> SelAllMPIGroups();
    [OperationContract]
    List<uspSelAllMPIItems_Result> SelAllMPIItems();
    [OperationContract]
    int UpsertDealerMPIGroupItems(int? dealerId, int? mPIGroupPosition, int? mPIGroupId, int? mPIItemId, bool? isValid, int? sortOrder);



    [OperationContract]
    int UpdateKioskResetPassword(int Id);
    [OperationContract]
    List<uspSelMPIListByDealerId_Result> SelMPIListByDealerId(int? dealerId, Guid vehicleServiceGuid, Guid PersonGuid);

    [OperationContract]
    int? SelMPICountByServiceGuid(Guid VehicleServiceGuid);
    //[OperationContract]
    //List<uspSelVehicleServiceMPIDetailChassis_Result> SelVehicleServiceMPIDetailChassis(Guid VehicleServiceGuid, Guid MPIMasterGuid);

    //[OperationContract]
    //List<uspSelVehicleServiceMPIDetailBrakes_Result> SelVehicleServiceMPIDetailBrakes(Guid VehicleServiceGuid, Guid MPIMasterGuid);

    //[OperationContract]
    //List<uspSelVehicleServiceMPIDetailTires_Result> SelVehicleServiceMPIDetailTires(Guid VehicleServiceGuid, Guid MPIMasterGuid);


    [OperationContract]
    List<uspSelKioskByMachineId_Result> SelKioskByMachineId(string Token, string machineId);

    [OperationContract]
    uspInsAddress_Result InsertAddress(Nullable<System.Guid> gUID, Nullable<System.Guid> personGUID, Nullable<int> dealerId, Nullable<byte> typeId, Nullable<int> sTPId, Nullable<bool> preferred, string line1, string line2, string line3, string city, string zipCode, string zipPlus, Nullable<decimal> longitude, Nullable<decimal> latitude, Nullable<bool> valid, Nullable<System.Guid> enteredBy, Nullable<System.DateTime> entered);

    [OperationContract]
    List<uspGetDealerDetails_Result> GetDealerDetails(string Token, string machineId);

    [OperationContract]
    List<uspSelDealerByFamilyId_Result> SelDealerByFamilyId(string Token, string dealerGroupId);
    [OperationContract]
    List<uspSelDealerDetailsById_Result> SelDealerDetailsById(int dealerId);
    [OperationContract]
    int UpdateAllServiceStatusToComplete(string Token, int? dealerId);

    [OperationContract]
    Guid? RegisterCustomer(Customer jSonCustomer);
    [OperationContract]
    List<uspVerifySendAlertsUser_Result> VerifySendAlertsUser(string Token, int dealerId, string userName, string password, string roles);
    [OperationContract]
    List<uspSelDealerDept_Result> SelDealerDept(string Token, int? dealerId);
    [OperationContract]
    List<uspSelDealerEmployees_Result> SelDealerEmployees(string Token, int? dealerId);

    [OperationContract]
    List<uspSelDealerPreTextMessage_Result> SelDealerPreTextMessage(string Token, int? dealerId);

    [OperationContract]
    List<uspSelDealerMessage_Result> SelDealerMessage(uspSelDealerMessage_Result msg);

    [OperationContract]
    List<uspSelDealerMsgHist_Result> SelDealerMsgHist(uspSelDealerMsgHist_Result msg);

    [OperationContract]
    List<uspSelCustomerLite_Result> SelCustomerLite(uspSelCustomerLite_Result msg);

    [OperationContract]
    int InsDealerMsg(uspSelDealerMsg_Result msg, List<DealerEmpMsgDataTable> dealerEmpMsgDataTable);

    [OperationContract]
    int UpsertPreTextMessage(uspSelDealerPreTextMessage_Result msg);
    [OperationContract]
    List<uspLoginDealerEmployee_Result> LoginDealerEmployee(int? dealerId, string userName, string password);

    [OperationContract]
    List<uspLoginDealerEmployeeByEmail_Result> LoginDealerEmployeeByEmail(string userEmail, string password);
    [OperationContract]
    List<uspSelDealerEmpPages_Result> SelDealerEmpPages(int? dealerId, Guid? dealerEmpGuid);

    [OperationContract]
    List<uspSelDealerEmpPagesAdmin_Result> SelDealerEmpPagesAdmin(int? dealerId, Guid? dealerEmpGuid);


    [OperationContract]
    int UpdateEmpPagesAdmin(int? dealerId, Guid? dealerEmpGuid, int? pageId, bool isEnabled);

    //[OperationContract]
    //List<uspSelKeyLockerOpenPeg_Result> SelKeyLockerOpenPeg(uspSelKeyLockerOpenPeg_Result x);
    [OperationContract]
    int UpdKeyLockerPeg(uspSelKeyLockerOpenPeg_Result x);

    #endregion

    [OperationContract]
    List<uspSelVehSvcsWebARCH_Result> SelVehSvcsWebARCH(uspSelVehSvcsWebARCH_Result x);

    [OperationContract]
    List<uspSelVehSvcsForARCH_Result> SelVehSvcsForARCH(string Token, int dealerId, DateTime? serviceDateFrom, DateTime? serviceDateTo, string lastName, int? serviceStatusId, bool showInServiceCustomer);

    [OperationContract]
    List<uspSelVehAlertByVehSvcGuid_Result> SelVehAlertByVehsSvcGuid(string Token, Guid vehicleServiceGuid);

    [OperationContract]
    ATPData ScheduleService(ATPServiceDataMasterKiosk serviceDataMasterlist);

    [OperationContract]
    List<uspLkpTables_Result> SelLookUpTable(string Token, string tableName);

    [OperationContract]
    List<uspSelLookUpTableByDealerId_Result> SelLookUpTableByDealerId(string tableName, int? dealerId);

    [OperationContract]
    int InsVehAlert(string Token, uspSelVehAlertByVehSvcGuid_Result alert);

    [OperationContract]
    int UpSertEmailAddress(string Token, uspSelVehSvcsForARCH_Result data);

    [OperationContract]
    int UpSertPhoneNumber(string Token, uspSelVehSvcsForARCH_Result data);
    [OperationContract]
    int UpSertPhoneByPersonGuid(Guid? phoneGuid, string phoneNumber, Guid? updatedBy, Guid? enteredBy, Guid? personGuid);

    [OperationContract]
    int UpSertEmailByPersonGuid(Guid? emailGuid, string emailAddress, Guid? updatedBy, Guid? enteredBy, Guid? personGuid);

    [OperationContract]
    List<uspInsVehicle_Result> InsertVehicle(uspSelVehicleByPersonId_Result vehicle);
    [OperationContract]
    uspInsPerson_Result InsertPerson(uspSelPersonById_Result person);
    [OperationContract]
    List<uspSelVehicleByPersonId_Result> SelVehicleByPersonId(Guid? personGuid);
    [OperationContract]
    List<uspSelPersonByGuid_Result> SelPersonByGuid(Guid? personGuid);
    [OperationContract]
    List<uspSelPersonById_Result> SelPersonById(Guid? personGuid);
    [OperationContract]
    List<uspSelPersonByUserName_Result> SelPersonByUserName(bool? IsValid, string userName);

    [OperationContract]
    List<uspSelPersonByLastFirstName_Result> SelPersonByLastFirstName(string lastName, string firstName);


    [OperationContract]
    uspSelVehicleById_Result SelVehicleById(Guid? vehicleGuid);
    #region"vehicle Service"
    [OperationContract]
    int UpsertVehicleServiceMPI(int DealerId, Guid? MPIMasterGuid, Guid? VehicleServiceGuid, Guid? Person, Guid? vehicleGUID, string techComments, string techWriterComments, Guid? EnteredBy, string MilesIn,
                string MilesOut,
                string RoNum,
                string FleetNumber, List<VehicleServiceMPIDataTable> vehicleServiceMPIDataTable, MPIDetailTiresDataTable mpiDetailTiresTableType, MPIDetailBrakesDataTable mpiDetailBrakesDataTable, MPIDetailChassisDataTable mpiDetailChassisDataTable);
    [OperationContract]
    List<string> UpdateVehiceServiceStatus(int? dealerId, Guid? vehicleServiceGUID, Guid? vehicleGUID, Guid? personGUID, Nullable<byte> statusId, Nullable<System.Guid> updatedBy);


    [OperationContract]
    List<uspSelPkgByDealerId_Result> GetServicePackages(string dealerId, string VIN);

    [OperationContract]
    List<uspSelSvcTypeByDealerId_Result> GetServiceTypes(string dealerId, string VIN);
    [OperationContract]
    List<uspSelPackageByDealerId_Result> SelPackageByDealerId(string dealerId);
    [OperationContract]
    List<uspSelNextExpressNumber_Result> SelNextExpressNumber(int dealerId, DateTime scheduleDate);
    [OperationContract]
    List<uspSelServiceTypeEmails_Result> SelServiceTypeEmails(string serviceTypes, string packageIds);
    [OperationContract]
    List<uspSelVehicleSvcsByDealerId_Result> SelVehicleSvcsByDealerId(int? dealerId, int? serviceStatusId, DateTime? startDate, DateTime? endDate, short? pageNumber, short? pageSize);
    [OperationContract]
    List<uspSelVehicleSvcsByPersonId_Result> SelVehicleSvcsByPersonId(uspSelVehicleSvcsByPersonId_Result svcs);

    [OperationContract]
    List<uspSelExpSvcsStatByDealerId_Result> SelExpSvcsStatByDealerId(int? dealerId, int? serviceStatusId, DateTime? startDate, DateTime? endDate, string lastName, short? pageNumber, short? pageSize);

    [OperationContract]
    List<uspSelSvcTypeByPkgId_Result> SelSvcTypeByPkgId(int dealerId, int packageId);
    [OperationContract]
    List<uspSelVehicleServiceImage_Result> SelVehicleServiceImage(uspSelVehicleServiceImage_Result svcs);
    [OperationContract]
    int DelVehicleServiceImage(uspSelVehicleServiceImage_Result svcs);
    [OperationContract]
    int InsVehicleServiceImage(uspSelVehicleServiceImage_Result svcs);


    #endregion
    #region "Login"
    [OperationContract]
    List<uspSecurityLogInByUserName_Result> LogInByUserName(byte? Environment, string userName, string password);
    [OperationContract]
    List<uspSecurityLogInByVIN_Result> LogInByVIN(byte? Environment, string VIN);
    [OperationContract]
    List<uspSecurityLogInByIdCard_Result> LogInByIdCard(byte? Environment, string IdCardNumber, string FirstName, string MiddleName, string LastName, string AddressLine1, string AddressLine2, string AddressLine3, string City, string STP, string ZipCode, string ZipPlus);
    [OperationContract]
    int LogInByCreditCard(byte? Environment, string CreditCardNumber, byte ExpirationMonth, short ExpirationYear, string FirstName, string MiddleName, string LastName);
    [OperationContract]
    List<uspSecurityLogOut_Result> LogOut(System.Guid? GUID, string Token);


    #endregion


    #region "Vehicle"

    [OperationContract]
    List<short?> GetYears();

    [OperationContract]
    List<uspSelVehicleMakes_Result> GetMakes(string year, string dealerId);

    [OperationContract]
    List<uspSelVehicleModels_Result> GetModels(string year, string makeId);
    [OperationContract]

    List<uspSelVehicleTrims_Result> GetTrims(string year, string makeId, string modelId);

    [OperationContract]
    bool LogError(string msg);
    [OperationContract]
    bool LogInformation(string msg);
    #endregion

    #region "to be addressed"
    /*
    [OperationContract]
    ATP.Service.Common.Model.Entity.Message SetPerson(string Token, ADAM.Service.Model.Entity.Person Person);

    [OperationContract]
    ATP.Service.Common.Model.Entity.Message SetPersonPhone(string Token, ADAM.Service.Model.Entity.Phone Phone);
    [OperationContract]
    ATP.Service.Common.Model.Entity.Message SetPersonAddress(string token, ADAM.Service.Model.Entity.Address Address);
    [OperationContract]
    ADAM.Service.Model.Entity.LoggedIn LogInByUserName(byte? Environment, string UserName, string Password);
    [OperationContract]
    ADAM.Service.Model.Entity.LoggedIn LogInByVIN(byte? Environment, string VIN);
    [OperationContract]
    ADAM.Service.Model.Entity.LoggedIn LogInByIdCard(byte? Environment, string IdCardNumber, string FirstName, string MiddleName, string LastName, string AddressLine1, string AddressLine2, string AddressLine3, string City, string STP, string ZipCode, string ZipPlus);
    [OperationContract]
    ADAM.Service.Model.Entity.LoggedIn LogInByCreditCard(byte? Environment, string CreditCardNumber, byte ExpirationMonth, short ExpirationYear, string FirstName, string MiddleName, string LastName);

    [OperationContract]
    ATP.Service.Common.Model.Entity.Message LogOut(System.Guid GUID, string Token);

    [OperationContract]
    ADAM.Service.Model.Entity.PersonDetail GetPersonDetailById(string Token, System.Guid GUID);

    [OperationContract]
    ADAM.Service.Model.Entity.Vehicle GetVehicleById(string Token, System.Guid GUID);

    [OperationContract]
    ATP.Service.Common.Model.Entity.Message SaveVehicle(string Token, ADAM.Service.Model.Entity.Vehicle Vehicle);

    */

    #endregion
  }



}
