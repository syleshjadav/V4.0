using MyShopWeb.DAL;
using System;
using System.Web.Mvc;
using System.Linq;
using System.Web;
using System.Web.Services;
using MyShopWeb.Models;

namespace Authentication.Controllers
{
    // [Authorize]
    public class HomeController : Controller
    {

        public Guid EnteredBy = new Guid("C8F23075-18DC-4E26-8501-C083D72033B3");


        public int DealerId = 103;

        public ActionResult Index()
        {
            DealerId = 103;
           // return View();

           return View(new SafetyStickers() { AI = new StickerModel { StickerTypeId = 1 } });
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
}