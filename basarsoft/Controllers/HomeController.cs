using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using basarsoft.Data;
using basarsoft.Models;
using basarsoft.Services;
using basarsoft.Interfaces;

namespace basarsoft.Controllers
{
    [ApiController]
    [Route("api/items")]
    public class HomeController : ControllerBase
    {
        private readonly IItemsService _itemsService;

        public HomeController(ApplicationDbContext context, IItemsService itemsService)
        {
            _itemsService = itemsService;
        }

        [HttpGet()]
        public Response GetAllItems()
        {
            var result = new Response();
            try
            {
                result.Data = _itemsService.GetAllItems();
                result.Success = true;
                result.Message = "Items retrieved successfully.";
                result.StatusCode = 200; // OK
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"Error retrieving items: {ex.Message}";
                result.StatusCode = 500; // Internal Server Error
            }
            return result;
        }

        [HttpGet("{id}")]
        public Response GetItem(int id)
        {
            var result = new Response();
            try
            {
                var items = _itemsService.GetItemById(id);
                if (items.Any())
                {
                    result.Data = items;
                    result.Success = true;
                    result.Message = "Item retrieved successfully.";
                    // Islerin duzgun calistigini belirtir 
                    result.StatusCode = 200;
                }
                else
                {
                    result.Success = false;
                    result.Message = "Item not found.";
                    // Not Found zaten
                    result.StatusCode = 404;
                }
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"Error retrieving item: {ex.Message}";
                // Internal Server Error
                result.StatusCode = 500;
            }
            return result;
        }

        [HttpPost()]
        public Response CreateItem(Items obj)
        {
            var result = new Response();
            try
            {
                result.Data = _itemsService.CreateItem(obj);
                result.Success = true;
                result.Message = "Item created successfully.";
                result.StatusCode = 201; // Created
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"Error creating item: {ex.Message}";
                result.StatusCode = 500; // Internal Server Error
            }
            return result;
        }

        [HttpPut("{id}")]
        public Response UpdateItem(int id, [FromBody] Items obj)
        {
            var result = new Response();
            try
            {
                var updatedItems = _itemsService.UpdateItem(id, obj);
                if (updatedItems.Any())
                {
                    result.Data = updatedItems;
                    result.Success = true;
                    result.Message = "Item updated successfully.";
                    result.StatusCode = 200; // OK
                }
                else
                {
                    result.Success = false;
                    result.Message = "Item not found for update.";
                    result.StatusCode = 404; // Not Found
                }
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"Error updating item: {ex.Message}";
                result.StatusCode = 500; // Internal Server Error
            }
            return result;
        }

        [HttpDelete("{id}")]
        public Response DeleteItem(int id)
        {
            var result = new Response();
            try
            {
                var remainingItems = _itemsService.DeleteItem(id);
                if (remainingItems.Any())
                {
                    result.Data = remainingItems;
                    result.Success = true;
                    result.Message = "Item deleted successfully.";
                    result.StatusCode = 200; // OK
                }
                else
                {
                    result.Success = false;
                    result.Message = "Item not found for deletion.";
                     // Not Found
                    result.StatusCode = 404;
                }
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"Error deleting item: {ex.Message}";
                result.StatusCode = 500; // Internal Server Error
            }
            return result;
        }
    }
}
