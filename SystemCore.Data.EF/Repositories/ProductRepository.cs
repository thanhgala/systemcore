using System.Collections.Generic;
using System.Linq;
using SystemCore.Data.Entities;
using SystemCore.Data.IRepositories;

namespace SystemCore.Data.EF.Repositories
{
    public class ProductRepository : EFRepository<Product, int>, IProductRepository
    {
        AppDbContext _context;
        public ProductRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public List<Product> GetByAlias(string alias)
        {
            return _context.Products.Where(x => x.SeoAlias == alias).ToList();
        }
    }
}