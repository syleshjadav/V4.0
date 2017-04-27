using MyShopWeb.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyShopWeb.Controllers
{
    public class StickerController : Controller
    {
        public Guid EnteredBy = new Guid("C8F23075-18DC-4E26-8501-C083D72033B3");


        public int DealerId = 103;

        //  [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            DealerId = 103;
            return View();
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


        [HttpPost]
        public JsonResult StickerTypeList()
        {
            try
            {
                using (var entity = new MyShopDataClassesDataContext())
                {
                    var ds = entity.uspSelAllStickerTypes().ToList();
                    return Json(new { Result = "OK", Records = ds, TotalRecordCount = ds.Count() });
                }
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }
        [HttpPost]
        public JsonResult GetStickerTypeList()
        {
            try
            {
                using (var entity = new MyShopDataClassesDataContext())
                {
                    var ds = entity.uspSelAllStickerTypes().ToList().Select(c => new { DisplayText = c.StickerTypeCD, Value = c.StickerTypeId });

                    //  var ds2 = entity.uspSelAllFilingStatus().ToList();

                    return Json(new { Result = "OK", Options = ds });
                }
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }
        [HttpPost]
        public JsonResult DealerStickerTypeList()
        {
            try
            {
                using (var entity = new MyShopDataClassesDataContext())
                {
                    var ds = entity.uspSelDealerStickerType(DealerId).ToList();
                    return Json(new { Result = "OK", Records = ds, TotalRecordCount = ds.Count() });
                }
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }

        [HttpPost]
        public JsonResult InsDealerStickerTypeList(uspSelDealerStickerTypeResult m)
        {
            try
            {
                using (var entity = new MyShopDataClassesDataContext())
                {
                    bool? isValid = m.IsValid == true ? true : false;

                    var ds = entity.uspUpsertDealerStickerType(DealerId, m.StickerTypeId, m.Cost, isValid, m.ReOrderCount, EnteredBy);

                    return Json(new { Result = "OK", Record = m });
                }
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }

        [HttpPost]
        public JsonResult UpdtDealerStickerTypeList(uspSelDealerStickerTypeResult m)
        {
            try
            {
                using (var entity = new MyShopDataClassesDataContext())
                {
                    bool? isValid = m.IsValid == true ? true : false;
                    var ds = entity.uspUpsertDealerStickerType(DealerId, m.StickerTypeId, m.Cost, isValid, m.ReOrderCount, EnteredBy);

                    return Json(new { Result = "OK", Record = m });
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
                    var ds = entity.uspSelAllStickerStatus().ToList();
                    return Json(new { Result = "OK", Records = ds, TotalRecordCount = ds.Count() });
                }
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }
    }
}