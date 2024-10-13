using PortfolioProjectNight.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PortfolioProjectNight.Controllers
{
    public class WorksController : Controller
    {
        DbMyPortfolioNightEntities context = new DbMyPortfolioNightEntities();

        public ActionResult WorksList()
        {
            var values = context.Works.ToList();
            return View(values);


        }
        [HttpGet]
        public ActionResult CreateWorks()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateWorks(Works works)
        {
            context.Works.Add(works);
            context.SaveChanges();
            return RedirectToAction("Workslist");
        }

        public ActionResult DeleteWorks(int id)
        {
            var value = context.Works.Find(id);
            context.Works.Remove(value);
            context.SaveChanges();
            return RedirectToAction("Workslist");

        }

        [HttpGet]
        public ActionResult UpdateWorks(int id)
        {
            var value = context.Works.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateWorks(Works works)
        {
            var value = context.Works.Find(works.WorksID);
            value.unvan = works.unvan;
            value.description = works.description;
            value.photo = works.photo;
            context.SaveChanges();
            return RedirectToAction("Workslist");
        }
    }
}