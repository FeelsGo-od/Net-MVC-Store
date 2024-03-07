using Newtonsoft.Json;

namespace RestSharpAPI.Models;

public partial class ProductModel
{
    [JsonProperty("code")]
    public long Code { get; set; }

    [JsonProperty("result")]
    public ProductResult? Result { get; set; }

    [JsonProperty("extra")]
    public object[]? Extra { get; set; }
}

public partial class ProductResult
{
    [JsonProperty("sync_product")]
    public SyncProduct? SyncProduct { get; set; }

    [JsonProperty("sync_variants")]
    public SyncVariant[]? SyncVariants { get; set; }
}

public partial class SyncProduct
{
    [JsonProperty("id")]
    public long Id { get; set; }

    [JsonProperty("external_id")]
    public string? ExternalId { get; set; }

    [JsonProperty("name")]
    public string? Name { get; set; }

    [JsonProperty("variants")]
    public long Variants { get; set; }

    [JsonProperty("synced")]
    public long Synced { get; set; }

    [JsonProperty("thumbnail_url")]
    public Uri? ThumbnailUrl { get; set; }

    [JsonProperty("is_ignored")]
    public bool IsIgnored { get; set; }
}

public partial class SyncVariant
{
    [JsonProperty("id")]
    public long Id { get; set; }

    [JsonProperty("external_id")]
    public string? ExternalId { get; set; }

    [JsonProperty("sync_product_id")]
    public long SyncProductId { get; set; }

    [JsonProperty("name")]
    public string? Name { get; set; }

    [JsonProperty("synced")]
    public bool Synced { get; set; }

    [JsonProperty("variant_id")]
    public long VariantId { get; set; }

    [JsonProperty("main_category_id")]
    public long MainCategoryId { get; set; }

    [JsonProperty("warehouse_product_variant_id")]
    public object? WarehouseProductVariantId { get; set; }

    [JsonProperty("retail_price")]
    public string? RetailPrice { get; set; }

    [JsonProperty("sku")]
    public string? Sku { get; set; }

    [JsonProperty("currency")]
    public string? Currency { get; set; }

    [JsonProperty("product")]
    public ProductDetails? Product { get; set; }

    [JsonProperty("files")]
    public ProductFile[]? Files { get; set; }

    [JsonProperty("options")]
    public ProductOption[]? Options { get; set; }

    [JsonProperty("is_ignored")]
    public bool IsIgnored { get; set; }

    [JsonProperty("size")]
    public string? Size { get; set; }

    [JsonProperty("color")]
    public string? Color { get; set; }

    [JsonProperty("availability_status")]
    public string? AvailabilityStatus { get; set; }
}

public partial class ProductFile
{
    [JsonProperty("id")]
    public long Id { get; set; }

    [JsonProperty("type")]
    public string? Type { get; set; }

    [JsonProperty("hash")]
    public string? Hash { get; set; }

    [JsonProperty("url")]
    public object? Url { get; set; }

    [JsonProperty("filename")]
    public string? Filename { get; set; }

    [JsonProperty("mime_type")]
    public string? MimeType { get; set; }

    [JsonProperty("size")]
    public long Size { get; set; }

    [JsonProperty("width")]
    public long Width { get; set; }

    [JsonProperty("height")]
    public long Height { get; set; }

    [JsonProperty("dpi")]
    public long? Dpi { get; set; }

    [JsonProperty("status")]
    public string? Status { get; set; }

    [JsonProperty("created")]
    public long Created { get; set; }

    [JsonProperty("thumbnail_url")]
    public Uri? ThumbnailUrl { get; set; }

    [JsonProperty("preview_url")]
    public Uri? PreviewUrl { get; set; }

    [JsonProperty("visible")]
    public bool Visible { get; set; }

    [JsonProperty("is_temporary")]
    public bool IsTemporary { get; set; }

    [JsonProperty("stitch_count_tier")]
    public object? StitchCountTier { get; set; }
}

public partial class ProductOption
{
    [JsonProperty("id")]
    public string? Id { get; set; }

    [JsonProperty("value")]
    public object? Value { get; set; }
}

public partial class ProductDetails
{
    [JsonProperty("variant_id")]
    public long VariantId { get; set; }

    [JsonProperty("product_id")]
    public long ProductId { get; set; }

    [JsonProperty("image")]
    public Uri? Image { get; set; }

    [JsonProperty("name")]
    public string? Name { get; set; }
}