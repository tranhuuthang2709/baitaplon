using baitaplon.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace baitaplon.Areas.Admin.Controllers
{
    public class SinhVienmanageController : Controller
    {
        // GET: Admin/SinhVien

        QLSVEntities db = new QLSVEntities();
        public ActionResult Index(string searchString, int? MaLop)
        {
            var sv = from s in db.sinhvien
                       select s;
            // lấy sv có tên chứa chuỗi tìm kiếm.
            if (!String.IsNullOrEmpty(searchString))
            {
                sv = sv.Where(l => l.TenSV.Contains(searchString));
            }
            //lấy các sinh viên thuộc lớp có mã lớp tương ứng.
            if (MaLop.HasValue)
            {
                sv = sv.Where(s => s.MaLop == MaLop.Value);
            }

            ViewBag.MaLop = new SelectList(db.lop, "MaLop", "TenLop");
            return View(sv.ToList());
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(sinhvien model)
        {
            if (ModelState.IsValid)
            {
                db.sinhvien.Add(model);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpGet]
        public ActionResult Edit(int MaSV)
        {
            var sinhvienmodel = db.sinhvien.Find(MaSV);
            if (sinhvienmodel == null)
            {
                return HttpNotFound();
            }
            return View(sinhvienmodel);
        }

        [HttpPost]
        public ActionResult Edit(sinhvien model)
        {
            if (ModelState.IsValid)
            {
                var sv = db.sinhvien.Find(model.MaSV);
                if (sv != null)
                {
                    sv.TenSV = model.TenSV;
                    sv.MatKhau = model.MatKhau;
                    sv.GioiTinh = model.GioiTinh;
                    sv.SDT = model.SDT;
                    sv.NgaySinh = model.NgaySinh;
                    sv.MaLop = model.MaLop;

                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    return HttpNotFound();
                }
            }
            return View(model);
        }

        public ActionResult Delete(int MaSV)
        {
            var model = db.sinhvien.Find(MaSV);
            db.sinhvien.Remove(model);
            db.SaveChanges();
            return RedirectToAction("index");
        }
       
    }
}
