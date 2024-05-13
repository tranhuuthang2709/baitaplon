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
                return View();
            }
        }

        public ActionResult trangchu()
        {

            ViewBag.MaSV = Session["masv"];
            string name = Convert.ToString(Session["name"]);
            ViewBag.name = name;
            return View();
        }

        [HttpGet]
        public ActionResult thongtin(int? MaSV)
        {
            var sinhvien = db.sinhvien.Find(MaSV);
            return View(sinhvien);
        }
        [HttpPost]
        public ActionResult thongtin(sinhvien sinhvien)
        {
            var update = db.sinhvien.Find(sinhvien.MaSV);

            update.TenSV = sinhvien.TenSV;
            update.MatKhau = sinhvien.MatKhau;
            update.GioiTinh = sinhvien.GioiTinh;
            update.SDT = sinhvien.SDT;
            update.NgaySinh = sinhvien.NgaySinh;
            update.MaLop = sinhvien.MaLop;

            var masv = db.SaveChanges();
            if (masv > 0)
            {
                return ActionResult("thongtin");
            }
            else
            {
                return View(sinhvien);
            }
        }

        private ActionResult ActionResult(string v)
        {
            throw new NotImplementedException();
        }
    }
}