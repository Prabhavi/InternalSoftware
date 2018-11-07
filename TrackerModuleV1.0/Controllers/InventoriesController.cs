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
        public ActionResult Index()
        {
            var inventories = db.Inventories.Include(i => i.LastUser).Include(i => i.Part).Include(i => i.Supplier);
            return View(inventories.ToList());
        }

        // GET: Inventories/Details/5
        public ActionResult Details(string id1, string id2)
        {
            if (id1 == null || id2 == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Inventory inventory = db.Inventories.Find(id1,id2);

            Inventory inventory = db.Inventories
              .Include(i => i.LastUser)
              .Include(i => i.Part)
              .Include(i => i.Supplier)
              .SingleOrDefault(x => x.PartId == id1 && x.SupplierId == id2);

            if (inventory == null)
            {
                return HttpNotFound();
            }
            
            return View(inventory);
        }

        // GET: Inventories/Create
        public ActionResult Create()
        {
            ViewBag.LastUserId = new SelectList(db.Users, "UserId", "FirstName");
            ViewBag.PartId = new SelectList(db.Parts, "PartId", "PartId");
            ViewBag.SupplierId = new SelectList(db.Suppliers, "SupplierId", "SupplierName");
            return View();
        }

        // POST: Inventories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PartId,SupplierId,UoM,UsedQnty,InStock,SafetyStock,RackNo,LineNo,StoreLocation,LastUsedDate,LastUserId")] Inventory inventory)
        {
            if (ModelState.IsValid)
            {
                
                //var inventoryx = db.Inventories.SingleOrDefault(p => p.PartId == PartId);
                var part = db.Parts.SingleOrDefault(p => p.PartId == inventory.PartId);
                if (part != null)
                {

                    inventory.Part.Equals(part);
                }
                db.Inventories.Add(inventory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            
            ViewBag.LastUserId = new SelectList(db.Users, "UserId", "FirstName", inventory.LastUserId);
            ViewBag.PartId = new SelectList(db.Parts, "PartId", "PartName", inventory.PartId);
            ViewBag.SupplierId = new SelectList(db.Suppliers, "SupplierId", "SupplierName", inventory.SupplierId);
            return View(inventory);
        }

        // GET: Inventories/Edit/5
        public ActionResult Edit(string id1,string id2)
        {
            if (id1 == null || id2 == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            
            //db.Inventories.Find()
            Inventory inventory = db.Inventories.Find(id1,id2);
            if (inventory == null)
            {
                return HttpNotFound();
            }
            ViewBag.LastUserId = new SelectList(db.Users, "UserId", "FirstName", inventory.LastUserId);
            ViewBag.PartId = new SelectList(db.Parts, "PartId", "PartName", inventory.PartId);
            ViewBag.SupplierId = new SelectList(db.Suppliers, "SupplierId", "SupplierName", inventory.SupplierId);
            return View(inventory);
        }

        // POST: Inventories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PartId,SupplierId,UoM,UsedQnty,InStock,SafetyStock,RackNo,LineNo,StoreLocation,LastUsedDate,LastUserId")] Inventory inventory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(inventory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.LastUserId = new SelectList(db.Users, "UserId", "FirstName", inventory.LastUserId);
            ViewBag.PartId = new SelectList(db.Parts, "PartId", "PartName", inventory.PartId);
            ViewBag.SupplierId = new SelectList(db.Suppliers, "SupplierId", "SupplierName", inventory.SupplierId);
            return View(inventory);
        }

        // GET: Inventories/Delete/5
        public ActionResult Delete(string id1, string id2)
        {
            if (id1 == null || id2 == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inventory inventory = db.Inventories.Find(id1,id2);
            if (inventory == null)
            {
                return HttpNotFound();
            }
            return View(inventory);
        }

        // POST: Inventories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id1, string id2)
        {
            Inventory inventory = db.Inventories.Find(id1,id2);
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
