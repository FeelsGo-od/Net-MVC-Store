namespace RestSharpAPI.Models;

public class CartItem
{
    public decimal VariantId { get; set; }
    public string? Name { get; set; }
    public decimal RetailPrice { get; set; }
    public int Quantity
    {
        get => _quantity;
        set => _quantity = value >= 0 ? value : 0; // Ensure non-negative quantity
    }

    private int _quantity;

    public override bool Equals(object? obj)
    {
        if (obj == null || GetType() != obj.GetType())
        {
            return false;
        }
        
        CartItem other = (CartItem)obj;
        return VariantId == other.VariantId;
    }
    
    public override int GetHashCode()
    {
        return VariantId.GetHashCode();
    }
}
