using Microsoft.AspNetCore.Mvc;

namespace MyApp.Namespace
{
    public class TransController : Controller
    {
        // GET: TransController
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Viewdata()
        {
            ViewData["Message"] = "ViewData";
            return View();
        }
        public ActionResult Viewbag()
        {
            ViewBag.Message = "ViewBag";
            return View();
        }
        public ActionResult Tempdata1()
        {
            TempData["M1"] = "tempdata";
            return RedirectToAction("Tempdata2");
        }

        public ActionResult Tempdata2()
        {
            return View();
        }

        public ActionResult Setsession()
        {
            HttpContext.Session.SetString("name", "manan");
            return View();
        }
        public ActionResult Getsession()
        {
            return View();
        }
        public ActionResult Create()
        {
            return Content("<h1>Hello</h1>", "text/html");
        }

        public ActionResult yt()
        {
            return Redirect("https://www.youtube.com/watch?v=f2ogKOsIJng&list=RDf2ogKOsIJng&start_radio=1");
        }

        public ActionResult RTA()
        {
            return RedirectToAction("Viewbag");
        }

        public ActionResult partialRTA()
        {
            return PartialView("part");
        }

        public ActionResult JsonResult()
        {
            var data = new { name = "Manan", Age = 22 };
            return Json(data);
        }

        public ActionResult Getobject()
        {
            var data = new { Message = "Success", Code = 200 };
            return new ObjectResult(data) { StatusCode = 200 };
        }

    }
}
