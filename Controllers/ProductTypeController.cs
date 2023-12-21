using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShoppingApp.Data;
using ShoppingApp.Models;

namespace ShoppingApp.Controllers
{
    public class ProductTypeController : Controller
    {
        private readonly Repository _repository;
        public ProductTypeController(Repository repository)
        {
            _repository = repository;
        }


        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(ProductType type)
        {
            if (ModelState.IsValid)
            {
                _repository.Types.Add(type);
                await _repository.SaveChangesAsync();
                return Redirect("/home/admin");

            }
            return View(type);
        }
        public async Task<IActionResult> Delete(int id)
        {
            var item = _repository.Types.Find(id);
            if (item == null) return NotFound();

            _repository.Types.Remove(item);
            await _repository.SaveChangesAsync();
            return Redirect("/home/admin");
        }

        public ActionResult CategoryList()
        {
            return View(_repository.Types);
        }
    }
}
