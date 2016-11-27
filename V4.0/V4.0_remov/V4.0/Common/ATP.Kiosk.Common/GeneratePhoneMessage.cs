using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ATP.Kiosk.Common
{
    public class GeneratePhoneMessage
    {
        public string GetMessageToSend(string dealerId, string FirstName, string LastName, string VIN,
                                                string message, string messageType, string title, string deviceTypeId, string ronum, String roAmount, string personGuid, string vehPhId)
        {
            //string dealerId = SelectedVehicleInService.DealerId.ToString();
            //string FirstName = SelectedVehicleInService.FirstName;
            //string LastName = SelectedVehicleInService.LastName;
            //string VIN = SelectedVehicleInService.VIN;
            if (string.IsNullOrEmpty(VIN)) { VIN = "NOVIN"; }
            var jsonStr = string.Empty;

            if (deviceTypeId == "0")
            {

                var cust = new NotificationList
                {
                    Notification =
                        new Notification
                        {
                            DealerId = dealerId,
                            FirstName = FirstName,
                            LastName = LastName,
                            Message = message,
                            MessageType = messageType,
                            Title = title,
                            VIN = VIN,
                            RONum = ronum,
                            ROAmount = roAmount,
                            PersonGuid = personGuid,
                            VehPhId = vehPhId
                        }

                };
                jsonStr = JSonHelpers.ToJson<NotificationList>(cust);

                return jsonStr;
            }
            else if (deviceTypeId == "1")
            {
                if (messageType == "CUSUPDT")
                {
                    var cust = new appsList
                    {
                        aps = new aps
                        {
                            alert = "Your Profile has been updated",
                            sound = "default",
                            contentavailable="1"
                        },
                        Notification =
                                              new Notification
                                              {
                                                  DealerId = dealerId,
                                                  FirstName = FirstName,
                                                  LastName = LastName,
                                                  Message = message,
                                                  MessageType = messageType,
                                                  Title = title,
                                                  VIN = VIN,
                                                  RONum = ronum,
                                                  ROAmount = roAmount,
                                                  VehPhId = vehPhId,
                                                  PersonGuid=personGuid 
                                              }
                    };
                    jsonStr = JSonHelpers.ToJson<appsList>(cust);

                    jsonStr = jsonStr.Replace("null,", "");



                }
                else {
                    var cust = new appsList
                    {
                        aps = new aps
                        {
                            alert = "You have a message",
                            sound = "default"
                        },
                        Notification =
                           new Notification
                           {
                               DealerId = dealerId,
                               FirstName = FirstName,
                               LastName = LastName,
                               Message = message,
                               MessageType = messageType,
                               Title = title,
                               VIN = VIN,
                               RONum = ronum,
                               ROAmount = roAmount,
                               VehPhId = vehPhId
                           }
                    };
                    jsonStr = JSonHelpers.ToJson<appsList>(cust);
                }

            }

            return jsonStr;

        }

        public string GetMessageToSendFORCUSUPDT(string dealerId, string FirstName, string LastName, string VIN,
                                               string message, string messageType, string title, string deviceTypeId, string ronum, String roAmount, string personGuid, string vehPhId)
        {
            //string dealerId = SelectedVehicleInService.DealerId.ToString();
            //string FirstName = SelectedVehicleInService.FirstName;
            //string LastName = SelectedVehicleInService.LastName;
            //string VIN = SelectedVehicleInService.VIN;
            if (string.IsNullOrEmpty(VIN)) { VIN = "NOVIN"; }
            var jsonStr = string.Empty;

            if (deviceTypeId == "0")
            {

                var cust = new NotificationList
                {
                    Notification =
                        new Notification
                        {
                            DealerId = dealerId,
                            FirstName = FirstName,
                            LastName = LastName,
                            Message = message,
                            MessageType = messageType,
                            Title = title,
                            VIN = VIN,
                            RONum = ronum,
                            ROAmount = roAmount,
                            PersonGuid = personGuid,
                            VehPhId = vehPhId
                        }

                };
                jsonStr = JSonHelpers.ToJson<NotificationList>(cust);

                return jsonStr;
            }
            else if (deviceTypeId == "1")
            {

                var cust = new appsList
                {
                    aps = new aps
                    {
                        alert = "You have a message",
                        sound = "default"
                    },

                    Notification =
                       new Notification
                       {
                           DealerId = dealerId,
                           FirstName = FirstName,
                           LastName = LastName,
                           Message = message,
                           MessageType = messageType,
                           Title = title,
                           VIN = VIN,
                           RONum = ronum,
                           ROAmount = roAmount,
                           VehPhId = vehPhId
                       }
                };
                jsonStr = JSonHelpers.ToJson<appsList>(cust);


            }

            return jsonStr;

        }

        public string SendMessageToAndroid(string deviceId, string message, string tickerText, string contentTitle)
        {
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

            var cust = new GCM
            {
                registration_ids = new List<string> { deviceId },
                data = new Data { tickerText = tickerText, contentTitle = contentTitle, vibrate = "true", sound = "default", time = DateTime.Now.ToString(), message = message }
            };

            var jsonStr = JSonHelpers.ToJson<GCM>(cust);

            return SendGCMNotification(jsonStr);
        }
        private string SendGCMNotification(string postData, string postDataContentType = "application/json")
        {
            string apiKey = "AIzaSyBj5E6vNelDzyOTgSykhbDAmJp4IAW4s2M";

            //  MESSAGE CONTENT
            byte[] byteArray = Encoding.UTF8.GetBytes(postData);

            //
            //  CREATE REQUEST
            HttpWebRequest Request = (HttpWebRequest)WebRequest.Create("https://android.googleapis.com/gcm/send");
            Request.Method = "POST";
            Request.KeepAlive = false;
            Request.ContentType = postDataContentType;
            Request.Headers.Add(HttpRequestHeader.Authorization, string.Format("key={0}", apiKey));
            Request.ContentLength = byteArray.Length;

            Stream dataStream = Request.GetRequestStream();
            dataStream.Write(byteArray, 0, byteArray.Length);
            dataStream.Close();

            try
            {
                WebResponse Response = Request.GetResponse();
                HttpStatusCode ResponseCode = ((HttpWebResponse)Response).StatusCode;
                if (ResponseCode.Equals(HttpStatusCode.Unauthorized) || ResponseCode.Equals(HttpStatusCode.Forbidden))
                {
                    return "Unauthorized - need new token";

                }
                else if (!ResponseCode.Equals(HttpStatusCode.OK))
                {
                    return "Response from web service isn't OK";
                }

                StreamReader Reader = new StreamReader(Response.GetResponseStream());
                string responseLine = Reader.ReadToEnd();
                Reader.Close();

                return responseLine;
            }
            catch (Exception e)
            {
                return e.Message.ToString();
            }
            // return "error";
        }
    }
    [Serializable, DataContract]
    public class Result
    {
        [DataMember]
        public string message_id { get; set; }
    }
    [Serializable, DataContract]
    public class GCMReturn
    {
        [DataMember]
        public string multicast_id { get; set; }
        [DataMember]
        public string success { get; set; }
        [DataMember]
        public string failure { get; set; }
        [DataMember]
        public string canonical_ids { get; set; }
        [DataMember]
        public List<Result> results { get; set; }
    }
    [Serializable, DataContract]
    public class aps
    {

      

        [DataMember]

        public string alert { get; set; }
        [DataMember]
        public string sound { get; set; }
        [DataMember]
        public string contentavailable { get; set; }

    }

    [Serializable, DataContract]
    public class ContAvail
    {
        [DataMember]
        public string contentavailable { get; set; }


    }


    [Serializable, DataContract]
    public class NotificationList
    {
        [DataMember]
        public Notification Notification { get; set; }
    }
    [Serializable, DataContract]
    public class Notification
    {
        public Notification() { }

        [DataMember]
        public string DealerId { get; set; }

        [DataMember]
        public string FirstName { get; set; }


        [DataMember]
        public string LastName { get; set; }

        [DataMember]
        public string Message { get; set; }

        [DataMember]
        public string MessageType { get; set; }

        [DataMember]
        public string Title { get; set; }

        [DataMember]
        public string VIN { get; set; }

        [DataMember]
        public string RONum { get; set; }
        [DataMember]
        public string ROAmount { get; set; }
        [DataMember]
        public string PersonGuid { get; set; }

        [DataMember]
        public string VehPhId { get; set; }

    }

    [Serializable, DataContract]
    public class appsList
    {

        [DataMember(Order = 1)]
        public aps aps { get; set; }

       

        [DataMember(Order = 2)]
        public Notification Notification { get; set; }
    }

    [Serializable, DataContract]
    public class GCM
    {
        [DataMember]
        public List<string> registration_ids { get; set; }
        [DataMember]
        public Data data { get; set; }
    }

    [Serializable, DataContract]
    public class Data
    {
        public Data() { }

        [DataMember]
        public string tickerText { get; set; }

        [DataMember]
        public string contentTitle { get; set; }


        [DataMember]
        public string vibrate { get; set; }

        [DataMember]
        public string sound { get; set; }

        [DataMember]
        public string time { get; set; }

        [DataMember]
        public string message { get; set; }




    }

}
