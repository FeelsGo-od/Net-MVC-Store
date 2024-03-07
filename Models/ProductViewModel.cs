using Newtonsoft.Json;

namespace RestSharpAPI.Models;

public class ProductsViewModel
{
    public int Code { get; set; }
    public required List<Products> Result { get; set; }
    public required List<object> Extra { get; set; }
    public required ProductsPaging Paging { get; set; }
}

public class Products
{
    public int Id { get; set; }

    [JsonProperty("external_id")]
    public required string ExternalId { get; set; }
    public required string Name { get; set; }
    public int Variants { get; set; }
    public int Synced { get; set; }

    [JsonProperty("thumbnail_url")]
    public required string ThumbnailUrl { get; set; }

    [JsonProperty("is_ignored")]
    public bool IsIgnored { get; set; }
}

public class ProductsPaging
{
    public int Total { get; set; }
    public int Offset { get; set; }
    public int Limit { get; set; }
}