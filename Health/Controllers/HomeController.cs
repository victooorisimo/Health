using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Health.Controllers {

    public class HomeController : Controller {

        public ActionResult Index() {
            LoadFile();
            return View();
        }

        public ActionResult About(){
            ViewBag.Message = "Your application description page.";
            return View();
        }

        public ActionResult Contact(){
            ViewBag.Message = "Your contact page.";
            return View();
        }

        public void LoadFile() {
            using (var fileStream = new FileStream(AppDomain.CurrentDomain.BaseDirectory + "/Test/TestFile.csv", FileMode.Open)){

            }
        }
    }
}