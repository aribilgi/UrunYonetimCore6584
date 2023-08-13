using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using UrunYonetimCore6584.Core.Entities;
using UrunYonetimCore6584.MVCUI.Utils;
using UrunYonetimCore6584.Service.Abstract;

namespace UrunYonetimCore6584.MVCUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductsController : Controller
    {
        private readonly IProductService _service;
        private readonly IService<Category> _serviceCategory;
        private readonly IService<Brand> _serviceBrand;

        public ProductsController(IProductService service, IService<Category> serviceCategory, IService<Brand> serviceBrand)
        {
            _service = service;
            _serviceCategory = serviceCategory;
            _serviceBrand = serviceBrand;
        }

        // GET: ProductsController
        public async Task<ActionResult> Index()
        {
            var model = await _service.GetAllProductsByIncludeAsync();
            return View(model);
        }

        // GET: ProductsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ProductsController/Create
        public ActionResult Create()
        {
            ViewBag.BrandId = new SelectList(_serviceBrand.GetAll(), "Id", "Name");
            ViewBag.CategoryId = new SelectList(_serviceCategory.GetAll(), "Id", "Name");
            return View();
        }

        // POST: ProductsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateAsync(Product collection, IFormFile? Image, IFormFile? Image2, IFormFile? Image3)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (Image is not null)
                        collection.Image = await FileHelper.FileLoaderAsync(Image, "Products/");
                    if (Image2 is not null)
                        collection.Image2 = await FileHelper.FileLoaderAsync(Image2, "Products/");
                    if (Image3 is not null)
                        collection.Image3 = await FileHelper.FileLoaderAsync(Image3, "Products/");
                    await _service.AddAsync(collection);
                    await _service.SaveAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception hata)
                {
                    ModelState.AddModelError("", "Hata Oluştu!" + hata.Message);
                }
            }
            ViewBag.BrandId = new SelectList(_serviceBrand.GetAll(), "Id", "Name");
            ViewBag.CategoryId = new SelectList(_serviceCategory.GetAll(), "Id", "Name");
            return View();
        }

        // GET: ProductsController/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.BrandId = new SelectList(_serviceBrand.GetAll(), "Id", "Name");
            ViewBag.CategoryId = new SelectList(_serviceCategory.GetAll(), "Id", "Name");
            var model = _service.Find(id);
            return View(model);
        }

        // POST: ProductsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditAsync(int id, Product collection, IFormFile? Image, IFormFile? Image2, IFormFile? Image3)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (Image is not null)
                        collection.Image = await FileHelper.FileLoaderAsync(Image, "Products/");
                    if (Image2 is not null)
                        collection.Image2 = await FileHelper.FileLoaderAsync(Image2, "Products/");
                    if (Image3 is not null)
                        collection.Image3 = await FileHelper.FileLoaderAsync(Image3, "Products/");
                    _service.Update(collection);
                    await _service.SaveAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception hata)
                {
                    ModelState.AddModelError("", "Hata Oluştu!" + hata.Message);
                }
            }
            ViewBag.BrandId = new SelectList(_serviceBrand.GetAll(), "Id", "Name");
            ViewBag.CategoryId = new SelectList(_serviceCategory.GetAll(), "Id", "Name");
            return View();
        }

        // GET: ProductsController/Delete/5
        public async Task<ActionResult> DeleteAsync(int id)
        {
            var model = await _service.GetProductByIncludeAsync(id);
            return View(model);
        }

        // POST: ProductsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Product collection)
        {
            try
            {
                _service.Delete(collection);
                _service.Save();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
