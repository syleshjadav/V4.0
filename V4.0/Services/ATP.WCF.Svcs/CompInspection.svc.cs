using ATP.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ATP.WCF.Svcs
{
  [ServiceErrorBehaviour(typeof(HttpErrorHandler))]
  public class CompInspection : ICompInspection
    {
       

        public List<uspSelAllCompInspectionExportData_Result> SelAllCompInspectionExportData(Nullable<int> dealerId)
        {

            using (var entity = new ATP.DataModel.Entities())
            {

                var xx = entity.uspSelAllCompInspectionExportData(dealerId).ToList();

                return xx;
            }
        }

        public int UpdtExportToCompInspectionStatus(Nullable<long> iD, Nullable<int> dealerId, Nullable<bool> isFailed, string failedReaon)
        {

            using (var entity = new ATP.DataModel.Entities())
            {

                var xx = entity.uspUpdtExportToCompInspectionStatus(iD,dealerId,isFailed,failedReaon);

                return xx;
            }
        }

    }
}
