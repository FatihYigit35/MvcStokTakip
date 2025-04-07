using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcStokTakip.Models.Entity;

namespace MvcStokTakip.Controllers
{
    public class KategoriController : Controller
    {
        // GET: Kategori
        private readonly MvcDenemeStokTakipEntities db = new MvcDenemeStokTakipEntities();
        public ActionResult Index()
        {
            var katogiler = db.Kategoriler.ToList();
            return View(katogiler);
        }

        [HttpGet]
        public ActionResult Yeni()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Yeni(Kategoriler kategori)
        {
            db.Kategoriler.Add(kategori);
            db.SaveChanges();
            return GotoMain();
        }

        public ActionResult Sil(int id)
        {
            var kategori = db.Kategoriler.Find(id);
            db.Kategoriler.Remove(kategori);
            db.SaveChanges();
            return GotoMain();
        }

        public ActionResult GotoMain()
        {
            return RedirectToAction("Index");
        }

        public ActionResult Getir(int id)
        {
            var kategori = db.Kategoriler.Find(id);
            return View("Getir", kategori);
        }

        public ActionResult Guncelle(Kategoriler kategori)
        {
            var kat = db.Kategoriler.Find(kategori.id);
            kat.ad = kategori.ad;
            db.SaveChanges();
            return GotoMain();
        }
    }
}