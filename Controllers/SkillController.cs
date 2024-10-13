using PortfolioProjectNight.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;


namespace PortfolioProjectNight.Controllers
{
    public class SkillController : Controller
    {
        

        DbMyPortfolioNightEntities context  = new DbMyPortfolioNightEntities();
        public ActionResult SkillList(int? page)
        {
            // Varsayılan olarak 1. sayfayı göster
            int pageNumber = page ?? 1;

            // Sayfa başına 5 eleman gösterelim
            int pageSize = 5;

            // Normal List<Skill> alalım
            var values = context.Skill.ToList();

            // List<Skill>'i IPagedList<Skill>'e dönüştürelim
            var pagedValues = values.ToPagedList(pageNumber, pageSize);

            return View(pagedValues);
        }

        [HttpGet]
        public ActionResult CreateSkill()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateSkill(Skill skill) 
        {
            ModelState.AddModelError("SkillName", "Beceri adı boş olamaz."); // Hata mesajı ekleme

            if (ModelState.IsValid)
            {
                context.Skill.Add(skill);
                context.SaveChanges();
            }
            return RedirectToAction("SkillList");
        }

        public ActionResult DeleteSkill(int id)
        {
            var value=context.Skill.Find(id);
            context.Skill.Remove(value);
            context.SaveChanges();
            return RedirectToAction("SkillList");

        }

        [HttpGet]
        public ActionResult UpdateSkill(int id)
        {
            var value = context.Skill.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateSkill(Skill skill)
        {

            var value = context.Skill.Find(skill.SkillId);
            value.SkillName = skill.SkillName;
            value.Rate = skill.Rate;
            value.Icon = skill.Icon;
            value.Status = skill.Status;
            context.SaveChanges();
            return RedirectToAction("SkillList");
        }

        public ActionResult SkillListById(int page = 1)
        {
            var values = context.Skill.ToList().ToPagedList(page, 5);
            return View(values);


        }

        public ActionResult ChangeMessageStatusToTrue(int id)
        {
            var value = context.Skill.Find(id);
            value.Status = true;
            context.SaveChanges();
            return RedirectToAction("SkillList");
        }

        public ActionResult ChangeMessageStatusToFalse(int id)
        {
            var value = context.Skill.Find(id);
            value.Status = false;
            context.SaveChanges();
            return RedirectToAction("SkillList");
        }



    }
}