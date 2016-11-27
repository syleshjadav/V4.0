
using ATP.DataModel;
using ATP.DataModel.DataTables;
using ATP.SvcsLibrary.DealerSvcRef;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;

namespace ATP.SvcsLibrary
{
    public class Dealer
    {

        public int CreateNewCustomer(uspSelVehSvcsForARCH_Result x)
        {
            return ATP.Common.ProxyHelper.Service<IDealer>.Use(svcs =>
            {
                 return svcs.CreateNewCustomer(x);
            });
        }

        public List<uspSelMPISubmitHistory_Result> SelMPISubmitHistory(Guid? vehicleServiceGuid)
        {
            return ATP.Common.ProxyHelper.Service<IDealer>.Use(svcs =>
            {
                return svcs.SelMPISubmitHistory(vehicleServiceGuid).ToList();
            });
        }
        public int? CloseVehicleSericeRO(Guid? vehicleServiceGuid, int? serviceTypeId, Guid? ROClosedBy)
        {
            return ATP.Common.ProxyHelper.Service<IDealer>.Use(svcs =>
            {
                return svcs.CloseVehicleSericeRO(vehicleServiceGuid, serviceTypeId, ROClosedBy);
            });
        }

        public List<uspSelVehicleServiceMPIStatus_Result> SelVehicleServiceMPIStatus(int? DealerId, Guid? vehicleGuid, Guid? vehicleServiceGuid, Guid? swGuid, Guid? techGuid, Guid? partGuid, int? serviceTypeId)
        {
            return ATP.Common.ProxyHelper.Service<IDealer>.Use(svcs =>
            {
                return svcs.SelVehicleServiceMPIStatus(DealerId,  vehicleGuid, vehicleServiceGuid, swGuid, techGuid, partGuid, serviceTypeId).ToList();
            });
        }

        public List<uspSelMPIVehicleServiceByDealerId_Result> SelMPIVehicleServiceByDealerId(int? DealerId, Guid? personGuid, Guid? vehicleGuid, Guid? vehicleServiceGuid, Guid? vehicleServiceMPIMasterGuid)
        {
            return ATP.Common.ProxyHelper.Service<IDealer>.Use(svcs =>
            {
                return svcs.SelMPIVehicleServiceByDealerId(DealerId, personGuid, vehicleGuid, vehicleServiceGuid, vehicleServiceMPIMasterGuid).ToList();

            });
        }

        public int? UpsertMPIByPersonGuid(uspSelMPIVehicleServiceByDealerId_Result m)
        {
            return ATP.Common.ProxyHelper.Service<IDealer>.Use(svcs =>
            {
                return svcs.UpsertMPIByPersonGuid(m);

            });
        }

        public List<uspSelCustomerByGuid_Result> SelCustomerByGuid(Guid? personGuid)
        {
            return ATP.Common.ProxyHelper.Service<IDealer>.Use(svcs =>
            {
                return svcs.SelCustomerByGuid(personGuid);

            });
        }

        public int? UpdateMPICost(Guid? vehicleServiceMPIMasterGuid, int? mPIItemId, decimal? cost, decimal? laborCost, decimal? totalCost, bool? IsSendToCust)
        {

            return ATP.Common.ProxyHelper.Service<IDealer>.Use(svcs =>
            {
                return svcs.UpdateMPICost(vehicleServiceMPIMasterGuid, mPIItemId, cost, laborCost, totalCost, IsSendToCust);
               
            });
        }

        public int? CloseVehicleSericeTask(Guid? vehicleServiceMPIMasterGuid, int? serviceTypeId, Guid? taskClosedBy)
        {
            return ATP.Common.ProxyHelper.Service<IDealer>.Use(svcs =>
            {
                return svcs.CloseVehicleSericeTask(vehicleServiceMPIMasterGuid, serviceTypeId, taskClosedBy);
                
            });

           
        }

        public List<uspSelVehicleServicePricing_Result> SelVehicleServicePricing(int? DealerId, Guid? vehicleServiceGuid, Guid? SW, Guid? techGuid, Guid? partsGuid,int? ServiceTypeId)
        {
            return ATP.Common.ProxyHelper.Service<IDealer>.Use(svcs =>
            {
                return svcs.SelVehicleServicePricing(DealerId, vehicleServiceGuid,SW,techGuid,partsGuid,ServiceTypeId);
            });
        }


        public List<uspSelVehicleServicePricingSW_Result> SelVehicleServicePricingSW(int? DealerId, Guid? vehicleServiceGuid, Guid? SW, Guid? techGuid, Guid? partsGuid, int? ServiceTypeId)
        {
            return ATP.Common.ProxyHelper.Service<IDealer>.Use(svcs =>
            {
                return svcs.SelVehicleServicePricingSW(DealerId, vehicleServiceGuid, SW, techGuid, partsGuid, ServiceTypeId);
            });
        }

        public List<uspSelVehicleServicePricingTech_Result> SelVehicleServicePricingTech(int? DealerId, Guid? vehicleServiceGuid, Guid? SW, Guid? techGuid, Guid? partsGuid, int? ServiceTypeId)
        {
            return ATP.Common.ProxyHelper.Service<IDealer>.Use(svcs =>
            {
                return svcs.SelVehicleServicePricingTech(DealerId, vehicleServiceGuid, SW, techGuid, partsGuid, ServiceTypeId);
            });
        }

        public List<uspSelVehicleServicePricingParts_Result> SelVehicleServicePricingParts(int? DealerId, Guid? vehicleServiceGuid, Guid? SW, Guid? techGuid, Guid? partsGuid, int? ServiceTypeId)
        {
            return ATP.Common.ProxyHelper.Service<IDealer>.Use(svcs =>
            {
                return svcs.SelVehicleServicePricingParts(DealerId, vehicleServiceGuid, SW, techGuid, partsGuid, ServiceTypeId);
            });
        }



        public int? UPSertVehicleServicePricing(uspSelVehicleServicePricing_Result m)
        {

            return ATP.Common.ProxyHelper.Service<IDealer>.Use(svcs =>
            {
                return svcs.UPSertVehicleServicePricing(m);
            });
        }

        public List<uspSelVehicleServicesByDealerEmp_Result> SelVehicleServicesByDealerEmp(Guid? serviceWriterGuid, Guid? techGuid)
        {

            return ATP.Common.ProxyHelper.Service<IDealer>.Use(svcs =>
            {
                return svcs.SelVehicleServicesByDealerEmp(serviceWriterGuid,techGuid);
            });
        }

        public int? UpdateIsVehicleInShop(Guid? VehicleGuid,bool? isVehicleInShop)
        {

            return ATP.Common.ProxyHelper.Service<IDealer>.Use(svcs =>
            {
                return svcs.UpdateIsVehicleInShop(VehicleGuid, isVehicleInShop);
            });
        }

        public List<uspSelMPIImages_Result> SelMPIImages(int dealerId, Guid? personGuid)
        {
            return ATP.Common.ProxyHelper.Service<IDealer>.Use(svcs =>
            {
                return svcs.SelMPIImages(dealerId, personGuid);
            });

        }

        public long? UpSertMPIImages(uspSelMPIImages_Result m)
        {
            return ATP.Common.ProxyHelper.Service<IDealer>.Use(svcs =>
            {
                return svcs.uspUpSertMPIImages(m);
            });
        }

        public List<uspSelPersonGroup_Result> SelPersonGroup(int dealerId)
        {
            return ATP.Common.ProxyHelper.Service<IDealer>.Use(svcs =>
            {
                return svcs.SelPersonGroup(dealerId);
            });
        }

        public int UpdateDealerMsg(int? dealerid, int? msgId, Guid? DealerEmployeeId)
        {
            return ATP.Common.ProxyHelper.Service<IDealer>.Use(svcs =>
            {
                return svcs.UpdateDealerMsg(dealerid,msgId,DealerEmployeeId);
            });
        }

        public int UpdateDealerMsgBell(int? dealerid, int? msgId, Guid? DealerEmployeeId)
        {
            return ATP.Common.ProxyHelper.Service<IDealer>.Use(svcs =>
            {
                return svcs.UpdateDealerMsgBell(dealerid, msgId, DealerEmployeeId);
            });
        }
        public int UpdatePersonVehicleLite(uspSelCustomerLite_Result m)
        {
            return ATP.Common.ProxyHelper.Service<IDealer>.Use(svcs =>
            {
                return svcs.UpdatePersonVehicleLite(m);
            });
        }

        public int UpsertDealerKiosk(uspSelDealerKiosks_Result m)
        {
            return ATP.Common.ProxyHelper.Service<IDealer>.Use(svcs =>
            {
                return svcs.UpsertDealerKiosk(m);
            });
        }

        public List<uspSelAdminMPIListByDealerId_Result> SelAdminMPIListByDealerId(int? dealerId)
        {
            return ATP.Common.ProxyHelper.Service<IDealer>.Use(svcs =>
            {
                return svcs.SelAdminMPIListByDealerId(dealerId);
            });
        }

        public int? SelMPICountByServiceGuid(Guid VehicleServiceGuid)
        {

            return ATP.Common.ProxyHelper.Service<DealerSvcRef.IDealer>.Use(svcs =>
            {
                return svcs.SelMPICountByServiceGuid(VehicleServiceGuid);
            });
        }
        public List<uspSelAllMPIGroups_Result> SelAllMPIGroups()
        {
            return ATP.Common.ProxyHelper.Service<DealerSvcRef.IDealer>.Use(svcs =>
            {
                return svcs.SelAllMPIGroups();
            });

           
        }
        public List<uspSelAllMPIItems_Result> SelAllMPIItems()
        {
            return ATP.Common.ProxyHelper.Service<DealerSvcRef.IDealer>.Use(svcs =>
            {
                return svcs.SelAllMPIItems();
            });

            
        }
        public int UpsertDealerMPIGroupItems(int? dealerId, int? mPIGroupPosition, int? mPIGroupId, int? mPIItemId, bool? isValid, int? sortOrder)
        {
            return ATP.Common.ProxyHelper.Service<DealerSvcRef.IDealer>.Use(svcs =>
            {
                return svcs.UpsertDealerMPIGroupItems(dealerId, mPIGroupPosition, mPIGroupId, mPIItemId, isValid, sortOrder); 
            });

            
        }
        public List<uspSelDealerByFamilyId_Result> SelDealerByFamilyId(string Token, string dealerGroupId)
        {
            return ATP.Common.ProxyHelper.Service<IDealer>.Use(svcs =>
          {
              return svcs.SelDealerByFamilyId(Token, dealerGroupId);
          });

        }

        public List<uspSelDealerKiosks_Result> SelDealerKiosks(bool valid, int dealerId)
        {
            return ATP.Common.ProxyHelper.Service<IDealer>.Use(svcs =>
            {
                return svcs.SelDealerKiosks(valid, dealerId);
            });
        }

        public int UpdateKioskResetPassword(int Id)
        {
            return ATP.Common.ProxyHelper.Service<IDealer>.Use(svcs =>
            {
                return svcs.UpdateKioskResetPassword(Id);
            });
        }

        public List<uspSelMPIListByDealerId_Result> SelMPIListByDealerId(int? dealerId, Guid vehicleServiceGuid,Guid PersonGuid)
        {
            return ATP.Common.ProxyHelper.Service<IDealer>.Use(svcs =>
            {
                return svcs.SelMPIListByDealerId(dealerId, vehicleServiceGuid, PersonGuid);
            });
        }
        //public List<uspSelVehicleServiceMPIDetailChassis_Result> SelVehicleServiceMPIDetailChassis(Guid VehicleServiceGuid, Guid MPIMasterGuid)
        //{


        //    return ATP.Common.ProxyHelper.Service<DealerSvcRef.IDealer>.Use(svcs =>
        //{
        //    return svcs.SelVehicleServiceMPIDetailChassis(VehicleServiceGuid, MPIMasterGuid);
        //});

        //}
        //public List<uspSelVehicleServiceMPIDetailBrakes_Result> SelVehicleServiceMPIDetailBrakes(Guid VehicleServiceGuid, Guid MPIMasterGuid)
        //{
        //    return ATP.Common.ProxyHelper.Service<IDealer>.Use(svcs =>
        //    {
        //        return svcs.SelVehicleServiceMPIDetailBrakes(VehicleServiceGuid, MPIMasterGuid);
        //    });
        //}
        //public List<uspSelVehicleServiceMPIDetailTires_Result> SelVehicleServiceMPIDetailTires(Guid VehicleServiceGuid, Guid MPIMasterGuid)
        //{
        //    return ATP.Common.ProxyHelper.Service<DealerSvcRef.IDealer>.Use(svcs =>
        //    {
        //        return svcs.SelVehicleServiceMPIDetailTires(VehicleServiceGuid, MPIMasterGuid);
        //    });
        //}


      public  int UpsertDealerContacts(uspSelDealerDetailsById_Result m)
        {
            return ATP.Common.ProxyHelper.Service<DealerSvcRef.IDealer>.Use(svcs =>
            {
                return svcs.UpsertDealerContacts(m);
            });
        }

        public int UpsertDealerEmployee(uspSelDealerEmployees_Result m)
        {
            return ATP.Common.ProxyHelper.Service<DealerSvcRef.IDealer>.Use(svcs =>
            {
                return svcs.UpsertDealerEmployee(m);
            });
        }
        public int UpsertVehicleServiceMPI(int DealerId,Guid? MPIMasterGuid, Guid? VehicleServiceGuid, Guid? PersonGuid, Guid? VehicleGuid, string techComments, string techWriterComments, Guid? EnteredBy,
             string MilesIn,
                    string MilesOut,
                    string RoNum,
                    string FleetNumber, List<VehicleServiceMPIDataTable> vehicleServiceMPIDataTable, MPIDetailTiresDataTable mpiDetailTiresTableType, MPIDetailBrakesDataTable mpiDetailBrakesDataTable, MPIDetailChassisDataTable mpiDetailChassisDataTable)
        {
            return ATP.Common.ProxyHelper.Service<DealerSvcRef.IDealer>.Use(svcs =>
            {
                return svcs.UpsertVehicleServiceMPI(DealerId,MPIMasterGuid, VehicleServiceGuid, PersonGuid, VehicleGuid, techComments, techWriterComments, EnteredBy,  MilesIn,
                     MilesOut,
                     RoNum,
                     FleetNumber, vehicleServiceMPIDataTable, mpiDetailTiresTableType, mpiDetailBrakesDataTable, mpiDetailChassisDataTable);
            });
        }

        public List<uspSelKioskByMachineId_Result> SelKioskByMachineId(string Token, string machineId)
        {
            return ATP.Common.ProxyHelper.Service<DealerSvcRef.IDealer>.Use(svcs =>
            {
                return svcs.SelKioskByMachineId(Token, machineId);
            });
        }



        public List<uspSelDealerDept_Result> SelDealerDept(string Token, int? dealerId)
        {
            return ATP.Common.ProxyHelper.Service<DealerSvcRef.IDealer>.Use(svcs =>
            {
                return svcs.SelDealerDept(Token, dealerId);
            });
        }

        public List<uspSelDealerEmployees_Result> SelDealerEmployees(string Token, int? dealerId)
        {
            return ATP.Common.ProxyHelper.Service<DealerSvcRef.IDealer>.Use(svcs =>
            {
                return svcs.SelDealerEmployees(Token, dealerId);
            });
        }

        public List<uspSelDealerPreTextMessage_Result> SelDealerPreTextMessage(string Token, int? dealerId)
        {
            return ATP.Common.ProxyHelper.Service<DealerSvcRef.IDealer>.Use(svcs =>
            {
                return svcs.SelDealerPreTextMessage(Token, dealerId);
            });
        }

        public int UpsertPreTextMessage(uspSelDealerPreTextMessage_Result msg)
        {

            return ATP.Common.ProxyHelper.Service<DealerSvcRef.IDealer>.Use(svcs =>
            {
                return svcs.UpsertPreTextMessage(msg);
            });
        }

        public int InsDealerMsg(uspSelDealerMsg_Result msg, List<DealerEmpMsgDataTable> dealerEmpMsgDataTable)
        {
            return ATP.Common.ProxyHelper.Service<DealerSvcRef.IDealer>.Use(svcs =>
            {
                return svcs.InsDealerMsg(msg, dealerEmpMsgDataTable);
            });
        }

        public List<uspSelDealerMessage_Result> SelDealerMsg(uspSelDealerMessage_Result msg)
        {
            return ATP.Common.ProxyHelper.Service<DealerSvcRef.IDealer>.Use(svcs =>
            {
                return svcs.SelDealerMessage(msg);
            });
        }
        #region "Adam Lite"
        public List<uspSelDealerMsgHist_Result> SelDealerMsgHist(uspSelDealerMsgHist_Result msg)
        {
            return ATP.Common.ProxyHelper.Service<DealerSvcRef.IDealer>.Use(svcs =>
            {
                return svcs.SelDealerMsgHist(msg);
            });
        }
        public List<uspSelCustomerLite_Result> SelCustomerLite(uspSelCustomerLite_Result msg)
        {
            return ATP.Common.ProxyHelper.Service<DealerSvcRef.IDealer>.Use(svcs =>
            {
                return svcs.SelCustomerLite(msg);
            });
        }

        #endregion

        public List<uspLoginDealerEmployee_Result> LoginDealerEmployee(int? dealerId, string userName, string password)
        {
            return ATP.Common.ProxyHelper.Service<DealerSvcRef.IDealer>.Use(svcs =>
            {
                return svcs.LoginDealerEmployee(dealerId, userName, password);
            });
        }

        public List<uspLoginDealerEmployeeByEmail_Result> LoginDealerEmployeeByEmail(string userEmail, string password)
        {
            return ATP.Common.ProxyHelper.Service<DealerSvcRef.IDealer>.Use(svcs =>
            {
                return svcs.LoginDealerEmployeeByEmail(userEmail, password);
            });
        }


        public List<uspSelDealerEmpPages_Result> SelDealerEmpPages(int? dealerId, Guid? dealerEmpGuid)
        {
            return ATP.Common.ProxyHelper.Service<DealerSvcRef.IDealer>.Use(svcs =>
            {
                return svcs.SelDealerEmpPages(dealerId, dealerEmpGuid);
            });
        }

        public List<uspSelDealerEmpPagesAdmin_Result> SelDealerEmpPagesAdmin(int? dealerId, Guid? dealerEmpGuid)
        {
            return ATP.Common.ProxyHelper.Service<DealerSvcRef.IDealer>.Use(svcs =>
            {
                return svcs.SelDealerEmpPagesAdmin(dealerId, dealerEmpGuid);
            });
        }

        public int UpdateEmpPagesAdmin(int? dealerId, Guid? dealerEmpGuid, int? pageId, bool isEnabled)
        {
            return ATP.Common.ProxyHelper.Service<DealerSvcRef.IDealer>.Use(svcs =>
            {
                return svcs.UpdateEmpPagesAdmin(dealerId, dealerEmpGuid,pageId,isEnabled);
            });
        }

        public List<uspSelKeyLockerOpenPeg_Result> SelKeyLockerOpenPeg(uspSelKeyLockerOpenPeg_Result x)
        {
            return ATP.Common.ProxyHelper.Service<DealerSvcRef.IDealer>.Use(svcs =>
            {
                return svcs.SelKeyLockerOpenPeg(x);
            });
        }

        public int UpdKeyLockerPeg(uspSelKeyLockerOpenPeg_Result x)
        {
            return ATP.Common.ProxyHelper.Service<DealerSvcRef.IDealer>.Use(svcs =>
            {
                return svcs.UpdKeyLockerPeg(x);
            });
        }
        public uspInsAddress_Result InsertAddress(Nullable<System.Guid> gUID, Nullable<System.Guid> personGUID, Nullable<int> dealerId, Nullable<byte> typeId, Nullable<int> sTPId, Nullable<bool> preferred, string line1, string line2, string line3, string city, string zipCode, string zipPlus, Nullable<decimal> longitude, Nullable<decimal> latitude, Nullable<bool> valid, Nullable<System.Guid> enteredBy, Nullable<System.DateTime> entered)
        {
            return ATP.Common.ProxyHelper.Service<DealerSvcRef.IDealer>.Use(svcs =>
            {
                return svcs.InsertAddress(gUID, personGUID, dealerId, typeId, sTPId, preferred, line1, line2, line3, city, zipCode, zipPlus, longitude, latitude, valid,
                    enteredBy, entered);
            });
        }

        public Guid? RegisterCustomer(Customer jSonCustomer)
        {
            return ATP.Common.ProxyHelper.Service<DealerSvcRef.IDealer>.Use(svcs =>
            {
                return svcs.RegisterCustomer(jSonCustomer);
            });
        }

        public List<uspSelDealerByFamilyId_Result> SelDealerByFamilyId(string dealerGroupId)
        {
            //  int? grpId = Convert.ToInt16(dealerGroupId);

            return ATP.Common.ProxyHelper.Service<DealerSvcRef.IDealer>.Use(svcs =>
            {
                return svcs.SelDealerByFamilyId(null, dealerGroupId);
            });

        }
        public List<uspGetDealerDetails_Result> GetDealerDetails(string Token, string machineId)
        {
            return ATP.Common.ProxyHelper.Service<DealerSvcRef.IDealer>.Use(svcs =>
                                                                 {
                                                                     return svcs.GetDealerDetails(Token, machineId);
                                                                 });
        }

        public List<uspSelDealerDetailsById_Result> SelDealerDetailsById(int dealerId)
        {
            return ATP.Common.ProxyHelper.Service<DealerSvcRef.IDealer>.Use(svcs =>
            {
                return svcs.SelDealerDetailsById(dealerId);
            });
        }


        public int UpdateAllServiceStatusToComplete(string Token, int? dealerId)
        {
            return ATP.Common.ProxyHelper.Service<DealerSvcRef.IDealer>.Use(svcs =>
            {
                return svcs.UpdateAllServiceStatusToComplete(Token, dealerId);
            });
        }

        public List<uspVerifySendAlertsUser_Result> VerifySendAlertsUser(string Token, int dealerId, string userName, string password, string roles)
        {
            return ATP.Common.ProxyHelper.Service<DealerSvcRef.IDealer>.Use(svcs =>
            {
                return svcs.VerifySendAlertsUser(Token, dealerId, userName, password, roles);
            });
        }

        public List<uspSelVehSvcsForARCH_Result> SelVehSvcsForARCH(string Token, int dealerId, DateTime? serviceDateFrom, DateTime? serviceDateTo, string lastName, int? serviceStatusId, bool showInServiceCustomer)
        {
            return ATP.Common.ProxyHelper.Service<DealerSvcRef.IDealer>.Use(svcs =>
            {
                return svcs.SelVehSvcsForARCH(Token, dealerId, serviceDateFrom, serviceDateTo, lastName, serviceStatusId, showInServiceCustomer);
            });
        }

        public List<uspSelVehSvcsWebARCH_Result> SelVehSvcsWebARCH(uspSelVehSvcsWebARCH_Result x)
        {
            return ATP.Common.ProxyHelper.Service<DealerSvcRef.IDealer>.Use(svcs =>
            {
                return svcs.SelVehSvcsWebARCH(x);
            });
        }

        public List<uspSelVehAlertByVehSvcGuid_Result> SelVehAlertByVehGuid(string token, Guid vehicleServiceGuid)
        {
            return ATP.Common.ProxyHelper.Service<DealerSvcRef.IDealer>.Use(svcs =>
            {
                return svcs.SelVehAlertByVehsSvcGuid(token, vehicleServiceGuid);
            });
        }

        public List<uspLkpTables_Result> SelLookUpTable(string token, string tableName)
        {
            return ATP.Common.ProxyHelper.Service<DealerSvcRef.IDealer>.Use(svcs =>
            {
                return svcs.SelLookUpTable(token, tableName);
            });
        }

        public List<uspSelLookUpTableByDealerId_Result> SelLookUpTableByDealerId(string tableName, int? dealerId)
        {
            return ATP.Common.ProxyHelper.Service<DealerSvcRef.IDealer>.Use(svcs =>
            {
                return svcs.SelLookUpTableByDealerId(tableName, dealerId);
            });

        }

        public int UpSertEmailAddress(string token, uspSelVehSvcsForARCH_Result data)
        {
            return ATP.Common.ProxyHelper.Service<DealerSvcRef.IDealer>.Use(svcs =>
            {
                return svcs.UpSertEmailAddress(token, data);
            });
        }

        public int UpSertPhoneAddress(string Token, uspSelVehSvcsForARCH_Result data)
        {

            return ATP.Common.ProxyHelper.Service<DealerSvcRef.IDealer>.Use(svcs =>
            {
                return svcs.UpSertPhoneNumber(Token, data);
            });
        }

        public int UpSertPhoneByPersonGuid(Guid? phoneGuid, string phoneNumber, Guid? updatedBy, Guid? enteredBy, Guid? personGuid)
        {
            return ATP.Common.ProxyHelper.Service<DealerSvcRef.IDealer>.Use(svcs =>
            {
                return svcs.UpSertPhoneByPersonGuid(phoneGuid, phoneNumber, updatedBy, enteredBy, personGuid);
            });
        }

        public int UpSertEmailByPersonGuid(Guid? emailGuid, string emailAddress, Guid? updatedBy, Guid? enteredBy, Guid? personGuid)
        {
            return ATP.Common.ProxyHelper.Service<DealerSvcRef.IDealer>.Use(svcs =>
            {
                return svcs.UpSertEmailByPersonGuid(emailGuid, emailAddress, updatedBy, enteredBy, personGuid);
            });
        }


        public int InsVehAlert(string Token, uspSelVehAlertByVehSvcGuid_Result alert)
        {
            return ATP.Common.ProxyHelper.Service<DealerSvcRef.IDealer>.Use(svcs =>
            {
                return svcs.InsVehAlert(Token, alert);
            });
        }

        public int UpdateVehiceServiceStatus(string Token, Nullable<System.Guid> vehicleServiceGUID, Nullable<byte> statusId, Nullable<System.Guid> updatedBy, Nullable<System.DateTime> updated)
        {
            return ATP.Common.ProxyHelper.Service<DealerSvcRef.IDealer>.Use(svcs =>
            {
                return svcs.UpdateVehiceServiceStatus(Token, vehicleServiceGUID, statusId, updatedBy);
            });


        }

        public List<uspSelPkgByDealerId_Result> GetServicePackages(string dealerId, string VIN)
        {
            return ATP.Common.ProxyHelper.Service<DealerSvcRef.IDealer>.Use(svcs =>
            {
                return svcs.GetServicePackages(dealerId, VIN);
            });
        }

        public List<uspSelSvcTypeByDealerId_Result> GetServiceTypes(string dealerId, string VIN)
        {
            return ATP.Common.ProxyHelper.Service<DealerSvcRef.IDealer>.Use(svcs =>
            {
                return svcs.GetServiceTypes(dealerId, VIN);
            });
        }

        public List<uspSelSvcTypeByPkgId_Result> SelSvcTypeByPkgId(int dealerId, int packageId)
        {
            return ATP.Common.ProxyHelper.Service<DealerSvcRef.IDealer>.Use(svcs =>
            {
                return svcs.SelSvcTypeByPkgId(dealerId, packageId);
            });
        }


        public List<uspSelPackageByDealerId_Result> SelPackageByDealerId(string dealerId)
        {
            return ATP.Common.ProxyHelper.Service<DealerSvcRef.IDealer>.Use(svcs =>
            {
                return svcs.SelPackageByDealerId(dealerId);
            });

        }
        public List<uspSelServiceTypeEmails_Result> SelServiceTypeEmails(string serviceTypes, string packageIds)
        {
            return ATP.Common.ProxyHelper.Service<DealerSvcRef.IDealer>.Use(svcs =>
            {
                return svcs.SelServiceTypeEmails(serviceTypes, packageIds);
            });
        }

        public ATPData ScheduleService(ATPServiceDataMasterKiosk serviceDataMasterlist)
        {
            return ATP.Common.ProxyHelper.Service<DealerSvcRef.IDealer>.Use(svcs =>
            {
                return svcs.ScheduleService(serviceDataMasterlist);
            });
        }

        public List<short?> GetYears()
        {

            return ATP.Common.ProxyHelper.Service<DealerSvcRef.IDealer>.Use(svcs =>
            {
                return svcs.GetYears();
            });


        }

        public List<uspSelVehicleMakes_Result> GetMakes(string year, string dealerId)
        {
            return ATP.Common.ProxyHelper.Service<DealerSvcRef.IDealer>.Use(svcs =>
            {
                return svcs.GetMakes(year, dealerId);
            });


        }

        public List<uspSelVehicleModels_Result> GetModels(string year, string makeId)
        {
            return ATP.Common.ProxyHelper.Service<DealerSvcRef.IDealer>.Use(svcs =>
            {
                return svcs.GetModels(year, makeId);
            });


        }

        public List<uspSelVehicleTrims_Result> GetTrims(string year, string makeId, string modelId)
        {
            return ATP.Common.ProxyHelper.Service<DealerSvcRef.IDealer>.Use(svcs =>
            {
                return svcs.GetTrims(year, makeId, modelId);
            });
        }

        public List<uspInsVehicle_Result> InsertVehicle(uspSelVehicleByPersonId_Result vehicle)
        {
            return ATP.Common.ProxyHelper.Service<DealerSvcRef.IDealer>.Use(svcs =>
            {
                return svcs.InsertVehicle(vehicle);
            });


        }

        public uspInsPerson_Result InsertPerson(uspSelPersonById_Result person)
        {
            return ATP.Common.ProxyHelper.Service<DealerSvcRef.IDealer>.Use(svcs =>
            {
                return svcs.InsertPerson(person);
            });
        }
        public List<uspSelVehicleByPersonId_Result> SelVehicleByPersonId(Guid? personGuid)
        {
            return ATP.Common.ProxyHelper.Service<DealerSvcRef.IDealer>.Use(svcs =>
            {
                return svcs.SelVehicleByPersonId(personGuid);
            });

        }

        public List<uspSelVehicleServiceImage_Result> SelVehicleServiceImage(uspSelVehicleServiceImage_Result x)
        {
            return ATP.Common.ProxyHelper.Service<DealerSvcRef.IDealer>.Use(svcs =>
            {
                return svcs.SelVehicleServiceImage(x);
            });
        }

        public int DelVehicleServiceImage(uspSelVehicleServiceImage_Result x)
        {
            return ATP.Common.ProxyHelper.Service<DealerSvcRef.IDealer>.Use(svcs =>
            {
                return svcs.DelVehicleServiceImage(x);
            });

        }

        public int InsVehicleServiceImage(uspSelVehicleServiceImage_Result x)
        {
            return ATP.Common.ProxyHelper.Service<DealerSvcRef.IDealer>.Use(svcs =>
            {
                return svcs.InsVehicleServiceImage(x);
            });
        }

        //public List<uspSelPersonById_Result> SelPersonById(Guid? personGuid)
        //{
        //    return ATP.Common.ProxyHelper.Service<DealerSvcRef.IDealer>.Use(svcs =>
        //             {
        //                 return svcs.SelPersonById(personGuid);
        //             });

        //}

        public List<uspSelPersonByGuid_Result> SelPersonByGuid(Guid? personGuid)
        {
            return ATP.Common.ProxyHelper.Service<DealerSvcRef.IDealer>.Use(svcs =>
            {
                return svcs.SelPersonByGuid(personGuid);
            });

        }

        public List<uspSelPersonByUserName_Result> SelPersonByUserName(bool? IsValid, string userName)
        {
            return ATP.Common.ProxyHelper.Service<DealerSvcRef.IDealer>.Use(svcs =>
            {
                return svcs.SelPersonByUserName(IsValid, userName);
            });
        }

        public List<uspSelPersonByLastFirstName_Result> SelPersonByLastFirstName(string lastName, string firstName)
        {

            return ATP.Common.ProxyHelper.Service<DealerSvcRef.IDealer>.Use(svcs =>
            {
                return svcs.SelPersonByLastFirstName(lastName, firstName).ToList();
            });
        }

        public uspSelVehicleById_Result SelVehicleById(Guid? vehicleGuid)
        {
            return ATP.Common.ProxyHelper.Service<DealerSvcRef.IDealer>.Use(svcs =>
            {
                return svcs.SelVehicleById(vehicleGuid);
            });

        }

        public List<uspSelVehicleSvcsByDealerId_Result> SelVehicleSvcsByDealerId(int? dealerId, int? serviceStatusId, DateTime? startDate, DateTime? endDate, short? pageNumber, short? pageSize)
        {
            return ATP.Common.ProxyHelper.Service<DealerSvcRef.IDealer>.Use(svcs =>
            {
                return svcs.SelVehicleSvcsByDealerId(dealerId, serviceStatusId, startDate, endDate, pageNumber, pageSize).ToList();
            });

        }

        public List<uspSelVehicleSvcsByPersonId_Result> SelVehicleSvcsByPersonId(uspSelVehicleSvcsByPersonId_Result vehSvcs)
        {
            return ATP.Common.ProxyHelper.Service<DealerSvcRef.IDealer>.Use(svcs =>
            {
                return svcs.SelVehicleSvcsByPersonId(vehSvcs).ToList();
            });
        }

        public List<uspSelExpSvcsStatByDealerId_Result> SelExpSvcsStatByDealerId(int? dealerId, int? serviceStatusId, DateTime? startDate, DateTime? endDate, string lastName, short? pageNumber, short? pageSize)
        {
            return ATP.Common.ProxyHelper.Service<DealerSvcRef.IDealer>.Use(svcs =>
            {
                return svcs.SelExpSvcsStatByDealerId(dealerId, serviceStatusId, startDate, endDate, lastName, pageNumber, pageSize).ToList();
            });


        }


        public List<uspSelNextExpressNumber_Result> SelNextExpressNumber(int dealerId, DateTime scheduleDate)
        {
            return ATP.Common.ProxyHelper.Service<DealerSvcRef.IDealer>.Use(svcs =>
            {
                return svcs.SelNextExpressNumber(dealerId, scheduleDate);
            });

        }

        #region "Login"

        public List<uspSecurityLogInByUserName_Result> LogInByUserName(byte? Environment, string userName, string password)
        {
            return ATP.Common.ProxyHelper.Service<DealerSvcRef.IDealer>.Use(svcs =>
            {
                return svcs.LogInByUserName(Environment, userName, password);
            });
        }
        public List<uspSecurityLogInByVIN_Result> LogInByVIN(byte? Environment, string VIN)
        {
            return ATP.Common.ProxyHelper.Service<DealerSvcRef.IDealer>.Use(svcs =>
            {
                return svcs.LogInByVIN(Environment, VIN);
            });
        }
        public List<uspSecurityLogInByIdCard_Result> LogInByIdCard(byte? Environment, string IdCardNumber, string FirstName, string MiddleName, string LastName, string AddressLine1, string AddressLine2, string AddressLine3, string City, string STP, string ZipCode, string ZipPlus)
        {
            return ATP.Common.ProxyHelper.Service<DealerSvcRef.IDealer>.Use(svcs =>
            {
                return svcs.LogInByIdCard(Environment, IdCardNumber, FirstName, MiddleName, LastName, AddressLine1, AddressLine2, AddressLine3, City, STP, ZipCode, ZipPlus); ;
            });
        }
        public int LogInByCreditCard(byte? Environment, string CreditCardNumber, byte ExpirationMonth, short ExpirationYear, string FirstName, string MiddleName, string LastName)
        {
            return ATP.Common.ProxyHelper.Service<DealerSvcRef.IDealer>.Use(svcs =>
            {
                return svcs.LogInByCreditCard(Environment, CreditCardNumber, ExpirationMonth, ExpirationYear, FirstName, MiddleName, LastName);

            });
        }
        public List<uspSecurityLogOut_Result> LogOut(System.Guid? GUID, string Token)
        {
            return ATP.Common.ProxyHelper.Service<DealerSvcRef.IDealer>.Use(svcs =>
            {
                return svcs.LogOut(GUID, Token);
            });
        }

        #endregion

        public void LogError(string msg)
        {
            var x = ATP.Common.ProxyHelper.Service<DealerSvcRef.IDealer>.Use(svcs =>
            {
                return svcs.LogError(msg);
            });
        }


        public string PingMe(string s)
        {
            return ATP.Common.ProxyHelper.Service<DealerSvcRef.IDealer>.Use(svcs =>
            {
                return svcs.PingMe(s);
            });
        }
    }
}
