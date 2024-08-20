// using System.Collections.Generic;
// using basarsoft.Interfaces;
// using basarsoft.Models;

// namespace basarsoft.Services
// {
//     public class ItemsServices : IItemsService
//     {
//         private readonly IItemsRepository _itemsRepository;

//         public ItemsServices(IItemsRepository itemsRepository)
//         {
//             _itemsRepository = itemsRepository;
//         }

//         public List<Items> GetAllItems()
//         {
//             return _itemsRepository.GetAll();
//         }

//         public List<Items> GetItemById(int id)
//         {
//             var item = _itemsRepository.GetById(id);
//             return new List<Items> { item };
//         }

//         public List<Items> CreateItem(Items itemsModel)
//         {
//             _itemsRepository.Add(itemsModel);
//             return _itemsRepository.GetAll();
//         }

//         public List<Items> UpdateItem(int id, Items itemsRequestDto)
//         {
//             var existingItem = _itemsRepository.GetById(id);

//             if (existingItem != null)
//             {
//                 existingItem.Xcoordinate = itemsRequestDto.Xcoordinate;
//                 existingItem.Ycoordinate = itemsRequestDto.Ycoordinate;
//                 existingItem.Name = itemsRequestDto.Name;
//                 existingItem.Description = itemsRequestDto.Description;

//                 _itemsRepository.Update(existingItem);
//             }

//             return _itemsRepository.GetAll();
//         }

//         public List<Items> DeleteItem(int id)
//         {
//             _itemsRepository.Delete(id);
//             return _itemsRepository.GetAll();
//         }
//     }
// }
