using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKütüphaneOtomasyonu.Models.Entity;
namespace MvcKütüphaneOtomasyonu.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        DBLİBRARYEntities db = new DBLİBRARYEntities();
        public ActionResult Index()
        {
            var categoryList = db.TBLCATEGORY.Where(x => x.DURUM==true).ToList();
            return View(categoryList);
        }



        [HttpGet]
        public ActionResult KategoriEkle()
        {
            return View();  

        }
        [HttpPost]
        public ActionResult KategoriEkle(TBLCATEGORY category)
        {
            db.TBLCATEGORY.Add(category);
            db.SaveChanges();
            return View();

        }
        public ActionResult KategoriSil(int id)
        {
            var kategori = db.TBLCATEGORY.Find(id);
            //db.TBLCATEGORY.Remove(kategori);
            kategori.DURUM = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult KategoriGetir(int id)
        {
            var kategori = db.TBLCATEGORY.Find(id);
            return View("KategoriGetir", kategori);
        }

        public ActionResult KategoriGuncelle(TBLCATEGORY p)
        {
            var kategori = db.TBLCATEGORY.Find(p.ID);
            kategori.AD = p.AD;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}