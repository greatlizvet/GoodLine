using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Test.Models;
using System.Security.Cryptography;

namespace Test.Controllers
{
    public class HomeController : Controller
    {
        BaseContext db = new BaseContext();
        // GET: Home
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreatePasta(Pasta pasta)
        {
            if (ModelState.IsValid)
            {
                db.Pastas.Add(new Pasta { AuthorName = Request.Form["name"], Text = Request.Form["text"], Status = Request.Form["status"], Time = Request.Form["time"], Hash = GenerateHash() });
                db.SaveChanges();
                return View("Index");
            }

            return View("Index");
        }

        private string GenerateHash()
        {
            string Hash = string.Empty;
            while(true)
            {
                var hash = new RNGCryptoServiceProvider();
                Hash = hash.ToString();
                var pasta = from p in db.Pastas
                            where p.Hash == Hash
                            select p.Hash;
                if (pasta == null)
                    break;
            }

            return Hash;
        }
    }
}