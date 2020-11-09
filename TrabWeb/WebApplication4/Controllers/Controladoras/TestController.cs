using Microsoft.AspNetCore.Mvc;

namespace WebApplication4.Controllers.Controladoras
{
    public class TestController : Controller
    {
        [HttpGet("nome")]
        public IActionResult Get()
        {  
            return Ok(new { name = "Tiago"});
        }
    }
}