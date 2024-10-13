using PortfolioProjectNight.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PortfolioProjectNight.Controllers
{
    public class AboutController : Controller
    {
        DbMyPortfolioNightEntities context = new DbMyPortfolioNightEntities();

        public ActionResult AboutList()
        {
            var values = context.About.ToList();
            return View(values);


        }

        [HttpGet]

        public ActionResult CreateAbout()
        {
            return View();
        }

        [HttpPost]

        public ActionResult CreateAbout(About about)
        {
            context.About.Add(about);
            context.SaveChanges();
            return RedirectToAction("AboutList");
        }

        [HttpGet]
        public ActionResult UpdateAbout(int id)
        {
            var value = context.About.Find(id);
            return View(value);

        }

        [HttpPost]
        public ActionResult UpdateAbout(About about)
        {
            var value = context.About.Find(about.AboutId);
            value.Title = about.Title;
            value.Description = about.Description;
            value.ImageUrl = about.ImageUrl;
            context.SaveChanges();
            return RedirectToAction("AboutList");
        }

        public ActionResult DeleteAbout(int id)
        {
            var value = context.About.Find(id);
            context.About.Remove(value);
            context.SaveChanges();
            return RedirectToAction("AboutList");
        }

        public ActionResult SocialMediaIcon()
        {

            var values = context.SocialMedia.ToList();
            return View(values);
        }

    }
}