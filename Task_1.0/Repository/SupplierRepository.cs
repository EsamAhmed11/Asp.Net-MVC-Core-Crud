using Task_1._0.Models;

namespace Task_1._0.Repository
{
    public class SupplierRepository:GenericRepository<Supplier>
    {
        private readonly ApplicationDbContext dbContext;

        public SupplierRepository(ApplicationDbContext dbContext):base(dbContext)
        {
            this.dbContext = dbContext;
        }
    }
}
