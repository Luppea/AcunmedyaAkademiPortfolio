﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AcunmedyaAkademiPortfolio.Models;

namespace AcunmedyaAkademiPortfolio.Controllers
{
    public class StatsController : Controller
    {
        DbAcunmedyaAkademi1Entities db = new DbAcunmedyaAkademi1Entities();
        public ActionResult StatsList()
        {
            var values = db.TblStats.ToList();
            return View(values);
        }
        [HttpGet]

        public ActionResult CreateStats()
        {
            return View();

        }

        [HttpPost]
        public ActionResult CreateStats(TblStats stats)
        {
            db.TblStats.Add(stats);
            db.SaveChanges();
            return RedirectToAction("StatsList");
        }
        public ActionResult DeleteStats(int id)
        {
            var value = db.TblStats.Find(id);
            db.TblStats.Remove(value);
            db.SaveChanges();
            return RedirectToAction("StatsList");


        }
        [HttpGet]
        public ActionResult UpdateStats(int id)
        {
            var value = db.TblStats.Find(id);
            return View(value); 
        }

        [HttpPost]
        public ActionResult UpdateStats(TblStats p)
        {
            var value = db.TblStats.Find(p.StatsId);
            value.StatsName = p.StatsName;
            value.StatsNumber = p.StatsNumber;
            value.StatsEmoji = p.StatsEmoji;
            db.SaveChanges();
            return RedirectToAction("StatsList");
        }
    }
}