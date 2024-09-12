using Microsoft.AspNetCore.Mvc;

namespace CampEscapeAPI.Controllers
{
    [ApiController]
    [Route("api/test")]
    public class TestController
    {
        [HttpGet]
        public List<string> GetStrings()
        {
            var listTest = new List<string>
            {
                "one",
                "two"
            };
            return listTest; 
        }
    }
}
