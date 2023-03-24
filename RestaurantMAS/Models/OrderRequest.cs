namespace RestaurantMAS.Models;

public class OrderRequest
{
    public string ClientId { get; set; }
    public string[] Items { get; set; }
}