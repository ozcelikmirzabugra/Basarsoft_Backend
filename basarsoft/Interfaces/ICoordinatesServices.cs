using System.Collections.Generic;
using System.Threading.Tasks;
using basarsoft.Controllers;
using basarsoft.Data;
using basarsoft.Interfaces;
// using basarsoft.Migrations;
using basarsoft.Models;
using basarsoft.Services;
using basarsoft.UnitOfWork;

namespace basarsoft.Interfaces
{
    public interface ICoordinatesServices<T> where T : class
    {
        Task<IEnumerable<T>> GetAllCoordinatesAsync();
        Task<T> GetCoordinateByIdAsync(int id);
        Task AddCoordinateAsync(T coordinate);
        Task UpdateCoordinateAsync(T coordinate);
        Task DeleteCoordinateAsync(int id);
    }
}
