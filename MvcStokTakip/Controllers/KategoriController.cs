using System.Linq;
using System.Web.Mvc;
using MvcStokTakip.Models.Entity;
using PagedList;
using PagedList.Mvc;

namespace MvcStokTakip.Controllers
{
    public class KategoriController : Controller
    {
        // GET: Kategori
        private readonly MvcDenemeStokTakipEntities db = new MvcDenemeStokTakipEntities();
        public ActionResult Index(int sayfa = 1)
        {
            var katogiler = db.Kategoriler.ToList().ToPagedList(sayfa, 4);
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
            if (!ModelState.IsValid)
            {
                return View("Yeni", kategori);
            }
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