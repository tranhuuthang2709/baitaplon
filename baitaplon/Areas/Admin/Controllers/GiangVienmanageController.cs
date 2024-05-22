using baitaplon.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace baitaplon.Areas.Admin.Controllers
{
    public class GiangVienmanageController : Controller
    {

        QLSVEntities db = new QLSVEntities();
        public ActionResult Index(string searchString, int? MaKhoa)
        {
            var gv = from s in db.giangvien
                     select s;
            // lấy sv có tên chứa chuỗi tìm kiếm.
            if (!String.IsNullOrEmpty(searchString))
            {
                gv = gv.Where(l => l.TenGV.Contains(searchString));
            }
            //lấy các sinh viên thuộc lớp có mã lớp tương ứng.
            if (MaKhoa.HasValue)
            {
                gv = gv.Where(s => s.MaKhoa == MaKhoa.Value);
            }

            ViewBag.MaKhoa = new SelectList(db.khoa, "MaKhoa", "TenKhoa");
            return View(gv.ToList());
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(giangvien model)
        {
            if (ModelState.IsValid)
            {
                db.giangvien.Add(model);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpGet]
        public ActionResult Edit(int MaGV)
        {
            var giangvienmodel = db.giangvien.Find(MaGV);
            if (giangvienmodel == null)
            {
                return HttpNotFound();
            }
            return View(giangvienmodel);
        }

        [HttpPost]
        public ActionResult Edit(giangvien model)
        {
            if (ModelState.IsValid)
            {
                var gv = db.giangvien.Find(model.MaGV);
                if (gv != null)
                {
                    gv.TenGV = model.TenGV;
                    gv.MatKhau = model.MatKhau;
                    gv.GioiTinh = model.GioiTinh;
                    gv.SDT = model.SDT;
                    gv.NgaySinh = model.NgaySinh;
                    gv.MaKhoa = model.MaKhoa;


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

        public ActionResult Delete(int MaGV)
        {
            var model = db.giangvien.Find(MaGV);
            db.giangvien.Remove(model);
            db.SaveChanges();
            return RedirectToAction("index");
        }
    }
}