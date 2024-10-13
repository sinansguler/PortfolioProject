using PortfolioProjectNight.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PortfolioProjectNight.Controllers
{
    public class CvDownloadController : Controller
    {
        DbMyPortfolioNightEntities context = new DbMyPortfolioNightEntities();

        public ActionResult Index()
        {
            var cvPath = context.About.Select(y => y.Cv).FirstOrDefault();
            ViewBag.CvDownload = cvPath;



            return View();
        }
    }
}