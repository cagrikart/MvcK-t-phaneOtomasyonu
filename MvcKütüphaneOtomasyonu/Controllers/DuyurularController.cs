using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKütüphaneOtomasyonu.Models.Entity;
namespace MvcKütüphaneOtomasyonu.Controllers
{
    public class DuyurularController : Controller
    {
        // GET: Duyurular
        DBLİBRARYEntities db = new DBLİBRARYEntities();
        public ActionResult Index()
        {
            var duyuruList = db.TBLDUYURULAR.ToList();
            return View(duyuruList);
        }
        [HttpGet]
        public ActionResult YeniDuyuru()
        {
            
            return View();
        }
        [HttpPost]
        public ActionResult YeniDuyuru(TBLDUYURULAR duyurular)
        {
            db.TBLDUYURULAR.Add(duyurular);
            db.SaveChanges();
            return RedirectToAction("Index");

        }

        public ActionResult DuyuruSil(int id)
        {
            var duyuru = db.TBLDUYURULAR.Find(id);
            db.TBLDUYURULAR.Remove(duyuru);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DuyuruGetir(int id)
        {
            var duyuru = db.TBLDUYURULAR.Find(id);
            return View("DuyuruGetir", duyuru);
        }
        public ActionResult DuyuruGuncelle(TBLDUYURULAR duyurular)
        {
            var duyuru = db.TBLDUYURULAR.Find(duyurular.ID);
            duyuru.KATEGORİ = duyurular.KATEGORİ;
            duyuru.İCERİK = duyurular.İCERİK;
            duyuru.TARİH =duyurular.TARİH;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}