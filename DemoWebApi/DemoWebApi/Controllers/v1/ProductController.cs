using DemoWebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Collections.Generic;

namespace DemoWebApi.Controllers.v1
{
    public class ProductsController : BaseApiController<ProductsController>
    {
        private readonly IOptions<Product> _products;

        public ProductsController(IOptions<Product> products)
        {
            _products = products;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IList<Product>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetAll()
        {
            var products = _products.Value;

            if (products == null)
                return NotFound();

            return Ok(products);
        }
    }
}
