using System;
using System.IO;
using System.Linq;
using System.Web.Mvc;
using Health.Models;
using Health.Services;

namespace Health.Controllers
{
    public class HealthController : Controller {

        // GET: Health
        public ActionResult Index(){

            return View();
        }

        public ActionResult Order(Order orderClient) {
            var orders = orderClient.orders;
            return View(orders.ToList());
        }

        // GET: Health/Details/5
        public ActionResult Details(int id) {
            return View();
        }

        // GET: Health/Create
        public ActionResult Create(){
            return View();
        }

        // POST: Health/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection){
            try{
                // TODO: Add insert logic here
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Health/Edit/5
        public ActionResult Edit(int id){
            return View();
        }

        // POST: Health/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection){
            try{
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }catch{
                return View();
            }
        }

        // GET: Health/Delete/5
        public ActionResult Delete(int id){
            return View();
        }

        // POST: Health/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection){
            try{
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }catch {
                return View();
            }
        }

        //Methods for delete element of binary tree
        public void searchMissing(){
            using (var fileStream = new FileStream(AppDomain.CurrentDomain.BaseDirectory + "/Test/TestFile.csv", FileMode.Open)){
                using (var streamReader = new StreamReader(fileStream)){
                    Medicine medicine = new Medicine();
                    while (streamReader.Peek() >= 0){
                        String lineReader = streamReader.ReadLine();
                        String[] parts = lineReader.Split(',');
                        if (parts[0] != ("id")){
                            if (parts[parts.Length - 1].Equals(0)){
                                medicine.setName(parts[1]);
                                medicine.setIdMedicine(Convert.ToInt32(parts[0]));
                                medicine.deleteMedicine();
                                medicine = new Medicine();
                            }
                        }
                    }
                }
            }
        }
    }
}
