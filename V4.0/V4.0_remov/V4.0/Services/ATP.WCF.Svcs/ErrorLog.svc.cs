using Elmah;
using System;

namespace ATP.WCF.Svcs
{
    [ServiceErrorBehaviour(typeof(HttpErrorHandler))]
    public class ErrorLog : IErrorLog
    {

        public bool LogError(string msg)
        {
            Elmah.ErrorLog.GetDefault(null).Log(new Error { Message=msg, Source="Unknown", Type="Exception",Time= DateTime.UtcNow});

           // throw new Exception(msg);
            return true;
        }

        public bool LogInformation(string msg)
        {
            Elmah.ErrorLog.GetDefault(null).Log(new Error { Message = msg, Source = "Unknown", Type ="Information", Time = DateTime.UtcNow });

           // throw new Exception(msg);
            return true;
        }
    }
}
