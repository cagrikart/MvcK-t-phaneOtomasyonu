 using MvcKütüphaneOtomasyonu.Models.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcKütüphaneOtomasyonu.Controllers
{
    public class OduncController : Controller
    {
        // GET: Odunc
        DBLİBRARYEntities db = new DBLİBRARYEntities(); 
        public ActionResult Index()
        {
            var hareketList = db.TBLHAREKET.Where(x => x.İSLEMDURUM == false).ToList();
            return View(hareketList);
        }
        [HttpGet]
        public ActionResult OduncVer ()
        {
            List<SelectListItem> deger1 = (from item in db.TBLUYELER.ToList()
                                           select new SelectListItem
                                           {
                                               Text = item.AD,
                                               Value = item.ID.ToString()

                                           }).ToList();

            List<SelectListItem> deger2 = (from item in db.TBLKİTAP.Where(x => x.DURUM == true).ToList()
                                           select new SelectListItem
                                           {
                                               Text = item.AD,
                                               Value = item.ID.ToString()

                                           }).ToList();
            List<SelectListItem> deger3 = (from item in db.TBLPERSONEL.ToList()
                                           select new SelectListItem
                                           {
                                               Text = item.PERSONEL,
                                               Value = item.ID.ToString()

                                           }).ToList();
            ViewBag.deger1 = deger1;
            ViewBag.deger2 = deger2;
            ViewBag.deger3 = deger3;

            return View();

        }
        [HttpPost]
        public ActionResult OduncVer (TBLHAREKET hareket)
        {
            var d1 = db.TBLUYELER.Where(x => x.ID == hareket.TBLUYELER.ID).FirstOrDefault();
            var d2 = db.TBLKİTAP.Where(y => y.ID == hareket.TBLKİTAP.ID).FirstOrDefault();
            var d3 = db.TBLPERSONEL.Where(z => z.ID == hareket.TBLPERSONEL.ID).FirstOrDefault();
            hareket.TBLUYELER = d1;
            hareket.TBLKİTAP = d2;
            hareket.TBLPERSONEL = d3;
            db.TBLHAREKET.Add(hareket);
            db.SaveChanges();
            return RedirectToAction("Index");

        }

        public ActionResult Odunciade(TBLHAREKET hareket)
        {
            var iade = db.TBLHAREKET.Find(hareket.ID);
            DateTime d1 = DateTime.Parse(iade.İADETARİHİ.ToString());
            ViewBag.dgr = d1;
            DateTime d2 = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            TimeSpan d3 = d2 - d1;
            ViewBag.dgr = d3.TotalDays;

            return View("Odunciade",iade);

        }
        public ActionResult OduncGuncelle(TBLHAREKET p)
        {
            var hareket = db.TBLHAREKET.Find(p.ID);
            hareket.UYEGETİRTARİH = p.UYEGETİRTARİH;
            hareket.İSLEMDURUM = true;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}