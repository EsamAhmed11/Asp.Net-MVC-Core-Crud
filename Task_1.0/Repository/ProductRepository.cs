using Microsoft.EntityFrameworkCore;
using Task_1._0.Models;

namespace Task_1._0.Repository
{
    public class ProductRepository:GenericRepository<Product>
    {
        private readonly ApplicationDbContext context;

        public ProductRepository(ApplicationDbContext context ):base(context)
        {
            this.context = context;
        }
        //Extend Method (GetAllAsync) in Child Class
        public override async Task<IEnumerable<Product>> GetAllAsync()
        {
           return await  context.Products.Include(n=>n._Supplier).ToListAsync();
        }
    }
}
