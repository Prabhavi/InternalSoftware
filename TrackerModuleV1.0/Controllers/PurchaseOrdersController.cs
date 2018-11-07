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
    public class PurchaseOrdersController : Controller
    {
        private PTMContex db = new PTMContex();

        // GET: PurchaseOrders
        public ActionResult Index()
        {
            var purchaseOrders = db.PurchaseOrders.Include(p => p.OrderBy).Include(p => p.Part).Include(p => p.Project).Include(p => p.Supplier);
            return View(purchaseOrders.ToList());
        }

        // GET: PurchaseOrders/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PurchaseOrder purchaseOrder = db.PurchaseOrders.Find(id);
            if (purchaseOrder == null)
            {
                return HttpNotFound();
            }
            return View(purchaseOrder);
        }

        // GET: PurchaseOrders/Create
        public ActionResult Create()
        {
            ViewBag.OrderById = new SelectList(db.Users, "UserId", "FirstName");
            ViewBag.PartNumber = new SelectList(db.Parts, "PartId", "PartId");
            ViewBag.ProjectNumber = new SelectList(db.Projects, "ProjectId", "ProjectId");
            ViewBag.SupplierId = new SelectList(db.Suppliers, "SupplierId", "SupplierName");
            return View();
        }

        // POST: PurchaseOrders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PurchaseOrderID,ProjectNumber,PartNumber,UOM,Currency,UnitPrice,OpenOrderQuantity,ApproveStatus,ApproveUserId,OrderDate,DeliverDate,DeliveryLocation,DeliveredQuantity,QuantityInTransit,SupplierId,OrderById")] PurchaseOrder purchaseOrder)
        {
            if (ModelState.IsValid)
            {
                db.PurchaseOrders.Add(purchaseOrder);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.OrderById = new SelectList(db.Users, "UserId", "FirstName", purchaseOrder.OrderById);
            ViewBag.PartNumber = new SelectList(db.Parts, "PartId", "PartName", purchaseOrder.PartNumber);
            ViewBag.ProjectNumber = new SelectList(db.Projects, "ProjectId", "ProjectName", purchaseOrder.ProjectNumber);
            ViewBag.SupplierId = new SelectList(db.Suppliers, "SupplierId", "SupplierName", purchaseOrder.SupplierId);
            return View(purchaseOrder);
        }

        // GET: PurchaseOrders/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PurchaseOrder purchaseOrder = db.PurchaseOrders.Find(id);
            if (purchaseOrder == null)
            {
                return HttpNotFound();
            }
            ViewBag.OrderById = new SelectList(db.Users, "UserId", "FirstName", purchaseOrder.OrderById);
            ViewBag.PartNumber = new SelectList(db.Parts, "PartId", "PartName", purchaseOrder.PartNumber);
            ViewBag.ProjectNumber = new SelectList(db.Projects, "ProjectId", "ProjectName", purchaseOrder.ProjectNumber);
            ViewBag.SupplierId = new SelectList(db.Suppliers, "SupplierId", "SupplierName", purchaseOrder.SupplierId);
            return View(purchaseOrder);
        }

        // POST: PurchaseOrders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PurchaseOrderID,ProjectNumber,PartNumber,UOM,Currency,UnitPrice,OpenOrderQuantity,ApproveStatus,ApproveUserId,OrderDate,DeliverDate,DeliveryLocation,DeliveredQuantity,QuantityInTransit,SupplierId,OrderById")] PurchaseOrder purchaseOrder)
        {
            if (ModelState.IsValid)
            {
                db.Entry(purchaseOrder).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.OrderById = new SelectList(db.Users, "UserId", "FirstName", purchaseOrder.OrderById);
            ViewBag.PartNumber = new SelectList(db.Parts, "PartId", "PartName", purchaseOrder.PartNumber);
            ViewBag.ProjectNumber = new SelectList(db.Projects, "ProjectId", "ProjectName", purchaseOrder.ProjectNumber);
            ViewBag.SupplierId = new SelectList(db.Suppliers, "SupplierId", "SupplierName", purchaseOrder.SupplierId);
            return View(purchaseOrder);
        }

        // GET: PurchaseOrders/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PurchaseOrder purchaseOrder = db.PurchaseOrders.Find(id);
            if (purchaseOrder == null)
            {
                return HttpNotFound();
            }
            return View(purchaseOrder);
        }

        // POST: PurchaseOrders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            PurchaseOrder purchaseOrder = db.PurchaseOrders.Find(id);
            db.PurchaseOrders.Remove(purchaseOrder);
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
