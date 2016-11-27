using ATP.DataModel;
using ATP.DataModel.DataTables;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ATP.Services.Data {
    public class Dealer {


        public List<uspSelAllRelatedCustomerVehicleInfo_Result> SelAllRelatedCustomerVehicleInfo(Nullable<long> relatedId, string emailAddress, string phoneNumber) {

            using (var entity = new ATP.DataModel.Entities()) {

                return entity.uspSelAllRelatedCustomerVehicleInfo(relatedId, emailAddress, phoneNumber).ToList();
            }
        }

        public ATP.DataModel.uspAssignKeylockerPin_Result AssignKeylockerPin(ATP.DataModel.uspSelCustomerLite_Result m) {

            using (var entity = new ATP.DataModel.Entities()) {

                var dId = Convert.ToInt32(m.DealerId);
                return entity.uspAssignKeylockerPin(dId, m.PersonGuid, m.VehicleGuid, m.IsPickUpOrDrop).ToList().SingleOrDefault();
            }
        }

        public int UpdateMPIRedYellow(uspSelMPIRedYellowByPersonGuid_Result m) {
            using (var entity = new ATP.DataModel.Entities()) {
                var personGuid = new Guid(m.PersonGuid);
                var dId = Convert.ToInt32(m.DealerId);
                return entity.uspUpdateMPIRedYellow(dId, personGuid, new Guid(m.MPIMasterGuid), m.MPIItemId, m.Custcomments, m.CustacceptedYN, m.VehPhId);
            }
        }
        //

        public List<uspSelMPIRedYellowByPersonGuid_Result> SelMPIRedYellowByPersonGuid(int? dealerId, Guid? personGuid, string VehPhId) {
            using (var entity = new ATP.DataModel.Entities()) {
                return entity.uspSelMPIRedYellowByPersonGuid(dealerId, personGuid, VehPhId).ToList();
            }
        }

        public int UpdatePersonVehicleLite(ATP.DataModel.uspSelCustomerLite_Result m) {
            using (var entity = new ATP.DataModel.Entities()) {
                return entity.uspUpdatePersonVehicleLite(m.VehicleGuid, m.PersonGuid, m.LastName, m.FirstName, m.EmailAddress, m.PhoneNumber, m.DealerPersonGroupId,
                    m.NextServiceDate, m.NextInspectionDate, m.NextEmissionDate, m.NextSvcInfo, m.VIN, m.VehicleYear.ToString(), m.VehicleName, m.Plate, m.VehicleYrMkMod, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null,null,null);
            }
        }
        public int UpdateDealerMsg(int? dealerid, int? msgId, Guid? DealerEmployeeId) {
            using (var entity = new ATP.DataModel.Entities()) {
                return entity.uspUpdateDealerMsg(dealerid, msgId, DealerEmployeeId);
            }
        }

        public int UpdateDealerMsgBell(int? dealerid, int? msgId, Guid? DealerEmployeeId) {
            using (var entity = new ATP.DataModel.Entities()) {
                return entity.uspUpdateDealerMsgBell(dealerid, msgId, DealerEmployeeId);
            }
        }

        public int UpsertDealerKiosk(uspSelDealerKiosks_Result m) {
            using (var entity = new ATP.DataModel.Entities()) {
                return entity.uspUpsertDealerKiosk(m.Id, m.DealerId, m.MachineId, m.OSTypeId, m.Name, m.Valid, m.ReSetPassword);
            }
        }

        public List<uspSelAdminMPIListByDealerId_Result> SelMPIListByDealerId(int? dealerId) {
            using (var entity = new ATP.DataModel.Entities()) {
                return entity.uspSelAdminMPIListByDealerId(dealerId).ToList();
            }
        }

        public List<uspSelMPIListByDealerId_Result> SelMPIListByDealerId(int? dealerId, Guid vehicleServiceGuid, Guid PersongGuid) {
            using (var entity = new ATP.DataModel.Entities()) {
                return entity.uspSelMPIListByDealerId(dealerId, vehicleServiceGuid, PersongGuid).ToList();
            }
        }
        public List<uspSelAllMPIGroups_Result> SelAllMPIGroups() {
            using (var entity = new ATP.DataModel.Entities()) {
                return entity.uspSelAllMPIGroups().ToList();
            }
        }
        public List<uspSelAllMPIItems_Result> SelAllMPIItems() {
            using (var entity = new ATP.DataModel.Entities()) {
                return entity.uspSelAllMPIItems().ToList();
            }
        }
        public int UpsertDealerMPIGroupItems(int? dealerId, int? mPIGroupPosition, int? mPIGroupId, int? mPIItemId, bool? isValid, int? sortOrder) {
            using (var entity = new ATP.DataModel.Entities()) {
                return entity.uspUpsertDealerMPIGroupItems(dealerId, mPIGroupPosition, mPIGroupId, mPIItemId, isValid, sortOrder);
            }
        }

        public List<uspGetDealerDetails_Result> GetDealerDetails(string Token, string machineId) {
            using (var entity = new ATP.DataModel.Entities()) {
                return entity.uspGetDealerDetails(machineId).ToList();
            }
        }

        public int UpsertDealerContacts(uspSelDealerDetailsById_Result m) {
            using (var entity = new ATP.DataModel.Entities()) {
                return entity.uspUpsertDealerContacts(m.Id, m.DealerName, m.Description, m.ImageOSPath, m.ImageHttpPath, m.ServiceEmailFromId, m.ServiceEmailFromName, m.ServiceEmailSubject,
                    m.EmailAddress, m.WebURL, m.Address1, m.Address2, m.City, m.State, m.ZipCode, m.SalesPhone, m.ServicePhone, m.GeneralInquryPhone, m.ManagerName, m.ManagerPhone, m.IsValid);
            }
        }


        public List<uspSelDealerKiosks_Result> SelDealerKiosks(bool valid, int dealerId) {
            using (var entity = new ATP.DataModel.Entities()) {
                return entity.uspSelDealerKiosks(valid, dealerId).ToList();
            }
        }

        public int UpdateKioskResetPassword(int Id) {
            using (var entity = new ATP.DataModel.Entities()) {
                return entity.uspUpdateKioskResetPassword(Id);
            }
        }

        public List<uspSelDealerDetailsById_Result> SelDealerDetailsById(int dealerId) {
            using (var entity = new ATP.DataModel.Entities()) {
                return entity.uspSelDealerDetailsById(dealerId).ToList();
            }
        }

        public int UpdateAllServiceStatusToComplete(string Token, int? dealerId) {
            //using (var entity = new ATP.DataModel.Entities())
            //{
            //    return entity.uspUpdateAllServiceStatusToComplete(dealerId);
            //}
            return 0;
        }


        public List<uspSelDealerFamilies_Result> GetDealerGroups() {
            using (var entity = new ATP.DataModel.Entities()) {
                return entity.uspSelDealerFamilies().ToList();
            }
        }

        //public List<uspSelDealersByFamilyId_Result> GetDealersByFamilyId(string dealerGroupId)
        //{
        //    int? grpId = Convert.ToInt16(dealerGroupId);
        //    using (var entity = new ATP.DataModel.Entities())
        //    {
        //        return entity.uspSelDealersByFamilyId(grpId).ToList();
        //    }
        //}

        public List<uspSelDealerByFamilyId_Result> GetDealersByFamilyId(string dealerGroupId) {
            int? grpId = Convert.ToInt16(dealerGroupId);
            using (var entity = new ATP.DataModel.Entities()) {
                return entity.uspSelDealerByFamilyId(grpId).ToList();
            }
        }

        public List<uspSelDealerDetailsById_Result> SelDealerDetailsById(string dealerGroupId) {
            int? grpId = Convert.ToInt16(dealerGroupId);
            using (var entity = new ATP.DataModel.Entities()) {
                return entity.uspSelDealerDetailsById(grpId).ToList();
            }
        }


        //public int SendMessageToDealer(uspSelVehicleAlertById_Result vehAlertMsg)
        //{
        //    /*  using (var entity = new ATP.DataModel.Entities())
        //      {
        //          return entity.uspInsVehicleAlert(machineId).ToList();
        //      }*/

        //    return 1;
        //}

        public List<uspSelServiceTypeEmails_Result> SelServiceTypeEmails(string serviceTypes, string packageIds) {

            using (var entity = new ATP.DataModel.Entities()) {
                return entity.uspSelServiceTypeEmails(serviceTypes, packageIds).ToList();
            }
        }

        public List<uspSelKioskByMachineId_Result> SelKioskByMachineId(string machineId) {

            using (var entity = new ATP.DataModel.Entities()) {
                return entity.uspSelKioskByMachineId(machineId).ToList();
            }
        }

        public List<uspSelNextExpressNumber_Result> SelNextExpressNumber(Nullable<int> dealerId, Nullable<System.DateTime> scheduleDate) {
            using (var entity = new ATP.DataModel.Entities()) {

                return entity.uspSelNextExpressNumber(dealerId, scheduleDate).ToList();
            }
        }

        public List<uspSelDealerDept_Result> SelDealerDept(string Token, int? dealerId) {
            using (var entity = new ATP.DataModel.Entities()) {
                return entity.uspSelDealerDept(dealerId).ToList();
            }
        }

        public List<uspSelDealerEmployees_Result> SelDealerEmployees(string Token, int? dealerId) {
            using (var entity = new ATP.DataModel.Entities()) {
                return entity.uspSelDealerEmployees(dealerId).ToList();
            }
        }

        public int UpsertDealerEmployee(uspSelDealerEmployees_Result m) {
            using (var entity = new ATP.DataModel.Entities()) {
                return entity.uspUpsertDealerEmployee(m.DealerId, m.EmployeeGuid, m.LoginName, m.EmployeeName, m.EmailAddress, m.PhoneNumber, m.DeptId, m.Password, m.IsValid, m.SiteRole, m.IsEnableDoorBell, m.GoogleGuid, m.DeviceTypeId, null, null, null, null, null);
            }
        }

        public List<uspSelDealerPreTextMessage_Result> SelDealerPreTextMessage(string Token, int? dealerId) {
            using (var entity = new ATP.DataModel.Entities()) {
                return entity.uspSelDealerPreTextMessage(dealerId).ToList();
            }
        }

        public int UpsertPreTextMessage(uspSelDealerPreTextMessage_Result msg) {
            using (var entity = new ATP.DataModel.Entities()) {
                return entity.uspUpsertPreTextMessage(msg.DealerId, msg.DeptId, msg.MessageId, msg.TextMessage, msg.IsDelete);
            }
        }

        public int InsDealerMsg(uspSelDealerMsg_Result msg, List<DealerEmpMsgDataTable> dealerEmpMsgDataTable) {
            using (var entity = new ATP.DataModel.CustomEntities()) {
                return entity.uspInsDealerMsg(msg, dealerEmpMsgDataTable);
            }
        }

        public int InsDealerMsgWeb(uspSelDealerMsg_Result x) {
            using (var entity = new ATP.DataModel.Entities()) {
                return entity.uspInsDealerMsgWeb(x.VehicleServiceGuid, x.VehicleGuid, x.DealerEmpGuid, x.PersonGuid, x.DealerId, x.MsgFrom, x.MsgTo, x.TxtMsg, x.IsCustMsg, x.IsMsgToCust);
            }
        }


        public List<uspSelDealerMessage_Result> SelDealerMessage(uspSelDealerMessage_Result msg) {
            using (var entity = new ATP.DataModel.Entities()) {
                return entity.uspSelDealerMessage(msg.DealerId, msg.DealerEmpGuid, msg.MsgDt, msg.VehicleServiceGuid, msg.PersonGuid, msg.FromPhNum, msg.ToPhNum).ToList();
            }
        }

        #region "Adam Lite"
        public List<uspSelDealerMsgHist_Result> SelDealerMsgHist(uspSelDealerMsgHist_Result msg) {
            using (var entity = new ATP.DataModel.Entities()) {
                return entity.uspSelDealerMsgHist(msg.DealerId, msg.DealerEmpGuid, msg.MsgDtFrom, msg.MsgDtTo, msg.VehicleServiceGuid, msg.FromPhNum, msg.ToPhNum, msg.MsgFrom, msg.MsgTo, msg.PageStartIndex, msg.PageSize).ToList();
            }
        }

        public List<uspSelCustomerLite_Result> SelCustomerLite(uspSelCustomerLite_Result msg) {
            using (var entity = new ATP.DataModel.Entities()) {
                return entity.uspSelCustomerLite(msg.DealerId, msg.LastName, msg.FirstName, msg.PhoneNumber, msg.PageStartIndex, msg.PageSize).ToList();
            }
        }

        #endregion
        public List<uspSelDealerEmpPages_Result> SelDealerEmpPages(int? dealerId, Guid? dealerEmpGuid) {
            using (var entity = new ATP.DataModel.Entities()) {
                return entity.uspSelDealerEmpPages(dealerId, dealerEmpGuid).ToList();
            }
        }
        public List<uspSelDealerEmpPagesAdmin_Result> SelDealerEmpPagesAdmin(int? dealerId, Guid? dealerEmpGuid) {
            using (var entity = new ATP.DataModel.Entities()) {
                return entity.uspSelDealerEmpPagesAdmin(dealerId, dealerEmpGuid).ToList();
            }

        }

        public int UpdateEmpPagesAdmin(int? dealerId, Guid? dealerEmpGuid, int? pageId, bool isEnabled) {
            using (var entity = new ATP.DataModel.Entities()) {
                return entity.uspUpdateEmpPagesAdmin(dealerId, dealerEmpGuid, pageId, isEnabled);
            }

        }

        public List<uspLoginDealerEmployee_Result> LoginDealerEmployee(int? dealerId, string userName, string password) {
            using (var entity = new ATP.DataModel.Entities()) {
                return entity.uspLoginDealerEmployee(dealerId, userName, password).ToList();
            }
        }
        public List<uspLoginDealerEmployeeByEmail_Result> LoginDealerEmployeeByEmail(string userEmail, string password) {
            using (var entity = new ATP.DataModel.Entities()) {
                return entity.uspLoginDealerEmployeeByEmail(userEmail, password).ToList();
            }
        }


        //public List<uspSelKeyLockerOpenPeg_Result> SelKeyLockerOpenPeg(uspSelKeyLockerOpenPeg_Result x)
        //{
        //    using (var entity = new ATP.DataModel.Entities())
        //    {
        //        return entity.uspSelKeyLockerOpenPeg(x.DealerId, x.KeyLockerId, x.DeviceTypeId).ToList();
        //    }
        //}

        public int UpdKeyLockerPeg(uspSelKeyLockerOpenPeg_Result x) {
            using (var entity = new ATP.DataModel.Entities()) {
                return entity.uspUpdKeyLockerPeg(x.DealerId, (byte)x.KeyLockerId,x.KeyLockerPegId,  x.IsDropOrPickUp, x.VehicleServiceGuid, x.ServiceStatusId, x.IsOpen, x.UpdatedBy);
            }
        }


    }
}
