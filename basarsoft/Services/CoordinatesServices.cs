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
    public class CoordinatesServices : ICoordinatesServices<Coordinates>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CoordinatesServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Coordinates>> GetAllCoordinatesAsync()
        {
            return await _unitOfWork.Repository<Coordinates>().GetAllAsync();
        }

        public async Task<Coordinates> GetCoordinateByIdAsync(int id)
        {
            return await _unitOfWork.Repository<Coordinates>().GetByIdAsync(id);
        }

        public async Task AddCoordinateAsync(Coordinates coordinate)
        {
            await _unitOfWork.Repository<Coordinates>().AddAsync(coordinate);
            await _unitOfWork.CommitAsync();
        }

        public async Task UpdateCoordinateAsync(Coordinates coordinate)
        {
            _unitOfWork.Repository<Coordinates>().Update(coordinate);
            await _unitOfWork.CommitAsync();
        }

        public async Task DeleteCoordinateAsync(int id)
        {
            var coordinate = await _unitOfWork.Repository<Coordinates>().GetByIdAsync(id);
            if (coordinate != null)
            {
                _unitOfWork.Repository<Coordinates>().Remove(coordinate);
                await _unitOfWork.CommitAsync();
            }
        }
    }
}
