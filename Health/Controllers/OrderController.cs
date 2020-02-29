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
            SearchZeros();
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
                
                return RedirectToAction("Index");
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

        [HttpPost]
        public ActionResult FindElement(FormCollection collection){
            var searchT = collection["search"];
            //Llamada al método de búsqueda dentro del View(PokemonModel.Filter(name));
            return View();
        }

        public void LoadFile(){
            using (var fileStream = new FileStream(AppDomain.CurrentDomain.BaseDirectory + "/Test/TestFile.csv", FileMode.Open)){
                using (var streamReader = new StreamReader(fileStream)){
                    Medicine medicine = new Medicine();
                    while (streamReader.Peek() >= 0){
                        String lineReader = streamReader.ReadLine();
                        String[] parts = lineReader.Split(',');
                        if (parts[0] != ("id")){
                            medicine.name = parts[1];
                            medicine.idMedicine =Convert.ToInt32(parts[0]);
                            medicine.saveMedicine();
                            medicine = new Medicine();
                        }
                    }
                }
            }
        }

        public void SearchZeros()
        {
            Random rnd = new Random();
            int random = rnd.Next(1, 15);
            int counter = 0;
            string line;

            // Read the file and display it line by line.
            System.IO.StreamReader file = new System.IO.StreamReader("c:\\test.txt");
            System.IO.StreamWriter write = new System.IO.StreamWriter("c:\\test.txt");

            while ((line = file.ReadLine()) != null)
            {
                if (line[line.Length - 1].Equals(0))
                {
                    line = line.Split(',')[5] + random;
                    write.WriteLine(line);
                    
                }
                counter++;
            }
            file.Close();
        }
    }
}
