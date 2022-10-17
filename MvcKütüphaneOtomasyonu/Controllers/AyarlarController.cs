using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKütüphaneOtomasyonu.Models.Entity;
namespace MvcKütüphaneOtomasyonu.Controllers
{
    public class AyarlarController : Controller
    {
        // GET: Ayarlar
        DBLİBRARYEntities db = new DBLİBRARYEntities();
        public ActionResult Index()
        {
            var adminList = db.TBLADMİN.ToList();
            return View(adminList);
        }
        public ActionResult Index2()
        {
            var adminList = db.TBLADMİN.ToList();
            return View(adminList);
        }
        [HttpGet]
        public ActionResult YeniAdmin()
        {
            var adminList = db.TBLADMİN.ToList();
            return View(adminList);
        }
        [HttpPost]
        public ActionResult YeniAdmin(TBLADMİN admin)
        {
            db.TBLADMİN.Add(admin);
            db.SaveChanges();
            return RedirectToAction("Index2");
        }
        public ActionResult AdminSil(int id)
        {
            var admin= db.TBLADMİN.Find(id);
            db.TBLADMİN.Remove(admin);
            db.SaveChanges();
            return RedirectToAction("Index2");
        }
        public ActionResult AdminGetir(int id)
        {
            var admin = db.TBLADMİN.Find(id);
            return View("AdminGetir",admin);
        }

        public ActionResult AdminGuncelle(TBLADMİN a)
        {
            var admin = db.TBLADMİN.Find(a.ID);
            admin.Kullanici = a.Kullanici;
            admin.Sifre = a.Sifre;
            admin.Yetki = a.Yetki;

            db.SaveChanges();
            return RedirectToAction("Index2");
        }
    }
}