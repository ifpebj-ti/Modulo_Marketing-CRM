using Microsoft.AspNetCore.Mvc;
using ModuloMarketing.Api.Domain;
using ModuloMarketing.Api.Repository.Implementation;
using ModuloMarketing.Api.Repository.Interfaces;

namespace ModuloMarketing.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HistoricoCampanhasController : ControllerBase
{
    private readonly ILogger<HistoricoCampanhasController> _logger;

    private readonly IHistoricoCampanhasRepository _historicoCampanhasRepository;

    public HistoricoCampanhasController(ILogger<HistoricoCampanhasController> logger, IHistoricoCampanhasRepository historicoCampanhasRepository)
    {
        _logger = logger;
        _historicoCampanhasRepository = historicoCampanhasRepository;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        _logger.LogWarning("Buscando todos os historicos de campanha");
        try
        {
            List<HistoricoCampanhas> historico = await _historicoCampanhasRepository.GetHistorico();
            return Ok(historico);
        }
        catch (Exception ex)
        {
            _logger.LogWarning(ex.Message);
            return BadRequest();
        }

    }


    [HttpGet]
    [Route("HistoricoPorId/{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        _logger.LogWarning("Buscando histórico por id");
        if (!ModelState.IsValid) return BadRequest(ModelState);
        try
        {
            HistoricoCampanhas historico = await _historicoCampanhasRepository.GetHistoricoPorId(id);
            if (historico == null) return NotFound();
            return Ok(historico);
        }
        catch (Exception ex)
        {
            return BadRequest();
        }

    }

}