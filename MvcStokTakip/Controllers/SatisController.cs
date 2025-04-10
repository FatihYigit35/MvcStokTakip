using MvcStokTakip.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcStokTakip.Controllers
{
    public class SatisController : Controller
    {
        // GET: Satis
        private readonly MvcDenemeStokTakipEntities db = new MvcDenemeStokTakipEntities();
        public ActionResult Index()
        {
            List<SelectListItem> urunler = (
                from i in db.Urunler.ToList()
                select new SelectListItem
                {
                    Text = i.ad + " (" + i.Markalar.ad + ")",
                    Value = i.id.ToString()
                }).ToList();
            ViewBag.urunler = urunler;

            List<SelectListItem> musteriler = (
                from i in db.Musteriler.ToList()
                select new SelectListItem
                {
                    Text = i.ad + " " + i.soyad,
                    Value = i.id.ToString()
                }).ToList();
            ViewBag.musteriler = musteriler;

            return View();
        }
        [HttpGet]
        public ActionResult Yeni()
        {
            List<SelectListItem> urunler = (
                from i in db.Urunler.ToList()
                select new SelectListItem
                {
                    Text = i.ad,
                    Value = i.id.ToString()
                }).ToList();
            ViewBag.urunler = urunler;

            List<SelectListItem> musteriler = (
                from i in db.Musteriler.ToList()
                select new SelectListItem
                {
                    Text = i.ad,
                    Value = i.id.ToString()
                }).ToList();
            ViewBag.musteriler = musteriler;

            return View();
        }

        [HttpPost]
        public ActionResult Yeni(Satislar satis)
        {
            //if (!ModelState.IsValid)
            //{
            //    return View("Yeni", satis);
            //}

            //List<SelectListItem> urunler = (
            //    from i in db.Urunler.ToList()
            //    select new SelectListItem
            //    {
            //        Text = i.ad,
            //        Value = i.id.ToString()
            //    }).ToList();
            //ViewBag.urunler = urunler;

            //List<SelectListItem> musteriler = (
            //    from i in db.Musteriler.ToList()
            //    select new SelectListItem
            //    {
            //        Text = i.ad,
            //        Value = i.id.ToString()
            //    }).ToList();
            //ViewBag.musteriler = musteriler;
            var urun = db.Urunler.Where(m => m.id == satis.Urunler.id).FirstOrDefault();
            satis.Urunler = urun;

            var musteri = db.Musteriler.Where(m => m.id == satis.Musteriler.id).FirstOrDefault();
            satis.Musteriler = musteri;

            db.Satislar.Add(satis);
            db.SaveChanges();
            return GotoMain();
        }
        public ActionResult GotoMain()
        {
            return RedirectToAction("Index");
        }
    }
}