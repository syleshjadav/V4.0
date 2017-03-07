using ATP.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ATP.WCF.Svcs
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IICompInspection" in both code and config file together.
    [ServiceContract]
    public interface ICompInspection
    {
        [OperationContract]
        List<uspSelAllCompInspectionExportData_Result> SelAllCompInspectionExportData(Nullable<int> dealerId);
    }
}
