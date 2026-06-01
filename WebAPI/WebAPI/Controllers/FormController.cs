using Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FormController : ControllerBase
    {

        private readonly FormSubmitInterface<Product> formSubmitService;

        public FormController(FormSubmitInterface<Product> formSubmitService)
        {
            this.formSubmitService = formSubmitService;
        }

        [HttpPost]
        public IActionResult Add([FromBody] Product product)
        {
            formSubmitService.Add(product);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Update( int id, [FromBody] Product product)
        {
            formSubmitService.Update(id, product);
            return Ok();
        }

       
    }
}
