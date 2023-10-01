using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        [HttpGet]
        public List<Product> Get()
        {
            return new List<Product>
            {
                new Product {ProductId = 1, ProductName = "Elma"},
                new Product {ProductId = 2, ProductName = "Armut"},
            };
        }
        
    }
}
