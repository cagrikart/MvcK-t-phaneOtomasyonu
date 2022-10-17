using MvcKütüphaneOtomasyonu.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
 
namespace MvcKütüphaneOtomasyonu.Controllers
{
    [Authorize]
    public class PanelController : Controller
    {
        // GET: Panel
        DBLİBRARYEntities db = new DBLİBRARYEntities();
        [Authorize]
        [HttpGet]
        public ActionResult Index()
        {
            var uyemail = (string)Session["Mail"];
            var degerler = db.TBLDUYURULAR.ToList();
            var uyeid =  db.TBLUYELER.Where(x => x.MAİL == uyemail).Select(y => y.ID).FirstOrDefault();
            var deger1 = db.TBLUYELER.Where(x => x.MAİL == uyemail).Select(y => y.AD).FirstOrDefault();
            var deger2 = db.TBLUYELER.Where(x => x.MAİL == uyemail).Select(y => y.SOYAD).FirstOrDefault();
            var deger3 = db.TBLUYELER.Where(x => x.MAİL == uyemail).Select(y => y.FOTOGRAF).FirstOrDefault();
            var deger4 = db.TBLUYELER.Where(x => x.MAİL == uyemail).Select(y => y.KULLANİCİADİ).FirstOrDefault();
            var deger6 = db.TBLUYELER.Where(x => x.MAİL == uyemail).Select(y => y.TELEFON).FirstOrDefault();
            var deger7 = db.TBLUYELER.Where(x => x.MAİL == uyemail).Select(y => y.MAİL).FirstOrDefault();
            var deger8 = db.TBLHAREKET.Where(x => x.UYE == uyeid).Count();
            var deger9 = db.TBLMESAJLAR.Where(x => x.ALICI== uyemail).Count();
            var deger10 = db.TBLDUYURULAR.Count();
            ViewBag.deger1 = deger1;
            ViewBag.deger2 = deger2;
            ViewBag.deger3 = deger3;
            ViewBag.deger4 = deger4;
            ViewBag.deger6 = deger6;
            ViewBag.deger7 = deger7;
            ViewBag.deger8 = deger8;
            ViewBag.deger9 = deger9;
            ViewBag.deger10 = deger10;
            return View(degerler);
        }
        [HttpPost]
        public ActionResult Index2(TBLUYELER uyeler)
        {
            var kullanici = (string)Session["Mail"];
            var uye = db.TBLUYELER.FirstOrDefault(x => x.MAİL == kullanici);
            uye.ŞİFRE = uyeler.ŞİFRE;
            uye.AD = uyeler.AD;
            uye.KULLANİCİADİ = uyeler.KULLANİCİADİ;
            uye.TELEFON = uyeler.TELEFON;
            db.SaveChanges();
            return RedirectToAction("Index"); ;
        }
     

        public ActionResult Kitaplarim()
        {
            var kullanici = (string)Session["Mail"];
            var id = db.TBLUYELER.Where(x => x.MAİL == kullanici.ToString()).Select(z => z.ID).FirstOrDefault();    
            var islemList = db.TBLHAREKET.Where(x => x.UYE == id).ToList();
            return View(islemList);
        }

        public ActionResult Duyurular()
        {
            var duyuruList = db.TBLDUYURULAR.ToList();
            return View(duyuruList);
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index" , "Vitrin");
        }
        public PartialViewResult DuyuruPartial ()
        {
            return PartialView();
        }
        public PartialViewResult Settings()
        {
            var kullanici = (string)Session["Mail"];
            var id = db.TBLUYELER.Where(x => x.MAİL == kullanici).Select(y => y.ID).FirstOrDefault();
            var uyebul = db.TBLUYELER.Find(id);
            return PartialView("Settings",uyebul);
        }
    }
}