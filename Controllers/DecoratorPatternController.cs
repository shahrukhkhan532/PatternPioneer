using PatternPioneer.DecoratorPattern;

namespace PatternPioneer.Controllers;

[Route("[controller]/[action]")]
[ApiController]
public class DecoratorPatternController : ControllerBase
{
    private readonly IRepository _repository;

    public DecoratorPatternController(IRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] int id)
    {
        var student = await _repository.GetPersonByIdAsync(id);
        return Ok(student);
    }

    [HttpGet]
    public async Task<IActionResult> Post([FromQuery] int id, string name)
    {
        await _repository.SavePersonAsync(new Student()
        {
            Id = id,
            Name = name
        });
        return Ok("Success");
    }
}
