using InventoryBinManagement;
using InventoryBinManagement.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace InventoryBinManagementTests;

public class ItemTests
{
    private readonly ILogger<ItemController> logger;
    private JsonRepo repo = new JsonRepo();


    public static Item GoodItem() 
    {
        return new Item() 
        {
            Id = Guid.NewGuid(),
            Description = "description",
            Quantity = 1,
            BinId = Guid.NewGuid(),
        };
    }

    [Fact]
    public void Add_Item_Fails_With_Null_Data()
    {
        var controller = new ItemController(logger, repo);
        var result = controller.AddItem(null);
        var expected = new BadRequestResult();
        Assert.Equal(result?.Result?.GetType().ToString(), expected.GetType().ToString());
    }

    [Fact]
    public void Add_A_Good_Item_Returns_Ok()
    {

        var item = GoodItem();
        var controller = new ItemController(logger, repo);
        var result = controller.AddItem(item);
        var expected = new OkObjectResult(item);
        Assert.Equal(result?.Result?.GetType().ToString(), expected.GetType().ToString());
    }

    [Fact]
    public void Missing_Removed_Item_Id_Returns_404()
    {
        var id = Guid.NewGuid();
        var controller = new ItemController(logger, repo);
        var result = controller.RemoveItem(id);
        var expected = new NotFoundResult();
        Assert.Equal(expected.GetType().ToString(), result.GetType().ToString());

    }

    [Fact]
    public void Can_Successfully_Remove_Existing()
    {
        var id  = Guid.NewGuid();
        var item = GoodItem();
        item.Id = id;
        var controller = new ItemController(logger, repo);
        var _ = controller.AddItem(item);
        var result = controller.RemoveItem(id);
        var expected = new OkResult();
        Assert.Equal(expected.GetType().ToString(), result.GetType().ToString());
    }
}
