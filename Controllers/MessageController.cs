using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PatternPioneer.Factories;

namespace PatternPioneer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MessageController : ControllerBase
    {
        private readonly MessageBuilderEngine _builderFactory;
        public MessageController(MessageBuilderEngine builderFactory)
        {
            _builderFactory = builderFactory;
        }

        [HttpGet]
        public IActionResult Get(int Id)
        {
            var strategy = _builderFactory.GetStrategy(new Domain.Entities.Rule()
            {
                EventId = Id
            });
            var message = strategy.BuildMessage();
            return Ok(message);
        }
    }
}
