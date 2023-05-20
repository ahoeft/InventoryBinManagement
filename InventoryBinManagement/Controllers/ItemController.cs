using InventoryBinManagement.Repo;
using Microsoft.AspNetCore.Mvc;

namespace InventoryBinManagement.Controllers
{
    [ApiController]
    [Route("User/API/[controller]")]
    public class ItemController : ControllerBase
    {
        private readonly ILogger<ItemController> _logger;
        private IRepo _repository;

        public ItemController(ILogger<ItemController> logger, IRepo repository)
        {
            _logger = logger;
            _repository = repository;
        }

        [HttpPost]
        public ActionResult<Item> AddItem(Item? item)
        {
            if (item == null) return new BadRequestResult();
            _repository.SaveItem(item);
            return new OkObjectResult(item);
        }

        [HttpPut("{id}")]
        public ActionResult<Item> AdjustItem(Guid id, Item item)
        {
            var existingItem = _repository.GetItem(id);
            if (existingItem == null) return new NotFoundObjectResult(id);
            _repository.SaveItem(existingItem); 
            return new OkObjectResult(item);
        }

        [HttpDelete("{id}")]
        public IActionResult RemoveItem(Guid id)
        {
            var existingItem = _repository.GetItem(id);
            if (existingItem == null) return new NotFoundResult();
            return new OkResult();
        }
    }
}