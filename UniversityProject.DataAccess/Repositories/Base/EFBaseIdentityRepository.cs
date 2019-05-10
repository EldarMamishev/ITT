using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UniversityProject.DataAccess.DataAccept;
using UniversityProject.DataAccess.Interfaces.Base;
using UniversityProject.Shared.Exceptions.DataAccessExceptions;

namespace UniversityProject.DataAccess.Repositories.Base
{
    public abstract class EFBaseIdentityRepository<T> : IBaseRepository<T> where T : IdentityUser<int>
    {
        #region Properties

        protected ApplicationDbContext _context;
        protected DbSet<T> _dbSet;

        #endregion

        #region Constructors

        public EFBaseIdentityRepository(ApplicationDbContext context)
        {
            _context = context;

            _dbSet = _context.Set<T>();
        }

        #endregion

        #region Public Methods

        public async Task Create(T item)
        {
            if (item != null)
            {
                _dbSet.Add(item);

                await _context.SaveChangesAsync();
            }
        }

        public async Task CreateMultiple(List<T> items)
        {
            if (items != null)
            {
                _dbSet.AddRange(items);

                await _context.SaveChangesAsync();
            }
        }

        public async Task Delete(int id)
        {
            T item = await _dbSet.FindAsync(id);

            if (item != null)
            {
                var dbEntry = _context.Entry(item);

                dbEntry.State = EntityState.Deleted;

                await _context.SaveChangesAsync();
            }
        }

        public async Task<T> Get(int id)
        {
            T item = await _dbSet.FindAsync(id);

            return item;
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            IEnumerable<T> items = await _dbSet.ToListAsync();

            return items;
        }

        public async Task Update(T item)
        {
            if (item != null)
            {
                var dbEntry = _context.Entry(item);

                if (dbEntry == null)
                {
                    var stringBuilder = new StringBuilder();

                    stringBuilder.AppendLine(string.Format("ItemId: {0}", item.Id));
                    stringBuilder.AppendLine(string.Format("Message: {0}", "Update error"));

                    string message = stringBuilder.ToString();

                    throw new DataAccessException(message);
                }

                dbEntry.State = EntityState.Modified;

                await _context.SaveChangesAsync();
            }
        }

        public async Task UpdateMultiple(List<T> items)
        {
            foreach (T item in items)
            {
                var dbEntry = default(EntityEntry<T>);

                if (item != null)
                {
                    dbEntry = _context.Entry(item);
                }

                if (dbEntry == null)
                {
                    var stringBuilder = new StringBuilder();

                    stringBuilder.AppendLine(string.Format("ItemId: {0}", item.Id));
                    stringBuilder.AppendLine(string.Format("Message: {0}", "Multiple update error"));

                    string message = stringBuilder.ToString();

                    throw new DataAccessException(message);
                }

                dbEntry.State = EntityState.Modified;
            }

            await _context.SaveChangesAsync();
        }

        #endregion
    }
}