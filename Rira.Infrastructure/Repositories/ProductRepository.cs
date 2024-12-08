using Rira.Domain.Entities;
using Rira.Domain.Interfaces;
using Rira.Infrastructure.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rira.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly Context _context;
        public ProductRepository(Context context)
        {
            _context = context;
        }
        public double GetAveragePrice()
        {
            return _context.Products.Average(p => p.Price);
        }

        public Product GetMostExpensiveProduct()
        {
            return _context.Products.OrderByDescending(p => p.Price).FirstOrDefault();
        }

        public IEnumerable<Product> GetProductsByCategory(Categories category)
        {
            return _context.Products.Where(p => p.Category == category);
        }

        public IEnumerable<IGrouping<Categories, Product>> GetProductsGroupedByCategory()
        {
            return _context.Products.GroupBy(p => p.Category);
        }

        public double GetTotalPrice()
        {
            return _context.Products.Sum(p => p.Price);
        }
    }
}
