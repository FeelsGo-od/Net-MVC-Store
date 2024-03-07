namespace RestSharpAPI.Models;

public class OrderViewModel
{
    public required string ProductName { get; set; }
    public int Quantity { get; set; }
    public required string CustomerName { get; set; }
    public required string ShippingAddress { get; set; }
}