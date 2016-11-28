using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using Elmah;

/// <summary>
/// So we can decorate Services with the [ServiceErrorBehaviour(typeof(HttpErrorHandler))]
/// ...and errors reported to ELMAH
/// </summary>
public class ServiceErrorBehaviourAttribute : Attribute, IServiceBehavior
{
    readonly Type _errorHandlerType;

    public ServiceErrorBehaviourAttribute(Type errorHandlerType)
    {
        this._errorHandlerType = errorHandlerType;
    }

    public void Validate(ServiceDescription description, ServiceHostBase serviceHostBase)
    {
    }

    public void AddBindingParameters(ServiceDescription description, ServiceHostBase serviceHostBase, Collection<ServiceEndpoint> endpoints, BindingParameterCollection parameters)
    {
    }

    public void ApplyDispatchBehavior(ServiceDescription description, ServiceHostBase serviceHostBase)
    {
        var errorHandler = (IErrorHandler)Activator.CreateInstance(_errorHandlerType);
        foreach (var channelDispatcher in serviceHostBase.ChannelDispatchers.OfType<ChannelDispatcher>())
        {
            channelDispatcher.ErrorHandlers.Add(errorHandler);
        }
    }
}
//public class RequireHttpsAttribute : AuthorizationFilterAttribute
//{
//    public override void OnAuthorization(HttpActionContext actionContext)
//    {
//        var request = actionContext.Request;

//        if (request.RequestUri.Scheme != Uri.UriSchemeHttps)
//        {
//            var html = "<p>Https is required</p>";

//            if (request.Method.Method == "GET")
//            {
//                actionContext.Response = request.CreateResponse(HttpStatusCode.Found);
//                actionContext.Response.Content = new StringContent(html, Encoding.UTF8, "text/html");

//                UriBuilder httpsNewUri = new UriBuilder(request.RequestUri);
//                httpsNewUri.Scheme = Uri.UriSchemeHttps;
//                httpsNewUri.Port = 443;

//                actionContext.Response.Headers.Location = httpsNewUri.Uri;
//            }
//            else
//            {
//                actionContext.Response = request.CreateResponse(HttpStatusCode.NotFound);
//                actionContext.Response.Content = new StringContent(html, Encoding.UTF8, "text/html");
//            }

//        }
//    }
//}

public class HttpErrorHandler : IErrorHandler
{
    public bool HandleError(Exception error)
    {
        return false;
    }

    public void ProvideFault(Exception error, MessageVersion version, ref Message fault)
    {
        if (error == null) return;

        try
        {
            ErrorLog.GetDefault(null).Log(new Error(error));
        }
        catch (Exception ex)
        {
            Console.Write(ex.Message);
        }
    }

}
