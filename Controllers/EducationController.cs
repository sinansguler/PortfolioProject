using PortfolioProjectNight.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PortfolioProjectNight.Controllers
{
    public class EducationController : Controller
    {
        DbMyPortfolioNightEntities context = new DbMyPortfolioNightEntities();
        // GET: Education
        public ActionResult EducationList()
        {
            var value = context.Education.ToList();
            return View(value);
        }

        [HttpGet]
        public ActionResult CreateEducation()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateEducation(Education education)
        {
            context.Education.Add(education);
            context.SaveChanges();
            return RedirectToAction("EducationList");
        }

        [HttpGet]
        public ActionResult DeleteEducation(int id)
        {
            var value = context.Education.Find(id);
            context.Education.Remove(value);
            context.SaveChanges();
            return RedirectToAction("EducationList");

        }

        [HttpGet]
        public ActionResult UpdateEducation(int id)
        {
            var value = context.Education.Find(id);
            return View(value);

        }

        [HttpPost]

        public ActionResult UpdateEducation(Education education)
        {
            var value = context.Education.Find(education.EducationId);
            value.Title = education.Title;
            value.SubTitle = education.SubTitle;
            value.Description = education.Description;
            context.SaveChanges();
            return RedirectToAction("EducationList");
            

        }



    }
}