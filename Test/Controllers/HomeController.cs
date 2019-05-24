using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Test.Models;
using System.Security.Cryptography;
using System.Net;

namespace Test.Controllers
{
    public class HomeController : Controller
    {
        BaseContext db = new BaseContext();
        // GET: Home
        [HttpGet]
        public ActionResult Index()
        {
            var pasta = from p in db.Pastas
                        select p;
            List<Pasta> model = pasta.ToList();
            return View(model);
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

        [HttpGet]
        public ActionResult IndexPasta(string Hash)
        {
            if (Hash == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var pasta = from p in db.Pastas
                        select p;
            pasta = pasta.Where(p => p.Hash == Hash);
            if(pasta == null)
            {
                return HttpNotFound();
            }
            return View(pasta);
        }

        private string GenerateHash()
        {
            string Hash = string.Empty;
            var bytes = new byte[16];
            while (true)
            {
                using (var rng = new RNGCryptoServiceProvider())
                {
                    rng.GetBytes(bytes);
                }
                Hash = BitConverter.ToString(bytes).Replace("-", "").ToLower();
                var pasta = from p in db.Pastas
                            where p.Hash == Hash
                            select p.Hash;
                string hash1 = pasta.ToString();
                if (Hash != hash1)
                    break;
            }
            return Hash;
        }
    }
}