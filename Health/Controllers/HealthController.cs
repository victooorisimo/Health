using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Health.Models;

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
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

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
    }
}
