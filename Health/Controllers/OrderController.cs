using Health.Models;
using Health.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Health.Controllers {
    public class OrderController : Controller {

        // GET: Order
        public ActionResult Index() {
            LoadFile();
            return View(Storage.Instance.orderList);
        }

        // GET: Order/Details/5
        public ActionResult Details(int id) {
            return View();
        }

        // GET: Order/Create
        public ActionResult Create() {
            return View();
        }

        // POST: Order/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection) {
            try {
                var newOrder = new Order{
                    Name = collection["Name"],
                    Address = collection["Address"],
                    Nit = collection["Nit"]
                };
                newOrder.saveOrder();
                return View("~/Views/Medicine/Index.cshtml", (Storage.Instance.medicinesList));
            }catch {
                return View();
            }
        }

        // GET: Order/Edit/5
        public ActionResult Edit(int id){
            return View();
        }

        // POST: Order/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection) {
            try {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            } catch {
                return View();
            }
        }

        // GET: Order/Delete/5
        public ActionResult Delete(int id) {
            return View();
        }

        // POST: Order/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection) {
            try {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            } catch {
                return View();
            }
        }

        public void LoadFile(){
            using (var fileStream = new FileStream(AppDomain.CurrentDomain.BaseDirectory + "/Test/TestFile.csv", FileMode.Open)){
                using (var streamReader = new StreamReader(fileStream)){
                    Medicine medicine = new Medicine();
                    while (streamReader.Peek() >= 0){
                        String lineReader = streamReader.ReadLine();
                        String[] parts = lineReader.Split(',');
                        if (parts[0] != ("id")){
                            medicine.idMedicine = Convert.ToInt32(parts[0]);
                            medicine.name = parts[1];
                            medicine.saveMedicine(true);
                            medicine.description = parts[2];
                            medicine.producer = parts[3];
                            medicine.price = Convert.ToDouble(parts[4]);
                            medicine.stock = Convert.ToInt32(parts[5]);
                            medicine.saveMedicine(false);
                            medicine = new Medicine();
                        }
                    }
                }
            }
            Storage.Instance.treeList.GetEnumerator();
        }
    }
}
