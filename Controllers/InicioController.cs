using Microsoft.AspNetCore.Mvc;

namespace FabricaGestao.Api.Controllers;

[ApiController]
[Route("")]
public class InicioController : ControllerBase
{
    [HttpGet("")]
    public IActionResult StatusCode()
    {
        return Ok("Web API - StatusCode: 201");
    }
}