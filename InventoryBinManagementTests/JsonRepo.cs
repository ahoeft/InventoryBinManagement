using InventoryBinManagement;
using InventoryBinManagement.Repo;
using System.Text.Json;

namespace InventoryBinManagementTests;

public class JsonRepo : IRepo
{

    private readonly string repoLocation = "C:\\Code\\InventoryBinManagement\\InventoryBinManagementTests\\Item.json";

    public Item? GetItem(Guid id)
    {
        var txt = File.ReadAllText(repoLocation);
        var items = JsonSerializer.Deserialize<List<Item>>(txt);
        return items?.Find( x => x.Id == id);
    }

    public void RemoveItem(Guid id)
    {
        var txt = File.ReadAllText(repoLocation);
        var items = JsonSerializer.Deserialize<List<Item>>(txt);
        var lessItems = items?.Where( x => x.Id != id);

        string jsonString = JsonSerializer.Serialize(lessItems);
        File.WriteAllText(repoLocation, jsonString);
    }

    public void SaveItem(Item item)
    {
        var txt = File.ReadAllText(repoLocation);
        var items = JsonSerializer.Deserialize<List<Item>>(txt);
        items?.Add(item);
        string jsonString = JsonSerializer.Serialize(items);
        File.WriteAllText(repoLocation, jsonString);
    }
}
