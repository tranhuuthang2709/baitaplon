using baitaplon.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace baitaplon.Controllers
{
    public class GiangvienController : Controller
    {
        QLSVEntities db = new QLSVEntities();

        [HttpGet]
        public ActionResult logingv()
        {
            return View();
        }

        [HttpPost]
        public ActionResult logingv(int MaGV, string MatKhau)
        {
            var acc = db.giangvien.SingleOrDefault(x => x.MaGV == MaGV && x.MatKhau == MatKhau);
            if (acc != null)
            {
                Session["user"] = acc;
                Session["magv"] = acc.MaGV;
                Session["name"] = acc.TenGV.ToString();
                return RedirectToAction("trangchu", "giangvien");
            }
            else
            {
                return View();
            }
        }

        public ActionResult trangchu()
        {
            ViewBag.Magv = Session["magv"];
            ViewBag.name = Session["name"]?.ToString();
            return View();
        }

        [HttpGet]
        public ActionResult xemthongtin(int? MaGV)
        {
            ViewBag.Magv = Session["magv"];
            var giangvien = db.giangvien.Find(MaGV);
            return View(giangvien);
        }

        [HttpGet]
        public ActionResult suathongtin(int? MaGV)
        {
            ViewBag.Magv = Session["magv"];
            var giangvien = db.giangvien.Find(MaGV);
            return View(giangvien);
        }

        [HttpPost]
        public ActionResult suathongtin(giangvien model)
        {
            var update = db.giangvien.Find(model.MaGV);
            if (update != null)
            {
                update.TenGV = model.TenGV;
                update.MatKhau = model.MatKhau;
                update.GioiTinh = model.GioiTinh;
                update.SDT = model.SDT;
                update.NgaySinh = model.NgaySinh;
                update.MaKhoa = model.MaKhoa;
                db.SaveChanges();
            }
            return RedirectToAction("logingv");
        }

        public ActionResult logout()
        {
            Session.Clear();
            return RedirectToAction("logingv");
        }

        [HttpGet]
        public ActionResult suadiemsv()
        {
            var listsinhvien = db.sinhvien.ToList();
            return View(listsinhvien);
        }

        [HttpGet]
        public ActionResult listDiem(int? MaSV)
        {
            var sinhvien = db.diemthi.Find(MaSV);
            if (sinhvien == null)
            {
                return HttpNotFound();
            } 

            var diemthi = db.diemthi.Where(d => d.MaSV == MaSV).ToList();
            ViewBag.SinhVien = sinhvien;
            return View(diemthi);
        }

        [HttpGet]
        public ActionResult EditDiem(int? MaMH)
        {
            var diemthi = db.diemthi.Find(MaMH);
            return View(diemthi);
        }

        [HttpPost]
        public ActionResult EditDiem(diemthi diemthi)
        {

            var update = db.diemthi.Find(diemthi.MaMH);
                update.DiemThi1 = diemthi.DiemThi1;
                db.SaveChanges();
                return RedirectToAction("suadiemsv");
            }



    }
}
