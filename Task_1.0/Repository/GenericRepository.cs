
using Microsoft.EntityFrameworkCore;
using Task_1._0.IRepository;
using Task_1._0.Models;

namespace Task_1._0.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ApplicationDbContext Context;

        public GenericRepository(ApplicationDbContext  _Context)
        {
            this.Context = _Context;
        }

        //Add Async
        public  async Task AddAsync(T Entity)
        {
           await Context.Set<T>().AddAsync(Entity);
        }

        //Delete Async
        public  async Task DeleteAsync(int id)
        {
           var TEntity= await Context.Set<T>().FindAsync(id);
            if (TEntity != null)
                Context.Set<T>().Remove(TEntity);
            else
                throw new NullReferenceException();
        }

        // Reterve All 
        public virtual  async Task<IEnumerable<T>> GetAllAsync()
        {
            List<T> list = await Context.Set<T>().ToListAsync();
            if(list!=null)
                return list;
            else
                return Enumerable.Empty<T>();
        }

        //Get Entity By Id Async
        public async Task<T> GetByIdAsync(int id)
        {
            var TEntity = await Context.Set<T>().FindAsync(id);
            if(TEntity != null)
                return TEntity;
            else
                return null;
        }

        //Save changes Async
        public async Task SaveChange_()
        {
            await Context.SaveChangesAsync();
        }

        //Update Entity Async
        public async Task UpdateAsync(T Entity)
        {
            if (Entity == null)
            {
                throw new NullReferenceException();
            }
            else
            {
                Context.Set<T>().Update(Entity);
            }
        }
    }
}
