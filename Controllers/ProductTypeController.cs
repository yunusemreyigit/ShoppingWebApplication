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
            _repository.Types.Add(type);
            await _repository.SaveChangesAsync();

            // if (TempData["preURL"] == null) return Redirect("/");

            // var preURL = TempData["preURL"].ToString();
            // return Redirect(preURL);
            return Redirect("/home/admin");
        }
        public async Task<IActionResult> Delete(int id)
        {
            var item = _repository.Types.Find(id);
            if (item == null) return NotFound();

            _repository.Types.Remove(item);
            await _repository.SaveChangesAsync();
            return Redirect("/home/admin");
        }
    }
}
