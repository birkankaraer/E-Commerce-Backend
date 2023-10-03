using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        IProductService productService;

        public ProductsController(IProductService productService)
        {
           this.productService = productService;
        }

        [HttpGet]
        public List<Product> Get()
        {
            
            var result = productService.GetAll();
            return result.Data;
        }
        
    }
}
