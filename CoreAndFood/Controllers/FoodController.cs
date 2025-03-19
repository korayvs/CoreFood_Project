using CoreAndFood.Models;
using CoreAndFood.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CoreAndFood.Controllers
{
    public class FoodController : Controller
    {
        //Context c = new Context();
        FoodRepository foodRepository = new FoodRepository();
        public IActionResult Index()
        {
            return View(foodRepository.TList("Category"));
        }

        public IActionResult AddFood()
        {
            CategoryRepository categoryRepository = new CategoryRepository();

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
    }
}
