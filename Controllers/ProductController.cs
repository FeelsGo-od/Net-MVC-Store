using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;
using RestSharpAPI.Models;

namespace RestSharpAPI.Controllers;

public class ProductController : Controller
{
    private readonly IConfiguration _config;
    private readonly string apiUrl = "https://api.printful.com/";

    public ProductController(IConfiguration config)
    {
        _config = config;
    }

    public IActionResult Details(int id)
    {
        // Retrieve the product details based on the id
        var apiKey = _config["MyApi:ApiKey"];
        var restClient = new RestClient(apiUrl);
        var request = new RestRequest($"store/products/{id}");
        request.AddHeader("Authorization", $"Bearer {apiKey}");
        var response = restClient.Execute(request);
        if (response.StatusCode == System.Net.HttpStatusCode.OK)
        {
            var result = response.Content;
            var apiResponse = JsonConvert.DeserializeObject<ProductModel>(result!);
            // Pass the response content to the view
            return View(apiResponse?.Result);
        }
        else
        {
            // Handle errors, e.g., redirect to an error page
            return RedirectToAction("Error");
        }
    }
}