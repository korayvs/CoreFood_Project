using CoreAndFood.Repository;
using Microsoft.AspNetCore.Mvc;

namespace CoreAndFood.ViewComponents
{
    public class CategoryGetList : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            CategoryRepository categoryrepository = new CategoryRepository();
            var cagorylist = categoryrepository.TList();
            return View(cagorylist);
        }
    }
}
