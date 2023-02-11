using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using shop.web.Areas.Admin.Models;

namespace shop.web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Test1()
        {
            ViewBag.TestEnumValues = Enum.GetValues(typeof(TestEnum)).Cast<TestEnum>().Select(item => new SelectListItem
            {
                Text = item.ToString(),
                Value = ((int)item).ToString()
            });

            return View();
        }

        [HttpPost]
        public IActionResult Test1(TestModel model)
        {
            if (ModelState.IsValid)
            {
                // Add To DB and return some page

                return RedirectToAction(nameof(Index));
            }

            ViewBag.TestEnumValues = Enum.GetValues(typeof(TestEnum)).Cast<TestEnum>().Select(item => new SelectListItem
            {
                Text = item.ToString(),
                Value = ((int)item).ToString()
            });

            return View(model);
        }
    }
}
