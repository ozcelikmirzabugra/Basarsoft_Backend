using System.Collections.Generic;
using System.Linq;
using basarsoft.Data;
using basarsoft.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace basarsoft.Services
{
    public class ItemsServices<T> : IItemsService<T> where T : class
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<T> _dbSet;

        public ItemsServices(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public IEnumerable<T> GetAllItems()
        {
            return _dbSet.ToList();
            //return _dbSet.GetAllItems.ToList(); UOW kullaninca bu konuma gececek.
        }

        public T GetItemById(int id)
        {
            return _dbSet.Find(id);
        }

        public void CreateItem(T item)
        {
            _dbSet.Add(item);
            _context.SaveChanges();
        }

        public void UpdateItem(int id, T itemDto)
        {
            var existingItem = _dbSet.Find(id);

            if (existingItem != null)
            {
                _context.Entry(existingItem).CurrentValues.SetValues(itemDto);
                _context.SaveChanges();
            }
        }

        public void DeleteItem(int id)
        {
            var item = _dbSet.Find(id);

            if (item != null)
            {
                _dbSet.Remove(item);
                _context.SaveChanges();
            }
        }
    }
}
