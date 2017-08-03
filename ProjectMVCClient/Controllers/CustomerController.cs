using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectMVCClient.ServiceReference1;

namespace ProjectMVCClient.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        Service1Client sc = new Service1Client();
        List<tblCustomer> customers = new List<tblCustomer>();

        public ActionResult Index()
        {
            customers = sc.GetCustomer().ToList();
            return View(customers);
        }

        public ActionResult Edit()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Edit(int customerid, string customername, string address, int employeeid)
        {
            tblCustomer c1 = sc.EditCustomer(customerid, customername, address, employeeid);
            return RedirectToAction("Index");
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(tblCustomer c2, int customerid, string customername, string address, int employeeid)
        {
            c2 = sc.AddCustomer(customerid, customername, address, employeeid);
            return RedirectToAction("Index");
        }

        public ActionResult Delete()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            tblCustomer c2 = sc.DeleteCustomer(id);
            return View(c2);
        }
    }
}