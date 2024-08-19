using System.Collections.Generic;
// using basarsoft.Dtos.Items;
using basarsoft.Models;

namespace basarsoft.Interfaces
{
    public interface IItemsService
    {
        List<Items> GetAllItems();
        List<Items> GetItemById(int id);
        List<Items> CreateItem(Items itemsModel);
        List<Items> UpdateItem(int id, Items itemsRequestDto);
        List<Items> DeleteItem(int id);
    }
}
