using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShoppingApp.Data;
using ShoppingApp.Models;

namespace ShoppingApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly Repository _repository;
        private readonly IWebHostEnvironment _environment;
        public ProductController(Repository repository, IWebHostEnvironment enviroment)
        {
            _repository = repository;
            _environment = enviroment;
        }
        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.typeList = _repository.Types.ToList();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(Product product)
        {
            if (ModelState.IsValid)
            {
                IFormFile file = null;
                if (Request.Form.Files.Count > 0)
                {
                    file = Request.Form.Files[0];
                }

                if (file != null && file.Length > 0)
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        await file.CopyToAsync(memoryStream);
                        product.Image = memoryStream.ToArray();

                    }
                }
                _repository.Products.Add(product);
                await _repository.SaveChangesAsync();
                return Redirect("/home/admin");
            }
            ViewBag.typeList = _repository.Types.ToList();
            return View(product);
        }
        [HttpGet]
        public IActionResult Details(int id)
        {
            Product item = _repository.Products.Find(id);
            if (item != null)
            {
                return View(model: item);
            }
            return Redirect("/Home/Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var item = await _repository.Products
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (item == null)
            {
                return NotFound();
            }
            _repository.Products.Remove(item);
            await _repository.SaveChangesAsync();
            return Redirect("/home/admin");
        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            Product item = _repository.Products.Find(id);
            ViewBag.typeList = _repository.Types.ToList();
            if (item == null) return NotFound();
            return View(item);
        }
        [HttpPost]
        public async Task<IActionResult> Update(Product product)
        {
            if (ModelState.IsValid)
            {
                IFormFile file = null;
                if (Request.Form.Files.Count > 0)
                {
                    file = Request.Form.Files[0];
                }

                if (file != null && file.Length > 0)
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        file.CopyTo(memoryStream);
                        product.Image = memoryStream.ToArray();

                    }
                }

                _repository.Update(product);
                await _repository.SaveChangesAsync();
                return Redirect("/home/admin");
            }
            ViewBag.typeList = _repository.Types.ToList();
            return View(product);
        }
    }
}
