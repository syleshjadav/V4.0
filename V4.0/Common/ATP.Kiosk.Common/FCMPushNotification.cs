using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web.Script.Serialization;

namespace ATP.Kiosk.Common {
    public class FCMPushNotification {
        public FCMPushNotification() {
            // TODO: Add constructor logic here
        }

        public bool Successful {
            get;
            set;
        }

        public string Response {
            get;
            set;
        }
        public Exception Error {
            get;
            set;
        }

        public string SendMessageToAndroid(string deviceId, string message, string tickerText, string contentTitle) {
            //string deviceId = "APA91bGa8MkLmgaRaUGxwCOj-rWraFxT2BOtmluYibeb28x_SE8UAH20Rod2OyUCE3BZjY7UX-MdDF2UPOAhcVc82oRDp3d-cmqahOlJW_JERLEa2QzAQAdkhUowErimipBOzBKaV6mDWnzwBCS6UqLnezyOh2zLKQ";
            // string deviceId = "APA91bGDIal5L6EgEs2kcO-a_XZLS_5DSRIrGeQO27JA8-HnsfYaK-xbAqzjeaV0WU6AIbs29BuD-FLM6FXMbJfpLGd5ruSqXu7Ch3vdPV837kZDqI4f2A3wkQ1XuKfEbN-XCdAKvTypsqoOmoMbHHQDSb5PQRwvmg";

            // string message = "some test message" + System.DateTime.Now.ToString();
            // string tickerText = "example test GCM";
            // string contentTitle = "content title GCM";
            // var delaywhileidle = "false";
            //string postData =
            //"{ \"registration_ids\": [ \"" + deviceId + "\" ], " +
            //    //"\"delay_while_idle\":\"" + delaywhileidle + "\", " +
            //  "\"data\": {\"tickerText\":\"" + tickerText + "\", " +
            //             "\"contentTitle\":\"" + contentTitle + "\", " +
            //             "\"vibrate\":\"" + "true" + "\", " +
            //             "\"sound\":\"" + "default" + "\", " +
            //             "\"time\":\"" + System.DateTime.Now.ToString() + "\", " +
            //             "\"message\": \"" + message + "\"}}";

            var cust = new GCM {
                registration_ids = new List<string> { deviceId },
                data = new Data { tickerText = tickerText, contentTitle = contentTitle, vibrate = "true", sound = "default", time = DateTime.Now.ToString(), message = message }
            };

            var jsonStr = JSonHelpers.ToJson<GCM>(cust);

            return SendNotification(jsonStr);
        }

        private string SendNotification(string postData) {
            String sResponseFromServer ="";

            FCMPushNotification result = new FCMPushNotification();
            try {
                result.Successful = true;
                result.Error = null;
                // var value = message;
                var requestUri = "https://fcm.googleapis.com/fcm/send";
               

                string fcmServerAPIKey = "AAAAAop4Xr4:APA91bE2tiRVWcqOvs14oSmE7ZEO3cs6K8Dg0Zp763ZTcXtqMcR1XvNT_aspAbz44OJN21hrmXiMDIgFmBVpjJNyB8RDr1QKChN2FJZM63_xoCmHQEp-7eIoqkT-C6cvUWT4MRwKP71z";
                string fcmServerId = "10913078974";

                WebRequest webRequest = WebRequest.Create(requestUri);
                webRequest.Method = "POST";
                webRequest.Headers.Add(string.Format("Authorization: key={0}", fcmServerAPIKey));
                webRequest.Headers.Add(string.Format("Sender: id={0}", fcmServerId));
                webRequest.ContentType = "application/json";

             
                var serializer = new JavaScriptSerializer();
                var json = serializer.Serialize(postData);

                Byte[] byteArray = Encoding.UTF8.GetBytes(json);

                webRequest.ContentLength = byteArray.Length;
                using (var dataStream = webRequest.GetRequestStream()) {
                    dataStream.Write(byteArray, 0, byteArray.Length);

                    using (WebResponse webResponse = webRequest.GetResponse()) {
                        using (var dataStreamResponse = webResponse.GetResponseStream()) {
                            using (StreamReader tReader = new StreamReader(dataStreamResponse)) {
                                 sResponseFromServer = tReader.ReadToEnd();
                                //result.Response = sResponseFromServer;

                                return sResponseFromServer;
                            }
                        }
                    }
                }

            }
            catch (Exception ex) {
                result.Successful = false;
                result.Response = null;
                result.Error = ex;
            }
            return sResponseFromServer;

        }
    }
}
