using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace API_TEST_NET.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OperationController : ControllerBase
    {
        [HttpGet]
        public decimal Get(decimal a, decimal b)
        {
            return a + b;
        }

        [HttpPost]
        public decimal Add(Numbers numbers, [FromHeader] string Host)
        {
            Console.WriteLine(Host);
            return numbers.A + numbers.B;
        }
    }

     public class Numbers
    {
        public decimal A { get; set; }
        public decimal B { get; set; }
    }
}
