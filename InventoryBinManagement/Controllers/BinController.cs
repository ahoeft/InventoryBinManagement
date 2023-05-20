using InventoryBinManagement.Repo;
using Microsoft.AspNetCore.Mvc;

namespace InventoryBinManagement.Controllers
{

    [ApiController]
    [Route("User/API/[controller]")]
    public class BinController
    {
        private IBinRepo _repository;

        public BinController(IBinRepo repository)
        {
            _repository = repository;
        }

        [HttpPost]
        public ActionResult<Bin> AddItemToBin(Guid id, Item item)
        {
            if (item == null) return new BadRequestResult();
            var bin = _repository.GetBin(id);
            bin?.Items?.Add(item);
            _repository.SaveItemToBin(id, item);
            return new OkObjectResult(item);
        }

        [HttpPut("{id}")]
        public IActionResult AdjustItemQuantity(Guid binId, Guid itemId, int quantity)
        {
            var bin = _repository.GetBin(binId);
            if(bin == null || bin.Items == null) return new NotFoundResult();
            var item = bin.Items.Find(x => x.Id == itemId);
            if (item == null) return new NotFoundResult();
            item.Quantity = quantity;
            _repository.SaveBin(bin);
            return new OkResult();
        }

        [HttpDelete("{id}")]
        public IActionResult RemoveItemFromBin(Guid binId, Guid itemId)
        {
            var bin = _repository.GetBin(binId);
            if(bin == null || bin.Items == null) return new NotFoundResult();
            var items = bin.Items.Where(x => x.Id != itemId).ToList();
            bin.Items = items;
            _repository.SaveBin(bin);
            return new OkResult();
        }

        [HttpPost(Name = "AddItem")]
        public IActionResult AddBin()
        {
            throw new NotImplementedException();
        }
    }
}
