﻿using Health.Models;
using Health.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Health.Controllers {

    public class MedicineController : Controller {
        // GET: Medicine

        [HttpPost]
        public ViewResult FindElement(FormCollection collection) {
            var element = new Medicine { name = collection["search"] };
            var found = Storage.Instance.treeList.searchValue(element, Medicine.CompareByName);
            var elementToList = from s in Storage.Instance.medicinesList
                                select s;
            elementToList = elementToList.Where(s => s.name.Contains(found.name));
            return View(elementToList.ToList());
        }


        public ActionResult Index(){
            return View(Storage.Instance.medicinesReturn);
        }

        // GET: Medicine/Details/5
        public ActionResult Details(int id) {
            return View();
        }

        // GET: Medicine/Create
        public ActionResult Create() {
            return View();
        }

        // POST: Medicine/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection) {
            try {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }catch{
                return View();
            }
        }

        // GET: Medicine/Edit/5
        public ActionResult Edit(int id) {
            return View();
        }

        // POST: Medicine/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection) {
            try {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            } catch {
                return View();
            }
        }

        // GET: Medicine/Delete/5
        public ActionResult Delete(int id) {
            return View();
        }

        // POST: Medicine/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection) {
            try {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            } catch {
                return View();
            }
        }
    }
}
