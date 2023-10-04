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
    private readonly ICampanhaRepository _campanhaRepository;

    public CampanhaController(ILogger<CampanhaController> logger, ICampanhaRepository campanhaRepository)
    {
        _logger = logger;
        _campanhaRepository = campanhaRepository;
    }

    [HttpGet(Name = "GetCampanhas")]
    public async Task<IActionResult> Get()
    {
        _logger.LogWarning("Buscando todas as campanhas");
        try
        {
            List<Campanha> campanhas = await _campanhaRepository.GetTodasASCampanhas();
            return Ok(campanhas);
        }
        catch (Exception ex)
        {
            _logger.LogWarning(ex.Message);
            return BadRequest();
        }

    }

    [HttpGet]
    [Route("GetCampanhasAtivas")]
    public async Task<IActionResult> GetCampanhasAtivas()
    {
        try
        {
            _logger.LogWarning("Buscando campanhas ativas");
            List<Campanha> campanhasAtivas = await _campanhaRepository.GetCampanhasAtivas();
            return Ok(campanhasAtivas);
        }
        catch (Exception ex)
        {
            _logger.LogWarning(ex.Message);
            return BadRequest();
        }

    }

    [HttpGet]
    [Route("CampanhaPorId/{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        _logger.LogWarning("Buscando campanha por id");
        if (!ModelState.IsValid) return BadRequest(ModelState);
        try
        {
            Campanha campanha = await _campanhaRepository.GetCampanhaPorId(id);
            if (campanha == null) return NotFound();
            return Ok(campanha);
        }
        catch (Exception ex)
        {
            _logger.LogWarning(ex.Message);
            return BadRequest();
        }

    }


    [HttpPost(Name = "PostCampanhas")]
    public async Task<IActionResult> Post([FromBody] CampanhaRequest request)
    {

        if (!ModelState.IsValid) return BadRequest(ModelState);

        _logger.LogWarning("Criando Campanha");
        try
        {
            Campanha campanha = await _campanhaRepository.SalvarCampanha(request);
            return CreatedAtAction(nameof(GetById), new { id = campanha.Id_Campanha }, campanha);
        }
        catch (Exception ex)
        {
            _logger.LogWarning(ex.Message);
            return BadRequest();
        }

    }

}
