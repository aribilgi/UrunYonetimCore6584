﻿using Microsoft.AspNetCore.Http;
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
        private readonly IService<Product> _service;
        private readonly IService<Category> _serviceCategory;
        private readonly IService<Brand> _serviceBrand;

        public ProductsController(IService<Product> service, IService<Category> serviceCategory, IService<Brand> serviceBrand)
        {
            _service = service;
            _serviceCategory = serviceCategory;
            _serviceBrand = serviceBrand;
        }

        // GET: ProductsController
        public ActionResult Index()
        {
            var model = _service.GetAll();
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
            ViewBag.BrandId = new SelectList(_serviceBrand.GetAll(), "Id", "Name");
            ViewBag.CategoryId = new SelectList(_serviceCategory.GetAll(), "Id", "Name");
            return View();
        }

        // GET: ProductsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ProductsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Product collection, IFormFile? Image, IFormFile? Image2, IFormFile? Image3)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProductsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
