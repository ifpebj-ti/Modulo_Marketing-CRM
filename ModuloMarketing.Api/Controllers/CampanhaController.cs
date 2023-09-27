using Microsoft.AspNetCore.Mvc;
using ModuloMarketing.Api.Domain;
using ModuloMarketing.Api.Repository.Implementation;
using ModuloMarketing.Api.Repository.Interfaces;

namespace ModuloMarketing.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class CampanhaController : ControllerBase
{
    
    private readonly ILogger<CampanhaController> _logger;

    public CampanhaController(ILogger<CampanhaController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetCampanhas")]
    public List<Campanha> Get()
    {
        return new List<Campanha>();
        // return _produtosEmPromocaoRepository.GetTodosOsProdutosEmPromocao();
    }

}
