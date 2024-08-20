using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using basarsoft.Interfaces;
using basarsoft.Models;

namespace basarsoft.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IItemsService<Items> _itemsService;

        public HomeController(IItemsService<Items> itemsService)
        {
            _itemsService = itemsService;
        }

        [HttpGet]
        public Response GetAllItems()
        {
            try
            {
                var items = _itemsService.GetAllItems();
                return new Response
                {
                    Success = true,
                    Message = "Items retrieved successfully.",
                    StatusCode = 200,
                    Data = items
                };
            }
            catch (Exception ex)
            {
                return new Response
                {
                    Success = false,
                    Message = $"An error occurred: {ex.Message}",
                    StatusCode = 500,
                    Data = null
                };
            }
        }

        [HttpGet("{id}")]
        public Response GetItemById(int id)
        {
            try
            {
                var item = _itemsService.GetItemById(id);
                if (item == null)
                {
                    return new Response
                    {
                        Success = false,
                        Message = "Item not found.",
                        StatusCode = 404,
                        Data = null
                    };
                }

                return new Response
                {
                    Success = true,
                    Message = "Item retrieved successfully.",
                    StatusCode = 200,
                    Data = item
                };
            }
            catch (Exception ex)
            {
                return new Response
                {
                    Success = false,
                    Message = $"An error occurred: {ex.Message}",
                    StatusCode = 500,
                    Data = null
                };
            }
        }

        [HttpPost]
        public Response CreateItem([FromBody] Items item)
        {
            try
            {
                if (item == null)
                {
                    return new Response
                    {
                        Success = false,
                        Message = "Invalid item data.",
                        StatusCode = 400,
                        Data = null
                    };
                }

                _itemsService.CreateItem(item);
                return new Response
                {
                    Success = true,
                    Message = "Item created successfully.",
                    StatusCode = 201,
                    Data = item
                };
            }
            catch (Exception ex)
            {
                return new Response
                {
                    Success = false,
                    Message = $"An error occurred: {ex.Message}",
                    StatusCode = 500,
                    Data = null
                };
            }
        }

        [HttpPut("{id}")]
        public Response UpdateItem(int id, [FromBody] Items itemDto)
        {
            try
            {
                if (itemDto == null || id != itemDto.Id)
                {
                    return new Response
                    {
                        Success = false,
                        Message = "Invalid item data or ID mismatch.",
                        StatusCode = 400,
                        Data = null
                    };
                }

                _itemsService.UpdateItem(id, itemDto);
                return new Response
                {
                    Success = true,
                    Message = "Item updated successfully.",
                    StatusCode = 204, // NoContent response
                    Data = null
                };
            }
            catch (Exception ex)
            {
                return new Response
                {
                    Success = false,
                    Message = $"An error occurred: {ex.Message}",
                    StatusCode = 500,
                    Data = null
                };
            }
        }

        [HttpDelete("{id}")]
        public Response DeleteItem(int id)
        {
            try
            {
                var item = _itemsService.GetItemById(id);
                if (item == null)
                {
                    return new Response
                    {
                        Success = false,
                        Message = "Item not found.",
                        StatusCode = 404,
                        Data = null
                    };
                }

                _itemsService.DeleteItem(id);
                return new Response
                {
                    Success = true,
                    Message = "Item deleted successfully.",
                    StatusCode = 204, // NoContent response
                    Data = null
                };
            }
            catch (Exception ex)
            {
                return new Response
                {
                    Success = false,
                    Message = $"An error occurred: {ex.Message}",
                    StatusCode = 500,
                    Data = null
                };
            }
        }
    }
}
