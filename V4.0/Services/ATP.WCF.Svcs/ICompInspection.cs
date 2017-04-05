using ATP.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ATP.WCF.Svcs
{
    [ServiceContract(Name = "ICompInspection", Namespace = "http://www.ADAMCentralUSA.com/ADAM/Service/CompInspection")]

    public interface ICompInspection
    {
        [OperationContract]
        List<uspSelAllCompInspectionExportData_Result> SelAllCompInspectionExportData(Nullable<int> dealerId);


        [OperationContract]
        int UpdtExportToCompInspectionStatus(Nullable<long> iD, Nullable<int> dealerId, Nullable<bool> isFailed, string failedReaon);

        [OperationContract]
        bool LogError(string msg);
        [OperationContract]
        bool LogInformation(string msg);
    }
}
