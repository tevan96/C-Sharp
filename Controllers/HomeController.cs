using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GussmannTechnologyWebsite.Models;

using System.Web.Mvc;
using System.IO;

namespace GussmannTechnologyWebsite.Controllers
{
    public class HomeController : Controller
    {
        GussmannPhilippinesDBEntities db = new GussmannPhilippinesDBEntities();
        public ActionResult Index()
        {
            var image = db.HomeTbls.ToList();

            ViewBag.Image = image;

            return View();
        }


    


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}