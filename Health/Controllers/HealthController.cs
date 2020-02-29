using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Health.Models;
using PagedList;

namespace Health.Controllers
{
    public class HealthController : Controller
    {
        
        // GET: Health
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Order(Order orderClient)
        {
            var orders = orderClient.orders;
            return View(orders.ToList());
        }

        // GET: Health/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Health/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Health/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection, string currentFilter, string searchString, int ? page)
        {
            try
            {
                //Agregar la lista que se imprimira en la tabla
                if(searchString != null)
                {
                    page = 1;
                }
                else
                {
                    searchString = currentFilter;
                }
                ViewBag.CurrentFilter = searchString;

                int pageSize = 3;
                int pageNumber = (page ?? 1);
                //return View(listaDeMedicamentos.ToPagedList(pageNumbre, pageSize))

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Health/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Health/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Health/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Health/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public void SearchZeros()
        {
            int counter = 0;
            
            string line;

            // Read the file and display it line by line.
            System.IO.StreamReader file = new System.IO.StreamReader("c:\\test.txt");
            while ((line = file.ReadLine()) != null)
            {
                if (line.Contains("0"))
                {

                    Console.WriteLine(counter.ToString() + ": " + line);
                }

                counter++;
            }

            file.Close();
        }

    }
}
