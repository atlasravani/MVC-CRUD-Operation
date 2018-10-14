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
            List<Customer> customers;
            using (var db = new MVCExampleEntities())
            {
                customers = db.Customers.ToList();
            }
            return View(customers);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Customer c)
        {
            using (var db = new MVCExampleEntities())
            {
                db.Customers.Add(c);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int? id)
        {
            Customer cuatomers;
            using (var db = new MVCExampleEntities())
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                cuatomers = db.Customers.Find(id);
                if (cuatomers == null)
                {
                    return HttpNotFound();
                }
                return View(cuatomers);
            }

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Title,ReleaseDate,Genre,Price")] Customer customers)
        {
            using (var db = new MVCExampleEntities())
            {
                if (ModelState.IsValid)
                {
                    db.Entry(customers).State = System.Data.Entity.EntityState.Modified;
                    db.Entry(customers).Property(uco => uco.Name).IsModified = false;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(customers);

            }
        }
        public ActionResult Details(int? id)
        {
            Customer customers;
            using (var db = new MVCExampleEntities())
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                customers = db.Customers.Find(id);
                if (customers == null)
                {
                    return HttpNotFound();
                }
            }
            return View(customers);
        }
        public ActionResult Delete(int? id)
        {
            Customer customers;
            using (var db = new MVCExampleEntities())
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                customers = db.Customers.Find(id);
                if (customers == null)
                {
                    return HttpNotFound();
                }
            }
            return View(customers);
        }

        // POST: /Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            using (var db = new MVCExampleEntities())
            {
                Customer customers = db.Customers.Find(id);
                db.Customers.Remove(customers);
                db.SaveChanges();
            }
            return RedirectToAction("Index");

        }
    }
}