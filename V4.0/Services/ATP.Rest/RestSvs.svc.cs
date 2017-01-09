using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Runtime.Serialization;
using System.Globalization;
using System.Linq;
using System.ServiceModel;

using System.ServiceModel.Activation;
using ATP.DataModel;
using System.Configuration;
using System.Net;
using System.Net.Mail;

namespace ATP.Rest {
    [ServiceErrorBehaviour(typeof(HttpErrorHandler))]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class RestSvs : IRestSvs {
        private const string Token = "m0QDEdNAtH0Kp/l1dsNAmXu1IZrrkPCLuYs1tpf8eGQ";


        //public string GetVinDetails(string vin) {
        //    // var requestUrl = "https://demo.vinterpreter.us:9881/ords/demo/v1/get_vin_info?vin=1FMDU34E8VZA90882";
        //    // var requestUrl = "https://demo.vinterpreter.us:9881/ords/demo/v1/get_recall_info_vin?vin=1ZVFT82H775283137";
        //    var requestUrl = string.Format("{0}{1}", "https://demo.vinterpreter.us:9881/ords/demo/v1/get_vin_info?vin=", vin);
        //    try {
        //        string rtnvalue = "";

        //        var client = new WebClient();


        //        // Synchronous Consumption
        //        //  var client = new WebClient();
        //        client.Headers.Add("API_ACT", "DEMOMYSHOP");
        //        client.Headers.Add("API_KEY", "0C06A4EC8A71236336F1BCF401B50869");

        //        rtnvalue = client.DownloadString(requestUrl);


        //        // Create the Json serializer and parse the response
        //        //DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(RootObject));
        //        //using (var ms = new MemoryStream(Encoding.Unicode.GetBytes(content)))
        //        //{
        //        //    var weatherData = (RootObject)serializer.ReadObject(ms);
        //        //}
        //        return rtnvalue;

        //    }
        //    catch (Exception ex) {
        //        //Console.WriteLine(ex.Message);
        //        return ex.Message;
        //    }
        //}




        public List<ATPDataMPIRedYellow> SelMPIRedYellowByPersonGuid(string dealerId, string pGuid, string VehPhId) {
            try {
                var str = string.Format("Deal={0}, Per={1},vehph={2}", dealerId, pGuid, VehPhId);


                TraceLog("SelMPIRedYellowByPersonGuid", str);

                if (!string.IsNullOrEmpty(dealerId) && !string.IsNullOrEmpty(pGuid)) {

                    var personGuid = new Guid(pGuid);
                    var dId = Convert.ToInt32(dealerId);

                    return new ATP.Services.Data.Dealer().SelMPIRedYellowByPersonGuid(dId, personGuid, VehPhId)
                         .Select(m =>
                         new ATPDataMPIRedYellow {
                             Cost = m.Cost,
                             CustacceptedYN = m.CustacceptedYN,
                             Custcomments = m.Custcomments,
                             DealerId = m.DealerId,
                             IsLocked = m.IsLocked,
                             Itemdesc = m.Itemdesc,
                             MPIItemId = m.MPIItemId,
                             MPIMasterGuid = m.MPIMasterGuid,
                             PersonGuid = m.PersonGuid,
                             RYGNValue = m.RYGNValue,
                             SWComments = m.SWComments,
                             TechComments = m.TechComments,
                             VehicleId = m.VehicleId.ToString(),
                             VehPhId = m.VehPhId

                         }).ToList();


                }
            }
            catch (Exception ex) {
                TraceLog("SelMPIRedYellowByPersonGuid", string.Format("{0} -  Error while SelMPIRedYellowByPersonGuid  - {1}", pGuid, ex.StackTrace));
            }
            return new List<ATPDataMPIRedYellow>();

        }

        public ATPData UpdateMPIRedYellow(ATPDataMPIRedYellow m) {
            var str = "";
            //  TraceLog("UpdateMPIRedYellow", "Inside");
            try {

                str = string.Format("Deal={0}, MPiItem={1},PGuid={2},mpimastguid{3},CustAcc={4}, custComm={5}", m.DealerId, m.MPIItemId, m.PersonGuid, m.MPIMasterGuid, m.CustacceptedYN, m.Custcomments);


                TraceLog("UpdateMPIRedYellow", str);
                //dId, personGuid, new Guid(m.MPIMasterGuid),m.MPIItemId,m.Custcomments,m.CustacceptedYN
                var x = new uspSelMPIRedYellowByPersonGuid_Result {
                    Cost = m.Cost,
                    CustacceptedYN = m.CustacceptedYN,
                    Custcomments = m.Custcomments,
                    DealerId = m.DealerId,
                    IsLocked = m.IsLocked,
                    Itemdesc = m.Itemdesc,
                    MPIItemId = m.MPIItemId,
                    MPIMasterGuid = m.MPIMasterGuid,
                    PersonGuid = m.PersonGuid,
                    RYGNValue = m.RYGNValue,
                    SWComments = m.SWComments,
                    TechComments = m.TechComments

                };


                var xx = new ATP.Services.Data.Dealer().UpdateMPIRedYellow(x);

                return new ATPData { Id = "1", Value = "Success" };

            }
            catch (Exception ex) {
                TraceLog("UpdateMPIRedYellow", string.Format("{0} -  Error while UpdateMPIRedYellow  - {1}", str, ex.Message));
            }
            return new ATPData { Id = "-1", Value = "Failure" };
        }

        public List<ATPCustomerDetailsByGuid> SelCustomerDetailsByGuid(string dealerId, string pGuid, string vehicleId) {
            try {
                if (!string.IsNullOrEmpty(dealerId) && !string.IsNullOrEmpty(pGuid)) {

                    var personGuid = new Guid(pGuid);
                    var dId = Convert.ToInt32(dealerId);
                    var vehId = Convert.ToInt32(vehicleId);
                    //return new ATP.Services.Data.Person().SelCustomerDetailsByGuid(dId, personGuid).ToList();
                    return new ATP.Services.Data.Person().SelCustomerDetailsByGuid(dId, personGuid, vehId)
                         .Select(m =>
                         new ATPCustomerDetailsByGuid {
                             Address1 = m.Address1,
                             Address2 = m.Address2,
                             City = m.City,
                             DealerFamilyId = m.DealerFamilyId.ToString(),
                             DealerId = m.DealerId.ToString(),
                             DeviceTypeId = m.DeviceTypeId.ToString(),
                             DealerPersonGroupId = m.DealerPersonGroupId,
                             EmailAddress = m.EmailAddress,
                             FirstName = m.FirstName,
                             GoogleGuid = m.GoogleGuid,
                             GroupName = m.GroupName,
                             IsValid = m.IsValid.ToString(),
                             LastName = m.LastName,
                             MiddleName = m.MiddleName,
                             NextInspectionDate = m.NextInspectionDate,
                             NextServiceDate = m.NextServiceDate,
                             PersonGuid = m.PersonGuid,
                             PhoneNumber = m.PhoneNumber,
                             Plate = m.Plate,
                             NextSvcInfo = m.NextSvcInfo,
                             State = m.State,
                             VehicleGuid = m.VehicleGuid.ToString(),
                             VehicleMake = m.VehicleMake,
                             VehicleModel = m.VehicleModel,
                             VehicleName = m.VehicleName,
                             VehicleTrim = m.VehicleTrim,
                             VehicleYear = m.VehicleYear != null ? m.VehicleYear.ToString() : "",
                             VehicleYrMkMod = m.VehicleYrMkMod,
                             VIN = m.VIN,
                             Zip = m.ZipCode,
                             VehicleId = m.VehicleId.ToString(),
                             VehPhId = m.VehPhId
                         }).ToList();
                }
            }
            catch (Exception ex) {

                TraceLog("SelCustomerDetailsByGuid", string.Format("{0} -  Error while SelCustomerDetailsByGuid  - {1}", pGuid, ex.Message));

            }

            return new List<ATPCustomerDetailsByGuid>();

        }

        public List<ATPCustomerDetailsByGuid> FindCustByPhPlateEmail(ATPFindExistingCutomer x) {

            try {
                //  var dId = Convert.ToInt32(dealerId);


                return new ATP.Services.Data.Person().FindCustomerByPhPlateEmail(x.Plate, x.Phone, x.EmailAddress, x.DeviceId)
                     .Select(m =>
                     new ATPCustomerDetailsByGuid {

                         DealerFamilyId = "5",
                         DealerId = m.DealerId.ToString(),
                         DealerName = m.DealerName,

                         EmailAddress = m.EmailAddress,
                         FirstName = m.FirstName,
                         GoogleGuid = m.GoogleGuid,
                         LastName = m.LastName,
                         MiddleName = m.MiddleName,
                         NextInspectionDate = m.NextInspectionDate,
                         NextServiceDate = m.NextServiceDate,
                         PersonGuid = m.PersonGuid.ToString(),
                         PhoneNumber = m.PhoneNumber,
                         Plate = m.Plate,
                         VehicleGuid = m.VehicleGuid.ToString(),
                         VehicleMake = m.VehicleMake,
                         VehicleModel = m.VehicleModel,
                         VehicleName = m.VehicleName,
                         VehicleTrim = m.VehicleTrim,
                         VehicleYear = m.VehicleYear != null ? m.VehicleYear.ToString() : "",
                         VehicleYrMkMod = m.VehicleYrMkMod,
                         VIN = m.VIN,
                         VehicleId = m.VehicleId.ToString(),
                         VehPhId = m.VehPhId,
                         Address1 = m.Address1,
                         Address2 = m.Address2,
                         City = m.City,
                         Zip = m.ZipCode,
                         State = m.State,
                         NextSvcInfo = m.NextSvcInfo,
                         DeviceTypeId = m.DeviceTypeId != null ? m.DeviceTypeId.ToString() : "0"

                     }).ToList();

            }
            catch (Exception ex) {

                TraceLog("FindCustByPhPlateEmail", string.Format("{0} -  Error while FindCustByPhPlateEmail  - {1}", x.EmailAddress, ex.Message));

            }

            return new List<ATPCustomerDetailsByGuid>();

        }


        public List<ATPCustomerDetailsByGuid> FindCustomerByPhPlateEmail(string Plate, string Phone, string Email, string GoogleGuid) {

            try {
                //  var dId = Convert.ToInt32(dealerId);


                return new ATP.Services.Data.Person().FindCustomerByPhPlateEmail(Plate, Phone, Email, GoogleGuid)
                     .Select(m =>
                     new ATPCustomerDetailsByGuid {

                         DealerFamilyId = "5",
                         DealerId = m.DealerId.ToString(),
                         DealerName = m.DealerName,

                         EmailAddress = m.EmailAddress,
                         FirstName = m.FirstName,
                         GoogleGuid = m.GoogleGuid,
                         LastName = m.LastName,
                         MiddleName = m.MiddleName,
                         NextInspectionDate = m.NextInspectionDate,
                         NextServiceDate = m.NextServiceDate,
                         PersonGuid = m.PersonGuid.ToString(),
                         PhoneNumber = m.PhoneNumber,
                         Plate = m.Plate,
                         VehicleGuid = m.VehicleGuid.ToString(),
                         VehicleMake = m.VehicleMake,
                         VehicleModel = m.VehicleModel,
                         VehicleName = m.VehicleName,
                         VehicleTrim = m.VehicleTrim,
                         VehicleYear = m.VehicleYear != null ? m.VehicleYear.ToString() : "",
                         VehicleYrMkMod = m.VehicleYrMkMod,
                         VIN = m.VIN,
                         VehicleId = m.VehicleId.ToString(),
                         VehPhId = m.VehPhId,
                         Address1 = m.Address1,
                         Address2 = m.Address2,
                         City = m.City,
                         Zip = m.ZipCode,
                         State = m.State,
                         NextSvcInfo = m.NextSvcInfo,
                         DeviceTypeId = m.DeviceTypeId != null ? m.DeviceTypeId.ToString() : "0"


                     }).ToList();

            }
            catch (Exception ex) {

                TraceLog("FindCustomerByPhPlateEmail", string.Format("{0} -  Error while FindCustomerByPhPlateEmail  - {1}", Email, ex.Message));

            }

            return new List<ATPCustomerDetailsByGuid>();

        }

        public ATPData SendOTPEmail(string pGuid, string vGuid, string Email) {
            var m = new ATPData { Id = "1" };


            try {

                var otp = new ATP.Services.Data.Person().GenerateOTP(new Guid(pGuid)).SingleOrDefault();

                m.Value = "Email Send";

                SendMail(Email, otp);
            }
            catch (Exception ex) {

                TraceLog("FindCustomerByPhPlateEmail", string.Format("{0} -  Error while SendOTPEmail  - {1}", Email, ex.Message));
                m.Value = "Error in sending Email";

            }

            return m;

        }
        public ATPData DeleteCustomer(string pGuid) {

            var m = new ATPData { Id = "1" };
            try {

                var rtn = new ATP.Services.Data.Person().DeleteCustomerByGuid(new Guid(pGuid));

            }
            catch (Exception ex) {

                TraceLog("DeleteCustomer", string.Format("{0} -  Error while DeleteCustomer  - {1}", pGuid, ex.Message));

            }

            return m;

        }



        public List<ATPCustomerDetailsByGuid> VerifyOTP(ATPVerifyCutomerOTP x) {

            string pGuid =x.PersonGuid;
            string OTP=x.OTP; string GoogleGuid=x.DeviceId; string DeviceTypeId=x.DeviceTypeId;



            List<ATPCustomerDetailsByGuid> rtr = new List<ATPCustomerDetailsByGuid>();

            // return rtr;

            try {

                var mx = new ATP.Services.Data.Person().VerifyOTP(new Guid(pGuid), OTP).ToList();

                if (mx != null && mx.Count() > 0) {
                    rtr = mx.Select(m =>
                      new ATPCustomerDetailsByGuid {

                          DealerFamilyId = "5",
                          DealerId = m.DealerId.ToString(),
                          DealerName = "",

                          EmailAddress = m.EmailAddress,
                          FirstName = m.FirstName,
                          GoogleGuid = m.GoogleGuid,
                          LastName = m.LastName,
                          MiddleName = m.MiddleName,
                          NextInspectionDate = m.NextInspectionDate,
                          NextServiceDate = m.NextServiceDate,
                          PersonGuid = m.PersonGuid.ToString(),
                          PhoneNumber = m.PhoneNumber,
                          Plate = m.Plate,
                          VehicleGuid = m.VehicleGuid.ToString(),
                          VehicleMake = m.VehicleMake,
                          VehicleModel = m.VehicleModel,
                          VehicleName = m.VehicleName,
                          VehicleTrim = m.VehicleTrim,
                          VehicleYear = m.VehicleYear != null ? m.VehicleYear.ToString() : "",
                          VehicleYrMkMod = m.VehicleYrMkMod,
                          VIN = m.VIN,
                          VehicleId = m.VehicleId.ToString(),
                          VehPhId = m.VehPhId,
                          Address1 = m.Address1,
                          Address2 = m.Address2,
                          City = m.City,
                          Zip = m.ZipCode,
                          State = m.State,
                          NextSvcInfo = m.NextSvcInfo,
                          DeviceTypeId = m.DeviceTypeId != null ? m.DeviceTypeId.ToString() : "0"
                      }).ToList();
                }
                try { 
                if (mx != null && mx.Count > 0) {
                    var pguid = new Guid(pGuid);
                    byte deviceTypeId = 0;
                    var res = byte.TryParse(DeviceTypeId, out deviceTypeId);
                    var m = new ATP.Services.Data.Person().UpdateGoogleGuid(pguid, GoogleGuid, deviceTypeId);

                }
                }
                catch (Exception ex) {

                    TraceLog("VerifyOTPUpdate", string.Format("{0} -  Error while VerifyOTPupdt  - {1}", pGuid, ex.StackTrace));
                }
            }
            catch (Exception ex) {

                TraceLog("VerifyOTP", string.Format("{0} -  Error while VerifyOTP  - {1}", pGuid, ex.StackTrace));
            }

            return rtr;

        }
        private static void SendMail(string emailAddress, string OTP) {
            //create the mail message 
            MailMessage mail = new MailMessage();

            try {

                //set the addresses 
                mail.From = new MailAddress("postmaster@myshopauto.com"); //IMPORTANT: This must be same as your smtp authentication address.
                mail.To.Add(emailAddress);

                //set the content 
                mail.Subject = "One Time Password ";
                mail.Body = "Your One Time Password is :  " + OTP;
                //send the message 
                SmtpClient smtp = new SmtpClient("mail.myshopauto.com");

                //IMPORANT:  Your smtp login email MUST be same as your FROM address. 
                NetworkCredential Credentials = new NetworkCredential("postmaster@myshopauto.com", "Password#1");
                smtp.Credentials = Credentials;
                smtp.Send(mail);

            }
            catch (Exception ex) {

                TraceLog("SendMail", string.Format("{0}-{1} -  Error while SendMail  - {2}", emailAddress, OTP, ex.Message));
            }



        }

        public List<ATPData> GetDealerGroups() {

            return new ATP.Services.Data.Dealer().GetDealerGroups()
                    .Select(m => new ATPData {
                        Id = m.Id.ToString(),
                        Value = m.Name
                    })
                    .ToList();

        }

        public List<ATPErrorLog> GetAllLogs() {
            try {
                var xx = new ATP.Services.Data.ErrorLogs().SelAllErrors()
                      .Select(m => new ATPErrorLog {
                          Created = m.Created.ToString(),
                          Class = m.Class,
                          Text = m.Text.ToString()
                      })
                      .ToList();

                return xx;
            }
            catch (Exception ex) {

            }
            return new List<ATPErrorLog>();
        }

        public List<ATPData> GetDealers(string dealerGroupId) {
            return new ATP.Services.Data.Dealer().GetDealersByFamilyId(dealerGroupId)
                 .Select(m => new ATPData {
                     Id = m.Id.ToString(),
                     Value = m.Name
                 })
                 .ToList();
        }

        public List<ATPDealerDetails> GetDealerDetails(string dealerId) {
            return new ATP.Services.Data.Dealer().SelDealerDetailsById(dealerId)
                 .Select(m => new ATPDealerDetails {
                     Id = m.Id.ToString(),
                     DealerName = m.DealerName,
                     Address1 = m.Address1,
                     Address2 = m.Address2,
                     City = m.City,
                     State = m.State,
                     ZipCode = m.ZipCode,
                     EmailAddress = m.EmailAddress,
                     ImageHttpPath = m.ImageHttpPath,
                     ManagerName = m.ManagerName,
                     ManagerPhone = m.ManagerPhone,
                     SalesPhone = m.SalesPhone,
                     ServicePhone = m.ServicePhone,
                     GeneralInquryPhone = m.GeneralInquryPhone,
                     WebURL = m.WebURL

                 })
                 .ToList();
        }

        public ATPAlertData GetAlerts(string dealerId, string vin, string lastName, string miles) {
            return new ATPAlertData { Id = "1", ShowYesNo = "Yes", Msg = "Test Alert" };
        }



        //public List<ATPAlertData> GetMPIList(string dealerId, string vin, string firstName, string lastName)
        //{
        //    new List<ATPAlertData>();
        //}

        public string GetAlertDuration() {
            return "24";
        }

        public List<ATPData> GetYears() {
            return new ATP.Services.Data.VehicleService().GetVehicleYears()
                                 .Select(m => new ATPData {
                                     Id = m.Value.ToString(),
                                     Value = m.Value.ToString()
                                 })
                                 .ToList();
        }

        public List<ATPData> GetMakes(string year, string dealerId) {
            return new ATP.Services.Data.VehicleService().GetMakes(year, dealerId)
                               .Select(m => new ATPData {
                                   Id = m.MakeId.ToString(),
                                   Value = m.Make
                               })
                               .ToList();
        }

        public List<ATPData> GetModels(string year, string makeId) {
            return new ATP.Services.Data.VehicleService().GetModels(year, makeId)
                       .Select(m => new ATPData {
                           Id = m.ModelId.ToString(),
                           Value = m.Model
                       })
                       .ToList();
        }

        public List<ATPData> GetTrims(string year, string makeId, string modelId) {
            return new ATP.Services.Data.VehicleService().GetTrims(year, makeId, modelId)
                       .Select(m => new ATPData {
                           Id = m.TrimId.ToString(),
                           Value = m.Trim
                       })
                       .ToList();
        }

        public ATPData ValidateCustomer(string firstName, string lastName, string VIN, string DealerId, string DealerFamilyId) {
            int dealerId = 0;
            dealerId = Convert.ToInt16(DealerId);

            return new ATP.Services.Data.Person().ValidateCustomer(firstName, lastName, VIN, dealerId)
                     .Select(m => new ATPData {
                         Id = m.PersonGUID.ToString(),
                         Value = m.PersonGUID.ToString()
                     })
                     .FirstOrDefault();
        }

        public ATPData RegisterCustomer(CustomerForRestSvc jSonCustomer) {
            try {
                //         int? mke = Convert.ToInt32(cust.MakeId);
                //int? mod = Convert.ToInt32(cust.ModelId);
                //int? trim = Convert.ToInt32(cust.TrimId);
                //short? yr = Convert.ToInt16(cust.Year);
                //int? deal = Convert.ToInt32(cust.DealerId);
                //int? dealFmly = Convert.ToInt32(cust.DealerFamilyId);
                //int? CurrentMileage = Convert.ToInt32(cust.CurrentMileage);
                //int? YearlyMiles = Convert.ToInt32(cust.YearlyMiles);
                //var vehName = cust.VehName;

                TraceLog("RegisterCustomer", string.Format("{0} -  Before RegisterCustomer Insert Called", jSonCustomer.VIN));
                var str = string.Format("Mke:{0}-Mod:{1}-Trim:{2}-Yr:{3}-Deal:{4}-DealFmly:{5}-CurrMil:{6}-YrlyMil:{7}-VehName:{8}-Fn:{9}-Lm:{10}-Email:{11}-Vin:{12}",
                    jSonCustomer.MakeId, jSonCustomer.ModelId, jSonCustomer.TrimId, jSonCustomer.Year, jSonCustomer.DealerId,
                    jSonCustomer.DealerFamilyId, jSonCustomer.CurrentMileage, jSonCustomer.YearlyMiles, jSonCustomer.VehName, jSonCustomer.FirstName, jSonCustomer.LastName, jSonCustomer.Email, jSonCustomer.VIN);

                TraceLog("RegisterCustomer1", str);

                var xx = new ATP.Services.Data.Person().RegisterCustomerForPhone(jSonCustomer);

                return new ATPData { Id = "1", Value = "Success" };

            }
            catch (Exception ex) {
                TraceLog("RegisterCustomer", string.Format("{0} -  Error while RegisterCustomer  - {1}", jSonCustomer.VIN, ex.Message));
            }
            return new ATPData { Id = "-1", Value = "Failure" };
        }

        public ATPData RegisterCustomerLite(CustomerForRestSvcLite jsonCust) {
            try {
                //TraceLog("RegisterCustomer", string.Format("{0} -  Before RegisterCustomer Insert Called", jsonCust.LastName));
                var str = string.Format("Deal:{0}-DealFmly:{1}-VehYrMkMod:{2}-Fn:{3}-Lm:{4}-Email:{5}-Ph:{6}--Add{7}--City{8}--state{9}--zip{10}--PGuid{11}",
                     jsonCust.DealerId, jsonCust.DealerFamilyId, jsonCust.VehYrMkMod, jsonCust.FirstName, jsonCust.LastName,
                     jsonCust.Email, jsonCust.Phone, jsonCust.Address, jsonCust.City, jsonCust.State, jsonCust.Zip, jsonCust.PersonGuid);

                TraceLog("Reg-Cust", str);
                if (String.IsNullOrEmpty(jsonCust.PersonGuid)) {
                    var xx = new ATP.Services.Data.Person().RegisterCustomerForLite(jsonCust);

                    if (xx != null && xx.PersonGUID != null) {
                        return new ATPData { Id = "1", Value = xx.PersonGUID.ToString() };
                    }
                    else {
                        return new ATPData { Id = "-1", Value = "Fail" };
                    }
                }
                else {
                    var xx = new ATP.Services.Data.Person().UpdateCustomerForLite(jsonCust);

                    return new ATPData { Id = "1", Value = "Success" };
                }

            }
            catch (Exception ex) {
                TraceLog("Reg-Cust", string.Format("{0} -  Error while RegisterCustomer  - {1}", jsonCust.LastName, ex.StackTrace));
            }
            return new ATPData { Id = "-1", Value = "Fail" };
        }

        public MyShopRegisterCustomerData RegisterCustomerMyShopAuto(ATPCustomerDetailsByGuid m) {
            try {
                //TraceLog("RegisterCustomer", string.Format("{0} -  Before RegisterCustomer Insert Called", jsonCust.LastName));
                var str = string.Format("Deal:{0}-DealFmly:{1}-VehYrMkMod:{2}-Fn:{3}-Lm:{4}-Email:{5}-Ph:{6}--Add{7}--City{8}--state{9}--zip{10}--PGuid{11}--vehid{12}--VehPhId:{13}-- NextSvcDt:{14}--NextInsMonth:{15}--NextSvcInfo:{16}--Plate:{17}",
                     m.DealerId, m.DealerFamilyId, m.VehicleYrMkMod, m.FirstName, m.LastName,
                     m.EmailAddress, m.PhoneNumber, m.Address1, m.City, m.State, m.Zip, m.PersonGuid, m.VehicleId, m.VehPhId, m.NextServiceDate, m.NextInspectionDate, m.NextSvcInfo, m.Plate);

                TraceLog("RegisterCustomerMyShopAuto", str);
                if (String.IsNullOrEmpty(m.PersonGuid)) {
                    var xx = new ATP.Services.Data.Person().RegisterCustomerMyShopAuto(m);

                    if (xx != null) {
                        str = string.Format("PersonGuid:{0}VehicleId: {1} VehPhId: {2}", xx.PersonGUID.ToString(), xx.VehicleID.ToString(), m.VehPhId);
                        TraceLog("RegisterCustomerMyShopAutoAfterSaveIns", str);
                        return new MyShopRegisterCustomerData { PersonGuid = xx.PersonGUID.ToString(), VehicleId = xx.VehicleID.ToString(), Message = "SUCCESS", VehPhId = m.VehPhId };
                    }
                    else {
                        return new MyShopRegisterCustomerData { PersonGuid = m.PersonGuid, VehicleId = m.VehicleId, Message = "FAIL", VehPhId = m.VehPhId };
                    }
                }
                else {
                    var xx = new ATP.Services.Data.Person().UpdateCustomerMyShopAuto(m);
                    str = string.Format("PersonGuid:{0}VehicleId: {1} VehPhId: {2}", xx.PersonGUID.ToString(), xx.VehicleID.ToString(), m.VehPhId);
                    TraceLog("RegisterCustomerMyShopAutoAfterSaveUpd", str);
                    return new MyShopRegisterCustomerData { PersonGuid = xx.PersonGUID.ToString(), VehicleId = xx.VehicleID.ToString(), Message = "SUCCESS", VehPhId = m.VehPhId };
                }

            }
            catch (Exception ex) {
                TraceLog("Reg-Cust", string.Format("{0} -  Error while RegisterCustomerMyShopAuto  - {1}", m.LastName, ex.StackTrace));
            }
            return new MyShopRegisterCustomerData { PersonGuid = m.PersonGuid, VehicleId = m.VehicleId, Message = "FAIL" };
        }




        //public ATPData UpdateCustomerLite(CustomerForRestSvcLite jsonCust)
        //{
        //    try
        //    {
        //        //TraceLog("RegisterCustomer", string.Format("{0} -  Before RegisterCustomer Insert Called", jsonCust.LastName));
        //        var str = string.Format("Deal:{0}-DealFmly:{1}-VehYrMkMod:{2}-Fn:{3}-Lm:{4}-Email:{5}-Ph:{6}--Add{7}--City{8}--state{9}--zip{10}--guid{11}",
        //             jsonCust.DealerId, jsonCust.DealerFamilyId, jsonCust.VehYrMkMod, jsonCust.FirstName, jsonCust.LastName,
        //             jsonCust.Email, jsonCust.Phone, jsonCust.Address, jsonCust.City, jsonCust.State, jsonCust.Zip, jsonCust.PersonGuid.ToString());

        //        TraceLog("Update-Cust", str);

        //        var xx = new ATP.Services.Data.Person().UpdateCustomerForLite(jsonCust);


        //        return new ATPData { Id = "1", Value = "Success" };
        //    }
        //    catch (Exception ex)
        //    {
        //        TraceLog("update-Cust", string.Format("{0} -  Error while RegisterCustomer  - {1}", jsonCust.LastName, ex.Message));
        //    }
        //    return new ATPData { Id = "-1", Value = "Fail" };
        //}
        public List<ATPAlertData> GetChatMessages(string dealerId, string vin, string firstName, string lastName) {
            var str = string.Format("dealerId:{0}-vin:{1}-firstName:{2}-lastName:{3}", dealerId, vin, firstName, lastName);

            TraceLog("GetChatMessages", str);

            int dealid = Convert.ToInt32(dealerId);
            return new ATP.Services.Data.Person().SelChatMessage(firstName, lastName, vin, dealid, null)
                    .Select(m => new ATPAlertData {
                        Id = m.MsgId.ToString(),
                        ShowYesNo = "Yes",
                        Msg = m.ChatMsg,
                        IsCustMsg = m.IsCustMsg.ToString(),
                        MsgDt = m.MsgDt.ToString()

                    }
                    ).ToList();

        }
        public List<ATPAlertData> GetChatMessagesLite(string dealerId, string pGuid, string firstName, string lastName) {

            var str = string.Format("dealerId:{0}-pGuid:{1}-firstName:{2}-lastName:{3}", dealerId, pGuid, firstName, lastName);

            TraceLog("GetChatMessagesLite", str);

            int dealId = Convert.ToInt32(dealerId);
            return new ATP.Services.Data.Person().SelChatMessage(firstName, lastName, "", dealId, pGuid)
                    .Select(m => new ATPAlertData {
                        Id = m.MsgId.ToString(),
                        ShowYesNo = "Yes",
                        Msg = m.ChatMsg,
                        IsCustMsg = m.IsCustMsg.ToString(),
                        MsgDt = m.MsgDt.ToString()

                    }
                    ).ToList();

        }

        public List<ATPAlertDataNew> GetChatMsgLite(string dealerId, string pGuid, string firstName, string lastName) {

            var str = string.Format("dealerId:{0}-pGuid:{1}-firstName:{2}-lastName:{3}", dealerId, pGuid, firstName, lastName);

            TraceLog("GetChatMsgLite", str);

            int dealId = Convert.ToInt32(dealerId);

            return new ATP.Services.Data.Person().SelChatMessage(firstName, lastName, "", dealId, pGuid)
                    .Select(m => new ATPAlertDataNew {
                        Id = m.MsgId.ToString(),
                        ShowYesNo = "Yes",
                        Msg = m.ChatMsg,
                        IsCustMsg = m.IsCustMsg.ToString(),
                        MsgDt = m.MsgDt.ToString(),
                        DealerEmpGuid = m.DealerEmpguid.ToString(),
                        PersonGuid = pGuid
                    }
                    ).ToList();

        }


        public ATPData SendMessageToDealer(ATPChatMessage chatMsg) // soon remove this method
        {
            string outMgs;
            string msg = "";
            try {
                msg = chatMsg.Message;

                if (chatMsg.Message.ToString().ToUpper() == "GETPIN") {
                    int? dealid = Convert.ToInt32(chatMsg.DealerId);
                    var personGuid = new Guid(chatMsg.PersonGuid);
                    var vehicleGuid = new Guid(chatMsg.VIN);

                    var rtnValue = new uspAssignKeylockerPin_Result();
                    using (var entity = new ATP.DataModel.Entities()) {
                        rtnValue = entity.uspAssignKeylockerPin(dealid, personGuid, vehicleGuid, false).SingleOrDefault();
                    }
                    msg = rtnValue.KeyLockerPin;
                    //     return new ATPData { Id = rtnValue.KeyLockerPin, Value = rtnValue.Comments };
                }
                TraceLog(" SendMessageToDealer", string.Format("MSG:{0}- Last:{1}- Vin:{2}- Dealer{3}-PersonGuid{4} ", msg, chatMsg.LastName, chatMsg.VIN, chatMsg.DealerId, chatMsg.PersonGuid));

                var deviceId = new ATP.Services.Data.Person().InsChatMessage(8, chatMsg.FirstName, chatMsg.LastName, chatMsg.VIN, msg, chatMsg.DealerId, chatMsg.PersonGuid, null, out outMgs);

                return new ATPData { Id = "1", Value = "Success" };
            }
            catch (Exception ex) {
                TraceLog(" SendMessageToDealer", string.Format("First:{0}- Last:{1}- Vin:{2}- Dealer{3}-PersonGuid{4} ", chatMsg.FirstName, chatMsg.LastName, chatMsg.VIN, chatMsg.DealerId, chatMsg.PersonGuid));

                return new ATPData { Id = "-1", Value = ex.ToString() };
            }

        }

        public ATPData SendMsgToDealer(ATPChatMessageNew chatMsg) {
            string outMgs;
            try {

                var msg = chatMsg.Message;

                if (chatMsg.Message.ToString().ToUpper() == "GETPIND" || chatMsg.Message.ToString().ToUpper() == "GETPINP") {
                    int? dealid = Convert.ToInt32(chatMsg.DealerId);
                    var personGuid = new Guid(chatMsg.PersonGuid);
                    var vehicleGuid = new Guid(chatMsg.PersonGuid);
                    var pickordrop = " KEY DROP :";
                    bool bGetPin = true;

                    var rtnValue = new uspAssignKeylockerPin_Result();
                    using (var entity = new ATP.DataModel.Entities()) {


                        if (chatMsg.Message.ToString().ToUpper() == "GETPINP") {
                            bGetPin = false;
                            pickordrop = "KEY PICKUP :";
                        }

                        rtnValue = entity.uspAssignKeylockerPin(dealid, personGuid, vehicleGuid, bGetPin).SingleOrDefault(); // true - drop , false - pickup
                    }

                    msg = "Your Pin for Key Locker " + pickordrop + rtnValue.KeyLockerPin;
                    //     return new ATPData { Id = rtnValue.KeyLockerPin, Value = rtnValue.Comments };

                    // TraceLog(" sylesh", string.Format("First:{0}- Last:{1}- Vin:{2}- Dealer{3}-PersonGuid{4}-DealerEmp{5} ", personGuid, vehicleGuid, chatMsg.VIN, chatMsg.DealerId, chatMsg.PersonGuid, chatMsg.DealerEmpGuid));
                    TraceLog(" SendMessageToDealer", string.Format("MSG:{0}- Last:{1}- Vin:{2}- Dealer{3}-PersonGuid{4} ", msg, chatMsg.LastName, chatMsg.VIN, chatMsg.DealerId, chatMsg.PersonGuid));
                    if (String.IsNullOrEmpty(rtnValue.KeyLockerPin)) {
                        msg = rtnValue.Comments;
                    }

                }

                var deviceId = new ATP.Services.Data.Person().InsChatMessage(8, chatMsg.FirstName, chatMsg.LastName, chatMsg.VIN, msg, chatMsg.DealerId, chatMsg.PersonGuid, chatMsg.DealerEmpGuid, out outMgs);
                return new ATPData { Id = "1", Value = "Success" };
            }
            catch (Exception ex) {
                TraceLog(" SendMsgToDealer", string.Format("First:{0}- Last:{1}- Vin:{2}- Dealer{3}-PersonGuid{4}-DealerEmp{5} ", chatMsg.FirstName, chatMsg.LastName, chatMsg.VIN, chatMsg.DealerId, chatMsg.PersonGuid, chatMsg.DealerEmpGuid));

                return new ATPData { Id = "-1", Value = ex.ToString() };
            }

        }


        public List<ATPServiceData> GetServiceTypes(string dealerId, string VIN) {
            var pkg = new ATP.Services.Data.VehicleService().GetServicePackages(dealerId, VIN)
             .Select(m => new ATPServiceData {
                 Id = m.Id.ToString(),
                 Value = m.ShortName,
                 Cost = m.PackageCost.ToString(),
                 Desc = m.Description,
                 IsPackage = "1"
             });


            var svc = new ATP.Services.Data.VehicleService().GetServiceTypes(dealerId, VIN)
                    .Where(x => x.Express == true)
                  .Select(m => new ATPServiceData {
                      Id = m.ServiceTypeId.ToString(),
                      Value = m.ShortName,
                      Cost = m.Cost.ToString(),
                      Desc = m.Description,
                      IsPackage = "0"
                  });

            //  return svc.ToList();
            return svc.Union(pkg).ToList();

        }

        public ATPServiceDataMaster VerifyService(ATPServiceDataMaster ServiceDataMasterlist) {
            string dealerId; //string VIN;
            var svcMaster = new ATPServiceDataMaster();
            try {
                TraceLog("  VerifyService", string.Format("DealerId:{0}- Last:{1}- Vin:{2}- VIN:{3}  -  Called", ServiceDataMasterlist.DealerId, ServiceDataMasterlist.FirstName, ServiceDataMasterlist.LastName, ServiceDataMasterlist.VIN));


                dealerId = ServiceDataMasterlist.DealerId;
                svcMaster = new ATPServiceDataMaster {
                    DealerId = ServiceDataMasterlist.DealerId,
                    FirstName = ServiceDataMasterlist.FirstName,
                    LastName = ServiceDataMasterlist.LastName,
                    VIN = ServiceDataMasterlist.VIN,
                    ATPServiceDataList = new List<ATPServiceData>()
                };

                if (ServiceDataMasterlist.ATPServiceDataList == null || ServiceDataMasterlist.ATPServiceDataList.Count == 0) {
                    TraceLog(" Error VerifyService", "ServiceDataMasterlist.ATPServiceDataList is empty or null");

                }
                else {
                    var selectedServices = ServiceDataMasterlist.ATPServiceDataList.Where(x => x.IsPackage == "0").ToList();
                    var selectedPackages = ServiceDataMasterlist.ATPServiceDataList.Where(x => x.IsPackage == "1");

                    string packageList = "";
                    foreach (var pkg in selectedPackages) {
                        packageList += pkg.Id + ",";
                    }

                    var serviceToEliminate = new ATP.Services.Data.VehicleService().GetSeviceTypesByPackageIds(dealerId, packageList);

                    if (serviceToEliminate != null && serviceToEliminate.Any()) {
                        var xx = selectedServices.RemoveAll(x => serviceToEliminate.Exists(m => m.ServiceTypeId.ToString() == x.Id.ToString()));
                    }


                    var newlist = selectedServices.Union(selectedPackages);

                    if (newlist.Any()) {
                        //return newlist.ToList();
                        svcMaster.ATPServiceDataList = newlist.ToList();
                    }
                    else {
                        svcMaster.ATPServiceDataList = new List<ATPServiceData> { new ATPServiceData { Id = "1", Value = "Error" } };

                    }
                }
                return svcMaster;


            }
            catch (Exception ex) {

                TraceLog(" Error VerifyService", string.Format("DealerId:{0}- fn:{1}- lm:{2}- Vin:{3}-  err {4} ", ServiceDataMasterlist.DealerId, ServiceDataMasterlist.FirstName, ServiceDataMasterlist.LastName, ServiceDataMasterlist.VIN, ex.Message));

                svcMaster.ATPServiceDataList = new List<ATPServiceData> { new ATPServiceData { Id = "1", Value = "Error" } };
                return svcMaster;


            }

        }

        public ATPData ScheduleService(ATPServiceDataMaster m) {
            var x = new ATPServiceDataMasterWithDt {
                DealerId = m.DealerId,
                ATPServiceDataList = m.ATPServiceDataList,
                FirstName = m.FirstName,
                LastName = m.LastName,
                VIN = m.VIN
            };

            return new ATP.Services.Data.VehicleService().SetServiceForPhone(x);
        }

        public ATPData DropKeys(ATPServiceDataKeyDrop m) {

            int? dealid = Convert.ToInt32(m.DealerId);
            var personGuid = new Guid(m.PersonGuid);
            var vehicleGuid = new Guid(m.VehicleGuid);
            var rtn = new ATPData();

            try {
                TraceLog("DropKeys", string.Format("DealerId:{0} , PersonGuid : {1} VehicleGuid:{2} , Dealer:{3} ", m.DealerId, m.PersonGuid, m.VehicleGuid, m.DealerId));

                //rtnValue = entity.uspAssignKeylockerPin(dealid, personGuid, vehicleGuid, bGetPin).SingleOrDefault(); // true - drop , false - pickup


               rtn = new ATP.Services.Data.VehicleService().SetServiceAndGeneratePin(m);

            }
            catch (Exception ex) {
                TraceLog("DropKeys", string.Format("DealerId:{0} , PersonGuid : {1} VehicleGuid:{2} , Dealer:{3} {4} ", m.DealerId, m.PersonGuid, m.VehicleGuid, m.DealerId,ex.StackTrace));

            }

            return rtn;

        }



        public ATPData PickUpKeys(ATPGetPickUpPin m) {


            string outMgs;
            try {


                int? dealid = Convert.ToInt32(m.DealerId);
                var personGuid = new Guid(m.PersonGuid);
                var vehicleGuid = new Guid(m.PersonGuid);
                var pickordrop = " KEY PICKUP :";
                bool bGetPin = false;

                var rtnValue = new uspAssignKeylockerPin_Result();
                using (var entity = new ATP.DataModel.Entities()) {
                    rtnValue = entity.uspAssignKeylockerPin(dealid, personGuid, vehicleGuid, bGetPin).SingleOrDefault(); // true - drop , false - pickup
                }
                

                var msg = "Your Pin for Key Locker " + pickordrop + rtnValue.KeyLockerPin;

                TraceLog(" PickUpKeys", string.Format("First:{0}- Last:{1}- Vin:{2}- Dealer{3}-PersonGuid{4}-DealerEmp{5} ", m.FirstName, m.LastName, m.VIN, m.DealerId, m.PersonGuid, null));

                if (String.IsNullOrEmpty(rtnValue.KeyLockerPin)) {
                    msg = rtnValue.Comments;
                }


                var deviceId = new ATP.Services.Data.Person().InsChatMessage(8, m.FirstName, m.LastName, m.VIN, msg, m.DealerId, m.PersonGuid, null, out outMgs);
                return new ATPData { Id = "1", Value = "Success" };
            }
            catch (Exception ex) {
                TraceLog(" PickUpKeys", string.Format("First:{0}- Last:{1}- Vin:{2}- Dealer{3}-PersonGuid{4}-DealerEmp{5} ", m.FirstName, m.LastName, m.VIN, m.DealerId, m.PersonGuid, null));

                return new ATPData { Id = "-1", Value = ex.ToString() };
            }

        }

        public ATPLoginDealerEmp LoginDealerEmployee(ATPLoginDealerEmployee m) {

            TraceLog("LoginDealerEmployee", string.Format("{0} - {1} -  login emp", m.EmpEmail, m.EmpPassword));

            return new ATP.Services.Data.VehicleService().LoginReCallDealerEmployee(m);
        }

        public ATPLoginDealerEmp LoginDealerEmployeeTest(string dealerId, string empEmail, string empPassword) {

            TraceLog("LoginDealerEmployeeTest", string.Format("{0} - {1} - {2} - login emp", dealerId, empEmail, empPassword));


            return new ATP.Services.Data.VehicleService().LoginReCallDealerEmployee(dealerId, empEmail, empPassword);
        }

        public ATPData ScheduleServiceWithDt(ATPServiceDataMasterWithDt ServiceDataMasterlist) {

            return new ATP.Services.Data.VehicleService().SetServiceForPhone(ServiceDataMasterlist);
        }

        public ATPData RegisterDeviceId(ATPRegisterDeviceId registerDevice) {
            string firstName = registerDevice.FirstName;
            string lastName = registerDevice.LastName;
            string VIN = registerDevice.VIN;
            string DeviceId = registerDevice.DeviceId;
            byte deviceTypeId = 0;
            string perGuid = registerDevice.PersonGuid;
            var res = byte.TryParse(registerDevice.DeviceTypeId, out deviceTypeId);
            int dealerId = 0;
            Guid? personGUID = null;

            try {
                var xx = int.TryParse(registerDevice.DealerId, out dealerId);


                TraceLog("RegisterDeviceId", string.Format("First:{0}- Last:{1}- Vin:{2}- Device:{3} Dealer{4}-PersonGuid{5} - Before ValidateCustomer Called", firstName, lastName, VIN, DeviceId, dealerId, perGuid));

                if (!string.IsNullOrEmpty(registerDevice.PersonGuid)) {
                    var cust = new ATP.Services.Data.Person().SelPersonByGuid(new Guid(perGuid));
                    if (cust != null && cust.Any()) {
                        personGUID = cust.ToList().FirstOrDefault().PersonGuid;
                    }

                }
                else {
                    var cust = new ATP.Services.Data.Person().ValidateCustomer(firstName, lastName, VIN, dealerId);
                    if (cust != null && cust.Any()) {
                        personGUID = cust.ToList().FirstOrDefault().PersonGUID;
                    }
                }

                // TraceLog("RegisterDeviceId", string.Format("{0} -  After ValidateCustomer Called", VIN));
                //  TraceLog("RegisterDeviceId", string.Format("First:{0}- Last:{1}- Vin:{2}- Device:{3} Dealer{4}-PersonGuid{5} - After ValidateCustomer Called", firstName, lastName, VIN, DeviceId, dealerId, perGuid));


                if (personGUID != null) {
                    var i = new ATP.Services.Data.Person().RegisterDeviceId((Guid)personGUID, DeviceId, deviceTypeId);
                    //  TraceLog("RegisterDeviceId", string.Format("Vin:{0}--PerGuid:{1} - Found Customer and Registered DeviceId", VIN, personGUID.ToString()));
                    return new ATPData { Id = "1", Value = "Success" };
                }
                else {
                    TraceLog("RegisterDeviceId", string.Format("{0} - {1} - {2} - Did not find customer DeviceId not registered", VIN, firstName, lastName));
                }

            }
            catch (Exception ex) {

                TraceLog(" Error while Registered DeviceId", string.Format("First:{0}- Last:{1}- Vin:{2}- Device:{3} Dealer{4}-PersonGuid{5} - Before ValidateCustomer Called", firstName, lastName, VIN, DeviceId, dealerId, perGuid));

                return new ATPData { Id = "-1", Value = ex.Message };
            }
            return new ATPData { Id = "-1", Value = "Failure" };

        }

        private static void TraceLog(string className, string msg) {
            var Istrace = ConfigurationManager.AppSettings["LogTrace"].ToString();

            if (Istrace.ToUpper() == "TRUE") {
                var log = new ATP.Services.Data.ErrorLogs().InsertErrors(new uspSelAllErrors_Result {
                    Created = DateTime.Now,
                    Class = className,
                    Text = msg
                });
            }
        }

        public ATPData GetDeviceId(string firstName, string lastName, string VIN) {
            var deviceId = new ATP.Services.Data.Person().GetDeviceId(firstName, lastName, VIN).ToString();

            if (deviceId.ToString().Length > 10) {

                return new ATPData { Id = "1", Value = deviceId };
            }
            return new ATPData { Id = "-1", Value = "Failure" };
        }



        public string Ping(string message) {
            throw new NotImplementedException();
        }

        public static int? ParseToNullableInt(string value) {
            return String.IsNullOrEmpty(value) ? null : (int.Parse(value) as int?);
        }

        public static short? ParseToNullableShort(string value) {
            return String.IsNullOrEmpty(value) ? null : (short.Parse(value) as short?);
        }

        public static decimal? ParseToNullableDecimal(string value) {
            return String.IsNullOrEmpty(value) ? null : (decimal.Parse(value) as decimal?);
        }





    }
}
