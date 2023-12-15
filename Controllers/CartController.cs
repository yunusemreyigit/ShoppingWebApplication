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
    public void RemoveFromCart(int id)
    {
        cart = HttpContext.Session.Get<Cart>("Cart");
        Product temp = new Product();
        temp.ProductId = id;
        cart.Products.Remove(temp);
        HttpContext.Session.Set<Cart>("Cart", cart);
        Console.WriteLine("Extracted :" + id);
    }
    public IActionResult DetailCart()
    {
        ViewBag.cart = HttpContext.Session.Get<Cart>("Cart") == null ? new Cart() :
        HttpContext.Session.Get<Cart>("Cart");
        return View();
    }
}