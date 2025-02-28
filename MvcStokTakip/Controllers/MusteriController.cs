﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcStokTakip.Models.Entity;

namespace MvcStokTakip.Controllers
{
    public class MusteriController : Controller
    {
        // GET: Musteriler
        private readonly MvcDenemeStokTakipEntities db = new MvcDenemeStokTakipEntities();
        public ActionResult Index()
        {
            var musteriler = db.Musteriler.ToList();
            return View(musteriler);
        }

        [HttpGet]
        public ActionResult Yeni()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Yeni(Musteriler musteri)
        {
            db.Musteriler.Add(musteri);
            db.SaveChanges();
            return GotoMain();
        }

        public ActionResult Sil(int id)
        {
            var musteri = db.Musteriler.Find(id);
            db.Musteriler.Remove(musteri);
            db.SaveChanges();
            return GotoMain();
        }

        public ActionResult GotoMain()
        {
            return RedirectToAction("Index");
        }
    }
}