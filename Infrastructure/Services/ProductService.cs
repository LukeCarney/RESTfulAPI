using Infrastructure.IServices;
using Microsoft.EntityFrameworkCore;
using RESTfulAPI;
using RESTfulAPI.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Models;

namespace Infrastructure.Services
{
    public class ProductService : IProductService
    {
        private readonly AppDbContext _context;
        public ProductService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ProductModel>> GetProducts()
        {
            return await _context.Products.Select(ProductModel.Projection).ToListAsync();

        }
        //public IEnumerable<ProductModel> GetProductsFilter(string Like)
        //{
        //    return _context.Products.FromSqlRaw("Select * from products  where name like '%" + Like+"%'");

        //}
        public async Task<ProductModel>GetProduct(int id)
        {
            var product = _context.Products.Where(x=>x.Id == id);
            var productModel = product.Select(ProductModel.Projection).SingleOrDefault();
            if (productModel == null)
            {
                return null;
            }
            return productModel;
        }
        public async Task<ProductModel> AddProduct(ProductModel product)
        {
    
            try
            {
                await _context.Products.AddAsync(new Product { 
                    
                    Id = product.Id,
                    Price = product.Price,
                    Name = product.Name
                });
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return null;
            }

            return product; 
        }
        public async Task<bool> UpdateProduct(int id, ProductModel product)
        {
            _context.Entry(new Product
            {

                Id = id,
                Price = product.Price,
                Name = product.Name
            }).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
                {
                    return false ;
                }
                else
                {
                    throw;
                }
            }
        }


        public async Task<bool> DeleteProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);

            if (product == null)
            {
                return false;
            }

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return true;

        }

        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.Id == id);
        }
    }

}

