using Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly GetDataInterface<Product> getDataService;
        public ProductsController(GetDataInterface<Product> getDataService, FormSubmitInterface<Product> formService)
        {
            this.getDataService = getDataService;
        }

        [HttpGet]
        public IActionResult GetProducts()
        {
            return Ok(getDataService.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetProductById(int id)
        {
            var product = getDataService.GetById(id);
            if (product == null) return NotFound();
            return Ok(product);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            getDataService.Delete(id);
            return Ok();
        }
    }
}
