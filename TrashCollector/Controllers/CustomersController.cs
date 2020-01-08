using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrashCollector.Models;
using System.Data.Entity;


namespace TrashCollector.Controllers
{
    public class CustomersController : Controller
    {

       public  ApplicationDbContext db;
        public CustomersController()
        {
            db = new ApplicationDbContext();
        }

        // GET: Customers
        public ActionResult Index()
        {
            var listOfcustomers = db.Customers.ToList();
            return View(listOfcustomers);
        }

        // GET: Customers/Details/5
        public ActionResult Details(int id)
        {
            Customer customer = db.Customers.Where(c => c.CustomerId == id).SingleOrDefault();
            return View(customer);
        }

        // GET: Customers/Create
        public ActionResult Create()
        {
            Customer customer = new Customer();
            return View(customer);
           
        }

        // POST: Customers/Create
        [HttpPost]
        public ActionResult Create(Customer customer)
        {
            
            try
            {
                // TODO: Add insert logic here
                string currentUserId = User.Identity.GetUserId();
                customer.ApplicationId = currentUserId;
                db.Customers.Add(customer);
                db.SaveChanges();
                return RedirectToAction("Details", "Customers", new { id = customer.CustomerId});
            }
            catch(Exception)
            {
                return View();
            }
        }

        // GET: Customers/Edit/5
        public ActionResult Edit(int id)
        {
            Customer customer = db.Customers.Where(c => c.CustomerId == id).SingleOrDefault();
            if (customer.CustomerId == 0)
            {
                db.Customers.Add(customer);
            }
            return View(customer);
        }

        // POST: Customers/Edit/5
        [HttpPost]
        public ActionResult Edit(int id,Customer customer)
        {
            try
            {
                // TODO: Add update logic here
                Customer editCustomer = db.Customers.Find(id);
                editCustomer.FirstName = customer.FirstName;
                editCustomer.LastName = customer.LastName;
                editCustomer.StreetAddress = customer.StreetAddress;
                editCustomer.CityName = customer.CityName;
                editCustomer.StateName = customer.StateName;
                editCustomer.ZipCode = customer.ZipCode;
                editCustomer.OneTimePickupDate = customer.OneTimePickupDate;
                editCustomer.WeeklyPickupDay = customer.WeeklyPickupDay;
                editCustomer.SuspendPickupStart = customer.SuspendPickupStart;
                editCustomer.SuspendPickupStop = customer.SuspendPickupStop;
                db.SaveChanges();
                return RedirectToAction("Details", "Customers", new { id = editCustomer.CustomerId });
             
            }
            catch(Exception)
            {
                return View();
            }
        }

        // GET: Customers/Delete/5
        public ActionResult Delete(int id)
        {
            Customer customer = db.Customers.Where(c => c.CustomerId == id).SingleOrDefault();
            return View(customer);
        }
        // POST: Customers/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Customer customer)
        {
            try
            {
                // TODO: Add delete logic here
                db.Customers.Remove(db.Customers.Find(id)); ;
                db.SaveChanges();
                return RedirectToAction("Index");
               
            }
            catch(Exception)
            {
                return View();
            }
        }
    }
}
