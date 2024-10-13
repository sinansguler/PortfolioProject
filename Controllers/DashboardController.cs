using PortfolioProjectNight.Models;
using System.Linq;
using System.Web.Mvc;

namespace PortfolioProjectNight.Controllers
{
    public class DashboardController : Controller
    {
        DbMyPortfolioNightEntities context = new DbMyPortfolioNightEntities();

        // Action to render the Dashboard view
        public ActionResult Dashboard()
        {
            // Fetch data and set it to ViewBag before rendering the view
            ViewBag.ChartData = context.Skill.Select(s => s.SkillName).ToList();
            ViewBag.Labels = context.Skill.Select(r => r.Rate).ToList();
            return View();
        }
    }
}
