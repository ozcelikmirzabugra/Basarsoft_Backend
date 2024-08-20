using System.Collections.Generic;
using basarsoft.Interfaces;
using basarsoft.Models;

namespace basarsoft.Services
{
    public class ItemsRepository : IItemsRepository<Items>
    {
        private readonly IItemsRepository<Items> _itemsRepository;

        public ItemsRepository(IItemsRepository<Items> itemsRepository)
        {
            _itemsRepository = itemsRepository;
        }

        public IEnumerable<Items> GetAllItems()
        {
            return _itemsRepository.GetAllItems().ToList();
        }

        public Items GetItemById(int id)
        {
            return _itemsRepository.GetItemById(id);
        }

        public void CreateItem(Items item)
        {
            _itemsRepository.CreateItem(item);
        }

        public void UpdateItem(int id, Items itemDto)
        {
            var existingItem = _itemsRepository.GetItemById(id);

            if (existingItem != null)
            {
                existingItem.Xcoordinate = itemDto.Xcoordinate;
                existingItem.Ycoordinate = itemDto.Ycoordinate;
                existingItem.Name = itemDto.Name;
                existingItem.Description = itemDto.Description;

                _itemsRepository.UpdateItem(id, existingItem);
            }
        }

        public void DeleteItem(int id)
        {
            _itemsRepository.DeleteItem(id);
        }
    }
}
