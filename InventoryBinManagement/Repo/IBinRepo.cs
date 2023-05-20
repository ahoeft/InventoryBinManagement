namespace InventoryBinManagement.Repo;

public interface IBinRepo
{
    public void SaveItemToBin(Guid binId, Item item);
    public void SaveBin(Bin bin);
    public Bin? GetBin(Guid id);
    public void RemoveItem(Guid id);
}
