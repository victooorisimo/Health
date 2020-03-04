using Health.Services;
using Health.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using System.IO;

namespace Health.Controllers {

    public class MedicineController : Controller {
        // GET: Medicine


        public ActionResult Index(int? page)
        {
            int pageSize = 5;
            int pageIndex = 1;
            pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
            IPagedList<Medicine> listMedicines = null;
            listMedicines = Storage.Instance.medicinesReturn.ToPagedList(pageIndex, pageSize);
            return View(listMedicines);
        }

        [HttpPost]
        public ActionResult ResupplyAction(){

            Resupply();
            return RedirectToAction("Index");
        }


        //[HttpPost]
        //public ViewResult FindElement(FormCollection collection) {
        //    var element = new Medicine { name = collection["search"]};
        //    var quantity = new Medicine { stock = Convert.ToInt32(collection["quantity"]) };
        //    var found = Storage.Instance.treeList.searchValue(element, Medicine.CompareByName);


        //    if (found.stock >= quantity.stock){
        //        var elementToList = from s in Storage.Instance.medicinesList
        //                            select s;
        //        Storage.Instance.treeList.searchValue(element, Medicine.CompareByName).stock = quantity.stock; 
        //        elementToList = elementToList.Where(s => s.name.Contains(found.name));
        //        return View(elementToList.ToList());
        //    }
        //    return View(Storage.Instance.medicinesList.ToList());
        //}

        //[HttpPost]
        //public ViewResult FindElement(FormCollection collection)
        //{
        //    var element = new Medicine
        //    {
        //        name = collection["search"],
        //        stock = int.Parse(collection["quantity"])
        //    };
        //    var found = Storage.Instance.treeList.searchValue(element, Medicine.CompareByName);
        //    var elementToList = from s in Storage.Instance.medicinesList
        //                        select s;
        //    if (element.stock <= found.stock)
        //    {
        //        elementToList = elementToList.Where(s => s.name.Contains(found.name));
        //    }
        //    return View(elementToList.ToList());
        //}

        [HttpPost]
        public ViewResult FindElement(FormCollection collection, int?page)
        {
            if (Request.HttpMethod != "GET")
            {
                page = 1;
            }
            int pageSize = 3;
            int pageNumber = (page ?? 1);
            
            var element = new Medicine { name = collection["search"],
                                         stock = int.Parse(collection["quantity"])};
            var found = Storage.Instance.treeList.searchValue(element, Medicine.CompareByName);
            var elementToList = from s in Storage.Instance.medicinesList
                                select s;
            elementToList = elementToList.Where(s => s.name.Contains(found.name));
            return View(elementToList.ToPagedList(pageNumber, pageSize));
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

        public void Resupply()
        {
            Random rnd = new Random();
            int random = rnd.Next(1, 15);

            foreach (var item in Storage.Instance.medicinesList){
                    if (item.stock== 0){
                        item.stock = random;    
                    }
            }
        }

    }
}
