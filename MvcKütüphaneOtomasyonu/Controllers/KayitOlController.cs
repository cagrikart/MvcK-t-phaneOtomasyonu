using MvcKütüphaneOtomasyonu.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcKütüphaneOtomasyonu.Controllers
{
    [AllowAnonymous]

    public class KayitOlController : Controller
    {
        // GET: KayitOl

        DBLİBRARYEntities db = new DBLİBRARYEntities();

        [HttpGet]
        public ActionResult Kayit()
        {
            return View();
        } 
        [HttpPost]
        public ActionResult Kayit(TBLUYELER uyeler)
        {
            if(!ModelState.IsValid)
            {
                return View("Kayit");
            }
            db.TBLUYELER.Add(uyeler);
            db.SaveChanges();
            return View();
        }
    }
}