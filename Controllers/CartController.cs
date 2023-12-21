using System.IO.Compression;
using Microsoft.AspNetCore.Mvc;
using ShoppingApp.Data;
using ShoppingApp.Extensions;
using ShoppingApp.Models;

public class CartController : Controller
{
    Cart cart;
    private readonly Repository repository;

    public CartController(Repository repository)
    {
        this.repository = repository;
    }

    public void AddCart(int id)
    {
        cart = HttpContext.Session.Get<Cart>("Cart") == null ?
       new Cart() : HttpContext.Session.Get<Cart>("Cart");
        var product = repository.Products.Find(id);
        cart.Products.Add(product);
        HttpContext.Session.Set<Cart>("Cart", cart);
    }
    [HttpGet]
    public IActionResult RemoveFromCart(int id)
    {
        cart = HttpContext.Session.Get<Cart>("Cart");
        cart.Products.Remove(cart.Products.Find(x => x.ProductId == id));
        HttpContext.Session.Set<Cart>("Cart", cart);
        return RedirectToAction("DetailCart");
    }
    public IActionResult DetailCart()
    {
        ViewBag.cart = HttpContext.Session.Get<Cart>("Cart") == null ? new Cart() :
        HttpContext.Session.Get<Cart>("Cart");
        return View();
    }
}