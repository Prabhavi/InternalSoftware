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
using static TrackerModuleV1._0.Models.PTM.EnumClass;

namespace TrackerModuleV1._0.Controllers
{
    public class PartsController : Controller
    {
        private PTMContex db = new PTMContex();

        // GET: Parts
        public ActionResult Index()
        {
            var parts = db.Parts.Include(p => p.CreatedBy);
            return View(parts.ToList());
        }

        // GET: Parts/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Part part = db.Parts.Find(id);
            Part part = db.Parts
             .Include(i => i.ApproveBy)
             .Include(i => i.CreatedBy)
             .Include(i => i.Suppliers)
             .SingleOrDefault(x => x.PartId == id);
            if (part == null)
            {
                return HttpNotFound();
            }
            ViewBag.FilePath = part.FilePath;
            return View(part);
        }

        // GET: Parts/Create
        public ActionResult Create()
        {
            var partTypeList = Enum.GetValues(typeof(PartType))
                .Cast<PartType>()
                .Select(t => new AccessClass
                {
                    ID = ((int)t),
                    Name = t.ToString()
                });
            ViewBag.ListData = partTypeList;

            var status = Enum.GetValues(typeof(Status));
            ViewBag.Status = status;

            ViewBag.CreatedUserId = new SelectList(db.Users, "UserId", "FirstName");
            return View();
        }

        // POST: Parts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PartId,PartName,PartDescription,FileName,FilePath,Status,CreatedUserId")] Part part, HttpPostedFileBase fileupload)
        {
            string filename = string.Empty;
            string filepath = string.Empty;



            if (fileupload != null)
            {
                filename = fileupload.FileName;
                filepath = Server.MapPath("~/Content/AttachmentsPart/");
                fileupload.SaveAs(filepath + filename);
                part.FileName = filename;
                part.FilePath = "~/Content/AttachmentsPart/" + filename;
            }
            if (ModelState.IsValid)
            {
                db.Parts.Add(part);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CreatedUserId = new SelectList(db.Users, "UserId", "FirstName", part.CreatedUserId);
            return View(part);
        }

        // GET: Parts/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Part part = db.Parts.Find(id);
            if (part == null)
            {
                return HttpNotFound();
            }
            ViewBag.CreatedUserId = new SelectList(db.Users, "UserId", "FirstName", part.CreatedUserId);
            return View(part);
        }

        // POST: Parts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PartId,PartName,PartDescription,NovenaTecPartNumber,SwissRanksPartNumber,OEMPartNumber,VendorPartNumber,StockQuantity,Status,CreatedUserId,ApprovedUserId")] Part part)
        {
            if (ModelState.IsValid)
            {
                db.Entry(part).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CreatedUserId = new SelectList(db.Users, "UserId", "FirstName", part.CreatedUserId);
            return View(part);
        }

        // GET: Parts/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Part part = db.Parts.Find(id);
            if (part == null)
            {
                return HttpNotFound();
            }
            return View(part);
        }

        // POST: Parts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Part part = db.Parts.Find(id);
            db.Parts.Remove(part);
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


        public ActionResult getSubcategory(int partType)
        {
            switch (partType)
            {
                case 1:
                    var SubCategoryList1 = Enum.GetValues(typeof(Document))
                .Cast<Document>()
                .Select(t => new AccessClass
                {
                    ID = ((int)t),
                    Name = t.ToString()
                });
                    ViewBag.SubCategoryList = SubCategoryList1;
                    break;

                case 2:
                    var SubCategoryList2 = Enum.GetValues(typeof(Record))
                .Cast<Record>()
                .Select(t => new AccessClass
                {
                    ID = ((int)t),
                    Name = t.ToString()
                });
                    ViewBag.SubCategoryList = SubCategoryList2;
                    break;
                case 3:
                    var SubCategoryList3 = Enum.GetValues(typeof(Mechanical_Part))
                .Cast<Mechanical_Part>()
                .Select(t => new AccessClass
                {
                    ID = ((int)t),
                    Name = t.ToString()
                });
                    ViewBag.SubCategoryList = SubCategoryList3;
                    break;

            }
            //if(partType== 1)
            //{
            //    var SubCategoryList = Enum.GetValues(typeof(Document))
            //    .Cast<Document>()
            //    .Select(t => new AccessClass
            //    {
            //        ID = ((int)t),
            //        Name = t.ToString()
            //    });
            //    ViewBag.SubCategoryList = SubCategoryList;
            //    //return PartialView("DisplaySubcategory");
            //}
            return PartialView("DisplaySubcategory");
        }


    }
}
