using Microsoft.AspNetCore.Mvc;
using ModuloMarketing.Api.Domain;
using ModuloMarketing.Api.Repository.Implementation;
using ModuloMarketing.Api.Repository.Interfaces;

namespace ModuloMarketing.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class ClienteController : ControllerBase
{
    
    private readonly ILogger<ClienteController> _logger;
    private readonly IProdutosEmPromocaoRepository _produtosEmPromocaoRepository;

    public ClienteController(ILogger<ClienteController> logger, IProdutosEmPromocaoRepository produtosEmPromocaoRepository)
    {
        _logger = logger;
        _produtosEmPromocaoRepository = produtosEmPromocaoRepository;
    }

    [HttpGet(Name = "GetProdutosEmPromocao")]
    public List<ProdutosEmPromocao> Get()
    {
        return _produtosEmPromocaoRepository.GetTodosOsProdutosEmPromocao();
    }

}
