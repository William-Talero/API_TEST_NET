using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace API_TEST_NET.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SomeController : ControllerBase
    {
        [HttpGet("sync")]
        public IActionResult GetSync()
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            stopwatch.Start();

            Thread.Sleep(1000);
            Console.WriteLine("Conexión a la base de datos.");

            Thread.Sleep(1000);
            Console.WriteLine("Envio de mail terminado.");

            Console.WriteLine("Todo ha terminado.");

            stopwatch.Stop();

            return Ok(stopwatch.Elapsed);
        }

        [HttpGet("async")]
        public async Task<IActionResult> GetAsync()
        {
            var task1 = new Task<int>(() =>
            {
                Thread.Sleep(1000);
                Console.WriteLine("Conexión a la base de datos.");
                return 1;
            });

            task1.Start();

            Console.WriteLine("Hago otra cosa");

            var result1 = await task1;

            Console.WriteLine("Todo ha termiando");

       
            return Ok(result1);
        }
    }
}
