using System.ServiceModel;

namespace ATP.WCF.Svcs
{
    [ServiceContract(Name = "IErrorLog", Namespace = "http://www.AdamKiosks.com/Service/ErrorLog")]
    public interface IErrorLog
    {
        [OperationContract]
        bool LogError(string msg);
        [OperationContract]
        bool LogInformation(string msg);
    }
}
