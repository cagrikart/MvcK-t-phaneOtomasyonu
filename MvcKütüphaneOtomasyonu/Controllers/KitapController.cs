using MvcKütüphaneOtomasyonu.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcKütüphaneOtomasyonu.Controllers
{
    public class KitapController : Controller
    {
        // GET: Kitap
        DBLİBRARYEntities db = new DBLİBRARYEntities();
        public ActionResult Index(string p)
        {
            var kitaplar = from k in db.TBLKİTAP select k;
            if (!string.IsNullOrEmpty(p))
            {
                kitaplar = kitaplar.Where(m => m.AD.Contains(p));
            }
            // var kitaplar = db.TBLKITAP.ToList();
            return View(kitaplar.ToList());
        }

        [HttpGet]
        public ActionResult KitapEkle()
        {
            List<SelectListItem> deger1 = (from i in db.TBLCATEGORY.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.AD,
                                               Value = i.ID.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;



            List<SelectListItem> deger2 = (from i in db.TBLYAZAR.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.AD + " " + i.SOYAD,
                                               Value = i.ID.ToString()
                                           }).ToList();
            ViewBag.dgr2 = deger2;
            return View();

        }
        [HttpPost]
        public ActionResult KitapEkle(TBLKİTAP kitap)
        {
            var kategori = db.TBLCATEGORY.Where(k => k.ID == kitap.TBLCATEGORY.ID)
                .FirstOrDefault();
            var yazar = db.TBLYAZAR.Where(k => k.ID == kitap.TBLYAZAR.ID).FirstOrDefault();
            kitap.TBLCATEGORY = kategori;
            kitap.TBLYAZAR = yazar;
            db.TBLKİTAP.Add(kitap);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult KitapSil(int id)
        {
            var kitap = db.TBLKİTAP.Find(id);
            db.TBLKİTAP.Remove(kitap);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult KitapGetir(int id)
        {
            var kitap = db.TBLKİTAP.Find(id);
            List<SelectListItem> deger1 = (from i in db.TBLCATEGORY.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.AD,
                                               Value = i.ID.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;



            List<SelectListItem> deger2 = (from i in db.TBLYAZAR.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.AD + " " + i.SOYAD,
                                               Value = i.ID.ToString()
                                           }).ToList();
            ViewBag.dgr2 = deger2;
            return View("KitapGetir", kitap);
        }

        public ActionResult KitapGuncelle(TBLKİTAP p)
        {
            var kitap = db.TBLKİTAP.Find(p.ID);
            kitap.AD = p.AD;
            kitap.BASİMYİL = p.BASİMYİL;
            kitap.SAYFA = p.SAYFA;
            kitap.YAYİNEVİ = p.YAYİNEVİ;
            kitap.DURUM = true;
            var kategori = db.TBLCATEGORY.Where(k => k.ID == kitap.TBLCATEGORY.ID)
               .FirstOrDefault();
            var yazar = db.TBLYAZAR.Where(y => y.ID == kitap.TBLYAZAR.ID).FirstOrDefault();
            kitap.KATEGORİ = kategori.ID;
            kitap.YAZAR = yazar.ID;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
