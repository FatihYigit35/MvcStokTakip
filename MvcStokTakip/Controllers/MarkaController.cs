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
    }
}