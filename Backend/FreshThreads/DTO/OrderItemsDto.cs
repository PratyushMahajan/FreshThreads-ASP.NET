public class OrderItemsDto
{
    public long OrderItemId { get; set; }
    public long OrdersId { get; set; }
    public string Service { get; set; }
    public string Item { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }
}
