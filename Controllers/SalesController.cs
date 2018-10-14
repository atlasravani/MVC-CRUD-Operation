using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CustomerKeys.Models;
using System.Net;

namespace CustomerKeys.Controllers
{
    public class SalesController : Controller
    {
        // GET: Sales
        public ActionResult Index()
        {
            List<CustomerSold> sales;
            using (var db = new MVCExampleEntities())
            {
                sales = db.CustomerSolds
                    .Include("Customer")
                    .Include("Customer")
                    .Include("Store")
                    .ToList();
            }
            return View(sales);
        }
       
    }
}