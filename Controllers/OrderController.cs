using Microsoft.AspNetCore.Mvc;
using RestSharpAPI.Models;

public class OrderController : Controller
{
    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(OrderViewModel order)
    {
        // Process the order, save to database, etc.
        // Here, you can add your server-side logic to handle the order submission.
        string orderId = Guid.NewGuid().ToString();

        return RedirectToAction("Confirmation");
    }

    public IActionResult Confirmation()
    {
        return View();
    }
}