using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrashCollector.Models;

namespace TrashCollector.Controllers
{
    public class EmployeesController : Controller
    {
        ApplicationDbContext db;
        // GET: Employees

        public EmployeesController()
        {
            db = new ApplicationDbContext();
        }
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            var employee = db.Employees.Where(e => e.ApplicationId == userId).FirstOrDefault();
            var customersInMyArea = db.Customers.Where(c => c.ZipCode == employee.ZipCode && c.WeeklyPickupDay == DateTime.Today.DayOfWeek.ToString()).ToList();
            return View(customersInMyArea);
        }


        // GET: Employees/Details/5
        public ActionResult Details(int id)
        {
            Employee employee = db.Employees.Where(e => e.EmployeeId == id).SingleOrDefault();
            return View(employee);
        }

        // GET: Employees/Create
        public ActionResult Create()
        {
            Employee employee = new Employee();
            return View(employee);
        }

        // POST: Employees/Create
        [HttpPost]
        public ActionResult Create(Employee employee)
        {
            try
            {
                // TODO: Add insert logic here
                string currentUserId = User.Identity.GetUserId();
                employee.ApplicationId = currentUserId;
                db.Employees.Add(employee);
                db.SaveChanges();
                return RedirectToAction("Details", "Employees", new { id = employee.EmployeeId });

            }
            catch
            {
                return View();
            }
        }

        // GET: Employees/Edit/5
        public ActionResult Edit(int id)
        {
            Employee employee = db.Employees.Where(e => e.EmployeeId == id).SingleOrDefault();
            return View(employee);
        }

        // POST: Employees/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Employee employee)
        {
            try
            {
                // TODO: Add update logic here
                Employee editEmployee = db.Employees.Find(id);
                editEmployee.FirstName = employee.FirstName;
                editEmployee.LastName = employee.LastName;
                editEmployee.ZipCode = employee.ZipCode;
                db.SaveChanges();
                return RedirectToAction("Details", "Employees", new { id = editEmployee.EmployeeId });

            }
            catch
            {
                return View();
            }
        }
        // GET: Customer/Update Status
        public ActionResult UpdatePickupStatus(int id)
        {
            Customer customer = db.Customers.Where(c => c.CustomerId == id).FirstOrDefault();
            return View(customer);
        }
        // POST: Customer/Update Status
        [HttpPost]
        public ActionResult UpdatePickupStatus(Customer customer, int id)
        {
            var editCustomer = db.Customers.Where(c=>c.CustomerId==id).SingleOrDefault();
            if (editCustomer.PickupCompleted == true)
            {
                
                editCustomer.Balance += 50;
                editCustomer.PickupCompleted = false;
                db.SaveChanges();
                return RedirectToAction("Index", "Employees");
                
            }
            else
            {
                editCustomer.PickupCompleted = true;
                db.SaveChanges();
                return RedirectToAction("Index","Employees");
            }
            
        }
        
        // GET: Employees/Delete/5
        public ActionResult Delete(int id)
        {
            Employee employee = db.Employees.Where(e => e.EmployeeId == id).SingleOrDefault();
            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Employee employee)
        {
            try
            {
                // TODO: Add delete logic here
                db.Employees.Remove(db.Employees.Find(id));
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
