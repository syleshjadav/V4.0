using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATP.SvcsLibrary
{
    public class ErrorLog
    {
        //public void LogError(string msg)
        //{
        //    var x =ATP.Common.ProxyHelper.Service<ErrorLogSvcRef.IErrorLog>.Use(svcs =>
        //    {
        //       return svcs.LogError(msg);
        //    });
        //}
        public void Error(string msg)
        {
            var x = ATP.Common.ProxyHelper.Service<ErrorLogSvcRef.IErrorLog>.Use(svcs =>
            {
                return svcs.LogError(msg);
            });
        }
        public void Error(string msg, string msg1, string msg2)
        {
            var x = ATP.Common.ProxyHelper.Service<ErrorLogSvcRef.IErrorLog>.Use(svcs =>
            {
                return svcs.LogError(msg + msg1 + msg2);
            });
        }

        public void LogInformation(string msg)
        {
            var x = ATP.Common.ProxyHelper.Service<ErrorLogSvcRef.IErrorLog>.Use(svcs =>
            {
                return svcs.LogInformation(msg);
            });
        }
        public void Info(string msg)
        {
            var x = ATP.Common.ProxyHelper.Service<ErrorLogSvcRef.IErrorLog>.Use(svcs =>
            {
                return svcs.LogInformation(msg);
            });
        }

        public void Info(string msg, int msg1)
        {
            var x = ATP.Common.ProxyHelper.Service<ErrorLogSvcRef.IErrorLog>.Use(svcs =>
            {
                return svcs.LogInformation(msg + msg1.ToString());
            });
        }
    }
}
