using ATP.DataModel.DataTables;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace ATP.DataModel
{
    public partial class CustomEntities : IDisposable
    {
        public CustomEntities() { }

        void IDisposable.Dispose()
        {

        }
        private string _connStr = ConfigurationManager.ConnectionStrings["elmah-sql"].ToString();
        public int uspSetServiceForPhone(List<VehicleServicesDataTable> vehicleServicesDataTable, List<ATPServiceData> atpServiceDataList)
        {

            int affectedRows = -1;

            var servicesdt = EntitiesHelpers.ToDataTable<ATPServiceData>(atpServiceDataList);
            var vehicleServicesDataTabledt = EntitiesHelpers.ToDataTable<VehicleServicesDataTable>(vehicleServicesDataTable);

            using (SqlConnection con = new SqlConnection(_connStr))
            {
                con.Open();
                // Configure the SqlCommand and SqlParameter.
                SqlCommand sqlCmd = new SqlCommand("dbo.uspSetServiceForPhone", con);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@SelectedServices", servicesdt).SqlDbType = SqlDbType.Structured;
                sqlCmd.Parameters.AddWithValue("@ATPVehicleService", vehicleServicesDataTabledt).SqlDbType = SqlDbType.Structured;

                affectedRows = sqlCmd.ExecuteNonQuery();
                con.Close();
                con.Dispose();
            }

            return affectedRows;

        }


        public  int uspCreateSeviceAndKeyLockerBucket_TowTruck(Nullable<int> dealerId, string firstName, string phone, string svcInfo, Nullable<byte> serviceStatusId,
            Nullable<byte> assignedKeyLockerBucketId, Nullable<byte> outDoorKeyDroppedBy, List<ATPServiceData>  atpServiceDataList )
        {

            int affectedRows = -1;

            var servicesdt = EntitiesHelpers.ToDataTable<ATPServiceData>(atpServiceDataList);

            using (SqlConnection con = new SqlConnection(_connStr))
            {
                con.Open();
                // Configure the SqlCommand and SqlParameter.
                SqlCommand sqlCmd = new SqlCommand("dbo.uspCreateSeviceAndKeyLockerBucket_TowTruck", con);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@DealerId", dealerId).SqlDbType = SqlDbType.Int;
                sqlCmd.Parameters.AddWithValue("@FirstName", firstName).SqlDbType = SqlDbType.VarChar;
                sqlCmd.Parameters.AddWithValue("@Phone", phone).SqlDbType = SqlDbType.VarChar;
                sqlCmd.Parameters.AddWithValue("@SvcInfo", svcInfo).SqlDbType = SqlDbType.VarChar;

                sqlCmd.Parameters.AddWithValue("@ServiceStatusId", serviceStatusId).SqlDbType = SqlDbType.TinyInt;
                sqlCmd.Parameters.AddWithValue("@AssignedKeyLockerBucketId", assignedKeyLockerBucketId).SqlDbType = SqlDbType.TinyInt;
                sqlCmd.Parameters.AddWithValue("@OutDoorKeyDroppedBy", outDoorKeyDroppedBy).SqlDbType = SqlDbType.TinyInt;
                sqlCmd.Parameters.AddWithValue("@SelectedServices", servicesdt).SqlDbType = SqlDbType.Structured;
                

                affectedRows = sqlCmd.ExecuteNonQuery();
                con.Close();
                con.Dispose();
            }

            return affectedRows;
        }

        public int CreateSeviceForSTO(Nullable<int> dealerId, string firstName, string phone, string svcInfo, Nullable<byte> serviceStatusId,
          Guid? PersonGuid, Guid? SvcGuid, List<ATPServiceData> atpServiceDataList, int expressNumber )
        {

            int affectedRows = -1;

            var servicesdt = EntitiesHelpers.ToDataTable<ATPServiceData>(atpServiceDataList);

            using (SqlConnection con = new SqlConnection(_connStr))
            {
                con.Open();
                // Configure the SqlCommand and SqlParameter.
                SqlCommand sqlCmd = new SqlCommand("dbo.uspCreateSeviceForSTO", con);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@DealerId", dealerId).SqlDbType = SqlDbType.Int;
                sqlCmd.Parameters.AddWithValue("@PersonGuid", PersonGuid).SqlDbType = SqlDbType.UniqueIdentifier;
                sqlCmd.Parameters.AddWithValue("@SvcGuid", SvcGuid).SqlDbType = SqlDbType.UniqueIdentifier;
                sqlCmd.Parameters.AddWithValue("@FirstName", firstName).SqlDbType = SqlDbType.VarChar;
                sqlCmd.Parameters.AddWithValue("@Phone", phone).SqlDbType = SqlDbType.VarChar;
                sqlCmd.Parameters.AddWithValue("@SvcInfo", svcInfo).SqlDbType = SqlDbType.VarChar;
                sqlCmd.Parameters.AddWithValue("@ServiceStatusId", serviceStatusId).SqlDbType = SqlDbType.TinyInt;
                sqlCmd.Parameters.AddWithValue("@SelectedServices", servicesdt).SqlDbType = SqlDbType.Structured;
                sqlCmd.Parameters.AddWithValue("@ExpressNumber", expressNumber).SqlDbType = SqlDbType.Int;
                affectedRows = sqlCmd.ExecuteNonQuery();
                con.Close();
                con.Dispose();
            }

            return affectedRows;
        }


        public int UpsertVehicleServiceMPI(
                    int DealerId,
                    Guid? @MPIMasterGuid,
                    Guid? VehicleServiceGuid,
                    Guid? PersonGuid,
                    Guid? vehicleGUID,
                    string TechComments,
                    string TechWriterComments,
                    Guid? EnteredOrUpdatedBy,
                    string MilesIn,
                    string  MilesOut,
                    string RoNum,
                    string FleetNumber,
                    List<VehicleServiceMPIDataTable> vehicleServiceMPIDataTable,
                    MPIDetailTiresDataTable mpiDetailTiresTableType,
                    MPIDetailBrakesDataTable mpiDetailBrakesDataTable,
                    MPIDetailChassisDataTable mpiDetailChassisDataTable)
        {

            int affectedRows = -1;


            var vehicleServiceMPIDatDataTabledt = EntitiesHelpers.ToDataTable<VehicleServiceMPIDataTable>(vehicleServiceMPIDataTable);
            var mpiDetailTiresTableTypedt = EntitiesHelpers.ToDataTable<MPIDetailTiresDataTable>(mpiDetailTiresTableType);
            var mpiDetailBrakesDataTabledt = EntitiesHelpers.ToDataTable<MPIDetailBrakesDataTable>(mpiDetailBrakesDataTable);
            var mpiDetailChassisDataTabledt = EntitiesHelpers.ToDataTable<MPIDetailChassisDataTable>(mpiDetailChassisDataTable);

            using (SqlConnection con = new SqlConnection(_connStr))
            {
                con.Open();
                // Configure the SqlCommand and SqlParameter.
                SqlCommand sqlCmd = new SqlCommand("dbo.uspUpsertVehicleServiceMPI", con);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@MPIMasterGuid", MPIMasterGuid).SqlDbType = SqlDbType.UniqueIdentifier;
                sqlCmd.Parameters.AddWithValue("@VehicleServiceGuid", VehicleServiceGuid).SqlDbType = SqlDbType.UniqueIdentifier;
                sqlCmd.Parameters.AddWithValue("@PersonGuid", PersonGuid).SqlDbType = SqlDbType.UniqueIdentifier;
                sqlCmd.Parameters.AddWithValue("@VehicleGUID", vehicleGUID).SqlDbType = SqlDbType.UniqueIdentifier;
                sqlCmd.Parameters.AddWithValue("@TechComments", TechComments).SqlDbType = SqlDbType.Text;
                sqlCmd.Parameters.AddWithValue("@TechWriterComments", TechWriterComments).SqlDbType = SqlDbType.Text;
                sqlCmd.Parameters.AddWithValue("@EnteredBy", EnteredOrUpdatedBy).SqlDbType = SqlDbType.UniqueIdentifier;
                sqlCmd.Parameters.AddWithValue("@DealerId", DealerId).SqlDbType = SqlDbType.Int;

                sqlCmd.Parameters.AddWithValue("@MilesIn", MilesIn).SqlDbType = SqlDbType.NVarChar;
                sqlCmd.Parameters.AddWithValue("@MilesOut", MilesOut).SqlDbType = SqlDbType.NVarChar;
                sqlCmd.Parameters.AddWithValue("@RoNum", RoNum).SqlDbType = SqlDbType.NVarChar;
                sqlCmd.Parameters.AddWithValue("@FleetNumber", FleetNumber).SqlDbType = SqlDbType.NVarChar;

                sqlCmd.Parameters.AddWithValue("@MPITableType", vehicleServiceMPIDatDataTabledt).SqlDbType = SqlDbType.Structured;
                sqlCmd.Parameters.AddWithValue("@MPIDetailTiresTableType", mpiDetailTiresTableTypedt).SqlDbType = SqlDbType.Structured;
                sqlCmd.Parameters.AddWithValue("@MPIDetailBrakesTableType", mpiDetailBrakesDataTabledt).SqlDbType = SqlDbType.Structured;
                sqlCmd.Parameters.AddWithValue("@MPIDetailChassisTableType", mpiDetailChassisDataTabledt).SqlDbType = SqlDbType.Structured;


                affectedRows = sqlCmd.ExecuteNonQuery();
                con.Close();
                con.Dispose();
            }

            return affectedRows;

        }

        public int uspInsDealerMsg(uspSelDealerMsg_Result msg, List<DealerEmpMsgDataTable> dealerEmpMsgDataTable)
        {

            int affectedRows = -1;
            try
            {
                var dealerEmpMsgDt = EntitiesHelpers.ToDataTable<DealerEmpMsgDataTable>(dealerEmpMsgDataTable);

                using (SqlConnection con = new SqlConnection(_connStr))
                {
                    con.Open();
                    // Configure the SqlCommand and SqlParameter.
                    SqlCommand sqlCmd = new SqlCommand("dbo.uspInsDealerMsg", con);
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.Parameters.AddWithValue("@VehicleServiceGuid", msg.VehicleServiceGuid).SqlDbType = SqlDbType.UniqueIdentifier;
                    sqlCmd.Parameters.AddWithValue("@VehicleGuid", msg.VehicleGuid).SqlDbType = SqlDbType.UniqueIdentifier;
                    sqlCmd.Parameters.AddWithValue("@DealerEmpGuid", msg.DealerEmpGuid).SqlDbType = SqlDbType.UniqueIdentifier;
                    sqlCmd.Parameters.AddWithValue("@PersonGuid", msg.PersonGuid).SqlDbType = SqlDbType.UniqueIdentifier;
                    sqlCmd.Parameters.AddWithValue("@DealerId", msg.DealerId).SqlDbType = SqlDbType.Int;
                    sqlCmd.Parameters.AddWithValue("@MsgFrom", msg.MsgFrom).SqlDbType = SqlDbType.NVarChar;
                    sqlCmd.Parameters.AddWithValue("@MsgTo", msg.MsgTo).SqlDbType = SqlDbType.NVarChar;
                    sqlCmd.Parameters.AddWithValue("@TxtMsg", msg.TxtMsg).SqlDbType = SqlDbType.NVarChar;
                    sqlCmd.Parameters.AddWithValue("@IsCustMsg", msg.IsCustMsg).SqlDbType = SqlDbType.Bit;
                    sqlCmd.Parameters.AddWithValue("@IsMsgToCust", msg.IsMsgToCust).SqlDbType = SqlDbType.Bit;

                    sqlCmd.Parameters.AddWithValue("@ATPDealerEmpMsgDataType", dealerEmpMsgDt).SqlDbType = SqlDbType.Structured;

                    affectedRows = sqlCmd.ExecuteNonQuery();
                    con.Close();
                    con.Dispose();
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }

            return affectedRows;

        }
    }


    public static class EntitiesHelpers
    {
        public static DataTable ToDataTable<T>(this List<T> iList)
        {
            DataTable dataTable = new DataTable();
            PropertyDescriptorCollection propertyDescriptorCollection = TypeDescriptor.GetProperties(typeof(T));
            for (int i = 0; i < propertyDescriptorCollection.Count; i++)
            {
                PropertyDescriptor propertyDescriptor = propertyDescriptorCollection[i];
                Type type = propertyDescriptor.PropertyType;

                if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>))
                    type = Nullable.GetUnderlyingType(type);


                dataTable.Columns.Add(propertyDescriptor.Name, type);
            }
            object[] values = new object[propertyDescriptorCollection.Count];
            foreach (T iListItem in iList)
            {
                for (int i = 0; i < values.Length; i++)
                {
                    values[i] = propertyDescriptorCollection[i].GetValue(iListItem);
                }
                dataTable.Rows.Add(values);
            }
            return dataTable;
        }



        public static DataTable ToDataTable<T>(T entity) where T : class
        {
            var properties = typeof(T).GetProperties();
            var dataTable = new DataTable();

            foreach (var property in properties)
            {
                dataTable.Columns.Add(property.Name, property.PropertyType);
            }

            dataTable.Rows.Add(properties.Select(p => p.GetValue(entity, null)).ToArray());
            return dataTable;
        }

    }
}

