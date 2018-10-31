using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TrackerModuleV1._0.Data;
using TrackerModuleV1._0.Models.PTM;

namespace TrackerModuleV1._0.Controllers
{
    public class InventoriesController : Controller
    {
        private PTMContex db = new PTMContex();

        // GET: Inventories
        //public ActionResult Index()
        //{
        //    return View(db.Inventories.ToList());
        //}

        public ActionResult Index(string sortOrder, string searchDesc, string id)
        {
            //ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "PartName" : "";
            ViewBag.DateSortParm = sortOrder == "DeliveryDate" ? "DeliveryDate_desc" : "DeliveryDate";
            var inventories = from i in db.Inventories
                              select i;
            if (!String.IsNullOrEmpty(searchDesc))
            {
                inventories = inventories.Where(i => i.ShortDescription.Contains(searchDesc));
            }
            switch (sortOrder)
            {
                //case "PartName":
                //    inventories = inventories.OrderByDescending(i => i.Part);
                //    break;
                case "DeliveryDate":
                    inventories = inventories.OrderBy(i => i.DeliveryDate);
                    break;
                //case "DeliveryDate_desc":
                //    inventories = inventories.OrderByDescending(i => i.DeliveryDate);
                //    break;
                default:
                    //inventories = inventories.OrderBy(i => i.Part);
                    inventories = inventories.OrderByDescending(i => i.DeliveryDate);
                    break;
            }
            return View(inventories.ToList());

            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            //Part inventory = db.Parts.Find(id);
            //if (inventory != null)
            //{
            //    //return HttpNotFound();
            //}
            //return View(inventory);
        }

        // GET: Inventories/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inventory inventory = db.Inventories.Find(id);
            if (inventory == null)
            {
                return HttpNotFound();
            }
            return View(inventory);
        }

        // GET: Inventories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Inventories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Part_PartId,InventoryId,ShortDescription,MaterialType,StoreLocation,UnitPrice,DeliveryStatus,DeliveryDate,OpenOrderQnty,QntyInTransit,DeliveryLocation,DeliveryQnty,UoM,UsedQnty,LastUsedDate,Stock,SafetyStock,RackNo,LineNo")] Inventory inventory)
        {
            if (ModelState.IsValid)
            {
                db.Inventories.Add(inventory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(inventory);
        }

        // GET: Inventories/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inventory inventory = db.Inventories.Find(id);
            if (inventory == null)
            {
                return HttpNotFound();
            }
            return View(inventory);
        }

        // POST: Inventories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "InventoryId,ShortDescription,MaterialType,StoreLocation,UnitPrice,DeliveryStatus,DeliveryDate,OpenOrderQnty,QntyInTransit,DeliveryLocation,DeliveryQnty,UoM,UsedQnty,LastUsedDate,Stock,SafetyStock,RackNo,LineNo")] Inventory inventory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(inventory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(inventory);
        }

        // GET: Inventories/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inventory inventory = db.Inventories.Find(id);
            if (inventory == null)
            {
                return HttpNotFound();
            }
            return View(inventory);
        }

        // POST: Inventories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Inventory inventory = db.Inventories.Find(id);
            db.Inventories.Remove(inventory);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
