using System.Collections.Generic;
using basarsoft.Interfaces;
using basarsoft.Models;

namespace basarsoft.Services
{
    public class ItemsService : IItemsService<Items>
    {
        private readonly IRepository<Items> _repository;

        public ItemsService(IRepository<Items> repository)
        {
            _repository = repository;
        }

        public IEnumerable<Items> GetAllItems()
        {
            return _repository.GetAll();
        }

        public Items GetItemById(int id)
        {
            return _repository.GetById(id);
        }

        public void CreateItem(Items item)
        {
            _repository.Add(item);
        }

        public void UpdateItem(int id, Items itemDto)
        {
            var existingItem = _repository.GetById(id);
            if (existingItem != null)
            {
                _repository.Update(itemDto);
            }
        }

        public void DeleteItem(int id)
        {
            _repository.Delete(id);
        }
    }
}
