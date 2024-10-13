using PortfolioProjectNight.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PortfolioProjectNight.Controllers
{
    public class InternController : Controller
    {
        DbMyPortfolioNightEntities Context = new DbMyPortfolioNightEntities();

        public ActionResult InternList()
        {
            var values = Context.Intern.ToList();
            return View(values);

           
        }

        [HttpGet]

        public ActionResult CreateIntern()
        {
            return View();
        }

        [HttpPost]

        public ActionResult CreateIntern(Intern intern)
        {  
            Context.Intern.Add(intern);
            Context.SaveChanges();
            return RedirectToAction("InternList");
        }

        [HttpGet]
        public ActionResult UpdateIntern(int id)
        {
            var value = Context.Intern.Find(id);
            return View(value);

        }

        [HttpPost]
        public ActionResult UpdateIntern(Intern intern)
        {
            var value = Context.Intern.Find(intern.InternId);
            value.InternYear = intern.InternYear;
            value.InternCompany = intern.InternCompany;
            value.InternWhatyoudid = intern.InternWhatyoudid;
            Context.SaveChanges();
            return RedirectToAction("InternList");
        }

        public ActionResult DeleteIntern(int id)
        {
            var value = Context.Intern.Find(id);
            Context.Intern.Remove(value);
            Context.SaveChanges();
            return RedirectToAction("InternList");
        }
    }
}