using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ParabolicFunction.Models;


namespace ParabolicFunction.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
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

        DataContext db = new DataContext();

        [HttpPost]
        public JsonResult BookSearch(string step, string from, string to, string a, string b, string c)
        {
            var userData = new UserData() { RangeFrom = int.Parse(from), RangeTo = int.Parse(to),
                Step = int.Parse(step), A = int.Parse(a), B = int.Parse(b), C = int.Parse(c)
            };
            db.UserData.Add(userData);
            db.SaveChanges();
            List<MyPoint> mas = result(userData);
            
            return Json(mas, JsonRequestBehavior.AllowGet);
        }

        private List<MyPoint> result(UserData userData)
        {
            List<MyPoint> mas = new List<MyPoint>();
            check(ref userData);
            int id = db.UserData.Max(p => p.UserDataId);
            for (int i = userData.RangeFrom; i <= userData.RangeTo; i+=userData.Step)
            {
                int y = (int)(userData.A * Math.Pow(i, 2) + userData.B * i + userData.C);
                MyPoint myPoint = new MyPoint() { ChartId = id, PointX = i, PointY = y };
                mas.Add(myPoint);
                db.MyPoint.Add(myPoint);
            }
            db.SaveChanges();
            return mas;
        }

        private void check(ref UserData userData)
        {
            if (userData.RangeTo < userData.RangeFrom)
            {
                int c = userData.RangeTo;
                userData.RangeTo = userData.RangeFrom;
                userData.RangeFrom = c;
            }
            if (userData.Step < 0)
            {
                userData.Step *= -1;
            }
        }
    }
}