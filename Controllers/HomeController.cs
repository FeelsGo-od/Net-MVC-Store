using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using RestSharpAPI.Models;
using RestSharp;
using Newtonsoft.Json;

namespace RestSharpAPI.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IConfiguration _config;
    private readonly string apiUrl = "https://api.printful.com/";

    public HomeController(ILogger<HomeController> logger, IConfiguration config)
    {
        _logger = logger;
        _config = config;
    }

    public IActionResult Index()
    {
        var apiKey = _config["MyApi:ApiKey"];
        var restClient = new RestClient(apiUrl);
        var request = new RestRequest("store/products");
        request.AddHeader("Authorization", $"Bearer {apiKey}");
        var response = restClient.Execute(request);
        if (response.StatusCode == System.Net.HttpStatusCode.OK)
        {
            var result = response.Content;
            var apiResponse = JsonConvert.DeserializeObject<ProductsViewModel>(result!);
            // Pass the response content to the view
            ViewBag.Products = apiResponse?.Result;
        }
        else
        {
            // Handle errors, e.g., redirect to an error page
            return RedirectToAction("Error");
        }
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
