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

        DataContext db = new DataContext();

        [HttpPost]
        public JsonResult BookSearch(string step, string from, string to, string a, string b, string c)
        {
            var userData = new UserData() { RangeFrom = double.Parse(from), RangeTo = double.Parse(to),
                Step = double.Parse(step), A = double.Parse(a), B = double.Parse(b), C = double.Parse(c)
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
            for (double i = userData.RangeFrom; i <= userData.RangeTo; i+=userData.Step)
            {
                double y = Math.Round(userData.A * Math.Pow(i, 2) + userData.B * i + userData.C, 3);
                MyPoint myPoint = new MyPoint() { ChartId = id, PointX = Math.Round(i,3), PointY = y };
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
                double c = userData.RangeTo;
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