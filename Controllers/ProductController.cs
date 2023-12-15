using Microsoft.AspNetCore.Mvc;
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
        public IActionResult Home()
        {
            return View(_repository.Products);
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
            var file = Request.Form.Files[0];

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
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var item = _repository.Products.Find(id);
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
            if (item == null) return NotFound();
            return View();
        }
        [HttpPost]
        public IActionResult Update(Product product)
        {
            Product item = _repository.Products.Find(product.ProductId);
            _repository.Products.Remove(item);
            _repository.Products.Add(product);
            _repository.SaveChanges();
            return View();
        }
    }
}
