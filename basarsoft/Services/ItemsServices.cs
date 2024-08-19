using System.Collections.Generic;
using System.Linq;
using basarsoft.Data;
using basarsoft.Interfaces;
using basarsoft.Models;
using Microsoft.EntityFrameworkCore;

namespace basarsoft.Services
{
    public class ItemsServices : IItemsService
    {
        private readonly ApplicationDbContext _context;

        public ItemsServices(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Items> GetAllItems()
        {
            return _context.Items.ToList();
        }

        public List<Items> GetItemById(int id)
        {
            var item = _context.Items.Where(x => x.Id == id).ToList();
            return item;
        }

        public List<Items> CreateItem(Items item)
        {
            _context.Items.Add(item);
            _context.SaveChanges();
            return _context.Items.ToList();
        }

        public List<Items> UpdateItem(int id, Items itemDto)
        {
            var existingItem = _context.Items.FirstOrDefault(x => x.Id == id);

            if (existingItem != null)
            {
                existingItem.Xcoordinate = itemDto.Xcoordinate;
                existingItem.Ycoordinate = itemDto.Ycoordinate;
                existingItem.Name = itemDto.Name;
                existingItem.Description = itemDto.Description;

                _context.SaveChanges();
            }

            return _context.Items.ToList();
        }

        public List<Items> DeleteItem(int id)
        {
            var item = _context.Items.FirstOrDefault(x => x.Id == id);

            if (item != null)
            {
                _context.Items.Remove(item);
                _context.SaveChanges();
            }

            return _context.Items.ToList();
        }
    }
}
