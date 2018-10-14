using CustomerKeys.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CustomerKeys.Models;
using System.Net;

namespace CustomerKeys.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult Index()
        {
            List<Customer> Customers;
            using (var db = new MVCExampleEntities())
            {
                Customers = db.Customers.ToList();
            }
                return View(Customers);
        }
        public ActionResult Create()
        {
                return View();
        }
        [HttpPost]
        public ActionResult Create(Customer p)
        {
         using(var db = new MVCExampleEntities())
            {
                db.Customers.Add(p);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int? id)
        {
            Customer Customers;
            using (var db = new MVCExampleEntities())
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Customers = db.Customers.Find(id);
                if (Customers == null)
                {
                    return HttpNotFound();
                }
                return View(Customers);
            }
                
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Title,ReleaseDate,Genre,Price")] Customer Customers)
        {
            using (var db = new MVCExampleEntities())
            {
                if (ModelState.IsValid)
                {
                    db.Entry(Customers).State = System.Data.Entity.EntityState.Modified;
                    db.Entry(Customers).Property(uco => uco.Name).IsModified = false;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(Customers);

            }
        }
        public ActionResult Details(int? id)
        {
            Customer Customers;
            using (var db = new MVCExampleEntities())
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Customers = db.Customers.Find(id);
                if (Customers == null)
                {
                    return HttpNotFound();
                }
            }
            return View(Customers);
        }
        public ActionResult Delete(int? id)
        {
            Customer Customers;
            using (var db = new MVCExampleEntities())
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Customers = db.Customers.Find(id);
                if (Customers == null)
                {
                    return HttpNotFound();
                }
            }
            return View(Customers);
        }

        // POST: /Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            using (var db = new MVCExampleEntities())
            {
                Customer Customers = db.Customers.Find(id);
                db.Customers.Remove(Customers);
                db.SaveChanges();
            }
            return RedirectToAction("Index");

        }

    }
}