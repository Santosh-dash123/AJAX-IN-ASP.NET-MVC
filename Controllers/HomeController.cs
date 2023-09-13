using PRACTICE_OF_AJAX.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PRACTICE_OF_AJAX.Controllers
{
    public class HomeController : Controller
    {
        AJAXEMPDBEntities db = new AJAXEMPDBEntities();

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(EMPLOYEE emp)
        {
            if(ModelState.IsValid)
            {
                db.EMPLOYEEs.Add(emp);
                db.SaveChanges();
                //return Json("Data inserted successfully!");
                return JavaScript("alert('Data inserted successfully!');");
            }
            else
            {
                return View(emp);
            }
        }

        [HttpGet]
        public ActionResult About()
        {
            ViewBag.Message = "All employee list page.";

            return View(db.EMPLOYEEs.ToList());
        }

        [HttpPost]
        public ActionResult About(string name)
        {
            if(String.IsNullOrEmpty(name) == false)
            {
                var data = db.EMPLOYEEs.Where(model => model.NAME == name).ToList();
                return PartialView("_Employees", data);
            }
            else
            {
                return PartialView("_Employees",db.EMPLOYEEs.ToList());
            }
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}