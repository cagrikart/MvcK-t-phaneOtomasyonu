using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKütüphaneOtomasyonu.Models.Entity;
namespace MvcKütüphaneOtomasyonu.Controllers
{
    public class İslemController : Controller
    {
        // GET: İslem
        DBLİBRARYEntities db = new DBLİBRARYEntities();
        public ActionResult Index()

        {
            var islemList = db.TBLHAREKET.Where(x => x.İSLEMDURUM == true).ToList();
            return View(islemList);
        }
    }
}