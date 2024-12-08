using Rira.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rira.Application.Interfaces
{
    public interface IProductService
    {
        IEnumerable<Product> GetProductsByCategory(Categories category);
        Product GetMostExpensiveProduct();
        double GetTotalPrice();
        IEnumerable<IGrouping<Categories, Product>> GetProductsGroupedByCategory();
        double GetAveragePrice();
    }
}
