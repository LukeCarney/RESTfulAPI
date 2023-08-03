using Domain.APIModels;
using Domain.Helpers;
using Infrastructure.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using RESTfulAPI.EntityModels;
using System.Runtime.CompilerServices;

namespace RESTfulAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly ILogger<ProductController> _logger;
        ProductHelper productHelper = new ProductHelper();

        /// <summary>
        /// API Controller for Products
        /// </summary>

        public ProductController(ILogger<ProductController> logger
            , IProductService productService
            )
        {
            _logger = logger;
            _productService = productService;
        }
        [HttpGet]
        public async Task<ActionResult> Get([FromQuery] FilterModel filterModel)
        {
            var products = await _productService.GetProducts();
            string validate = productHelper.ValidateFilter(filterModel);
            if(validate != "")
            {
                return BadRequest(validate);
            }
            products = productHelper.FilterProducts(products, filterModel);
            if(products.Count() == 0)
            {
                return NotFound("No products match your parameters.");
            }
            return Ok(products);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            if (await _productService.GetProduct(id) == null)
            {
                return NotFound("Product Not Found");
            }
            return Ok(await _productService.GetProduct(id));
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, Product product)
        {
            if (await _productService.GetProduct(id) == null)
            {
                return NotFound("Product Not Found");
            }
            var products= await _productService.GetProducts();
            string validationMessage = productHelper.ValidateProduct(product, products.ToList());
            if(validationMessage != "")
            {
                return BadRequest(validationMessage);
            }
            if (await _productService.UpdateProduct(id, product) == null)
            {
                return BadRequest();
            }
            return Ok(product);
        }
        [HttpPost]
        public async Task<ActionResult> Post(Product product)
        {
            var products = await _productService.GetProducts();
            string validationMessage = productHelper.ValidateProduct(product, products.ToList());
            if (validationMessage != "")
            {
                return BadRequest(validationMessage);
            }
            if (await _productService.AddProduct(product)== null)
            {
                return BadRequest();
            }
            return Ok(product);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            if (await _productService.GetProduct(id) == null)
            {
                return NotFound("Product Not Found.");
            }
            if (await _productService.DeleteProduct(id) == true)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
            
        }

    }
}
