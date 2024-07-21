using Business.Abstract;
using Business.Concarte;
using DataAccess.Concrete;
using Enitites.Concarete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApıAngular2024.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpGet("GetALL")]

        public IActionResult GetALL()
        {
            var Result = _productService.GetAll();
            if(Result.Success)
            {
                return Ok(Result.Data);
            }
           
             return BadRequest(Result.Message);
           
        }
        [HttpGet("GetByID")]

        public IActionResult GetByID(int id)
        {
            var Result = _productService.GetByID(id);
            if (Result.Success)
            {
                return Ok(Result);
            }

            return BadRequest(Result );

        }
        [HttpPost("add")]
        public IActionResult add(Product product)
        {
            var result = _productService.Add(product);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
