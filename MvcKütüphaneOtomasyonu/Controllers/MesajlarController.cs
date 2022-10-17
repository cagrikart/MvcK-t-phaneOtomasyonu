using MvcKütüphaneOtomasyonu.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcKütüphaneOtomasyonu.Controllers
{
    public class MesajlarController : Controller
    {
        // GET: Mesajlar
        DBLİBRARYEntities db = new DBLİBRARYEntities(); 

        public ActionResult Index()
        {
            var uyemail = (string)Session["Mail"].ToString();
            var mesajlar = db.TBLMESAJLAR.Where(x => x.ALICI == uyemail.ToString()).ToList(); ;
            return View(mesajlar);
        }


        [HttpGet]

        public ActionResult YeniMesaj()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniMesaj(TBLMESAJLAR mesajlar)
        {
            var uyeMail = (string)Session["Mail"].ToString();
            mesajlar.GONDEREN = uyeMail.ToString();
            mesajlar.TARİH = DateTime.Parse(DateTime.Now.ToShortDateString());
            db.TBLMESAJLAR.Add(mesajlar);
            db.SaveChanges();
            return View();
        }
        public ActionResult GonderilenMesaj(TBLMESAJLAR mesajlar)
        {
            var gonderilenMesaj = (string)Session["Mail"].ToString();
            var mesajList = db.TBLMESAJLAR.Where(x => x.GONDEREN == gonderilenMesaj.ToString()).ToList();
            return View(mesajList);
        }
        public PartialViewResult Partial1()
        {
            var uyeMail= (string)Session["Mail"].ToString();
            var gelenSayisi = db.TBLMESAJLAR.Where(x => x.ALICI == uyeMail).Count();
            ViewBag.deger1 = gelenSayisi;

            var gidenSayisi = db.TBLMESAJLAR.Where(x => x.GONDEREN == uyeMail).Count();
            ViewBag.deger2 = gidenSayisi;
            return PartialView();
        }
    }
}