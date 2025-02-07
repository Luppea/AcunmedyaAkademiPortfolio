using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AcunmedyaAkademiPortfolio.Models;

namespace AcunmedyaAkademiPortfolio.Controllers
{
    public class SkillController : Controller
    {
        DbAcunmedyaAkademi1Entities db = new DbAcunmedyaAkademi1Entities();
        public ActionResult SkillList()
        {
            var values = db.TblSkill.ToList();
            return View(values);
        }
        [HttpGet]

        public ActionResult CreateSkill()
        {
            return View();

        }

        [HttpPost]
        public ActionResult CreateSkill(TblSkill skill)
        {
            db.TblSkill.Add(skill);
            db.SaveChanges();
            return RedirectToAction("SkillList");
        }
        public ActionResult DeleteSkill(int id)
        {
            var value = db.TblSkill.Find(id);
            db.TblSkill.Remove(value);
            db.SaveChanges();
            return RedirectToAction("SkillList");


        }
        [HttpGet]
        public ActionResult UpdateSkill(int id)
        {
            var value = db.TblSkill.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateSkill(TblSkill p)
        {
            var value = db.TblSkill.Find(p.SkillId);
            value.SkillTitle = p.SkillTitle;
            value.SkillValue = p.SkillValue;
            db.SaveChanges();
            return RedirectToAction("SkillList");
        }
    }
}