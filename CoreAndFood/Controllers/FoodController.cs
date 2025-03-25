using CoreAndFood.Models;
using CoreAndFood.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using X.PagedList.Extensions;

namespace CoreAndFood.Controllers
{
    public class FoodController : Controller
    {
        //Context c = new Context();
        FoodRepository foodRepository = new FoodRepository();
        CategoryRepository categoryRepository = new CategoryRepository();
        public IActionResult Index(int page = 1)
        {
            return View(foodRepository.TList("Category").ToPagedList(page, 3));
        }

        public IActionResult AddFood()
        {
            List<SelectListItem> values = (from x in categoryRepository.TList()       //from x in c.Categories.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CategoryName,
                                               Value = x.CategoryID.ToString()
                                           }).ToList();
            ViewBag.v1 = values;
            return View();
        }

        [HttpPost]
        public IActionResult AddFood(Food p)
        {
            foodRepository.TAdd(p);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteFood(int id)
        {
            foodRepository.TDelete(new Food { FoodID = id });
            return RedirectToAction("Index");
        }

        public IActionResult GetFood(int id)
        {
            List<SelectListItem> values = (from y in categoryRepository.TList()       //from x in c.Categories.ToList()
                                           select new SelectListItem
                                           {
                                               Text = y.CategoryName,
                                               Value = y.CategoryID.ToString()
                                           }).ToList();
            ViewBag.v1 = values;

            var x = foodRepository.TGet(id);
            Food f = new Food
            {
                FoodID = x.FoodID,
                CategoryID = x.CategoryID,
                Name = x.Name,
                Price = x.Price,
                Stock = x.Stock,
                Description = x.Description,
                ImageUrl = x.ImageUrl
            };
            return View(f);
        }

        [HttpPost]
        public IActionResult UpdateFood(Food p)
        {
            var x = foodRepository.TGet(p.FoodID);
            x.Name = p.Name;
            x.Price = p.Price;
            x.Stock = p.Stock;
            x.ImageUrl = p.ImageUrl;
            x.Description = p.Description;
            x.CategoryID = p.CategoryID;

            foodRepository.TUpdate(x);
            return RedirectToAction("Index");
        }
    }
}
