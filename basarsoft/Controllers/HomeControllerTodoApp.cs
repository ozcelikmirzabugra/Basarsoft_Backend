using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using basarsoft.Interfaces;
using basarsoft.Models;

namespace basarsoft.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeControllerTodoApp : ControllerBase
    {
        private readonly ITodoServices<Todo> _todoService;

        public HomeControllerTodoApp(ITodoServices<Todo> todoService)
        {
            _todoService = todoService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTodo()
        {
            try
            {
                var todo = await _todoService.GetAllTodoAsync();
                var response = new
                {
                    data = todo.Select(c => new
                    {
                        id = c.Id,
                        name = c.Name
                    }).ToList()
                };

                return Ok(response);
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, new Response
                {
                    Success = false,
                    Message = $"An error occurred: {ex.Message}",
                    StatusCode = 500,
                    Data = null
                });
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTodoById(int id)
        {
            try
            {
                var todo = await _todoService.GetTodoByIdAsync(id);
                if (todo == null)
                {
                    return NotFound(new Response
                    {
                        Success = false,
                        Message = "todo not found.",
                        StatusCode = 404,
                        Data = null
                    });
                }

                return Ok(new Response
                {
                    Success = true,
                    Message = "todo retrieved successfully.",
                    StatusCode = 200,
                    Data = new
                    {
                        id = todo.Id,
                        name = todo.Name
                    }
                });
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, new Response
                {
                    Success = false,
                    Message = $"An error occurred: {ex.Message}",
                    StatusCode = 500,
                    Data = null
                });
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateTodo([FromBody] Todo todo)
        {
            try
            {
                if (todo == null)
                {
                    return BadRequest(new Response
                    {
                        Success = false,
                        Message = "Invalid todo data.",
                        StatusCode = 400,
                        Data = null
                    });
                }

                await _todoService.AddTodoAsync(todo);
                return CreatedAtAction(nameof(GetTodoById), new { id = todo.Id }, todo);
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, new Response
                {
                    Success = false,
                    Message = $"An error occurred: {ex.Message}",
                    StatusCode = 500,
                    Data = null
                });
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTodo(int id, [FromBody] Todo todo)
        {
            try
            {
                if (todo == null || id != todo.Id)
                {
                    return BadRequest(new Response
                    {
                        Success = false,
                        Message = "Invalid todo data or ID mismatch.",
                        StatusCode = 400,
                        Data = null
                    });
                }

                await _todoService.UpdateTodoAsync(todo);
                return NoContent();
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, new Response
                {
                    Success = false,
                    Message = $"An error occurred: {ex.Message}",
                    StatusCode = 500,
                    Data = null
                });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTodo(int id)
        {
            try
            {
                var todo = await _todoService.GetTodoByIdAsync(id);
                if (todo == null)
                {
                    return NotFound(new Response
                    {
                        Success = false,
                        Message = "todo not found.",
                        StatusCode = 404,
                        Data = null
                    });
                }

                await _todoService.DeleteTodoAsync(id);
                return NoContent();
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, new Response
                {
                    Success = false,
                    Message = $"An error occurred: {ex.Message}",
                    StatusCode = 500,
                    Data = null
                });
            }
        }
    }
}
