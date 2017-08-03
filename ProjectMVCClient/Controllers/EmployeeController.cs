using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectMVCClient.ServiceReference1;

namespace ProjectMVCClient.Controllers
{
    public class EmployeeController : Controller
    {
        string msg = string.Empty;
        Service1Client sc = new Service1Client();
        List<tblEmployee> employees = new List<tblEmployee>();

        // GET: Employee
        public ActionResult Index()
        {
            employees = sc.GetEmployee().ToList();
            return View(employees);
        }

        public ActionResult Edit()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Edit(int empno, string ename, int mgr)
        {
            tblEmployee e = sc.EditEmployee(empno, ename, mgr);
            return RedirectToAction("Index");
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(tblEmployee e1, int empno, string ename, int mgr)
        {
            e1 = sc.AddEmployee(empno, ename, mgr);
            employees.Add(e1);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int empno)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Delete(int empno, tblEmployee e1)
        {
            try
            {
                e1 = sc.DeleteEmployee(empno);
            }

            catch(Exception ex)
            {
                Response.Write("Exception! " + ex.Message);
            }

            return View(e1);
        }
    }
}