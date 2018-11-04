using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GussmannTechnologyWebsite.Models;

using System.Web.Mvc;
using System.IO;

namespace GussmannTechnologyWebsite.Controllers
{
    public class AdminController : Controller
    {
        GussmannPhilippinesDBEntities db = new GussmannPhilippinesDBEntities();
        // GET: Admin
        public ActionResult AdminIndex()
        {
            var image = db.HomeTbls.ToList();

            ViewBag.Image = image;

            return View();
        }

        public ActionResult AddImageHome()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddImageHome(HomeTbl hmtbl)
        {
            string filename = Path.GetFileNameWithoutExtension(hmtbl.ImageFile.FileName);
            string extension = Path.GetExtension(hmtbl.ImageFile.FileName);
            filename = DateTime.Now.ToString("yymmssfff") + extension;
            hmtbl.ImagePath = "~/Images/Home/" + filename;
            filename = Path.Combine(Server.MapPath("~/Images/Home/"), filename);
            hmtbl.ImageFile.SaveAs(filename);

            db.HomeTbls.Add(hmtbl);
            db.SaveChanges();
            return RedirectToAction("AdminIndex");

        }

        public ActionResult DeleteImageHome(int id)
        {
            var HMID = db.HomeTbls.Find(id);
            string fullPath = Request.MapPath(HMID.ImagePath);
            if (System.IO.File.Exists(fullPath))
            {
                System.IO.File.Delete(fullPath);
            }
            db.HomeTbls.Remove(HMID);
            db.SaveChanges();


            return RedirectToAction("AdminIndex");
        }
    }
}
