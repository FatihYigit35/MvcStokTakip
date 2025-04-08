using MvcStokTakip.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcStokTakip.Controllers
{
    public class MarkaController : Controller
    {
        // GET: Marka
        private readonly MvcDenemeStokTakipEntities db = new MvcDenemeStokTakipEntities();

        public ActionResult Index()
        {
            var markalar = db.Markalar.ToList();
            return View(markalar);
        }

        [HttpGet]
        public ActionResult Yeni()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Yeni(Markalar marka)
        {
            if (!ModelState.IsValid)
            {
                return View("Yeni", marka);
            }
            db.Markalar.Add(marka);
            db.SaveChanges();
            return GotoMain();
        }

        public ActionResult Sil(int id)
        {
            var marka = db.Markalar.Find(id);
            db.Markalar.Remove(marka);
            db.SaveChanges();
            return GotoMain();
        }

        public ActionResult GotoMain()
        {
            return RedirectToAction("Index");
        }

        public ActionResult Getir(int id)
        {
            var marka = db.Markalar.Find(id);
            return View("Getir", marka);
        }

        public ActionResult Guncelle(Markalar marka)
        {
            var kat = db.Markalar.Find(marka.id);
            kat.ad = marka.ad;
            db.SaveChanges();
            return GotoMain();
        }
    }
}