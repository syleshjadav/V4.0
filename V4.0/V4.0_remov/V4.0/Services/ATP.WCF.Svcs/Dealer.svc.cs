using ATP.DataModel;
using ATP.DataModel.DataTables;
using Elmah;
using System;
using System.Collections.Generic;
using System.Linq;


namespace ATP.WCF.Svcs {

  [ServiceErrorBehaviour(typeof(HttpErrorHandler))]
  public class Dealer : IDealer {
    #region "Dealer"


    public int CreateNewCustomer(uspSelVehSvcsForARCH_Result x) {
      new ATP.Services.Data.Person().CreateNewCustomer(x);
      return 0;
    }

    public List<uspSelMPISubmitHistory_Result> SelMPISubmitHistory(Guid? vehicleServiceGuid) {
      return new ATP.Services.Data.VehicleService().SelMPISubmitHistory(vehicleServiceGuid).ToList();
    }
    public int? CloseVehicleSericeRO(Guid? vehicleServiceGuid, int? serviceTypeId, Guid? ROClosedBy) {
      return new ATP.Services.Data.VehicleService().CloseVehicleSericeRO(vehicleServiceGuid, serviceTypeId, ROClosedBy);
    }



    public List<uspSelVehicleServiceMPIStatus_Result> SelVehicleServiceMPIStatus(int? DealerId, Guid? vehicleGuid, Guid? vehicleServiceGuid, Guid? swGuid, Guid? techGuid, Guid? partGuid, int? serviceTypeId) {
      return new ATP.Services.Data.VehicleService().SelVehicleServiceMPIStatus(DealerId, vehicleGuid, vehicleServiceGuid, swGuid, techGuid, partGuid, serviceTypeId).ToList();
    }


    public List<uspSelMPIVehicleServiceByDealerId_Result> SelMPIVehicleServiceByDealerId(int? DealerId, Guid? personGuid, Guid? vehicleGuid, Guid? vehicleServiceGuid, Guid? vehicleServiceMPIMasterGuid) {
      return new ATP.Services.Data.VehicleService().SelMPIVehicleServiceByDealerId(DealerId, personGuid, vehicleGuid, vehicleServiceGuid, vehicleServiceMPIMasterGuid).ToList();
    }

    public int? UpsertMPIByPersonGuid(uspSelMPIVehicleServiceByDealerId_Result m) {
      return new ATP.Services.Data.VehicleService().UpsertMPIByPersonGuid(m);
    }

    public List<uspSelCustomerByGuid_Result> SelCustomerByGuid(Guid? personGuid) {
      return new ATP.Services.Data.VehicleService().SelCustomerByGuid(personGuid).ToList();
    }



    public int? CloseVehicleSericeTask(Guid? vehicleServiceMPIMasterGuid, int? serviceTypeId, Guid? taskClosedBy) {
      return new ATP.Services.Data.VehicleService().CloseVehicleSericeTask(vehicleServiceMPIMasterGuid, serviceTypeId, taskClosedBy);
    }
    public int? UpdateMPICost(Guid? vehicleServiceMPIMasterGuid, int? mPIItemId, decimal? cost, decimal? laborCost, decimal? totalCost, bool? IsSendToCust) {
      return new ATP.Services.Data.VehicleService().UpdateMPICost(vehicleServiceMPIMasterGuid, mPIItemId, cost, laborCost, totalCost, IsSendToCust);
    }


    public List<uspSelVehicleServicesByDealerEmp_Result> SelVehicleServicesByDealerEmp(Guid? serviceWriterGuid, Guid? techGuid) {

      return new ATP.Services.Data.VehicleService().SelVehicleServicesByDealerEmp(serviceWriterGuid, techGuid);
    }

    public List<uspSelPersonGroup_Result> SelPersonGroup(int dealerId) {
      return new ATP.Services.Data.Person().SelPersonGroup(dealerId);
    }

    public int UpdateDealerMsg(int? dealerid, int? msgId, Guid? DealerEmployeeId) {
      return new ATP.Services.Data.Dealer().UpdateDealerMsg(dealerid, msgId, DealerEmployeeId);
    }
    public int UpdateDealerMsgBell(int? dealerid, int? msgId, Guid? DealerEmployeeId) {
      return new ATP.Services.Data.Dealer().UpdateDealerMsgBell(dealerid, msgId, DealerEmployeeId);
    }
    public int UpdatePersonVehicleLite(uspSelCustomerLite_Result m) {

      return new ATP.Services.Data.Dealer().UpdatePersonVehicleLite(m);

    }

    public int UpsertDealerKiosk(uspSelDealerKiosks_Result m) {
      return new ATP.Services.Data.Dealer().UpsertDealerKiosk(m);
    }

    public List<uspSelAdminMPIListByDealerId_Result> SelAdminMPIListByDealerId(int? dealerId) {
      return new ATP.Services.Data.Dealer().SelMPIListByDealerId(dealerId);
    }

    public List<uspSelDealerByFamilyId_Result> SelDealerByFamilyId(string Token, string dealerGroupId) {
      return new ATP.Services.Data.Dealer().GetDealersByFamilyId(dealerGroupId);
    }

    public List<uspSelAllMPIGroups_Result> SelAllMPIGroups() {
      return new ATP.Services.Data.Dealer().SelAllMPIGroups().ToList();
    }
    public List<uspSelAllMPIItems_Result> SelAllMPIItems() {
      return new ATP.Services.Data.Dealer().SelAllMPIItems().ToList();
    }
    public int UpsertDealerMPIGroupItems(int? dealerId, int? mPIGroupPosition, int? mPIGroupId, int? mPIItemId, bool? isValid, int? sortOrder) {
      return new ATP.Services.Data.Dealer().UpsertDealerMPIGroupItems(dealerId, mPIGroupPosition, mPIGroupId, mPIItemId, isValid, sortOrder);
    }


    public List<uspSelDealerKiosks_Result> SelDealerKiosks(bool valid, int dealerId) {
      return new ATP.Services.Data.Dealer().SelDealerKiosks(valid, dealerId);

    }
    public int UpdateKioskResetPassword(int Id) {
      return new ATP.Services.Data.Dealer().UpdateKioskResetPassword(Id);
    }

    public List<uspSelMPIListByDealerId_Result> SelMPIListByDealerId(int? dealerId, Guid vehicleServiceGuid, Guid PersongGuid) {
      return new ATP.Services.Data.Dealer().SelMPIListByDealerId(dealerId, vehicleServiceGuid, PersongGuid);
    }

    //public List<uspSelVehicleServiceMPIDetailChassis_Result> SelVehicleServiceMPIDetailChassis(Guid VehicleServiceGuid, Guid MPIMasterGuid)
    //{
    //    return new ATP.Services.Data.VehicleService().SelVehicleServiceMPIDetailChassis(VehicleServiceGuid, MPIMasterGuid);
    //}
    //public List<uspSelVehicleServiceMPIDetailBrakes_Result> SelVehicleServiceMPIDetailBrakes(Guid VehicleServiceGuid, Guid MPIMasterGuid)
    //{
    //    return new ATP.Services.Data.VehicleService().SelVehicleServiceMPIDetailBrakes(VehicleServiceGuid, MPIMasterGuid);
    //}
    //public List<uspSelVehicleServiceMPIDetailTires_Result> SelVehicleServiceMPIDetailTires(Guid VehicleServiceGuid, Guid MPIMasterGuid)
    //{
    //    return new ATP.Services.Data.VehicleService().SelVehicleServiceMPIDetailTires(VehicleServiceGuid, MPIMasterGuid);
    //}

    public int? SelMPICountByServiceGuid(Guid VehicleServiceGuid) {
      return new ATP.Services.Data.VehicleService().SelMPICountByServiceGuid(VehicleServiceGuid);
    }

    public List<uspSelNextExpressNumber_Result> SelNextExpressNumber(int dealerId, DateTime scheduleDate) {
      return new ATP.Services.Data.Dealer().SelNextExpressNumber(dealerId, scheduleDate);
    }

    public List<uspSelDealerDetailsById_Result> SelDealerDetailsById(int dealerId) {
      return new ATP.Services.Data.Dealer().SelDealerDetailsById(dealerId);
    }

    public List<uspGetDealerDetails_Result> GetDealerDetails(string Token, string machineId) {
      return new ATP.Services.Data.Dealer().GetDealerDetails(Token, machineId);
    }

    public int UpsertDealerContacts(uspSelDealerDetailsById_Result m) {
      return new ATP.Services.Data.Dealer().UpsertDealerContacts(m);
    }

    public int UpdateAllServiceStatusToComplete(string Token, int? dealerId) {
      return new ATP.Services.Data.Dealer().UpdateAllServiceStatusToComplete(Token, dealerId);
    }

    public List<uspSelServiceTypeEmails_Result> SelServiceTypeEmails(string serviceTypes, string packageIds) {
      return new ATP.Services.Data.Dealer().SelServiceTypeEmails(serviceTypes, packageIds);
    }
    public List<uspSelKioskByMachineId_Result> SelKioskByMachineId(string Token, string machineId) {
      return new ATP.Services.Data.Dealer().SelKioskByMachineId(machineId);
    }
    public List<uspSelDealerDept_Result> SelDealerDept(string Token, int? dealerId) {
      return new ATP.Services.Data.Dealer().SelDealerDept(Token, dealerId);

    }
    public List<uspSelDealerEmployees_Result> SelDealerEmployees(string Token, int? dealerId) {
      return new ATP.Services.Data.Dealer().SelDealerEmployees(Token, dealerId);
    }

    public int UpsertDealerEmployee(uspSelDealerEmployees_Result m) {
      return new ATP.Services.Data.Dealer().UpsertDealerEmployee(m);
    }

    public List<uspSelDealerPreTextMessage_Result> SelDealerPreTextMessage(string Token, int? dealerId) {
      return new ATP.Services.Data.Dealer().SelDealerPreTextMessage(Token, dealerId);
    }

    public int UpsertPreTextMessage(uspSelDealerPreTextMessage_Result msg) {
      return new ATP.Services.Data.Dealer().UpsertPreTextMessage(msg);
    }

    public int InsDealerMsg(uspSelDealerMsg_Result msg, List<DealerEmpMsgDataTable> dealerEmpMsgDataTable) {
      return new ATP.Services.Data.Dealer().InsDealerMsg(msg, dealerEmpMsgDataTable);
    }

    public List<uspSelDealerMessage_Result> SelDealerMessage(uspSelDealerMessage_Result msg) {
      return new ATP.Services.Data.Dealer().SelDealerMessage(msg).ToList();
    }
    #region "Adam Lite"
    public List<uspSelDealerMsgHist_Result> SelDealerMsgHist(uspSelDealerMsgHist_Result msg) {
      return new ATP.Services.Data.Dealer().SelDealerMsgHist(msg).ToList();
    }
    public List<uspSelCustomerLite_Result> SelCustomerLite(uspSelCustomerLite_Result msg) {
      return new ATP.Services.Data.Dealer().SelCustomerLite(msg).ToList();
    }

    #endregion

    public List<uspLoginDealerEmployee_Result> LoginDealerEmployee(int? dealerId, string userName, string password) {
      return new ATP.Services.Data.Dealer().LoginDealerEmployee(dealerId, userName, password).ToList();
    }

    public List<uspLoginDealerEmployeeByEmail_Result> LoginDealerEmployeeByEmail(string userEmail, string password) {
      return new ATP.Services.Data.Dealer().LoginDealerEmployeeByEmail(userEmail, password).ToList();
    }

    public List<uspSelDealerEmpPages_Result> SelDealerEmpPages(int? dealerId, Guid? dealerEmpGuid) {
      return new ATP.Services.Data.Dealer().SelDealerEmpPages(dealerId, dealerEmpGuid).ToList();
    }
    public List<uspSelDealerEmpPagesAdmin_Result> SelDealerEmpPagesAdmin(int? dealerId, Guid? dealerEmpGuid) {
      return new ATP.Services.Data.Dealer().SelDealerEmpPagesAdmin(dealerId, dealerEmpGuid).ToList();
    }

    public int UpdateEmpPagesAdmin(int? dealerId, Guid? dealerEmpGuid, int? pageId, bool isEnabled) {
      return new ATP.Services.Data.Dealer().UpdateEmpPagesAdmin(dealerId, dealerEmpGuid, pageId, isEnabled);
    }
    //public List<uspSelKeyLockerOpenPeg_Result> SelKeyLockerOpenPeg(uspSelKeyLockerOpenPeg_Result x)
    //{
    //    return new ATP.Services.Data.Dealer().SelKeyLockerOpenPeg(x).ToList();

    //}

    public int UpdKeyLockerPeg(uspSelKeyLockerOpenPeg_Result x) {
      return new ATP.Services.Data.Dealer().UpdKeyLockerPeg(x);
    }
    #endregion

    public uspInsAddress_Result InsertAddress(Nullable<System.Guid> gUID, Nullable<System.Guid> personGUID, Nullable<int> dealerId, Nullable<byte> typeId, Nullable<int> sTPId, Nullable<bool> preferred, string line1, string line2, string line3, string city, string zipCode, string zipPlus, Nullable<decimal> longitude, Nullable<decimal> latitude, Nullable<bool> valid, Nullable<System.Guid> enteredBy, Nullable<System.DateTime> entered) {
      return new ATP.Services.Data.Person().InsertAddress(gUID, personGUID, dealerId, typeId, sTPId, preferred, line1, line2, line3, city, zipCode, zipPlus, longitude, latitude, valid,
  enteredBy, entered);

    }

    public List<uspVerifySendAlertsUser_Result> VerifySendAlertsUser(string Token, int dealerId, string userName, string password, string roles) {
      return new ATP.Services.Data.Person().VerifySendAlertsUser(Token, dealerId, userName, password, roles).ToList();
    }

    public Guid? RegisterCustomer(Customer jSonCustomer) {
      return new ATP.Services.Data.Person().RegisterCustomer(jSonCustomer);
    }

    public List<uspSelVehSvcsForARCH_Result> SelVehSvcsForARCH(string Token, int dealerId, DateTime? serviceDateFrom, DateTime? serviceDateTo, string lastName, int? serviceStatusId, bool showInServiceCustomer) {
      return new ATP.Services.Data.VehicleService().SelVehSvcsForARCH(Token, dealerId, serviceDateFrom, serviceDateTo, lastName, serviceStatusId, showInServiceCustomer).ToList();
    }

    public List<uspSelVehSvcsWebARCH_Result> SelVehSvcsWebARCH(uspSelVehSvcsWebARCH_Result x) {
      return new ATP.Services.Data.VehicleService().SelVehSvcsWebARCH(x).ToList();
    }

    public int InsVehAlert(string Token, uspSelVehAlertByVehSvcGuid_Result alert) {
      return new ATP.Services.Data.Alerts().InsVehAlert(Token, alert);
    }

    public List<uspSelVehAlertByVehSvcGuid_Result> SelVehAlertByVehsSvcGuid(string token, Guid vehicleServiceGuid) {
      return new ATP.Services.Data.Alerts().SelVehAlertByVehGuid(token, vehicleServiceGuid).ToList();
    }

    public List<uspLkpTables_Result> SelLookUpTable(string Token, string tableName) {
      return new ATP.Services.Data.LookUp().SelLookUpTable(Token, tableName);
    }
    public List<uspSelLookUpTableByDealerId_Result> SelLookUpTableByDealerId(string tableName, int? dealerId) {
      return new ATP.Services.Data.LookUp().SelLookUpTableByDealerId(tableName, dealerId);
    }

    public int UpSertEmailAddress(string Token, uspSelVehSvcsForARCH_Result data) {
      return new ATP.Services.Data.Person().UpSertEmailAddress(Token, data);
    }

    public int UpSertPhoneNumber(string Token, uspSelVehSvcsForARCH_Result data) {
      return new ATP.Services.Data.Person().UpSertPhoneNumber(Token, data);
    }

    public int UpSertPhoneByPersonGuid(Guid? phoneGuid, string phoneNumber, Guid? updatedBy, Guid? enteredBy, Guid? personGuid) {
      return new ATP.Services.Data.Person().UpSertPhoneByPersonGuid(phoneGuid, phoneNumber, updatedBy, enteredBy, personGuid);
    }

    public int UpSertEmailByPersonGuid(Guid? emailGuid, string emailAddress, Guid? updatedBy, Guid? enteredBy, Guid? personGuid) {
      return new ATP.Services.Data.Person().UpSertEmailByPersonGuid(emailGuid, emailAddress, updatedBy, enteredBy, personGuid);
    }

    public List<string> UpdateVehiceServiceStatus(int? dealerId, Guid? vehicleServiceGUID, Guid? vehicleGUID, Guid? personGUID, Nullable<byte> statusId, Nullable<System.Guid> updatedBy) {
      return new ATP.Services.Data.VehicleService().UpdateVehiceServiceStatus(dealerId, vehicleServiceGUID, vehicleGUID, personGUID, statusId, updatedBy);

    }

    public List<uspSelPkgByDealerId_Result> GetServicePackages(string dealerId, string VIN) {
      return new ATP.Services.Data.VehicleService().GetServicePackages(dealerId, VIN);
    }

    public List<uspSelSvcTypeByDealerId_Result> GetServiceTypes(string dealerId, string VIN) {
      return new ATP.Services.Data.VehicleService().GetServiceTypes(dealerId, VIN);
    }

    public List<uspSelPackageByDealerId_Result> SelPackageByDealerId(string dealerId) {
      return new ATP.Services.Data.VehicleService().SelPackageByDealerId(dealerId);
    }

    #region "Vehicle Service"

    public List<uspSelVehicleServicePricing_Result> SelVehicleServicePricing(int? DealerId, Guid? vehicleGuid, Guid? SW, Guid? techGuid, Guid? partsGuid, int? ServiceTypeId) {
      return new ATP.Services.Data.VehicleService().SelVehicleServicePricing(DealerId, vehicleGuid, SW, techGuid, partsGuid, ServiceTypeId);
    }
    public List<uspSelVehicleServicePricingSW_Result> SelVehicleServicePricingSW(int? DealerId, Guid? vehicleGuid, Guid? SW, Guid? techGuid, Guid? partsGuid, int? ServiceTypeId) {
      return new ATP.Services.Data.VehicleService().SelVehicleServicePricingSW(DealerId, vehicleGuid, SW, techGuid, partsGuid, ServiceTypeId);
    }
    public List<uspSelVehicleServicePricingTech_Result> SelVehicleServicePricingTech(int? DealerId, Guid? vehicleGuid, Guid? SW, Guid? techGuid, Guid? partsGuid, int? ServiceTypeId) {
      return new ATP.Services.Data.VehicleService().SelVehicleServicePricingTech(DealerId, vehicleGuid, SW, techGuid, partsGuid, ServiceTypeId);
    }
    public List<uspSelVehicleServicePricingParts_Result> SelVehicleServicePricingParts(int? DealerId, Guid? vehicleGuid, Guid? SW, Guid? techGuid, Guid? partsGuid, int? ServiceTypeId) {
      return new ATP.Services.Data.VehicleService().SelVehicleServicePricingParts(DealerId, vehicleGuid, SW, techGuid, partsGuid, ServiceTypeId);
    }

    public int? UPSertVehicleServicePricing(uspSelVehicleServicePricing_Result m) {
      return new ATP.Services.Data.VehicleService().UPSertVehicleServicePricing(m);
    }
    public List<uspSelMPIImages_Result> SelMPIImages(int dealerId, Guid? personGuid) {
      return new ATP.Services.Data.VehicleService().SelMPIImages(dealerId, personGuid).ToList();

    }

    public long? uspUpSertMPIImages(uspSelMPIImages_Result m) {
      return new ATP.Services.Data.VehicleService().UpSertMPIImages(m);
    }

    public int UpsertVehicleServiceMPI(int DealerId, Guid? MPIMasterGuid, Guid? VehicleServiceGuid, Guid? Person, Guid? vehicleGUID, string techComments, string techWriterComments, Guid? EnteredBy,
                string MilesIn,
                string MilesOut,
                string RoNum,
                string FleetNumber, List<VehicleServiceMPIDataTable> vehicleServiceMPIDataTable, MPIDetailTiresDataTable mpiDetailTiresTableType, MPIDetailBrakesDataTable mpiDetailBrakesDataTable, MPIDetailChassisDataTable mpiDetailChassisDataTable) {
      return new ATP.Services.Data.VehicleService().UpsertVehicleServiceMPI(DealerId, MPIMasterGuid, VehicleServiceGuid, Person, vehicleGUID, techComments, techWriterComments, EnteredBy, MilesIn, MilesOut, RoNum, FleetNumber, vehicleServiceMPIDataTable, mpiDetailTiresTableType, mpiDetailBrakesDataTable, mpiDetailChassisDataTable);

    }
    public List<uspSelVehicleSvcsByDealerId_Result> SelVehicleSvcsByDealerId(int? dealerId, int? serviceStatusId, DateTime? startDate, DateTime? endDate, short? pageNumber, short? pageSize) {
      return new ATP.Services.Data.VehicleService().SelVehicleSvcsByDealerId(dealerId, serviceStatusId, startDate, endDate, pageNumber, pageSize).ToList();

    }

    public List<uspSelVehicleSvcsByPersonId_Result> SelVehicleSvcsByPersonId(uspSelVehicleSvcsByPersonId_Result svcs) {
      return new ATP.Services.Data.VehicleService().SelVehicleSvcsByPersonId(svcs).ToList();
    }

    public List<uspSelExpSvcsStatByDealerId_Result> SelExpSvcsStatByDealerId(int? dealerId, int? serviceStatusId, DateTime? startDate, DateTime? endDate, string lastName, short? pageNumber, short? pageSize) {
      return new ATP.Services.Data.VehicleService().SelExpSvcsStatByDealerId(dealerId, serviceStatusId, startDate, endDate, lastName, pageNumber, pageSize).ToList();

    }

    public ATPData ScheduleService(ATPServiceDataMasterKiosk serviceDataMasterlist) {
      //  var selectedServices = serviceList.Where(x => x.IsPackage == "0").ToList();
      // var selectedPackages = serviceList.Where(x => x.IsPackage == "1");
      var msg = new ATPData { Id = "-1", Value = "Failure" };
      var dealerId = serviceDataMasterlist.DealerId;
      // var dealId = ParseToNullableInt(dealerId);

      // string firstName = serviceDataMasterlist.FirstName;
      //  string lastName = serviceDataMasterlist.LastName;

      //  string VIN = serviceDataMasterlist.VIN;

      //    var cust = new ATP.Services.Data.Person().ValidateCustomer(firstName, lastName, VIN).FirstOrDefault();

      var serviceList = serviceDataMasterlist.ATPServiceDataList.ToList();


      if (serviceDataMasterlist.PersonGuid.ToString().Length > 10) {
        var vehicleServicesDataTable = new VehicleServicesDataTable {
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

        if (!String.IsNullOrEmpty(serviceDataMasterlist.EnteredBy)) {
          vehicleServicesDataTable.EnteredBy = new Guid(serviceDataMasterlist.EnteredBy);
        }

        List<VehicleServicesDataTable> vehsvcs = new List<VehicleServicesDataTable>();
        vehsvcs.Add(vehicleServicesDataTable);

        var ss = new ATP.Services.Data.VehicleService().SaveVehicleServices(vehsvcs, serviceList);

        msg.Id = "1";
        msg.Value = "Your Wait Time is 30 mts.";

      }
      else {
        msg.Id = "-1";
        msg.Value = "Failed due to Invalid Customer Vehicle Registration";

      }

      return msg;

    }

    public List<uspSelSvcTypeByPkgId_Result> SelSvcTypeByPkgId(int dealerId, int packageId) {

      return new ATP.Services.Data.VehicleService().SelSvcTypeByPkgId(dealerId, packageId);
    }

    public List<uspSelVehicleServiceImage_Result> SelVehicleServiceImage(uspSelVehicleServiceImage_Result svcs) {
      return new ATP.Services.Data.VehicleService().SelVehicleServiceImage(svcs);
    }

    public int DelVehicleServiceImage(uspSelVehicleServiceImage_Result svcs) {
      return new ATP.Services.Data.VehicleService().DelVehicleServiceImage(svcs);

    }

    public int InsVehicleServiceImage(uspSelVehicleServiceImage_Result svcs) {
      return new ATP.Services.Data.VehicleService().InsVehicleServiceImage(svcs);
    }
    #endregion

    #region "Vehicle"

    public int? UpdateIsVehicleInShop(Guid? VehicleGuid, bool? isVehicleInShop) {
      return new ATP.Services.Data.Person().UpdateIsVehicleInShop(VehicleGuid, isVehicleInShop);
    }



    public List<short?> GetYears() {
      return new ATP.Services.Data.VehicleService().GetVehicleYears();

    }

    public List<uspSelVehicleMakes_Result> GetMakes(string year, string dealerId) {
      return new ATP.Services.Data.VehicleService().GetMakes(year, dealerId);

    }

    public List<uspSelVehicleModels_Result> GetModels(string year, string makeId) {
      return new ATP.Services.Data.VehicleService().GetModels(year, makeId);

    }

    public List<uspSelVehicleTrims_Result> GetTrims(string year, string makeId, string modelId) {
      return new ATP.Services.Data.VehicleService().GetTrims(year, makeId, modelId);

    }

    #endregion

    #region "Person"
    public List<uspInsVehicle_Result> InsertVehicle(uspSelVehicleByPersonId_Result vehicle) {
      System.Guid? gUID = vehicle.GUID;
      if (vehicle.GUID == new Guid()) {
        gUID = null;
      }


      var personGUID = vehicle.PersonGUID;
      var dealerId = vehicle.DealerId;
      var makeId = vehicle.MakeId;
      var modelId = vehicle.ModelId;
      var trimId = vehicle.TrimId;
      var year = vehicle.ModelYear;
      var colorId = vehicle.ColorId;
      string name = vehicle.Name;
      var mileage = vehicle.Mileage;
      var lastServiceMileage = vehicle.LastServiceMileage;
      var yearlyAverageMileage = 0;
      var color = vehicle.Color;
      var licenseNumber = vehicle.LicensePlate;
      int ePD = 0;
      var vIN = vehicle.VIN;
      bool valid = vehicle.Valid;
      var enteredBy = vehicle.EnteredBy;
      var entered = vehicle.Entered;
      return new ATP.Services.Data.Person().InsertVehicle(gUID, personGUID, dealerId, makeId, modelId,
              trimId, year, colorId, name, mileage, lastServiceMileage,
              yearlyAverageMileage, color, licenseNumber, ePD, vIN, valid, enteredBy,
              entered);
    }

    public uspInsPerson_Result InsertPerson(uspSelPersonById_Result person) {

      return new ATP.Services.Data.Person().InsertPerson(person);
    }


    public List<uspSelVehicleByPersonId_Result> SelVehicleByPersonId(Guid? personGuid) {
      return new ATP.Services.Data.Person().SelVehicleByPersonId(personGuid);
    }
    public List<uspSelPersonById_Result> SelPersonById(Guid? personGuid) {
      return new ATP.Services.Data.Person().SelPersonById(personGuid);
    }

    public List<uspSelPersonByGuid_Result> SelPersonByGuid(Guid? personGuid) {
      return new ATP.Services.Data.Person().SelPersonByGuid(personGuid);
    }

    public List<uspSelPersonByUserName_Result> SelPersonByUserName(bool? IsValid, string userName) {
      return new ATP.Services.Data.Person().SelPersonByUserName(IsValid, userName);
    }
    public List<uspSelPersonByLastFirstName_Result> SelPersonByLastFirstName(string lastName, string firstName) {
      return new ATP.Services.Data.Person().SelPersonByLastFirstName(lastName, firstName).ToList();
    }

    public uspSelVehicleById_Result SelVehicleById(Guid? vehicleGuid) {
      return new ATP.Services.Data.Person().SelVehicleById(vehicleGuid).FirstOrDefault();
    }

    #endregion

    #region "Login"

    public List<uspSecurityLogInByUserName_Result> LogInByUserName(byte? Environment, string userName, string password) {
      return new ATP.Services.Data.Person().LogInByUserName(Environment, userName, password);
    }
    public List<uspSecurityLogInByVIN_Result> LogInByVIN(byte? Environment, string VIN) {
      return new ATP.Services.Data.Person().LogInByVIN(Environment, VIN);
    }
    public List<uspSecurityLogInByIdCard_Result> LogInByIdCard(byte? Environment, string IdCardNumber, string FirstName, string MiddleName, string LastName, string AddressLine1, string AddressLine2, string AddressLine3, string City, string STP, string ZipCode, string ZipPlus) {
      return new ATP.Services.Data.Person().LogInByIdCard(Environment, IdCardNumber, FirstName, MiddleName, LastName, AddressLine1, AddressLine2, AddressLine3, City, STP, ZipCode, ZipPlus);
    }
    public int LogInByCreditCard(byte? Environment, string CreditCardNumber, byte ExpirationMonth, short ExpirationYear, string FirstName, string MiddleName, string LastName) {
      return new ATP.Services.Data.Person().LogInByCreditCard(Environment, CreditCardNumber, ExpirationMonth, ExpirationYear, FirstName, MiddleName, LastName);
    }
    public List<uspSecurityLogOut_Result> LogOut(System.Guid? GUID, string Token) {
      return new ATP.Services.Data.Person().LogOut(GUID, Token);
    }

    #endregion

    #region "to be addressed"
    /*
    public ATP.Service.Common.Model.Entity.Message SetPerson(string Token, ADAM.Service.Model.Entity.Person Person)
    {
        var person = new ADAM.Service.Data.Person();
        return person.Set(Token, Person);
    }

    public ATP.Service.Common.Model.Entity.Message SetPersonPhone(string Token, ADAM.Service.Model.Entity.Phone Phone)
    {
        return new ADAM.Service.Data.Phone().Set(Token, Phone);
    }

    public ATP.Service.Common.Model.Entity.Message SetPersonAddress(string token, ADAM.Service.Model.Entity.Address Address)
    {
        return new ADAM.Service.Data.Address().Set(token, Address);
    }

     public ADAM.Service.Model.Entity.PersonDetail GetPersonDetailById(string Token, System.Guid GUID)
    {
        var person = new ADAM.Service.Data.Person();
        return person.GetDetailById(Token, GUID);
    }

    public ADAM.Service.Model.Entity.Vehicle GetVehicleById(string Token, System.Guid GUID)
    {
        var vehicle = new ADAM.Service.Data.Vehicle();
        return vehicle.GetById(Token, GUID);
    }

    public ATP.Service.Common.Model.Entity.Message SaveVehicle(string Token, ADAM.Service.Model.Entity.Vehicle Vehicle)
    {
        var data = new ADAM.Service.Data.Vehicle();
        return data.Set(Token, Vehicle);
    }
    */
    #endregion

    public static int? ParseToNullableInt(string value) {
      return String.IsNullOrEmpty(value) ? null : (int.Parse(value) as int?);
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
