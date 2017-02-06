using ATP.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ATP.Services.Data {
    public class VehicleService {

        public List<uspSelMPISubmitHistory_Result> SelMPISubmitHistory(Guid? vehicleServiceGuid) {
            using (var entity = new ATP.DataModel.Entities()) {
                return entity.uspSelMPISubmitHistory(vehicleServiceGuid).ToList();
            }
        }
        public int? CloseVehicleSericeRO(Guid? vehicleServiceGuid, int? serviceTypeId, Guid? ROClosedBy) {
            using (var entity = new ATP.DataModel.Entities()) {
                return entity.uspCloseVehicleSericeRO(vehicleServiceGuid, serviceTypeId, ROClosedBy);
            }
        }

        public List<uspSelVehicleServiceMPIStatus_Result> SelVehicleServiceMPIStatus(int? DealerId, Guid? vehicleGuid, Guid? vehicleServiceGuid, Guid? swGuid, Guid? techGuid, Guid? partGuid, int? serviceTypeId) {
            using (var entity = new ATP.DataModel.Entities()) {
                return entity.uspSelVehicleServiceMPIStatus(DealerId, vehicleServiceGuid, vehicleGuid, swGuid, techGuid, partGuid, serviceTypeId).ToList();
            }
        }

        public List<ATP.DataModel.uspSelMPIVehicleServiceByDealerId_Result> SelMPIVehicleServiceByDealerId(int? DealerId, Guid? personGuid, Guid? vehicleGuid, Guid? vehicleServiceGuid, Guid? vehicleServiceMPIMasterGuid) {
            using (var entity = new ATP.DataModel.Entities()) {
                return entity.uspSelMPIVehicleServiceByDealerId(DealerId, personGuid, vehicleGuid, vehicleServiceGuid, vehicleServiceMPIMasterGuid).ToList();
            }
        }

        public int UpsertMPIByPersonGuid(uspSelMPIVehicleServiceByDealerId_Result m) {
            using (var entity = new ATP.DataModel.Entities()) {
                return entity.uspUpsertMPIByPersonGuid(m.DealerId, m.PersonGuid, m.VehicleGUID, m.VehicleServiceGuid, m.VehicleServiceMPIMasterGuid, m.TechCommentsMain, m.ServiceWriterComments, m.EnteredBy, m.MilesIn, m.MilesOut, m.RoNumber, m.FleetNumber, m.TirePressure, m.XMLStr);
            }
        }

        public List<uspSelCustomerByGuid_Result> SelCustomerByGuid(Guid? personGuid) {
            using (var entity = new ATP.DataModel.Entities()) {
                return entity.uspSelCustomerByGuid(personGuid).ToList();
            }
        }


        public int? CloseVehicleSericeTask(Guid? vehicleServiceMPIMasterGuid, int? serviceTypeId, Guid? taskClosedBy) {
            using (var entity = new ATP.DataModel.Entities()) {
                return entity.uspCloseVehicleSericeTask(vehicleServiceMPIMasterGuid, serviceTypeId, taskClosedBy);
            }
        }

        public int? UpdateMPICost(Guid? vehicleServiceMPIMasterGuid, int? mPIItemId, decimal? cost, decimal? laborCost, decimal? totalCost, bool? IsSendToCust) {
            using (var entity = new ATP.DataModel.Entities()) {
                return entity.uspUpdateMPICost(vehicleServiceMPIMasterGuid, mPIItemId, cost, laborCost, totalCost, IsSendToCust,null);
            }
        }


        public List<uspSelVehicleServicePricing_Result> SelVehicleServicePricing(int? DealerId, Guid? vehicleGuid, Guid? SW, Guid? techGuid, Guid? partsGuid, int? ServiceTypeId) {
            using (var entity = new ATP.DataModel.Entities()) {
                return entity.uspSelVehicleServicePricing(DealerId, vehicleGuid, SW, techGuid, partsGuid, ServiceTypeId).ToList();
            }
        }


        public List<uspSelVehicleServicePricingSW_Result> SelVehicleServicePricingSW(int? DealerId, Guid? vehicleGuid, Guid? SW, Guid? techGuid, Guid? partsGuid, int? ServiceTypeId) {
            using (var entity = new ATP.DataModel.Entities()) {
                return entity.uspSelVehicleServicePricingSW(DealerId, vehicleGuid, SW, techGuid, partsGuid, ServiceTypeId).ToList();
            }
        }

        public List<uspSelVehicleServicePricingParts_Result> SelVehicleServicePricingParts(int? DealerId, Guid? vehicleGuid, Guid? SW, Guid? techGuid, Guid? partsGuid, int? ServiceTypeId) {
            using (var entity = new ATP.DataModel.Entities()) {
                return entity.uspSelVehicleServicePricingParts(DealerId, vehicleGuid, SW, techGuid, partsGuid, ServiceTypeId).ToList();
            }
        }

        public List<uspSelVehicleServicePricingTech_Result> SelVehicleServicePricingTech(int? DealerId, Guid? vehicleGuid, Guid? SW, Guid? techGuid, Guid? partsGuid, int? ServiceTypeId) {
            using (var entity = new ATP.DataModel.Entities()) {
                return entity.uspSelVehicleServicePricingTech(DealerId, vehicleGuid, SW, techGuid, partsGuid, ServiceTypeId).ToList();
            }
        }

        public int? UPSertVehicleServicePricing(uspSelVehicleServicePricing_Result m) {
            using (var entity = new ATP.DataModel.Entities()) {
                //  return entity.uspUPSertVehicleServicePricing(m.ServicePricingId, m.VehicleServiceGuid, m.ServiceTypeId, m.MPIItem, m.VehicleServiceMPIMasterGuid, m.PartNumber, m.PartDesc, m.TimeTaken,
                ///   m.TechComments, m.PartCost, m.PartComments, m.PriceRequestedDt, m.PriceQuotedDt, m.IsSendToPricing, m.TechGuid, m.PartGuid, m.SvcsWriterGuid, m.TotalCost, m.IsSendToCust,);
                return null;
            }
        }

        public List<uspSelVehicleServicesByDealerEmp_Result> SelVehicleServicesByDealerEmp(Guid? serviceWriterGuid, Guid? techGuid) {
            using (var entity = new ATP.DataModel.Entities()) {
                return entity.uspSelVehicleServicesByDealerEmp(serviceWriterGuid, techGuid).ToList();

            }
        }

        public List<uspSelMPIImages_Result> SelMPIImages(int dealerId, Guid? personGuid) {
            using (var entity = new ATP.DataModel.Entities()) {
                return entity.uspSelMPIImages(dealerId, personGuid).ToList();

            }
        }

        public long? UpSertMPIImages(uspSelMPIImages_Result m) {
            using (var entity = new ATP.DataModel.Entities()) {
                return entity.uspUpSertMPIImages(m.Id, m.dealerId, m.DealerEmpGuid, m.PersonGuid, m.ImgLnk1, m.ImgLnk2, m.ImgLnk3, m.ImgLnk4).FirstOrDefault();
            }
        }


        public List<uspSelVehSvcsForARCH_Result> SelVehSvcsForARCH(string Token, int dealerId, DateTime? serviceDateFrom, DateTime? serviceDateTo, string lastName, int? serviceStatusId, bool showInServiceCustomer) {

            using (var entity = new ATP.DataModel.Entities()) {
                var xx = entity.uspSelVehSvcsForARCH(dealerId, serviceDateFrom, serviceDateTo, lastName, serviceStatusId, showInServiceCustomer);

                return xx.ToList();
            }
        }

        public List<uspSelVehSvcsWebARCH_Result> SelVehSvcsWebARCH(uspSelVehSvcsWebARCH_Result x) {

            using (var entity = new ATP.DataModel.Entities()) {
                var xx = entity.uspSelVehSvcsWebARCH(x.DealerId, x.ServiceDateFrom, x.ServiceDateTo, x.LastName, x.ServiceStatusId, x.ShowInServiceCustomer, x.PageStartIndex, x.PageSize);

                return xx.ToList();
            }
        }
        public List<string> UpdateVehiceServiceStatus(int? dealerId, Guid? vehicleServiceGUID, Guid? vehicleGUID,  Guid? personGUID, Nullable<byte> statusId, Nullable<System.Guid> updatedBy) {

            using (var entity = new ATP.DataModel.Entities()) {
                var xx = entity.uspUpdVehSvcStatusByVehSvcId(dealerId,vehicleServiceGUID, vehicleGUID,personGUID, statusId, updatedBy).ToList();

                return xx;
            }

        }

        public List<short?> GetVehicleYears() {
            using (var entity = new ATP.DataModel.Entities()) {
                return entity.uspSelVehicleYear().ToList();
            }
        }

        public List<uspSelVehicleMakes_Result> GetMakes(string year, string dealerId) {
            int? dealid = Convert.ToInt32(dealerId);
            short? yr = Convert.ToInt16(year);

            using (var entity = new ATP.DataModel.Entities()) {
                return entity.uspSelVehicleMakes(dealid, null, null, null, null, yr, 1, 50).ToList();
            }
        }

        public List<uspSelVehicleModels_Result> GetModels(string year, string makeId) {
            int? mkeid = Convert.ToInt32(makeId);
            short? yr = Convert.ToInt16(year);
            using (var entity = new ATP.DataModel.Entities()) {
                return entity.uspSelVehicleModels(mkeid, null, null, null, yr, 1, 100).ToList();
            }
        }

        public List<uspSelVehicleTrims_Result> GetTrims(string year, string makeId, string modelId) {
            int? mkeid = Convert.ToInt32(makeId);
            int? mdl = Convert.ToInt32(modelId);
            short? yr = Convert.ToInt16(year);

            using (var entity = new ATP.DataModel.Entities()) {
                return entity.uspSelVehicleTrims(mkeid, null, mdl, null, null, null, null, null, null, yr, 1, 100).ToList();
            }
        }

        public List<uspSelSvcTypeByDealerId_Result> GetServiceTypes(string dealerId, string VIN) {
            int? dealid = Convert.ToInt32(dealerId);
            using (var entity = new ATP.DataModel.Entities()) {
                return entity.uspSelSvcTypeByDealerId(dealid).ToList();
            }
        }

        public List<uspSelSvcTypeByPkgId_Result> SelSvcTypeByPkgId(int dealerId, int packageId) {
            // int? dealid = Convert.ToInt32(dealerId);
            using (var entity = new ATP.DataModel.Entities()) {
                return entity.uspSelSvcTypeByPkgId(dealerId, packageId).ToList();
            }
        }

        public List<uspSelPkgByDealerId_Result> GetServicePackages(string dealerId, string VIN) {
            int? dealid = Convert.ToInt32(dealerId);
            using (var entity = new ATP.DataModel.Entities()) {
                return entity.uspSelPkgByDealerId(dealid).ToList();
            }
        }

        public List<uspSelSvcTypesByPkgIds_Result> GetSeviceTypesByPackageIds(string dealerId, string packageList) {
            int? dealid = Convert.ToInt32(dealerId);
            using (var entity = new ATP.DataModel.Entities()) {
                return entity.uspSelSvcTypesByPkgIds(dealid, packageList).ToList();
            }
        }

        public ATPData ScheduleService(string dealerId, string VIN, List<ATPServiceData> servicelist) {

            return new ATPData();
        }

        public int SaveVehicleServices(List<VehicleServicesDataTable> vehicleServicesDataTable, List<ATPServiceData> atpServiceDataList) {
            using (var entity = new ATP.DataModel.CustomEntities()) {
                return entity.uspSetServiceForPhone(vehicleServicesDataTable, atpServiceDataList);
            }
        }

        public int UpsertVehicleServiceMPI(int DealerId, Guid? MPIMasterGuid, Guid? VehicleServiceGuid, Guid? Person, Guid? vehicleGUID, string techComments, string techWriterComments, Guid? EnteredBy,
                     string MilesIn,
                    string MilesOut,
                    string RoNum,
                    string FleetNumber, List<VehicleServiceMPIDataTable> vehicleServiceMPIDataTable, MPIDetailTiresDataTable mpiDetailTiresTableType, MPIDetailBrakesDataTable mpiDetailBrakesDataTable, MPIDetailChassisDataTable mpiDetailChassisDataTable) {
            using (var entity = new ATP.DataModel.CustomEntities()) {
                return entity.UpsertVehicleServiceMPI(DealerId, MPIMasterGuid, VehicleServiceGuid, Person, vehicleGUID, techComments, techWriterComments, EnteredBy,
                    MilesIn, MilesOut, RoNum, FleetNumber, vehicleServiceMPIDataTable, mpiDetailTiresTableType, mpiDetailBrakesDataTable, mpiDetailChassisDataTable);
            }
        }

        public int? SelMPICountByServiceGuid(Guid VehicleServiceGuid) {
            using (var entity = new ATP.DataModel.Entities()) {
                return entity.uspSelMPICountByServiceGuid(VehicleServiceGuid).SingleOrDefault();
            }
        }


        //public List<uspSelVehicleServiceMPIDetailChassis_Result> SelVehicleServiceMPIDetailChassis(Guid VehicleServiceGuid, Guid MPIMasterGuid)
        //{
        //    using (var entity = new ATP.DataModel.Entities())
        //    {
        //        return entity.uspSelVehicleServiceMPIDetailChassis(VehicleServiceGuid, MPIMasterGuid).ToList();
        //    }
        //}
        //public List<uspSelVehicleServiceMPIDetailBrakes_Result> SelVehicleServiceMPIDetailBrakes(Guid VehicleServiceGuid, Guid MPIMasterGuid)
        //{
        //    using (var entity = new ATP.DataModel.Entities())
        //    {
        //        return entity.uspSelVehicleServiceMPIDetailBrakes(VehicleServiceGuid, MPIMasterGuid).ToList();
        //    }
        //}
        //public List<uspSelVehicleServiceMPIDetailTires_Result> SelVehicleServiceMPIDetailTires(Guid VehicleServiceGuid, Guid MPIMasterGuid)
        //{
        //    using (var entity = new ATP.DataModel.Entities())
        //    {
        //        return entity.uspSelVehicleServiceMPIDetailTires(VehicleServiceGuid, MPIMasterGuid).ToList();
        //    }
        //}



        public List<uspSelPackageByDealerId_Result> SelPackageByDealerId(string dealerId) {
            int? dealid = Convert.ToInt32(dealerId);
            using (var entity = new ATP.DataModel.Entities()) {
                return entity.uspSelPackageByDealerId(dealid).ToList();
            }
        }

        public ATPData SetServiceAndGeneratePin(ATPServiceDataKeyDrop m) {


            int? dealid = Convert.ToInt32(m.DealerId);
            var personGuid = new Guid(m.PersonGuid);
            var vehicleGuid = new Guid(m.VehicleGuid);


            var rtnValue = new uspAssignKeylockerPin_Result();
            try {
                using (var entity = new ATP.DataModel.Entities()) {
                    rtnValue = entity.uspAssignKeylockerPin(dealid, personGuid, vehicleGuid, true).SingleOrDefault();
                }

                if (rtnValue != null && !String.IsNullOrEmpty(rtnValue.KeyLockerPin)) {
                    // save the service types to db
                    var serviceList = m.ATPServiceDataList.ToList();
                    var vehicleServicesDataTable = new VehicleServicesDataTable {
                        ADAM = false,
                        Amount = 12,
                        Date = DateTime.Now,
                        DealerId = dealid,
                        EnteredBy = personGuid,
                        ExpressNumber = 0,
                        KioskId = 1,
                        Mileage = 1,
                        PackageCost = 1,
                        Paid = false,
                        ServiceCost = 1,
                        StatusId = 100,
                        VehicleGUID = vehicleGuid,
                        Reason = m.Comments

                    };
                    List<VehicleServicesDataTable> vehsvcs = new List<VehicleServicesDataTable>();
                    vehsvcs.Add(vehicleServicesDataTable);

                    var ss = new ATP.Services.Data.VehicleService().SaveVehicleServices(vehsvcs, serviceList);

                }

                return new ATPData { Id = rtnValue.KeyLockerPin, Value = rtnValue.Comments };
            }
            catch (Exception ex) {
                return new ATPData { Id = "-1", Value = ex.Message };
            };

        }

        public ATPLoginDealerEmp LoginReCallDealerEmployee(ATPLoginDealerEmployee m) {

            var rtnValue = new ATPLoginDealerEmp();


            try {
                       
                var x = new uspLoginDealerEmployeeByEmail_Result();
                using (var entity = new ATP.DataModel.Entities()) {
                    x = entity.uspLoginDealerEmployeeByEmail( m.EmpEmail, m.EmpPassword).SingleOrDefault();
                }

                if (x != null) {
                    return new ATPLoginDealerEmp {
                        DealerEmpGuid = x.DealerEmpGuid != null ? x.DealerEmpGuid.ToString() : null,
                        DealerId = x.DealerId.ToString(),
                        DeptId = x.DeptId != null ? x.DeptId.ToString() : null,
                        DeptName = x.DeptName,
                        EmailAddress = x.EmailAddress,
                        EmpName = x.EmpName,
                        PhoneNumber = x.PhoneNumber,
                        ERRMSG="SUCCESS"
                    };
                }

                return rtnValue;
            }
            catch (Exception ex) {
                rtnValue.ERRMSG = ex.Message;
                return rtnValue;
            };

        }



        public ATPLoginDealerEmp LoginReCallDealerEmployee(string dealerId, string empEmail, string empPassword) {
            var rtnValue = new ATPLoginDealerEmp();

            try {

                int? dealid = Convert.ToInt32(dealerId);
                rtnValue.DealerId = dealerId;

                var x = new uspLoginDealerEmp_Result();
                using (var entity = new ATP.DataModel.Entities()) {
                    x = entity.uspLoginDealerEmp(dealid, empEmail, empPassword).ToList().FirstOrDefault();
                }

                if (x != null) {
                    return new ATPLoginDealerEmp {
                        DealerEmpGuid = x.DealerEmpGuid != null ? x.DealerEmpGuid.ToString() : null,
                        DealerId = dealerId,
                       DeptId = x.DeptId != null ? x.DeptId.ToString() : null,
                        DeptName = x.DeptName,
                        EmailAddress = x.EmailAddress,
                        EmpName = x.EmpName,
                        PhoneNumber = x.PhoneNumber,
                    };
                }

                return rtnValue;
            }
            catch (Exception ex) {
                rtnValue.ERRMSG = ex.Message;
                return rtnValue;
            };

        }

        public ATPData SetServiceForPhone(ATPServiceDataMasterWithDt ServiceDataMasterlist) {
            var msg = new ATPData { Id = "-1", Value = "Failure" };
            try {
                var dealerId = ServiceDataMasterlist.DealerId;
                var dealId = Convert.ToInt32(dealerId);

                string firstName = ServiceDataMasterlist.FirstName;
                string lastName = ServiceDataMasterlist.LastName;
                string VIN = ServiceDataMasterlist.VIN;
                var cust = new ATP.Services.Data.Person().ValidateCustomer(firstName, lastName, VIN, dealId).FirstOrDefault();
                var serviceList = ServiceDataMasterlist.ATPServiceDataList.ToList();

                DateTime dateTime = DateTime.Now;
                if (!String.IsNullOrEmpty(ServiceDataMasterlist.ScheduleDate)) {
                    DateTime.TryParse(ServiceDataMasterlist.ScheduleDate, out dateTime);
                }



                //  DateTime.TryParse(ServiceDataMasterlist.ScheduleDate, out dateTime);

                if (cust.PersonGUID.ToString().Length > 10) {
                    var vehicleServicesDataTable = new VehicleServicesDataTable {
                        ADAM = false,
                        Amount = 12,
                        Date = dateTime,
                        DealerId = dealId,
                        EnteredBy = cust.PersonGUID,
                        // Entered= DateTime.Now,
                        ExpressNumber = 0,
                        // GUID= cust.PersonGUID,
                        KioskId = 9,
                        Mileage = 12,
                        PackageCost = 123.45,
                        Paid = false,
                        ServiceCost = 200.00,
                        StatusId = 100,
                        //Valid=true,
                        VehicleGUID = cust.VehicleGuid

                    };

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
            }
            catch (Exception ex) {
                msg.Id = "-1";
                msg.Value = ex.Message;
            }

            return msg;

        }

        public List<uspSelVehicleSvcsByDealerId_Result> SelVehicleSvcsByDealerId(int? dealerId, int? serviceStatusId, DateTime? startDate, DateTime? endDate, short? pageNumber, short? pageSize) {

            using (var entity = new ATP.DataModel.Entities()) {
                return entity.uspSelVehicleSvcsByDealerId(dealerId, serviceStatusId, startDate, endDate, pageNumber, pageSize).ToList();
            }
        }
        public List<uspSelVehicleSvcsByPersonId_Result> SelVehicleSvcsByPersonId(uspSelVehicleSvcsByPersonId_Result svcs) {
            using (var entity = new ATP.DataModel.Entities()) {
                return entity.uspSelVehicleSvcsByPersonId(svcs.DealerId, svcs.PersonGuid, svcs.ServiceDate, svcs.LastName, svcs.ServiceStatusId).ToList();
            }
        }

        public List<uspSelExpSvcsStatByDealerId_Result> SelExpSvcsStatByDealerId(int? dealerId, int? serviceStatusId, DateTime? startDate, DateTime? endDate, string lastName, short? pageNumber, short? pageSize) {

            using (var entity = new ATP.DataModel.Entities()) {
                return entity.uspSelExpSvcsStatByDealerId(dealerId, serviceStatusId, startDate, endDate, lastName, pageNumber, pageSize).ToList();
            }
        }

        public List<uspSelVehicleServiceImage_Result> SelVehicleServiceImage(uspSelVehicleServiceImage_Result svcs) {
            using (var entity = new ATP.DataModel.Entities()) {
                return entity.uspSelVehicleServiceImage(svcs.DealerId, svcs.VehicleGuid, svcs.VehicleServiceGuid, svcs.ImageUploadedBy, svcs.ImageId, svcs.IsExcludeImages).ToList();
            }
        }

        public int DelVehicleServiceImage(uspSelVehicleServiceImage_Result svcs) {
            using (var entity = new ATP.DataModel.Entities()) {
                return entity.uspDelVehicleServiceImage(svcs.DealerId, svcs.ImageUploadedBy, svcs.ImageId);
            }
        }

        public int InsVehicleServiceImage(uspSelVehicleServiceImage_Result svcs) {
            using (var entity = new ATP.DataModel.Entities()) {
                return entity.uspInsVehicleServiceImage(svcs.ImageId, svcs.DealerId, svcs.VehicleGuid, svcs.VehicleServiceGuid, svcs.ImageUploadedBy, svcs.VehImage, svcs.Comments);
            }
        }

    }
}
