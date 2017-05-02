using MyShopWeb.DAL;
using System;
using System.Web.Mvc;
using System.Linq;
using System.Web;
using System.Web.Services;
using MyShopWeb.Models;


using System.Collections.Generic;


namespace MyShopWeb.Controllers
{
    // [Authorize]
    public class HomeController : Controller
    {

        public Guid EnteredBy = new Guid("C8F23075-18DC-4E26-8501-C083D72033B3");


        public int DealerId = 103;

        public ActionResult Index()
        {
            DealerId = 103;
            return View();
        }

        [HttpPost]
        public JsonResult SelStickerOrderMaster()
        {
            try
            {
                using (var entity = new MyShopDataClassesDataContext())
                {
                    var ds = entity.uspSelStickerOrderMaster(DealerId,0,10).ToList();
                    return Json(new { Result = "OK", Records = ds, TotalRecordCount = ds.Count() });
                }
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }

        [HttpPost]
        public JsonResult StickerStatusList()
        {
            try
            {
                using (var entity = new MyShopDataClassesDataContext())
                {
                    var ds = entity.uspSelAllStickerStatus().ToList().Select(c => new { DisplayText = c.StickerIssuedStatus, Value = c.StickerStatusId });
                    return Json(new { Result = "OK", Options = ds });
                    
                }
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }
        [HttpPost]
        public JsonResult UpdtUpsertStickerOrder(uspSelStickerOrderMasterResult m)
        {
            return UpsertStickerOrder(m);
        }
        [HttpPost]
        public JsonResult InsUpsertStickerOrder(uspSelStickerOrderMasterResult m)
        {
            m.OrderStatusId = 100; // ordered.
            return UpsertStickerOrder(m);
        }

        private JsonResult UpsertStickerOrder(uspSelStickerOrderMasterResult m)
        {
            try
            {
                using (var entity = new MyShopDataClassesDataContext())
                {
                    // bool? isValid = m.IsValid == true ? true : false;

                    var ds = entity.uspUpsertStickerOrderMasterDetail(DealerId, m.StickerOrderMasterId, m.ReceiptId, m.IssuingLocationId, m.NoOfReceipts, m.TransmittalNum,
                        m.MessengerNum, m.IMQty, m.IMCost, m.AIQty, m.AICost, m.AOQty, m.AOCost, m.SIQty, m.SICost, m.MV46Qty, m.MV46Cost, m.TotalPayment,
                        m.BatchNo, m.OrderStatusId, m.EnteredBy);

                    return Json(new { Result = "OK", Record = m });
                }
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }

        public ActionResult Index_old()
        {
            DealerId = 103;
            // return View();
            var rtn = new StickerMaster();
            var ds = new List<uspSelDealerStickerTypeResult>();
            try
            {
                using (var entity = new MyShopDataClassesDataContext())
                {
                    ds = entity.uspSelDealerStickerType(DealerId).ToList();
                }

                rtn.MySafetyStickers = new SafetyStickers();



                if (ds.Where(m => m.StickerTypeCD == "AI" && m.DealerId == DealerId) != null)
                {
                    var reorderQtyAI = ds.Where(m => m.StickerTypeCD == "AI" && m.DealerId == DealerId).SingleOrDefault().ReOrderCount;
                    var costAI = ds.Where(m => m.StickerTypeCD == "AI" && m.DealerId == DealerId).SingleOrDefault().Cost;

                    rtn.MySafetyStickers.AI = new StickerModel { Cost = costAI, OrderQty = reorderQtyAI };
                }

                if (ds.Where(m => m.StickerTypeCD == "AI" && m.DealerId == DealerId) != null)
                {
                    var reorderQtyAO = ds.Where(m => m.StickerTypeCD == "AO" && m.DealerId == DealerId).SingleOrDefault().ReOrderCount;
                    var costAO = ds.Where(m => m.StickerTypeCD == "AO" && m.DealerId == DealerId).SingleOrDefault().Cost;

                    rtn.MySafetyStickers.AO = new StickerModel { Cost = costAO, OrderQty = reorderQtyAO };
                }

                if (ds.Where(m => m.StickerTypeCD == "AI" && m.DealerId == DealerId) != null)
                {
                    var reorderQtySI = ds.Where(m => m.StickerTypeCD == "SI" && m.DealerId == DealerId).SingleOrDefault().ReOrderCount;
                    var costSI = ds.Where(m => m.StickerTypeCD == "SI" && m.DealerId == DealerId).SingleOrDefault().Cost;

                    rtn.MySafetyStickers.SI = new StickerModel { Cost = costSI, OrderQty = reorderQtySI };
                }

                if (ds.Where(m => m.StickerTypeCD == "AI" && m.DealerId == DealerId) != null)
                {
                    var reorderQtyIM = ds.Where(m => m.StickerTypeCD == "IM" && m.DealerId == DealerId).FirstOrDefault().ReOrderCount;

                    rtn.MySafetyStickers.AI = new StickerModel { Cost = 0, OrderQty = reorderQtyIM };
                }


            }
            catch (Exception ex)
            {
            }


            rtn.DealerStickerTypes = ds;
            return View(rtn);
        }


        [HttpPost]
        public ActionResult SaveSticker(string hidOrderId, string submit)
        {
            switch (submit)
            {
                case "Print":
                    ViewBag.Message = "Customer saved successfully!";

                    //CreatePDFFile(m);

                    break;
                case "Cancel":
                    ViewBag.Message = "The operation was cancelled!";
                    break;
            }
            return View("Index");
        }


        [HttpPost]
        public JsonResult StickerAddToInventory(Data data)
        {
           // var data = "{ \"fname\" : \"" + fname + " \" , \"lastname\" : \"" + lastname + "\" }";
            //// you have to add the JsonRequestBehavior.AllowGet 
            //// otherwise it will throw an exception on run-time.

            return Json(data, JsonRequestBehavior.AllowGet);
        }

        private void CreatePDFFile(StickerMaster m)
        {
            var pdfPath = Server.MapPath("/Forms/mv-436A.pdf");
            var formFieldMap = PDFHelper.GetFormFieldNames(pdfPath);
            // string test="";

            //foreach(var x in formFieldMap)
            //{
            //    test += x.Key + "\n";
            //}
            decimal? grandTotal = 0;

            if (m.MySafetyStickers.AI != null)
            {
                var reorderQtyAI = m.MySafetyStickers.AI.OrderQty;
                var costAI = m.MySafetyStickers.AI.Cost;

                formFieldMap["Passenger cars trucks 17000 pounds or"] = reorderQtyAI.ToString(); // AI
                formFieldMap["fill_38"] = (reorderQtyAI * costAI).ToString(); // AI AMT
                grandTotal += (reorderQtyAI * costAI);
            }

            if (m.MySafetyStickers.AO != null)
            {
                var reorderQtyAO = m.MySafetyStickers.AO.OrderQty;
                var costAO = m.MySafetyStickers.AO.Cost;
                                
                formFieldMap["Order in multiples of 10 6 each"] = reorderQtyAO.ToString(); // AO
                formFieldMap["fill_39"] = (reorderQtyAO * costAO).ToString(); // AO AMT

                grandTotal += (reorderQtyAO * costAO);
            }

            if (m.MySafetyStickers.SI != null)
            {
                var reorderQtySI = m.MySafetyStickers.SI.OrderQty;
                var costSI = m.MySafetyStickers.SI.Cost;
                
                formFieldMap["SemiAnnual Inside SI"] = reorderQtySI.ToString(); // SI
                formFieldMap["fill_40"] = (reorderQtySI * costSI).ToString(); // SI AMT
                grandTotal += (reorderQtySI * costSI);
            }



            formFieldMap["Text1"] = "1"; // Station Name
            formFieldMap["Station Number"] = "2";
            formFieldMap["Station Street Address PO Box number may be used in addition to the actual address but cannot be used as the only address"] = "3";
            formFieldMap["Telephone Number"] = "4";
            formFieldMap["Text2"] = "5"; // Email
            //formFieldMap["JanRow1.0"] = "6";
            //formFieldMap["JanRow1.4"] = "7";
            //formFieldMap["JanRow1.2"] = "8";
            //formFieldMap["JanRow1.3"] = "9";
            //formFieldMap["JanRow1.5"] = "10";
            //formFieldMap["JanRow1.6"] = "11";
            //formFieldMap["JanRow1.7"] = "12";
            //formFieldMap["JanRow1.8"] = "13";
            //formFieldMap["JanRow1.9"] = "14";
            //formFieldMap["JanRow1.10"] = "15";
            //formFieldMap["JanRow1.11"] = "16";
            //formFieldMap["JanRow2.0"] = "17";
            //formFieldMap["JanRow2.2"] = "18";
            //formFieldMap["JanRow2.3"] = "19";
            //formFieldMap["JanRow2.4"] = "20";
            //formFieldMap["JanRow2.5"] = "21";
            //formFieldMap["JanRow2.6"] = "22";
            //formFieldMap["JanRow2.7"] = "23";
            //formFieldMap["JanRow2.8"] = "24";
            //formFieldMap["JanRow2.9"] = "25";
            //formFieldMap["JanRow2.10"] = "26";
            //formFieldMap["JanRow2.11"] = "27";
            formFieldMap["QuantityEExempt Inserts"] = "28";
            formFieldMap["QuantityWWaiver Inserts"] = "29";
            formFieldMap["QuantityTDot Inserts TEMP"] = "30";
            formFieldMap["Form MV46"] = "31";
            formFieldMap["QuantityEmissions Stickers IM Minimum order of 10 stickers"] = "32";

           
          
            formFieldMap["Operators"] = "39";
            formFieldMap["Total Amount for"] = "40"; // State
            formFieldMap["fill_44"] = grandTotal.ToString(); // Total AMT for Stickers
            formFieldMap["Print Name as Above"] = "42";
            //formFieldMap[" 500Total Amount Due  StickersPostage"] = "43";
            //formFieldMap["JanRow1.1"] = "44";
            //formFieldMap["JanRow2.1"] = "45";
            formFieldMap["Shipping and"] = "46"; // Date
            formFieldMap["Text3.0"] = "47"; //City
            formFieldMap["Text3.1"] = "48"; // State
            formFieldMap["Text3.2"] = "49"; // zip



            //formFieldMap["Station Number"] = "Jadhav";




            var pdfContents = PDFHelper.GeneratePDF(pdfPath, formFieldMap);

            var fname = Server.MapPath("/Forms/mv-436A_12.pdf");
            PDFHelper.CreatePDF(pdfContents, fname);

            Response.Redirect("/Forms/mv-436A_12.pdf");

            //String FileName = "FileName.txt";
            //String FilePath = "C:/...."; //Replace this
            //System.Web.HttpResponse response = System.Web.HttpContext.Current.Response;
            //response.ClearContent();
            //response.Clear();
            //response.ContentType = "text/plain";
            //response.AddHeader("Content-Disposition", "attachment; filename=" + FileName + ";");
            //response.TransmitFile(FilePath);
            //response.Flush();
            //response.End();

        }

        [Authorize(Roles = "Admin,Editor")]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

    }

    public class Data
    {
        public string username { get; set; }
        public string password { get; set; }
    }
}