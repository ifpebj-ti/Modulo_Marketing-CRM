using Microsoft.AspNetCore.Mvc;

namespace ModuloMarketing.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class ClienteController : ControllerBase
{
    
    private readonly ILogger<ClienteController> _logger;

    public ClienteController(ILogger<ClienteController> logger)
    {
        _logger = logger;
    }

}
