using MvcKütüphaneOtomasyonu.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcKütüphaneOtomasyonu.Controllers
{
    public class YazarController : Controller
    {
        // GET: Yazar
        DBLİBRARYEntities db = new DBLİBRARYEntities();
        public ActionResult Index()
        {
            var yazarList = db.TBLYAZAR.ToList();
            return View(yazarList);
        }
        [HttpGet]
        public ActionResult YazarEkle()
        {
            return View();

        }
        [HttpPost]
        public ActionResult YazarEkle(TBLYAZAR yazar)
        {
            if (!ModelState.IsValid)
            {
                return View("YazarEkle");
            }
            db.TBLYAZAR.Add(yazar);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult YazarSil(int id)
        {
            var yazar = db.TBLYAZAR.Find(id);
            db.TBLYAZAR.Remove(yazar);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult YazarGetir(int id)
        {
            var yazar = db.TBLYAZAR.Find(id);
            return View("YazarGetir", yazar);
        }

        public ActionResult YazarGuncelle(TBLYAZAR p)
        {
            var yazar = db.TBLYAZAR.Find(p.ID);
            yazar.AD = p.AD;
            yazar.SOYAD = p.SOYAD;
            yazar.DETAY = p.DETAY;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
          public ActionResult YazarKitaplar(int id)
        {
            var yazar = db.TBLKİTAP.Where(x => x.YAZAR == id).ToList();
            var yazarAd = db.TBLYAZAR.Where(y => y.ID == id).Select(z => z.AD + "  " + z.SOYAD).FirstOrDefault();
            ViewBag.yazar1 = yazarAd;
            return View(yazar);
        }

    }
}