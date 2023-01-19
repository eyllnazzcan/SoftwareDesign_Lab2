using System.Threading.Tasks;
using DotNetCRUD.Models;
using DotNetCRUD.Services;
using Microsoft.AspNetCore.Mvc;

namespace DotNetCRUD.Controllers;

[ApiController]
[Route("[controller]")]
public class CapitalController : Controller
{
    private readonly ICapitalService _capitalService;

    public CapitalController(ICapitalService capitalService)
    {
        _capitalService = capitalService;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var result = await _capitalService.GetCapitalList();

        return Ok(result);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetCapital(int id)
    {
        var result = await _capitalService.GetCapital(id);

        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> AddPlaylist([FromBody] Capital capital)
    {
        var result = await _capitalService.CreateCapital(capital);

        return Ok(result);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateCapital([FromBody] Capital capital)
    {
        var result = await _capitalService.UpdateCapital(capital);

        return Ok(result);
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteCapital(int id)
    {
        var result = await _capitalService.DeleteCapital(id);

        return Ok(result);
    }
}