namespace InventoryBinManagement
{
    public class Item
    {
        public Guid Id { get; set; }
        public string? Description { get; set; }
        public int Quantity { get; set; }
        public Guid BinId { get; set; }
    }
}
