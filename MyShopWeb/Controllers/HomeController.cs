using MyShopWeb.DAL;
using System;
using System.Web.Mvc;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace Authentication.Controllers
{
   // [Authorize]
    public class HomeController : Controller
    {


        public int DealerId { get; set; }
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
        public JsonResult UpdtDealerStickerTypeList(uspSelDealerStickerTypeResult m)
        {
            try
            {
                using (var entity = new MyShopDataClassesDataContext())
                {
                    var ds = entity.uspUpsertDealerStickerType(DealerId,m.StickerTypeId,m.Cost,m.IsValid);

                    return Json(new { Result = "OK", Record = m });
                    //return Json(new { Result = "OK" }); in case of update
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