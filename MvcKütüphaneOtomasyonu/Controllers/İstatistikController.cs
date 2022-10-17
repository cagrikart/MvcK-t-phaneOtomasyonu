﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKütüphaneOtomasyonu.Models.Entity; 
namespace MvcKütüphaneOtomasyonu.Controllers
{
    public class İstatistikController : Controller
    {
        // GET: İstatistik
        DBLİBRARYEntities db = new DBLİBRARYEntities();
        public ActionResult Index()
        {
            var deger1 = db.TBLUYELER.Count();
            var deger2 = db.TBLKİTAP.Where(x => x.DURUM == false).Count();
            var deger3 = db.TBLKİTAP.Where(x => x.DURUM == false).Count();
            var deger4 = db.TBLCEZALAR.Sum(x => x.PARA);
            ViewBag.deger1 = deger1;
            ViewBag.deger2 = deger2;
            ViewBag.deger3 = deger3;
            ViewBag.deger4 = deger4;
            return View();
        }
        public ActionResult Hava()
        {
            return View();
        }
        public ActionResult HavaKart()
        {
            return View();
        }
        public ActionResult Galeri()
        {
            return View();
        }
        [HttpPost]
        public ActionResult resimyukle(HttpPostedFileBase dosya)
        {
            if (dosya.ContentLength > 0)
            {
                string dosyayolu = Path.Combine(Server.MapPath("~/web2/resimler/"), Path.GetFileName(dosya.FileName));
                dosya.SaveAs(dosyayolu);
            }
            return RedirectToAction("Galeri");
        }
        public ActionResult LinqKart()
        {
            var deger1 = db.TBLKİTAP.Count();
            var deger2 = db.TBLUYELER.Count();
            var deger3 = db.TBLCEZALAR.Sum(x => x.PARA);
            var deger4 = db.TBLKİTAP.Where(x => x.DURUM == false).Count();
            var deger5 = db.TBLCATEGORY.Count();
            var deger8 = db.EnFazlaKitapYazar().FirstOrDefault();
            var deger9 = db.TBLKİTAP.GroupBy(x => x.YAYİNEVİ).OrderByDescending(z => z.Count()).Select(y => new { y.Key }).FirstOrDefault();
            var deger11 = db.TBLİLETİSİM.Count();

            ViewBag.dgr1 = deger1;
            ViewBag.dgr2 = deger2;
            ViewBag.dgr3 = deger3;
            ViewBag.dgr4 = deger4;
            ViewBag.dgr5 = deger5;
            ViewBag.dgr8 = deger8;
            ViewBag.dgr9 = deger9;
            ViewBag.dgr11 = deger11;

            return View();
        }
    }
}