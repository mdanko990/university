using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ContosoUniversity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestsController : ControllerBase
    {
        public ILogger<TestsController> Logger { get; }

        public TestsController(ILogger<TestsController> logger)
        {
            Logger = logger;
        }

        // GET: api/<TestsController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            Logger.Log(LogLevel.Information, nameof(Get));
            return ["value1", "value2"];
        }

        // GET api/<TestsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<TestsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<TestsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<TestsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
