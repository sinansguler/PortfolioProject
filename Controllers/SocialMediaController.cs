using PortfolioProjectNight.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace PortfolioProjectNight.Controllers
{

    public class SocialMediaController : Controller
    {

        DbMyPortfolioNightEntities Context = new DbMyPortfolioNightEntities();

        public ActionResult SocialMediaList()
        {

            var values = Context.SocialMedia.ToList();
            return View(values);
        }

        [HttpGet]

        public ActionResult CreateSocialMedia()
        {
            return View();
        }

        [HttpPost]

        public ActionResult CreateSocialMedia(SocialMedia socialmedia)
        {
            Context.SocialMedia.Add(socialmedia);
            ViewBag.SocialUrl = socialmedia.Url;
            ViewBag.SocialIcon = socialmedia.Icon;
            Context.SaveChanges();
            return RedirectToAction("SocialMediaList");

        }

        [HttpGet]

        public ActionResult UpdateSocialMedia(int id)
        {
            var value = Context.SocialMedia.Find(id);
            return View(value);

        }

        [HttpPost]

        public ActionResult UpdateSocialMedia(SocialMedia socialmedia)
        {
            var value = Context.SocialMedia.Find(socialmedia.SocialMediaId);
            value.Title = socialmedia.Title;
            value.Url = socialmedia.Url;
            value.Icon = socialmedia.Icon;
            Context.SaveChanges();
            return RedirectToAction("SocialMediaList");
        }

        public ActionResult DeleteSocialMedia(int id)
        {
            var value = Context.SocialMedia.Find(id);
            Context.SocialMedia.Remove(value);
            Context.SaveChanges();
            return RedirectToAction("SocialMediaList");
        }

    }
}