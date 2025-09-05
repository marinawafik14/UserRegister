using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using UserRegisteration.DBContext;
using UserRegisteration.Interfaces;

namespace UserRegisteration.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ApplicationDbContext _dbcontext;
        private readonly DbSet<T> _dbset;

     
        public GenericRepository(ApplicationDbContext dbcontext) { 
        
        this._dbcontext = dbcontext;
            this._dbset = dbcontext.Set<T>();
        }
        public async Task<T> AddAsync(T entity)
        {
           await _dbset.AddAsync(entity);
            return entity;
        }


        public async Task<IEnumerable<T>> GetAllAsync()
        {
           return await _dbset.ToListAsync();
        }

        public async Task<T> GetById(int id)
        {
            return await _dbset.FindAsync(id);
        }

       public async Task DeleteAsync(int id)
       
        {
            var entity = await _dbset.FindAsync(id);
            if (entity != null)
            {
                _dbset.Remove(entity);
            }
        }

        public async Task<T> UpdateAsync(T entity)
        {
            _dbset.Update(entity);
            await _dbcontext.SaveChangesAsync();
            return entity;
        }
    }
    
}
