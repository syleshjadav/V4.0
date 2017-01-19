using ATP.DataModel;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;

namespace ATP.Services.Data
{
    public class Person
    {
        public void CreateNewCustomer(uspSelVehSvcsForARCH_Result x)
        {
            using (var entity = new ATP.DataModel.Entities())
            {
                var xx= entity.uspCreateNewCustomer(x.DealerId,5, x.FirstName, "", x.LastName, x.EmailAddress, x.PhoneNumber ,x.Address1,x.Address2,"",x.City,x.State,x.Zip, x.Plate,x.VIN,x.NextServiceDate,x.NextInspectionDate,x.NextServiceDate,x.NextSvcInfo,x.vehYear,0,15000,x.VehicleName,x.VehicleYrMkMod, x.DealerPersonGroupId,null,null,null, null, null, null, null, null, null, null, null, null, null,null,null);

            }
        }

        public int? UpdateIsVehicleInShop(Guid? VehicleGuid,bool? isVehicleInShop)
        {
            using (var entity = new ATP.DataModel.Entities())
            {
                return entity.uspUpdateIsVehicleInShop(VehicleGuid, isVehicleInShop);
            }
        }

        public List<uspSelCustomerDetailsByGuid_Result> SelCustomerDetailsByGuid(int? dealerId, Guid? personGuid, int? vehicleId)
        {
            using (var entity = new ATP.DataModel.Entities())
            {

                return entity.uspSelCustomerDetailsByGuid(dealerId, personGuid, vehicleId).ToList();
            }
        }


        public List<uspFindCustomerByPhPlateEmail_Result> FindCustomerByPhPlateEmail(string Plate, string Phone, string Email,string googguid) {
            using (var entity = new ATP.DataModel.Entities()) {

                return entity.uspFindCustomerByPhPlateEmail(Plate, Phone, Email,null,null, googguid).ToList();
            }
        }

        public List<string> GenerateOTP(Guid? personGuid) {
            using (var entity = new ATP.DataModel.Entities()) {

                return entity.uspGenerateOTP(personGuid).ToList();
            }
        }

        public int DeleteCustomerByGuid(Guid? personGuid) {
            using (var entity = new ATP.DataModel.Entities()) {

                return entity.uspDeleteCustomerByGuid(personGuid);
            }
        }

        public List<uspVerifyOTP_Result> VerifyOTP(Guid? personGuid,string OTP) {
            using (var entity = new ATP.DataModel.Entities()) {

                return entity.uspVerifyOTP(personGuid,OTP).ToList();
            }
        }


        public int UpdateGoogleGuid(Guid? personGuid, string googleGuid,byte deviceTypeId) {
            using (var entity = new ATP.DataModel.Entities()) {

                return entity.uspUpdateGoogleGuid(personGuid, googleGuid,deviceTypeId);
            }
        }

        public List<uspSelPersonGroup_Result> SelPersonGroup(int dealerId)
        {

            using (var entity = new ATP.DataModel.Entities())
            {
                var xx = entity.uspSelPersonGroup(dealerId);

                return xx.ToList();
            }

        }

        public int UpSertEmailAddress(string Token, uspSelVehSvcsForARCH_Result data)
        {
            try
            {
                // Nullable<System.Guid> emailGuid, string emailAddress, Nullable<System.Guid> updatedBy, Nullable<System.Guid> vehicleServiceGuid, Nullable<System.Guid> vehicleGuid

                using (var entity = new ATP.DataModel.Entities())
                {
                    var xx = entity.uspUpSertEmailAddress(data.PersonGuid, data.EmailAddress, data.UpdatedBy, data.EnteredBy, data.VehicleServiceGuid, data.VehicleGuid, 4);

                    return xx;
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }

            return -1;
        }
        public int UpSertPhoneNumber(string Token, uspSelVehSvcsForARCH_Result data)
        {
            try
            {
                using (var entity = new ATP.DataModel.Entities())
                {
                    var xx = entity.uspUpSertPhoneNumber(data.PersonGuid, data.PhoneNumber, data.UpdatedBy, data.EnteredBy, data.VehicleServiceGuid, data.VehicleGuid, 2);

                    return xx;
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }

            return -1;
        }

        public int UpSertPhoneByPersonGuid(Guid? phoneGuid, string phoneNumber, Guid? updatedBy, Guid? enteredBy, Guid? personGuid)
        {

            using (var entity = new ATP.DataModel.Entities())
            {
                var xx = entity.uspUpSertPhoneByPersonGuid(phoneGuid, phoneNumber, updatedBy, enteredBy, personGuid, 2);
                return xx;
            }


        }

        public int UpSertEmailByPersonGuid(Guid? emailGuid, string emailAddress, Guid? updatedBy, Guid? enteredBy, Guid? personGuid)
        {

            using (var entity = new ATP.DataModel.Entities())
            {
                var xx = entity.uspUpSertEmailByPersonGuid(emailGuid, emailAddress, updatedBy, enteredBy, personGuid, 2);
                return xx;
            }


        }

        public uspInsAddress_Result InsertAddress(Nullable<System.Guid> gUID, Nullable<System.Guid> personGUID, Nullable<int> dealerId, Nullable<byte> typeId, Nullable<int> sTPId, Nullable<bool> preferred, string line1, string line2, string line3, string city, string zipCode, string zipPlus, Nullable<decimal> longitude, Nullable<decimal> latitude, Nullable<bool> valid, Nullable<System.Guid> enteredBy, Nullable<System.DateTime> entered)
        {
            using (var entity = new ATP.DataModel.Entities())
            {

                return entity.uspInsAddress(gUID, personGUID, dealerId, typeId, sTPId, preferred, line1, line2, line3, city, zipCode, zipPlus, longitude, latitude, valid,
                    enteredBy, entered).FirstOrDefault();
            }
        }


        public List<uspVerifySendAlertsUser_Result> VerifySendAlertsUser(string Token, int dealerId, string userName, string password, string roles)
        {
            try
            {
                using (var entity = new ATP.DataModel.Entities())
                {
                    var xx = entity.uspVerifySendAlertsUser(dealerId, userName, password, roles);

                    return xx.ToList();
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }

            return new List<uspVerifySendAlertsUser_Result>();
        }


        public List<uspSelCustomer_Result> ValidateCustomer(string FirstName, string LastName, string VIN, int dealerId)
        {
            using (var entity = new ATP.DataModel.Entities())
            {
                return entity.uspSelCustomer(FirstName, LastName, VIN, dealerId, null).ToList();
            }
        }

        public List<uspSelChatMessage_Result> SelChatMessage(string FirstName, string LastName, string VIN, int dealerId, string personGuid)
        {
            Guid? pGuid = null;

            if (!String.IsNullOrEmpty(personGuid))
            {
                pGuid = new Guid(personGuid);
            }

            using (var entity = new ATP.DataModel.Entities())
            {
                return entity.uspSelChatMessage(LastName, FirstName, VIN, dealerId, pGuid).ToList();
            }
        }

        public int InsChatMessage(int? alertId, string firstName, string lastName, string VIN, string chatMsg, string dealerId, string personGuid, string dealerEmpGuid, out string outMessage)
        {
            int? deal = Convert.ToInt32(dealerId);
            Guid? pGuid = null;
            Guid? pDealerEmpGuid = null;

            if (!String.IsNullOrEmpty(personGuid))
            {
                pGuid = new Guid(personGuid);
            }

            if (!String.IsNullOrEmpty(dealerEmpGuid))
            {
                pDealerEmpGuid = new Guid(dealerEmpGuid);
            }

            using (var entity = new ATP.DataModel.Entities())
            {
                ObjectParameter outMsg = new ObjectParameter("OutMessage", typeof(String));

                var xxx = entity.uspInsChatMessage(alertId, lastName, firstName, VIN, chatMsg, deal, pGuid, pDealerEmpGuid, outMsg);
                outMessage = outMsg.Value.ToString();
                return xxx;
            }
        }

        public Guid? RegisterCustomer(Customer cust)
        {

            int? mke = Convert.ToInt32(cust.MakeId);
            int? mod = Convert.ToInt32(cust.ModelId);
            int? trim = Convert.ToInt32(cust.TrimId);
            short? yr = Convert.ToInt16(cust.Year);
            int? CurrentMileage = Convert.ToInt32(cust.CurrentMileage);
            int? YearlyMiles = Convert.ToInt32(cust.YearlyMiles);


            using (var entity = new ATP.DataModel.Entities())
            {
                return entity.uspRegisterCustomer(
                                cust.DealerId, cust.DealerFamilyId, cust.FirstName, null, cust.LastName, cust.Email, cust.Phone, cust.Address, cust.Address2, null,
                                cust.City, cust.State, cust.Zip, cust.Plate, cust.VIN,
                                mke, mod, trim, yr, CurrentMileage, YearlyMiles, cust.VehicleName).FirstOrDefault().Result;
            }
        }

        public Guid? RegisterCustomerForPhone(CustomerForRestSvc cust)
        {

            int? mke = Convert.ToInt32(cust.MakeId);
            int? mod = Convert.ToInt32(cust.ModelId);
            int? trim = Convert.ToInt32(cust.TrimId);
            short? yr = Convert.ToInt16(cust.Year);
            int? deal = Convert.ToInt32(cust.DealerId);
            int? dealFmly = Convert.ToInt32(cust.DealerFamilyId);
            int? CurrentMileage = Convert.ToInt32(cust.CurrentMileage);
            int? YearlyMiles = Convert.ToInt32(cust.YearlyMiles);
            var vehName = cust.VehName;

            using (var entity = new ATP.DataModel.Entities())
            {
                return entity.uspRegisterCustomer(
                                deal, dealFmly, cust.FirstName, null, cust.LastName, cust.Email, cust.Phone, cust.Address, cust.Address2, null,
                                cust.City, cust.State, cust.Zip, cust.Plate, cust.VIN,
                                mke, mod, trim, yr, CurrentMileage, YearlyMiles, vehName).FirstOrDefault().Result;
            }
        }

        public uspRegisterCustomerLite_Result RegisterCustomerForLite(CustomerForRestSvcLite cust)
        {


            int? deal = Convert.ToInt32(cust.DealerId);
            int? dealFmly = Convert.ToInt32(cust.DealerFamilyId);



            using (var entity = new ATP.DataModel.Entities())
            {
                return entity.uspRegisterCustomerLite(
                                  deal, dealFmly, cust.FirstName, null, cust.LastName, cust.Email, cust.Phone, cust.Address, cust.Address2, null,
                                  cust.City, cust.State, cust.Zip, cust.VehYrMkMod).FirstOrDefault();
            }
        }

        public uspRegisterCustomerMyShopAuto_Result RegisterCustomerMyShopAuto(ATPCustomerDetailsByGuid m)
        {


            int? deal = Convert.ToInt32(m.DealerId);
            int? dealFmly = Convert.ToInt32(m.DealerFamilyId);



            using (var entity = new ATP.DataModel.Entities())
            {
                return entity.uspRegisterCustomerMyShopAuto(
                                  deal, dealFmly, m.FirstName, null, m.LastName, m.EmailAddress, m.PhoneNumber, m.Address1, m.Address2, null,
                                  m.City, m.State, m.Zip, m.VehicleYear,m.VehicleMake,m.VehicleModel,m.Plate, m.NextInspectionDate, m.NextServiceDate, m.NextSvcInfo,m.VehPhId).FirstOrDefault();
            }
        }


        public int? UpdateCustomerForLite(CustomerForRestSvcLite cust)
        {


            int? deal = Convert.ToInt32(cust.DealerId);
            // int? dealFmly = Convert.ToInt32(cust.DealerFamilyId);
            var personGuid = new Guid(cust.PersonGuid);


            using (var entity = new ATP.DataModel.Entities())
            {
                var X = entity.uspUpdateCustomerLite(deal, personGuid,
                                   cust.FirstName, null, cust.LastName, cust.Email, cust.Phone, cust.Address, cust.Address2,
                                   cust.City, cust.State, cust.Zip, cust.VehYrMkMod);
                return 0;
            }
        }

        public uspUpdateCustomerMyShopAuto_Result UpdateCustomerMyShopAuto(ATPCustomerDetailsByGuid m)
        {


            int? deal = Convert.ToInt32(m.DealerId);
            int? vehId=null;
            var personGuid = new Guid(m.PersonGuid);

            if (!String.IsNullOrEmpty(m.VehicleId) )
            {
                vehId = Convert.ToInt32(m.VehicleId);
            }


            using (var entity = new ATP.DataModel.Entities())
            {
                var X = entity.uspUpdateCustomerMyShopAuto(deal, personGuid, vehId, m.FirstName, null, m.LastName, m.EmailAddress, m.PhoneNumber,
                                   m.Address1, m.Address2, m.City, m.State, m.Zip, m.VehicleYrMkMod, m.NextInspectionDate, m.NextServiceDate,
                                   m.NextSvcInfo,m.VehPhId,m.VehicleYear,m.VehicleMake,m.VehicleModel,m.Plate).FirstOrDefault();
                return X;
            }
        }


        public int RegisterDeviceId(Guid personGuid, string deviceId, byte? deviceTypeId)
        {
            using (var entity = new ATP.DataModel.Entities())
            {

                return entity.uspUpdateDeviceId(personGuid, deviceId, deviceTypeId);
            }
        }

        public string GetDeviceId(string FirstName, string LastName, string VIN)
        {
            using (var entity = new ATP.DataModel.Entities())
            {
                return entity.uspSelDeviceId(FirstName, LastName, VIN).FirstOrDefault();
            }
        }

        public List<uspInsVehicle_Result> InsertVehicle(Nullable<System.Guid> gUID, Nullable<System.Guid> personGUID, Nullable<int> dealerId, Nullable<int> makeId, Nullable<int> modelId, Nullable<int> trimId, Nullable<short> year, Nullable<short> colorId, string name, Nullable<int> mileage, Nullable<int> lastServiceMileage, Nullable<int> yearlyAverageMileage, string color, string licenseNumber, Nullable<int> ePD, string vIN, Nullable<bool> valid, Nullable<System.Guid> enteredBy, Nullable<System.DateTime> entered)
        {
            var vehName = "";

            using (var entity = new ATP.DataModel.Entities())
            {

                return entity.uspInsVehicle(gUID, personGUID, dealerId, makeId, modelId,
                    trimId, year, colorId, name, mileage, lastServiceMileage,
                    yearlyAverageMileage, color, licenseNumber, ePD, vIN, valid, enteredBy,
                    entered, vehName).ToList();
            }
        }

        public uspInsPerson_Result InsertPerson(uspSelPersonById_Result person)
        {
            var gUID = person.GUID;
            var typeId = person.TypeId;
            var userName = person.UserName;
            var password = person.Password;
            var expired = person.Expired;
            var locked = person.Locked;
            var lastLogIn = person.LastLogIn;
            var previousUserName = person.PreviousUserName;
            string previousPassword = person.PreviousPassword;
            var previousModified = person.PreviousModified;
            var googleGUID = person.GoogleGUID;
            byte[] signature = new byte[0];
            var signatureUpdated = person.SignatureUpdated;
            var note = person.Note;
            bool valid = true;
            var enteredBy = person.EnteredBy;
            var entered = person.Entered;

            using (var entity = new ATP.DataModel.Entities())
            {

                var xx = entity.uspInsPerson(gUID, typeId, userName, password, expired, locked, lastLogIn, previousUserName, previousPassword, previousModified, googleGUID, signature, signatureUpdated, note, valid, enteredBy, entered).FirstOrDefault();

                var yy = entity.uspInsPersonName(gUID, xx.Result, 3, null, null, true,
                    person.NameFirst, person.NameMiddle, person.NameLast, true,
                    person.EnteredBy, person.Entered);

                return xx;
            }
        }

        public List<uspSelVehicleByPersonId_Result> SelVehicleByPersonId(Guid? personGuid)
        {
            using (var entity = new ATP.DataModel.Entities())
            {

                return entity.uspSelVehicleByPersonId(personGuid).ToList();
            }
        }
        //remove selpersonbyId soon
        public List<uspSelPersonById_Result> SelPersonById(Guid? personGuid)
        {
            using (var entity = new ATP.DataModel.Entities())
            {

                return entity.uspSelPersonById(personGuid).ToList();
            }
        }

        public List<uspSelPersonByGuid_Result> SelPersonByGuid(Guid? personGuid)
        {
            using (var entity = new ATP.DataModel.Entities())
            {

                return entity.uspSelPersonByGuid(personGuid).ToList();
            }
        }

        public List<uspSelPersonByUserName_Result> SelPersonByUserName(bool? IsValid, string userName)
        {
            using (var entity = new ATP.DataModel.Entities())
            {

                return entity.uspSelPersonByUserName(IsValid, userName).ToList();
            }
        }


        public List<uspSelPersonByLastFirstName_Result> SelPersonByLastFirstName(string lastName, string firstName)
        {
            using (var entity = new ATP.DataModel.Entities())
            {

                return entity.uspSelPersonByLastFirstName(lastName, firstName).ToList();
            }
        }


        public List<uspSelVehicleById_Result> SelVehicleById(Guid? vehicleGuid)
        {
            using (var entity = new ATP.DataModel.Entities())
            {

                return entity.uspSelVehicleById(vehicleGuid).ToList();
            }
        }

        public List<uspSecurityLogInByUserName_Result> LogInByUserName(byte? Environment, string userName, string password)
        {
            using (var entity = new ATP.DataModel.Entities())
            {

                return entity.uspSecurityLogInByUserName(Environment, userName, password).ToList();
            }
        }
        public List<uspSecurityLogInByVIN_Result> LogInByVIN(byte? Environment, string VIN)
        {
            using (var entity = new ATP.DataModel.Entities())
            {

                return entity.uspSecurityLogInByVIN(Environment, VIN).ToList();
            }
        }
        public List<uspSecurityLogInByIdCard_Result> LogInByIdCard(byte? Environment, string IdCardNumber, string FirstName, string MiddleName, string LastName, string AddressLine1, string AddressLine2, string AddressLine3, string City, string STP, string ZipCode, string ZipPlus)
        {
            using (var entity = new ATP.DataModel.Entities())
            {

                return entity.uspSecurityLogInByIdCard(Environment, IdCardNumber, FirstName, MiddleName, LastName, AddressLine1, AddressLine2, AddressLine3, City, STP, ZipCode, ZipPlus).ToList();
            }
        }
        public int LogInByCreditCard(byte? Environment, string CreditCardNumber, byte ExpirationMonth, short ExpirationYear, string FirstName, string MiddleName, string LastName)
        {
            using (var entity = new ATP.DataModel.Entities())
            {

                return entity.uspSecurityLogInByCreditCard(Environment, CreditCardNumber, ExpirationMonth, ExpirationYear, FirstName, MiddleName, LastName);
            }
        }
        public List<uspSecurityLogOut_Result> LogOut(System.Guid? GUID, string Token)
        {
            using (var entity = new ATP.DataModel.Entities())
            {

                return entity.uspSecurityLogOut(GUID).ToList();
            }
        }


    }
}
