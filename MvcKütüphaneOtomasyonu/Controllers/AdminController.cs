using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using MvcKütüphaneOtomasyonu.Models.Entity;

namespace MvcKütüphaneOtomasyonu.Controllers
{
    [AllowAnonymous]

    public class AdminController : Controller
    {
        // GET: Admin
        DBLİBRARYEntities db = new DBLİBRARYEntities ();
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost ]
        public ActionResult Login(TBLADMİN admin)
        {
            var bilgiler = db.TBLADMİN.FirstOrDefault(x => x.Kullanici== admin.Kullanici&& x.Sifre== admin.Sifre);
            if (bilgiler != null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.Kullanici, false);
                Session["Kullanici"] = bilgiler.Kullanici.ToString();
                return RedirectToAction("Index" , "İstatistik");
            }
            else return View();
        }
    }
}