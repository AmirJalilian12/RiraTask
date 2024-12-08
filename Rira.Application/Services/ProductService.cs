using Rira.Application.Interfaces;
using Rira.Domain.Entities;
using Rira.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rira.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public double GetAveragePrice()
        {
            return _productRepository.GetAveragePrice();
        }

        public Product GetMostExpensiveProduct()
        {
            return _productRepository.GetMostExpensiveProduct();
        }

        public IEnumerable<Product> GetProductsByCategory(Categories category)
        {
            return _productRepository.GetProductsByCategory(category);
        }

        public IEnumerable<IGrouping<Categories, Product>> GetProductsGroupedByCategory()
        {
            return _productRepository.GetProductsGroupedByCategory();
        }

        public double GetTotalPrice()
        {
            return _productRepository.GetTotalPrice();
        }
    }
}
