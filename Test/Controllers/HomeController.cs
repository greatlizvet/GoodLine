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
            List<Pasta> model = GetList();
            return View(model);
        }

        [HttpPost]
        public ActionResult CreatePasta(Pasta pasta)
        {
            if (ModelState.IsValid)
            {
                db.Pastas.Add(new Pasta { AuthorName = Request.Form["name"], Text = Request.Form["text"], Status = Request.Form["status"], Time = Request.Form["time"], Hash = GenerateHash(), CreationDate = DateTime.Now, EndTime = GetTime(pasta)});
                db.SaveChanges();
            }
            List<Pasta> model = GetList();
            return View("Index", model);
        }

        [HttpGet]
        public ActionResult IndexPasta(string Hash)
        {
            if (Hash == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pasta pasta = db.Pastas.FirstOrDefault(p => p.Hash == Hash);
            if(pasta == null)
            {
                return HttpNotFound();
            }
            if (DateTime.Now >= pasta.EndTime)
            {
                return View("TimeErrorPasta");
            }
            if (pasta.Status == "1")
            {
                return View("ErrorPasta");
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
                Pasta pasta = db.Pastas.FirstOrDefault(p => p.Hash == Hash);
                if (pasta == null)
                    break;
            }
            return Hash;
        }

        private List<Pasta> GetList()
        {
            var pasta = from p in db.Pastas
                        select p;
            List<Pasta> model = pasta.ToList();
            model.Reverse();
            return model;
        }

        private DateTime GetTime(Pasta pasta)
        {
            DateTime endDate;
            switch(pasta.Time)
            {
                case "10M":
                    return endDate = DateTime.Now.AddMinutes(10);
                case "1D":
                    return endDate = DateTime.Now.AddDays(1);
                case "1M":
                    return endDate = DateTime.Now.AddMonths(1);
            }
            return endDate = new DateTime(2050, 01, 01);
        }
    }
}