using Health.Models;
using Health.Services;
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
                using (var streamReader = new StreamReader(fileStream)) {
                    Medicine medicine = new Medicine();
                    while (streamReader.Peek() >= 0){
                        String lineReader = streamReader.ReadLine();
                        String[] parts = lineReader.Split(',');
                        if (parts[0] != ("id")){
                            medicine.setName(parts[1]);
                            medicine.setIdMedicine(Convert.ToInt32(parts[0]));
                            medicine.saveMedicine();
                            medicine = new Medicine();
                        }
                    }     
                }
            }
        }
    }
}