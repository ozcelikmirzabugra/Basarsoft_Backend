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
    public interface ITodoServices<T> where T : class
    {
        Task<IEnumerable<T>> GetAllTodoAsync();
        Task<T> GetTodoByIdAsync(int id);
        Task AddTodoAsync(T todo);
        Task UpdateTodoAsync(T todo);
        Task DeleteTodoAsync(int id);
    }
}
