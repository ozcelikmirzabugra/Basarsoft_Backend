// using System.Collections.Generic;
// using System.Threading.Tasks;
// using basarsoft.Controllers;
// using basarsoft.Data;
// using basarsoft.Interfaces;
// // using basarsoft.Migrations;
// using basarsoft.Models;
// using basarsoft.Services;
// using basarsoft.UnitOfWork;
// using System.Collections.Generic;
// using System.Threading.Tasks;


// namespace basarsoft.Services
// {
//     public class ItemsServices : IItemsServices<Items>
//     {
//         private readonly IUnitOfWork _unitOfWork;

//         public ItemsServices(IUnitOfWork unitOfWork)
//         {
//             _unitOfWork = unitOfWork;
//         }

//         public async Task<IEnumerable<Items>> GetAllItemsAsync()
//         {
//             return await _unitOfWork.Repository<Items>().GetAllAsync();
//         }

//         public async Task<Items> GetItemByIdAsync(int id)
//         {
//             return await _unitOfWork.Repository<Items>().GetByIdAsync(id);
//         }

//         public async Task AddItemAsync(Items item)
//         {
//             await _unitOfWork.Repository<Items>().AddAsync(item);
//             await _unitOfWork.CommitAsync();
//         }

//         public async Task UpdateItemAsync(Items item)
//         {
//             _unitOfWork.Repository<Items>().Update(item);
//             await _unitOfWork.CommitAsync();
//         }

//         public async Task DeleteItemAsync(int id)
//         {
//             var item = await _unitOfWork.Repository<Items>().GetByIdAsync(id);
//             if (item != null)
//             {
//                 _unitOfWork.Repository<Items>().Remove(item);
//                 await _unitOfWork.CommitAsync();
//             }
//         }
//     }
// }
