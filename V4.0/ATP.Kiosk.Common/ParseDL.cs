using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ATP.Kiosk.Common
{
   public static class ParseDL
    {
       //public static ATP.DataModel.LogIn ParseDLInfoSwiped(string cardinfo, string systemToken)
       // {

       //     try // only parsing errors
       //     {
       //         // LblError.Text = ""; // reset to null
       //         // iDLErrorCount = 0;
       //         var cardData = cardinfo.Split('^');

       //         var issued = cardData[0].Split('%');
       //         var names = cardData[1].Split('$');
       //         var fullAddress = cardData[2].Split('$');
       //         var numberDetails = cardData[3].Split('=');
       //         string fname = "", mname = "", lname = "", SurName=null;

       //         if (names != null)
       //         {
                    
       //             var iCount = names.ToArray().Count();
       //             if (names != null && names.ToArray().Count() >= 0)
       //             {
       //                 switch (iCount)
       //                 {
       //                     case 1:
       //                         fname = names[0];
       //                         break;
       //                     case 2:
       //                         fname = names[0];
       //                         lname = names[1];
       //                         break;
       //                     case 3:
       //                         fname = names[0];
       //                         mname = names[1];
       //                         lname = names[2];
       //                         break;
       //                     case 4:
       //                         fname = names[0];
       //                         mname = names[1];
       //                         lname = names[2];
       //                         SurName = names[3];
       //                         break;
       //                     default:
       //                           fname = names[0];
       //                           lname = names[1];
       //                         break;

       //                 }
       //             }
       //         }

       //         var idCard = "0";

       //         if (numberDetails.Any())
       //         {
       //             idCard = numberDetails[0].Replace("?", null).Replace(";", null).Trim();
       //         }

       //         var login = new ATP.DataModel.LogIn
       //         {
       //             AddressLine1 = fullAddress[0],
       //             AddressLine2 = cardinfo,
       //             ZipCode = "00000",// numberDetails[2].Substring(4, 5),
       //             Environment = 2, //koisk
       //             FirstName = fname,
       //             MiddleName = mname,
       //             LastName = lname,
       //             IdCard = idCard,
       //             Password = systemToken // need to pass the system token on password.

       //         };
       //         return login;
       //     }
       //     catch (Exception ex)
       //     {
       //         //MessageBox.Show(ex.Message);
       //         throw ex;
       //     }

       //     //return null;

       // }

       //public static DataModel.LogIn ParseDLScannedData(string scannedData, string systemToken)
       // {
       //     //Motrolla
       //     //@\n\rAAMVA6360250101DL00290199DAQ28214753\nDAARAMACHANDER SYLESH JADAV\nDAG6111 MACARTHUR DR\nDAIHARRISBURG\nDAJPA\nDAK17112      \nDARC   \nDAS*/*             \nDAT---- \nDAU506\nDAYBLK\nDBA20150619\nDBB19721117\nDBCM\nDBD20130828\nDBF00\nDBHY\r
       //     //datalogic
       //     //"@\n\rAAMVA6360250101DL00290199DAQ28214753\nDAARAMACHANDER SYLESH JADAV\nDAG6111 MACARTHUR DR\nDAIHARRISBURG\nDAJPA\nDAK17112      \nDARC   \nDAS*/*             \nDAT---- \nDAU506\nDAYBLK\nDBA20150619\nDBB19721117\nDBCM\nDBD20130828\nDBF00\nDBHY\r\r"
       //     scannedData = scannedData.Replace("\r", "");

       //     string[] lines = scannedData.Split('\n');

       //     var dic = new Dictionary<string, string>();
       //     if (lines.Count() > 5)
       //     {
       //         foreach (string line in lines)
       //         {
       //             if (line.Length > 2)
       //             {
       //                 if (line.IndexOf("AAM") == 1)
       //                 {
       //                     dic.Add(line.Substring(1, 3), line.Substring(4, (line.Length) - 4));
       //                 }
       //                 else
       //                 {
       //                     dic.Add(line.Substring(0, 3), line.Substring(3, (line.Length) - 3));
       //                 }
       //             }
       //         }
       //     }
       //     var fullDL = dic.ContainsKey("AAM") ? dic["AAM"].Trim() : null;
       //     var fullname = dic.ContainsKey("DAA") ? dic["DAA"].Trim() : null;
       //     var address1 = dic.ContainsKey("DAG") ? dic["DAG"].Trim() : null;
       //     var city = dic.ContainsKey("DAI") ? dic["DAI"].Trim() : null;
       //     var state = dic.ContainsKey("DAJ") ? dic["DAJ"].Trim() : null;
       //     var zip = dic.ContainsKey("DAK") ? dic["DAK"].Trim() : null;
       //     string fname = "", mname = "", lname = "", DL = null,SurName="";

       //     if (dic.Keys.ElementAt(0) != null)
       //     {
       //        // fullDL = dic[dic.Keys.ElementAt(0)].Trim();

       //         if (fullDL.IndexOf("DAQ") > 1)
       //         {
       //             DL = fullDL.Substring(2, 6) + fullDL.Substring(fullDL.IndexOf("DAQ") + 3, fullDL.Length - (fullDL.IndexOf("DAQ") + 3));
       //         }
       //     }
       //     if (fullname != null)
       //     {
       //         var names = fullname.Split();


       //         if (names != null && names.ToArray().Count() >= 0)
       //         {
       //             var iCount = names.ToArray().Count();

       //             switch (iCount)
       //             {
       //                 case 1:
       //                     fname = names[0];
       //                     break;
       //                 case 2:
       //                     fname = names[0];
       //                     lname = names[1];
       //                     break;
       //                 case 3:
       //                     fname = names[0];
       //                     mname = names[1];
       //                     lname = names[2];
       //                     break;
       //                 case 4:
       //                     fname = names[0];
       //                     mname = names[1];
       //                     lname = names[2];
       //                     SurName = names[3];
       //                     break;
       //                 default:
       //                       fname = names[0];
       //                       lname = names[1];
       //                     break;

       //             }

       //         }
       //     }

       //     var rnd = new Random();

       //     var login = new ATP.DataModel.LogIn
       //     {

       //         Environment = 2, //koisk
       //         FirstName = fname,
       //         MiddleName = mname,
       //         LastName = lname,
       //         IdCard = DL,
       //         AddressLine1 = address1,
       //         ZipCode = zip,
       //         City = city,
       //         STP = state,
       //         Password = systemToken,
       //         DealerId = 1

       //     };
       //     return login;
       // }

    }
}
