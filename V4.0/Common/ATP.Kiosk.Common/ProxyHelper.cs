using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;

namespace ATP.Kiosk.Common
{
   public class ProxyHelper
    {
        public static class Service<TChannel>
        {
            public static IChannelFactory<TChannel> ChannelFactory = new ChannelFactory<TChannel>("*");

            public static TReturn Use<TReturn>(Func<TChannel, TReturn> codeBlock)
            {
                var proxy = (IClientChannel)ChannelFactory.CreateChannel();
                var success = false;
                try
                {
                    var result = codeBlock((TChannel)proxy);
                    proxy.Close();
                    success = true;
                    return result;
                }
                finally
                {
                    if (!success)
                    {
                        proxy.Abort();
                    }
                }
            }

         

        }
    }
}
/*
how to use
 * 
 * return Service<IOrderService>.Use(orderService => 
{ 
    return orderService.PlaceOrder(request); 
});
 * 
*/