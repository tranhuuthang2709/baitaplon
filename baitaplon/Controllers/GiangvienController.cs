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
        // GET: Giaovien

        QLSVEntities db = new QLSVEntities();
        [HttpGet]
        public ActionResult logingv()
        {
            return View();
        }
        [HttpPost]
        public ActionResult logingv(int MaGV, string MatKhau)
        {
            var magv = MaGV;
            var mk = MatKhau;
            var acc = db.giangvien.SingleOrDefault(x => x.MaGV == magv && x.MatKhau == mk);
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
            string name = Convert.ToString(Session["name"]);
            ViewBag.name = name;
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

            update.TenGV = model.TenGV;
            update.MatKhau = model.MatKhau;
            update.GioiTinh = model.GioiTinh;
            update.SDT = model.SDT;
            update.NgaySinh = model.NgaySinh;
            update.MaKhoa = model.MaKhoa;

            var magv = db.SaveChanges();
            if (magv > 0)
            {
                return RedirectToAction("logingv");
            }
            else
            {
                return View(model);
            }
        }
        public ActionResult logout()
        {
            Session.Clear();
            return RedirectToAction("logingv");
        }

    }
}