using baitaplon.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace baitaplon.Controllers
{
    public class SinhvienController : Controller
    {
        QLSVEntities db = new QLSVEntities();
        // GET: Sinhvien
        [HttpGet]
        public ActionResult loginsv()
        {
            return View();
        }
        [HttpPost]
        public ActionResult loginsv(int MaSV,string MatKhau )
        {
            if (ModelState.IsValid)
            {
                var masv = MaSV;
                var mk = MatKhau;
                var acc = db.sinhvien.SingleOrDefault(x => x.MaSV == masv && x.MatKhau == mk);
                if (acc != null)
                {
                    Session["user"] = acc;

                    Session["masv"] = acc.MaSV;
                    Session["name"] = acc.TenSV.ToString();
                    return RedirectToAction("trangchu", "sinhvien");
                }
                else
                {
                    ModelState.AddModelError("", "Thông tin đăng nhập không đúng.");
                    return View();
                }
            }
                return View();
            
        }

        public ActionResult trangchu()
        {

            ViewBag.MaSV = Session["masv"];
            string name = Convert.ToString(Session["name"]);
            ViewBag.name = name;
            return View();
        }
        [HttpGet]
        public ActionResult xemthongtin(int? MaSV)
        {
            ViewBag.MaSV = Session["masv"];
            var sinhvien = db.sinhvien.Find(MaSV);
            return View(sinhvien);
        }
        [HttpGet]
        public ActionResult suathongtin(int? MaSV)
        {
            ViewBag.MaSV = Session["masv"];
            var sinhvien = db.sinhvien.Find(MaSV);
            return View(sinhvien);
        }
        [HttpPost]
        public ActionResult suathongtin(sinhvien model)
        {
            if (ModelState.IsValid)
            {
                var update = db.sinhvien.Find(model.MaSV);

                update.TenSV = model.TenSV;
                update.MatKhau = model.MatKhau;
                update.GioiTinh = model.GioiTinh;
                update.SDT = model.SDT;
                update.NgaySinh = model.NgaySinh;
                update.MaLop = model.MaLop;

                var masv = db.SaveChanges();
                if (masv > 0)
                {
                    return RedirectToAction("loginsv");
                }
                else
                {
                    return View(model);
                }
            }
            return View(model);
        }
        public ActionResult logout()
        {
            Session.Clear();
            return RedirectToAction("loginsv");
        }
        public ActionResult xemdiem(int? MaSV)
        {
            var sinhvien = db.sinhvien.Find(MaSV);
            if (sinhvien == null)
            {
                return HttpNotFound();
            }
            var diemthi = db.diemthi.Where(d => d.MaSV == MaSV).ToList();
            ViewBag.SinhVien = sinhvien;  
            return View(sinhvien);
        }



    }
}