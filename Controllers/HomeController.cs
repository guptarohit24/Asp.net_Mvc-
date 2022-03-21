using Asp_web_mvc.Models;
using Asp_web_mvc.myDAta;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Asp_web_mvc.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            myDBEntities1 obj = new myDBEntities1();
            List<ModelClass> Bikash = new List<ModelClass>();
            var x = obj.myTable1.ToList();
            foreach (var item in x)
            {
                Bikash.Add(new ModelClass
                {
                    Id= item.Id,
                    Name = item.Name,
                    Email = item.Email,
                    Company = item.Company,
                    Gender= item.Gender,
                    Salary= item.Salary
                });
            }
            return View(Bikash);
        }

        public ActionResult Delete(int Id)
        {
            myDBEntities1 obj = new myDBEntities1();
            var del = obj.myTable1.Where(m => m.Id == Id).First();
            obj.myTable1.Remove(del);
            obj.SaveChanges();
            return RedirectToAction("Index");
        }



        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}