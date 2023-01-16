using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using shop.web.Data;
using shop.web.Services;

namespace shop.web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductBrandController : Controller
    {
        private readonly IProductBrandService _productBrandService;

        public ProductBrandController(IProductBrandService productBrandService)
        {
            _productBrandService = productBrandService;
        }

        // GET: Admin/ProductBrand
        public async Task<IActionResult> Index()
        {
            try
            {
                return View(await _productBrandService.GetBrands());
            }
            catch(Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        // GET: Admin/ProductBrand/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || !_productBrandService.BrandsExists())
                return NotFound();

            var productBrand = await _productBrandService.GetBrandById(id);
            if (productBrand == null)
                return NotFound();

            return View(productBrand);
        }

        // GET: Admin/ProductBrand/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/ProductBrand/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] ProductBrand productBrand)
        {
            if (ModelState.IsValid)
            {
                await _productBrandService.AddBrand(productBrand);

                return RedirectToAction(nameof(Index));
            }

            return View(productBrand);
        }

        // GET: Admin/ProductBrand/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || !_productBrandService.BrandsExists())
                return NotFound();

            var productBrand = _productBrandService.Find(id);
            if (productBrand == null)
                return NotFound();

            return View(productBrand);
        }

        // POST: Admin/ProductBrand/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] ProductBrand productBrand)
        {
            if (id != productBrand.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    await _productBrandService.UpdateBrand(productBrand);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_productBrandService.ProductBrandExists(productBrand.Id))
                        return NotFound();
                    else
                        throw;
                }

                return RedirectToAction(nameof(Index));
            }

            return View(productBrand);
        }

        // GET: Admin/ProductBrand/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || !_productBrandService.BrandsExists())
                return NotFound();

            var productBrand = _productBrandService.GetBrandById(id);
            if (productBrand == null)
                return NotFound();

            return View(productBrand);
        }

        // POST: Admin/ProductBrand/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (!_productBrandService.BrandsExists())
                return Problem("Entity set 'ApplicationDbContext.ProductBrands' is null.");

            await _productBrandService.DeleteBrand(id);

            return RedirectToAction(nameof(Index));
        }
    }
}
