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
    public class HomeController : ControllerBase
    {
        private readonly ICoordinatesServices<Coordinates> _coordinatesService;

        public HomeController(ICoordinatesServices<Coordinates> coordinatesService)
        {
            _coordinatesService = coordinatesService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCoordinates()
        {
            try
            {
                var coordinates = await _coordinatesService.GetAllCoordinatesAsync();
                var response = new
                {
                    data = coordinates.Select(c => new
                    {
                        id = c.Id,
                        WKT = c.WKT,
                        Name = c.Name
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
        public async Task<IActionResult> GetCoordinateById(int id)
        {
            try
            {
                var coordinate = await _coordinatesService.GetCoordinateByIdAsync(id);
                if (coordinate == null)
                {
                    return NotFound(new Response
                    {
                        Success = false,
                        Message = "Coordinate not found.",
                        StatusCode = 404,
                        Data = null
                    });
                }

                return Ok(new Response
                {
                    Success = true,
                    Message = "Coordinate retrieved successfully.",
                    StatusCode = 200,
                    Data = new
                    {
                        id = coordinate.Id,
                        WKT = coordinate.WKT,
                        Name = coordinate.Name
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
        public async Task<IActionResult> CreateCoordinate([FromBody] Coordinates coordinate)
        {
            try
            {
                if (coordinate == null)
                {
                    return BadRequest(new Response
                    {
                        Success = false,
                        Message = "Invalid coordinate data.",
                        StatusCode = 400,
                        Data = null
                    });
                }

                await _coordinatesService.AddCoordinateAsync(coordinate);
                return CreatedAtAction(nameof(GetCoordinateById), new { id = coordinate.Id }, coordinate);
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
        public async Task<IActionResult> UpdateCoordinate(int id, [FromBody] Coordinates coordinate)
        {
            try
            {
                if (coordinate == null || id != coordinate.Id)
                {
                    return BadRequest(new Response
                    {
                        Success = false,
                        Message = "Invalid coordinate data or ID mismatch.",
                        StatusCode = 400,
                        Data = null
                    });
                }

                await _coordinatesService.UpdateCoordinateAsync(coordinate);
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
        public async Task<IActionResult> DeleteCoordinate(int id)
        {
            try
            {
                var coordinate = await _coordinatesService.GetCoordinateByIdAsync(id);
                if (coordinate == null)
                {
                    return NotFound(new Response
                    {
                        Success = false,
                        Message = "Coordinate not found.",
                        StatusCode = 404,
                        Data = null
                    });
                }

                await _coordinatesService.DeleteCoordinateAsync(id);
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
