using System.Collections.Generic;
using System.Linq;
using ATP.DataModel;

namespace ATP.Services.Data
{
    public class ErrorLogs
    {

        public List<uspSelAllErrors_Result> SelAllErrors()
        {
            using (var entity = new ATP.DataModel.Entities())
            {
                return entity.uspSelAllErrors().ToList();
            }

        }

        public List<uspInsErrorLog_Result> InsertErrors(uspSelAllErrors_Result error)
        {
            using (var entity = new ATP.DataModel.Entities())
            {
                return entity.uspInsErrorLog(error.Created,error.SeverityId,error.ExceptionId,
                    error.DBName,error.Number,error.SourceLine,error.SourceFile,
                    error.Class,error.Method,error.Event,error.State,error.ProcessId,error.MachineName,error.UserName,
                    error.TargetSite,error.StackTrace,error.Text).ToList();
            }

        }

    }
}
