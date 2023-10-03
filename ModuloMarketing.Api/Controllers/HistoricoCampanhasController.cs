using Microsoft.AspNetCore.Mvc;
using ModuloMarketing.Api.Domain;
using ModuloMarketing.Api.Repository.Implementation;
using ModuloMarketing.Api.Repository.Interfaces;

namespace ModuloMarketing.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class HistoricoCampanhasController : ControllerBase
{
    private readonly ILogger<HistoricoCampanhasController> _logger;

    private readonly IHistoricoCampanhasRepository _historicoCampanhasRepository;
    public HistoricoCampanhasController(ILogger<HistoricoCampanhasController> logger)
    {
        _logger = logger;
    }

    public HistoricoCampanhasController(ILogger<HistoricoCampanhasController> logger, IHistoricoCampanhasRepository historicoCampanhasRepository)
    {
        _logger = logger;
        _historicoCampanhasRepository = historicoCampanhasRepository;
    }

    [HttpGet(Name = "GetHistorico")]
    public async Task<IActionResult> Get()
    {
        List<HistoricoCampanhas> historico = await _historicoCampanhasRepository.GetHistorico();
        return Ok(historico);
    }


[HttpGet]
    [Route("HistoricoPorId/{id}")]
    public async Task<IActionResult> GetById([FromRoute]  int id)
    {
        try 
        {
            _logger.LogWarning("Buscando histórico por id");
            HistoricoCampanhas historico = await _historicoCampanhasRepository.GetHistoricoPorId(id);
            if (historico == null) return NotFound();
            return Ok(historico);
        } catch(Exception ex)
        { 
            return BadRequest();
        }

    }

    
}