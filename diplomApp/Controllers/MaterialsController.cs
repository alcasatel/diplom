using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using diplomApp.Models;

namespace diplomApp.Controllers
{
    public class MaterialsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Materials
        public ActionResult Index(int? typeId)
        {
            IEnumerable<Material> materials;
            if (typeId == null)
            {
                ViewBag.MaterialTitle = "Все материалы";
                materials = db.Materials.Include(m => m.MaterialType);
            }
            else
            {
                materials = (from m in db.Materials orderby m.CreationDate where m.MaterialTypeId == typeId select m);
                switch (typeId)
                {
                    case 1: ViewBag.MaterialTitle = "Новости";break;
                    case 2: ViewBag.MaterialTitle = "Статьи"; break;
                    case 3: ViewBag.MaterialTitle = "Учебные материалы"; break;
                    case 4: ViewBag.MaterialTitle = "Контроль"; break;
                }
            }
            
            return View(materials.ToList());
        }

        // GET: Materials/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Material material = db.Materials.Find(id);
            if (material == null)
            {
                return HttpNotFound();
            }
            return View(material);
        }

        // GET: Materials/Create
        public ActionResult Create()
        {
            ViewBag.MaterialTypeId = new SelectList(db.MaterialTypes, "Id", "Name");
            return View();
        }

        // POST: Materials/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Category,Name,Annotation,CreationDate,PathToPageContent,Image,MaterialTypeId,Tags")] Material material)
        {
            if (ModelState.IsValid)
            {
                db.Materials.Add(material);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaterialTypeId = new SelectList(db.MaterialTypes, "Id", "Name", material.MaterialTypeId);
            return View(material);
        }

        // GET: Materials/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Material material = db.Materials.Find(id);
            if (material == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaterialTypeId = new SelectList(db.MaterialTypes, "Id", "Name", material.MaterialTypeId);
            return View(material);
        }

        // POST: Materials/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Annotation,CreationDate,PathToPageContent,Image,MaterialTypeId,Tags")] Material material)
        {
            if (ModelState.IsValid)
            {
                db.Entry(material).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaterialTypeId = new SelectList(db.MaterialTypes, "Id", "Name", material.MaterialTypeId);
            return View(material);
        }

        // GET: Materials/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Material material = db.Materials.Find(id);
            if (material == null)
            {
                return HttpNotFound();
            }
            return View(material);
        }

        // POST: Materials/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Material material = db.Materials.Find(id);
            db.Materials.Remove(material);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult _newsBlock()
        {
            var materials = (from m in db.Materials orderby m.CreationDate where m.MaterialTypeId == 1 select m).Take(5);

            return PartialView(materials);
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
