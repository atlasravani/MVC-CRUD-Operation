using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CustomerKeys.Models;
using System.Net;

namespace CustomerKeys.Controllers
{
    public class StoreController : Controller
    {
        // GET: Store
        public ActionResult Index()
        {
            List<Store> stores;
            using (var db = new MVCExampleEntities())
            {
                stores = db.Stores.ToList();
            }
            return View(stores);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Store s)
        {
            using (var db = new MVCExampleEntities())
            {
                db.Stores.Add(s);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int? id)
        {
            Store stores;
            using (var db = new MVCExampleEntities())
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                stores = db.Stores.Find(id);
                if (stores == null)
                {
                    return HttpNotFound();
                }
                return View(stores);
            }

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Title,ReleaseDate,Genre,Price")] Store stores)
        {
            using (var db = new MVCExampleEntities())
            {
                if (ModelState.IsValid)
                {
                    db.Entry(stores).State = System.Data.Entity.EntityState.Modified;
                    db.Entry(stores).Property(uco => uco.Name).IsModified = false;
                    
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(stores);

            }
        }
        public ActionResult Details(int? id)
        {
            Store stores;
            using (var db = new MVCExampleEntities())
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                stores = db.Stores.Find(id);
                if (stores == null)
                {
                    return HttpNotFound();
                }
            }
            return View(stores);
        }
        public ActionResult Delete(int? id)
        {
            Store stores;
            using (var db = new MVCExampleEntities())
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                stores= db.Stores.Find(id);
                if (stores == null)
                {
                    return HttpNotFound();
                }
            }
            return View(stores);
        }

        // POST: /Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            using (var db = new MVCExampleEntities())
            {
                Store stores = db.Stores.Find(id);
                db.Stores.Remove(stores);
                db.SaveChanges();
            }
            return RedirectToAction("Index");

        }
    }
}