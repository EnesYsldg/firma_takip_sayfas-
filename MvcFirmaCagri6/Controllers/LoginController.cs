using MvcFirmaCagri6.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcFirmaCagri6.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        Dbis_TakipEntities db = new Dbis_TakipEntities();
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(TblFirmalar p)
        {
            var bilgiler = db.TblFirmalar.FirstOrDefault(x => x.Mail == p.Mail && x.Sifre == p.Sifre);
            if (bilgiler != null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.Mail, false);
                Session["Mail"] = bilgiler.Mail.ToString();
                return RedirectToAction("AktifCagrilar", "Default");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
        
    }
}