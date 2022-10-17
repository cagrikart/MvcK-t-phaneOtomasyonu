using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKütüphaneOtomasyonu.Models.Entity;
using PagedList;
using PagedList.Mvc;
namespace MvcKütüphaneOtomasyonu.Controllers
{
    public class UyeController : Controller
    {
        // GET: Uye
        DBLİBRARYEntities db = new DBLİBRARYEntities();
        public ActionResult Index(int sayfa = 1)
        {

            //var uyelist = db.TBLUYELER.ToList();
            var uyelist = db.TBLUYELER.ToList().ToPagedList(sayfa,10);
            return View(uyelist);
        }
        [HttpGet]
        public ActionResult UyeEkle()
        {
            return View();

        }
        [HttpPost]
        public ActionResult UyeEkle(TBLUYELER uye)
        {
            if (!ModelState.IsValid)
            {
                return View("UyeEkle");
            }
            db.TBLUYELER.Add(uye);
            db.SaveChanges();
            //return RedirectToAction("Index");
            return View();

        }
        public ActionResult UyeSil(int id)
        {
            var uye = db.TBLUYELER.Find(id);
            db.TBLUYELER.Remove(uye);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult UyeGetir(int id)
        {
            var uye = db.TBLUYELER.Find(id);
            return View("YazarGetir", uye);
        }

        public ActionResult UyeGuncelle(TBLUYELER p)
        {
            var uye = db.TBLUYELER.Find(p.ID);
            uye.AD = p.AD;
            uye.SOYAD = p.SOYAD;
            uye.MAİL = p.MAİL;
            uye.KULLANİCİADİ = p.KULLANİCİADİ;
            uye.ŞİFRE = p.ŞİFRE;
            uye.FOTOGRAF = p.FOTOGRAF;
            uye.TELEFON = p.TELEFON;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UyeKitapGecmisi (int id )
        {
            var kitapGecmisi = db.TBLHAREKET.Where(x => x.UYE == id).ToList();
            var uyeAd = db.TBLUYELER.Where(x => x.ID == id).Select(z => z.AD + "  " + z.SOYAD).FirstOrDefault();
            ViewBag.uyeAd = uyeAd;
            return View(kitapGecmisi);

        }
    }
}