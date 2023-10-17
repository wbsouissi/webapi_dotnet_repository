using MicroService1.Services;
using Microsoft.AspNetCore.Mvc;

namespace MicroService1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IProductService _productService;
       
        public ProductController(ILogger<WeatherForecastController> logger, IProductService productService)
        {
            _logger = logger;
            _productService = productService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllProduct()
        {
            return Ok(await _productService.GetAllProduct());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {           
            return Ok(await _productService.GetProduct(id));
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct([FromBody] Product product)
        {
            return Ok(await _productService.AddProduct(product));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProduct(int id, Product request)
        {
            var product = await _productService.UpdateProduct(id, request);
            if (product is null)
                return NotFound("le produit n'existe pas.");

            return Ok(product);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await _productService.DeleteProduct(id);
            if (product is null)
                return NotFound("le produit n'existe pas.");

            return Ok(product);
        }
    }
}
 