using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AcunmedyaAkademiPortfolio.Models;

namespace AcunmedyaAkademiPortfolio.Controllers
{
    public class ExperienceController : Controller
    {
        DbAcunmedyaAkademi1Entities db = new DbAcunmedyaAkademi1Entities();
        public ActionResult ExperienceList()
        {
            var values = db.TblExperience.ToList();
            return View(values);
        }

        [HttpGet]

        public ActionResult CreateExperience()
        {
            return View();

        }

        [HttpPost]
        public ActionResult CreateExperience(TblExperience experience)
        {
            db.TblExperience.Add(experience);
            db.SaveChanges();
            return RedirectToAction("ExperienceList");
        }

        public ActionResult DeleteExperience(int id)
        {
            var value = db.TblExperience.Find(id);
            db.TblExperience.Remove(value);
            db.SaveChanges();
            return RedirectToAction("ExperienceList");


        }
        [HttpGet]
        public ActionResult UpdateExperience(int id)
        {
            var value = db.TblExperience.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateExperience(TblExperience p)
        {
            var value = db.TblExperience.Find(p.ExperienceId);
            value.Title = p.Title;
            value.Period = p.Period;
            value.Description = p.Description;
            db.SaveChanges();
            return RedirectToAction("ExperienceList");
        }
    }
}