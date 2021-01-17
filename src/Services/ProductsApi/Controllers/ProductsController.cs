using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductsApi.Data.Interface;
using ProductsApi.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860
namespace ProductsApi.Controllers
{
    [Authorize]
    [Route("api/Products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        public ProductsController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        /// <summary>
        /// Get All product Details.
        /// </summary>
        [HttpGet]
        [Route("GetAllProducts")]
        [ProducesResponseType(typeof(List<ProductDetails>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllProducts()
        {
            var result =await  _productRepository.GetAllProduct();
            return Ok(result);
        }

        /// <summary>
        /// Get product Details based on ID.
        /// </summary>
        /// <param name="id"></param>
        [HttpGet]
        [Route("GetProduct/{id}")]
        [ProducesResponseType(typeof(ProductDetails), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetProduct(int id)
        {
            var result = await _productRepository.GetProduct(id);
            return Ok(result);
        }

        // POST api/<ProductsController>
        [HttpPost]
        public async Task<IActionResult> AddProduct(ProductDetails productDetails)
        {
             _productRepository.AddProduct(productDetails);
            return NoContent();
        }

        // PUT api/<ProductsController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(ProductDetails productDetails)
        {
            _productRepository.UpdateProduct(productDetails);
            return Ok();
        }

        // DELETE api/<ProductsController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(ProductDetails productDetails)
        {
            _productRepository.DeleteProduct( productDetails);
            return Ok();
        }
    }
}
