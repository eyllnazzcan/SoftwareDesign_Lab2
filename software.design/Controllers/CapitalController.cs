using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Software.Design.Services;

namespace Software.Design.Models.Controllers;

[ApiController]
[Route("api/products")]
public class CapitalController : ControllerBase
{
    private readonly ILogger<CapitalController> _logger;
    private readonly CapitalService _capitalService;


    public CapitalController(
        ILogger<CapitalController> logger,
        CapitalService capitalService)
    {
        _logger = logger;
        _capitalService = capitalService;
    }

    [HttpGet]
    public async Task<ActionResult<List<Capital>>> GetCapitals()
    {
        var capitals = await _capitalService.GetCapitals();
        return Ok(apitals);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<object>> GetCapital(Guid id)
    {
        return Ok();
    }

    [HttpPost]
    public async Task<ActionResult<object>> CreateProduct(CapitalDTO capitalDTO)
    {
        var capital = await _capitalService.Create(capitalDTO);
        return Created(capital);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<object>> UpdateCapital(Guid id)
    {
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<object>> DeleteCapital(Guid id)
    {
        return NoContent();
    }


    private ObjectResult Created(object value)
    {
        return StatusCode(201, value);
    }
}
