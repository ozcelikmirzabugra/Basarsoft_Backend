using System.Collections.Generic;
using System.Threading.Tasks;
using basarsoft.Controllers;
using basarsoft.Data;
using basarsoft.Interfaces;
// using basarsoft.Migrations;
using basarsoft.Models;
using basarsoft.Services;
using basarsoft.UnitOfWork;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace basarsoft.Services
{
    public class TodoServices : ITodoServices <Todo>
    {
        private readonly IUnitOfWork _unitOfWork;

        public TodoServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Todo>> GetAllTodoAsync()
        {
            return await _unitOfWork.Repository<Todo>().GetAllAsync();
        }

        public async Task<Todo> GetTodoByIdAsync(int id)
        {
            return await _unitOfWork.Repository<Todo>().GetByIdAsync(id);
        }

        public async Task AddTodoAsync(Todo todo)
        {
            await _unitOfWork.Repository<Todo>().AddAsync(todo);
            await _unitOfWork.CommitAsync();
        }

        public async Task UpdateTodoAsync(Todo todo)
        {
            _unitOfWork.Repository<Todo>().Update(todo);
            await _unitOfWork.CommitAsync();
        }

        public async Task DeleteTodoAsync(int id)
        {
            var todo = await _unitOfWork.Repository<Todo>().GetByIdAsync(id);
            if (todo != null)
            {
                _unitOfWork.Repository<Todo>().Remove(todo);
                await _unitOfWork.CommitAsync();
            }
        }
    }
}
