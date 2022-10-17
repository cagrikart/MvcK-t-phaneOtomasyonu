using MvcKütüphaneOtomasyonu.Models.Entity;
using MvcKütüphaneOtomasyonu.Models.Sınıflarım;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcKütüphaneOtomasyonu.Controllers
{
    public class VitrinController : Controller
    {
        // GET: Vitrin
        DBLİBRARYEntities db = new DBLİBRARYEntities();

        [HttpGet]
        public ActionResult Index()
        {
            Class1 class1 = new Class1();
            class1.kitapDeger = db.TBLKİTAP.ToList();
            class1.hakkimizdaDeger = db.HAKKİMİZDA.ToList();
            return View(class1);
        }

        [HttpPost]
        public ActionResult Index (TBLİLETİSİM iletisim)
        {
            db.TBLİLETİSİM.Add(iletisim);
            db.SaveChanges();
            return View(iletisim);  
        }

    }
}