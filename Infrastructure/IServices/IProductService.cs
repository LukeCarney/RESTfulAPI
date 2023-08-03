using Infrastructure.Models;
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
        Task<IEnumerable<ProductModel>> GetProducts();
        //IEnumerable<ProductModel> GetProductsFilter(string Like);
        Task<ProductModel> GetProduct(int id);
        Task<ProductModel> AddProduct(ProductModel product);
        Task<bool> UpdateProduct(int id, ProductModel product);
        Task<bool> DeleteProduct(int id);
    }
}
