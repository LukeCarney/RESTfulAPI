using Microsoft.EntityFrameworkCore;
using RESTfulAPI.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.IServices
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetProducts();
        IEnumerable<Product> GetProductsFilter(string Like);
        Task<Product> GetProduct(int id);
        Task<Product> AddProduct(Product product);
        Task<Product> UpdateProduct(int id, Product product);
        Task<bool> DeleteProduct(int id);
    }
}
