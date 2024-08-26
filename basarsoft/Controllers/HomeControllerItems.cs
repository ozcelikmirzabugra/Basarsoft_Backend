// using System.Collections.Generic;
// using System.Threading.Tasks;
// using Microsoft.AspNetCore.Mvc;
// using basarsoft.Interfaces;
// using basarsoft.Models;

// namespace basarsoft.Controllers
// {
//     [Route("api/[controller]")]
//     [ApiController]
//     public class HomeController : ControllerBase
//     {
//         private readonly IItemsServices<Items> _itemsService;

//         public HomeController(IItemsServices<Items> itemsService)
//         {
//             _itemsService = itemsService;
//         }

//         [HttpGet]
//         public async Task<IActionResult> GetAllItems()
//         {
//             try
//             {
//                 var items = await _itemsService.GetAllItemsAsync();
//                 return Ok(new Response
//                 {
//                     Success = true,
//                     Message = "Items retrieved successfully.",
//                     StatusCode = 200,
//                     Data = items
//                 });
//             }
//             catch (System.Exception ex)
//             {
//                 return StatusCode(500, new Response
//                 {
//                     Success = false,
//                     Message = $"An error occurred: {ex.Message}",
//                     StatusCode = 500,
//                     Data = null
//                 });
//             }
//         }

//         [HttpGet("{id}")]
//         public async Task<IActionResult> GetItemById(int id)
//         {
//             try
//             {
//                 var item = await _itemsService.GetItemByIdAsync(id);
//                 if (item == null)
//                 {
//                     return NotFound(new Response
//                     {
//                         Success = false,
//                         Message = "Item not found.",
//                         StatusCode = 404,
//                         Data = null
//                     });
//                 }

//                 return Ok(new Response
//                 {
//                     Success = true,
//                     Message = "Item retrieved successfully.",
//                     StatusCode = 200,
//                     Data = item
//                 });
//             }
//             catch (System.Exception ex)
//             {
//                 return StatusCode(500, new Response
//                 {
//                     Success = false,
//                     Message = $"An error occurred: {ex.Message}",
//                     StatusCode = 500,
//                     Data = null
//                 });
//             }
//         }

//         [HttpPost]
//         public async Task<IActionResult> CreateItem([FromBody] Items item)
//         {
//             try
//             {
//                 if (item == null)
//                 {
//                     return BadRequest(new Response
//                     {
//                         Success = false,
//                         Message = "Invalid item data.",
//                         StatusCode = 400,
//                         Data = null
//                     });
//                 }

//                 await _itemsService.AddItemAsync(item);
//                 return CreatedAtAction(nameof(GetItemById), new { id = item.Id }, new Response
//                 {
//                     Success = true,
//                     Message = "Item created successfully.",
//                     StatusCode = 201,
//                     Data = item
//                 });
//             }
//             catch (System.Exception ex)
//             {
//                 return StatusCode(500, new Response
//                 {
//                     Success = false,
//                     Message = $"An error occurred: {ex.Message}",
//                     StatusCode = 500,
//                     Data = null
//                 });
//             }
//         }

//         [HttpPut("{id}")]
//         public async Task<IActionResult> UpdateItem(int id, [FromBody] Items item)
//         {
//             try
//             {
//                 if (item == null || id != item.Id)
//                 {
//                     return BadRequest(new Response
//                     {
//                         Success = false,
//                         Message = "Invalid item data or ID mismatch.",
//                         StatusCode = 400,
//                         Data = null
//                     });
//                 }

//                 await _itemsService.UpdateItemAsync(item);
//                 return NoContent();
//             }
//             catch (System.Exception ex)
//             {
//                 return StatusCode(500, new Response
//                 {
//                     Success = false,
//                     Message = $"An error occurred: {ex.Message}",
//                     StatusCode = 500,
//                     Data = null
//                 });
//             }
//         }

//         [HttpDelete("{id}")]
//         public async Task<IActionResult> DeleteItem(int id)
//         {
//             try
//             {
//                 var item = await _itemsService.GetItemByIdAsync(id);
//                 if (item == null)
//                 {
//                     return NotFound(new Response
//                     {
//                         Success = false,
//                         Message = "Item not found.",
//                         StatusCode = 404,
//                         Data = null
//                     });
//                 }

//                 await _itemsService.DeleteItemAsync(id);
//                 return NoContent();
//             }
//             catch (System.Exception ex)
//             {
//                 return StatusCode(500, new Response
//                 {
//                     Success = false,
//                     Message = $"An error occurred: {ex.Message}",
//                     StatusCode = 500,
//                     Data = null
//                 });
//             }
//         }
//     }
// }
