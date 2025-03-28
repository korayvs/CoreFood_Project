using CoreAndFood.Models;
using CoreAndFood.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoreAndFood.Controllers
{
    [AllowAnonymous]
    public class ChartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Index2()
        {
            return View();
        }

        public IActionResult VisualizeProductResult()
        {
            return Json(ProList());
        }

        public List<Class1> ProList()
        {
            List<Class1> cs = new List<Class1>();
            cs.Add(new Class1()
            {
                proname = "Computer",
                stock = 150
            });
            cs.Add(new Class1()
            {
                proname = "LCD",
                stock = 75
            });
            cs.Add(new Class1()
            {
                proname = "Usb Disk",
                stock = 220
            });
            return cs;
        }
                
        public IActionResult Index3()
        {
            return View();
        }

        public IActionResult VisualizeProductResult2()
        {
            return Json(FoodList());
        }

        public List<Class2> FoodList()
        {
            List<Class2> cs2 = new List<Class2>();
            using (var c = new Context())
            {
                cs2 = c.Foods.Select(x => new Class2
                {
                    foodname = x.Name,
                    stock = x.Stock
                }).ToList();
            }
            return cs2;
        }

        public IActionResult Statistics()
        {
            FoodRepository f = new FoodRepository();
            CategoryRepository c = new CategoryRepository();

            var value1 = f.TList().Count();
            ViewBag.v1 = value1;

            var value2 = c.TList().Count();
            ViewBag.v2 = value2;

            var foid = c.TList().Where(x => x.CategoryName == "Fruit").Select(y => y.CategoryID).FirstOrDefault();
            //ViewBag.v = foid;
            var value3 = f.TList().Where(x => x.CategoryID == foid).Count();
            ViewBag.v3 = value3;

            var value4 = f.TList().Where(x => x.CategoryID == c.TList().Where(z => z.CategoryName == "Vegetables").Select(y => y.CategoryID).FirstOrDefault()).Count();
            ViewBag.v4 = value4;

            var value5 = f.TList().Sum(x => x.Stock);
            ViewBag.v5 = value5;

            var value6 = f.TList().Where(x => x.CategoryID == c.TList().Where(y => y.CategoryName == "Legumes").Select(z => z.CategoryID).FirstOrDefault()).Count();
            ViewBag.v6 = value6;

            var value7 = f.TList().OrderByDescending(x => x.Stock).Select(y => y.Name).FirstOrDefault();
            ViewBag.v7 = value7;

            var value8 = f.TList().OrderBy(x => x.Stock).Select(y => y.Name).FirstOrDefault();
            ViewBag.v8 = value8;

            var value9 = f.TList().Average(x => x.Price).ToString("0.00");
            ViewBag.v9 = value9;

            var value10 = c.TList().Where(x => x.CategoryName == "Fruit").Select(y => y.CategoryID).FirstOrDefault();
            var value10p = f.TList().Where(y => y.CategoryID == value10).Sum(x => x.Stock);
            ViewBag.v10 = value10p;

            var value11 = c.TList().Where(x => x.CategoryName == "Vegetables").Select(y => y.CategoryID).FirstOrDefault();
            var value11p = f.TList().Where(y => y.CategoryID == value11).Sum(x => x.Stock);
            ViewBag.v11 = value11p;

            var value12 = f.TList().OrderByDescending(x => x.Price).Select(y => y.Name).FirstOrDefault();
            ViewBag.v12 = value12;


            return View();
        }
    }
}
