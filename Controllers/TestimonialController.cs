using PortfolioProjectNight.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PortfolioProjectNight.Controllers
{
    public class TestimonialController : Controller
    {
        DbMyPortfolioNightEntities Context = new DbMyPortfolioNightEntities();

        public ActionResult TestimonialList()
        {
            var values = Context.Testimonial.ToList();
            return View(values);


        }

        [HttpGet]

        public ActionResult Createtestimonial()
        {
            return View();
        }
        [HttpPost]

        public ActionResult Createtestimonial(Testimonial testimonial)
        {
            Context.Testimonial.Add(testimonial);
            Context.SaveChanges();
            return RedirectToAction("TestimonialList");
        }

        [HttpGet]
        public ActionResult Updatetestimonial(int id)
        {
            var value = Context.Testimonial.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult Updatetestimonial(Testimonial testimonial)
        {
            var value = Context.Testimonial.Find(testimonial.TestiMonialID);
            value.NameSurname = testimonial.NameSurname;
            value.Title = testimonial.Title;
            value.Description = testimonial.Description;
            value.Photo = testimonial.Photo;
            value.Photo2 = testimonial.Photo2;
            Context.SaveChanges();
            return RedirectToAction("testimonialList");
        }

        public ActionResult Deletetestimonial(int id)
        {
            var value = Context.Testimonial.Find(id);
            Context.Testimonial.Remove(value);
            Context.SaveChanges();
            return RedirectToAction("TestimonialList");
        }
    }
}