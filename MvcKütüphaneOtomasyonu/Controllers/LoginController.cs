using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKütüphaneOtomasyonu.Models.Entity;
using System.Web.Security;
namespace MvcKütüphaneOtomasyonu.Controllers
{
    [AllowAnonymous] 
    public class LoginController : Controller
    {
        // GET: Login
        DBLİBRARYEntities db = new DBLİBRARYEntities();


        [HttpGet]
        public ActionResult GirisYap()
        {
            return View();
        }
        [HttpPost]
        public ActionResult GirisYap(TBLUYELER uyeler)
        {
            var bilgiler = db.TBLUYELER.FirstOrDefault(x => x.MAİL == uyeler.MAİL && x.ŞİFRE == uyeler.ŞİFRE);
            if (bilgiler != null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.MAİL, false);
                Session["Mail"] = bilgiler.MAİL.ToString();
                //Session["ad"] = bilgiler.AD.ToString();
                //Session["soyad"] = bilgiler.SOYAD.ToString();
                //Session["kullaniciadi"] = bilgiler.KULLANİCİADİ.ToString();
                //Session["şifre"] = bilgiler.ŞİFRE.ToString();
                //Session["fotograf"] = bilgiler.FOTOGRAF.ToString();
                //Session["telefon"] = bilgiler.TELEFON.ToString();
                //Session["okul"] = bilgiler.OKUL.ToString();
                 return RedirectToAction("Index", "Panel");
            }
            else
            {
                return View();

            }
        }

    }
}