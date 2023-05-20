namespace InventoryBinManagement.Repo;

public interface IRepo
{
    public void SaveItem(Item item);
    public Item? GetItem(Guid id);
    public void RemoveItem(Guid id);
}
