using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kai.Core.Product;
using Kai.Service.ProductService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Neo4j.Driver.V1;

namespace Kai.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [Route("GetAll")]
        [HttpGet]
       // [Authorize]
        public IActionResult GetProduct(string message)
        {
            var result = _productService.GetAllProduct();
            return Ok(result);
        }

        [Route("AddProduct")]
        [HttpPost]
        public IActionResult AddProduct([FromBody] ProductDto product)
        {
            if(product== null)
            {
                return BadRequest();
            }
            _productService.AddProduct(product);
            return Ok();
        }
    }
}