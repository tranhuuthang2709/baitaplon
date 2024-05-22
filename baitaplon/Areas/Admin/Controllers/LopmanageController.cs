using baitaplon.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace baitaplon.Areas.Admin.Controllers
{
    public class LopmanageController : Controller
    {
        
             QLSVEntities db = new QLSVEntities();


        public ActionResult Index(string searchString, int? maNganh)
        {
            var lops = from l in db.lop
                       select l;

            if (!String.IsNullOrEmpty(searchString))
            {
                lops = lops.Where(s => s.TenLop.Contains(searchString));
            }

            if (maNganh.HasValue)
            {
                lops = lops.Where(s => s.MaNganh == maNganh.Value);
            }

            ViewBag.MaNganh = new SelectList(db.nganh, "Manganh", "Tennganh");
            return View(lops.ToList());
        }

        public ActionResult Create()
            {
                return View();
            }

            [HttpPost]
            public ActionResult Create(lop lop)
            {
                if (ModelState.IsValid)
                {
                    db.lop.Add(lop);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                return View(lop);
            }
        [HttpGet]
        public ActionResult Edit(int MaLop)
            {
                var lop = db.lop.Find(MaLop);
                if (lop == null)
                {
                    return HttpNotFound();
                }
                return View(lop);
            }

            [HttpPost]
            public ActionResult Edit(lop model)
            {
                if (ModelState.IsValid)
                {
                var l = db.lop.Find(model.MaLop);
                if(l!= null)
                {
                    l.TenLop = model.TenLop;
                    l.MaNganh = model.MaNganh;

                    db.SaveChanges();
                    return RedirectToAction("index");
                }
                
            else
            {
                return HttpNotFound();
            }
        }
            return View(model);
    }

        public ActionResult Delete(int MaLop)
        {
            var model = db.lop.Find(MaLop);
            db.lop.Remove(model);
            db.SaveChanges();
            return RedirectToAction("index");
        }
        public ActionResult Details(int MaLop)
        {
            var lop = db.lop.Find(MaLop);

            var tenlop = db.lop.Find(MaLop).TenLop.ToString();
            ViewBag.ten = tenlop;
            if (lop == null)
            {
                return HttpNotFound();
            }

            var sinhvienList = db.sinhvien.Where(s => s.MaLop == MaLop).ToList();
            ViewBag.Lop = lop;
            return View(sinhvienList);
        }
    }
    }
