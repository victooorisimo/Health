using Health.Models;
using Health.Services;
using PagedList;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text.RegularExpressions;
using Microsoft.VisualBasic;


namespace Health.Controllers {
    public class OrderController : Controller {

        // GET: Order
        public ActionResult Index() {
            LoadFile();
            var orderList = Storage.Instance.orderList;
            return View(orderList.ToList());
        }

        // GET: Order/Create
        public ActionResult Create() {
            return View();
        }

        // POST: Order/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection, int ? page) {
            try {

                var newOrder = new Order{
                    Name = collection["Name"],
                    Address = collection["Address"],
                    Nit = collection["Nit"]
                };
                newOrder.saveOrder();
                return RedirectToAction("Index","Medicine");
            }catch {
                return View();
            }
        }

        public void LoadFile(){
            using (var fileStream = new FileStream(AppDomain.CurrentDomain.BaseDirectory + "/Test/TestFile.csv", FileMode.Open)){
                using (var streamReader = new StreamReader(fileStream)){
                    Medicine medicine = new Medicine();
                    while (streamReader.Peek() >= 0){
                        String lineReader = streamReader.ReadLine();
                        Regex delimitors = new Regex(@"^\d+\t(\d+)\t.+?\t(item\\[^\t]+\.ddj)", RegexOptions.IgnoreCase);
                        String[] parts = lineReader.Split(',');
                        
                        if (parts[0] != ("id"))
                        {
                            if (parts.Length == 6)
                            {
                                medicine.idMedicine = Convert.ToInt32(parts[0]);
                                medicine.name = parts[1];
                                medicine.saveMedicine(true);
                                medicine.description = parts[2];
                                medicine.producer = parts[3];
                                medicine.price = Convert.ToDouble((parts[4]).Substring(1,(parts[4].Length)-1));
                                medicine.stock = Convert.ToInt32(parts[5]);
                                medicine.saveMedicine(false);
                                medicine = new Medicine();
                            }

                        }                    
                    }
                }
            }
            Storage.Instance.treeList.GetEnumerator();
        }


        public ActionResult InitalPage()
        {
            return View();
        }

        [HttpPost]
        public ActionResult InitalPage(string add)
        {
            return RedirectToAction("Index");
        }


    }
}
