using baitaplon.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace baitaplon.Areas.Admin.Controllers
{
    public class HomemanageController : Controller
    {
        QLSVEntities db = new QLSVEntities();
        // GET: Admin/Home
        public ActionResult Index()
        {
            string name = Convert.ToString(Session["name"]);
            ViewBag.name = name;
            return View();
        }
        [HttpGet]
        public ActionResult loginadmin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult loginadmin(string Username, string Password)
        {
            if (ModelState.IsValid)
            {
                var acc = db.Admins.SingleOrDefault(x => x.Username == Username && x.Password == Password);
                if (acc != null)
                {
                    Session["user"] = acc;
                    Session["name"] = acc.Username.ToString();
                    return RedirectToAction("Index", "Homemanage");
                }
                else
                {
                    ModelState.AddModelError("", "Thông tin đăng nhập không đúng.");
                    return View();
                }
            }
            else
            {
                return View();
            }
        }
        public ActionResult logout()
        {
            Session.Clear();
            return RedirectToAction("Index", "Home", new { area = "" });
        }

    }
}