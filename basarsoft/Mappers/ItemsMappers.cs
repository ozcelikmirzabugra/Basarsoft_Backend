// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;
// using basarsoft.Models;
// using basarsoft.Dtos.Items;

// namespace basarsoft.Mappers
// {
//     public static class ItemsMappers
//     {
//         public static ItemsDto ToItemsDto(this Items itemsModel) 
//         {
//             return new ItemsDto
//             {
//                 Id = itemsModel.Id,
//                 Xcoordinate = itemsModel.Xcoordinate,
//                 Ycoordinate = itemsModel.Ycoordinate,
//                 Name = itemsModel.Name,
//                 Description = itemsModel.Description
//             };
//         }

//         public static Items ToItemsFromCreateDto(this CreateItemsRequestDto itemsDto)
//         {
//             return new Items
//             {
//                 Id = itemsDto.Id,
//                 Xcoordinate = itemsDto.Xcoordinate,
//                 Ycoordinate = itemsDto.Ycoordinate,
//                 Name = itemsDto.Name,
//                 Description = itemsDto.Description
//             };
//         }
//     }
// }