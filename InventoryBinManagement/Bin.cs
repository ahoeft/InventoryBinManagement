namespace InventoryBinManagement
{
    public class Bin
    {
        public Guid Id { get; set; }
        public string? Description { get; set; }
        public List<Item>? Items { get; set; }   
    }
}
