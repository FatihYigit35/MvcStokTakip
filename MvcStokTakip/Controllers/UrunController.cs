using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcStokTakip.Models.Entity;

namespace MvcStokTakip.Controllers
{
    public class UrunController : Controller
    {
        // GET: Urun
        private readonly MvcDenemeStokTakipEntities db = new MvcDenemeStokTakipEntities();
        public ActionResult Index()
        {
            var urunler = db.Urunler.ToList();
            return View(urunler);
        }

        [HttpGet]
        public ActionResult Yeni()
        {
            List<SelectListItem> kategoriler = (
                from i in db.Kategoriler.ToList()
                select new SelectListItem
                {
                    Text = i.ad,
                    Value = i.id.ToString()
                }).ToList();
            ViewBag.kategoriler = kategoriler;

            List<SelectListItem> markalar = (
                from i in db.Markalar.ToList()
                select new SelectListItem
                {
                    Text = i.ad,
                    Value = i.id.ToString()
                }).ToList();
            ViewBag.markalar = markalar;

            return View();
        }

        [HttpPost]
        public ActionResult Yeni(Urunler urun)
        {
            var kategori = db.Kategoriler.Where(m => m.id == urun.Kategoriler.id).FirstOrDefault();
            urun.Kategoriler = kategori;

            var marka = db.Markalar.Where(m => m.id == urun.Markalar.id).FirstOrDefault();
            urun.Markalar = marka;

            db.Urunler.Add(urun);
            db.SaveChanges();
            return GotoMain();
        }

        public ActionResult Sil(int id)
        {
            var urun = db.Urunler.Find(id);
            db.Urunler.Remove(urun);
            db.SaveChanges();
            return GotoMain();
        }

        public ActionResult GotoMain()
        {
            return RedirectToAction("Index");
        }
    }
}