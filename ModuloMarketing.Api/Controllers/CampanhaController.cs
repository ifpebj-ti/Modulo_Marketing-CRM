using Microsoft.AspNetCore.Mvc;
using ModuloMarketing.Api.Domain;
using ModuloMarketing.Api.Repository.Implementation;
using ModuloMarketing.Api.Repository.Interfaces;

namespace ModuloMarketing.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CampanhaController : ControllerBase
{

    private readonly ILogger<CampanhaController> _logger;
    private readonly ICampanhaRepository _campanhaRepository;

    public CampanhaController(ILogger<CampanhaController> logger, ICampanhaRepository campanhaRepository)
    {
        _logger = logger;
        _campanhaRepository = campanhaRepository;
    }

    [HttpGet]
    [Route("GetCampanhas")]
    public async Task<IActionResult> Get([FromQuery] int pageNumber = 1, [FromQuery] int itemNumber = 10)
    {
        _logger.LogWarning("Buscando todas as campanhas");
        try
        {
            List<Campanha> campanhas = await _campanhaRepository.GetTodasASCampanhas(pageNumber, itemNumber);
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
    public async Task<IActionResult> GetCampanhasAtivas([FromQuery] int pageNumber = 1, [FromQuery] int itemNumber = 10)
    {
        try
        {
            _logger.LogWarning("Buscando campanhas ativas");
            List<Campanha> campanhasAtivas = await _campanhaRepository.GetCampanhasAtivas(pageNumber, itemNumber);
            return Ok(campanhasAtivas);
        }
        catch (Exception ex)
        {
            _logger.LogWarning(ex.Message);
            return BadRequest();
        }
    }

    [HttpGet]
    [Route("GetCampanhaPorId/{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        _logger.LogWarning(string.Format("Buscando campanha por id {0}", id));
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

    [HttpGet]
    [Route("CampanhasRecorrentes")]
    public async Task<IActionResult> GetCampanhasRecorrentes([FromQuery] int pageNumber = 1, [FromQuery] int itemNumber = 10)
    {
        try
        {
            _logger.LogWarning("Buscando campanhas recorrentes");
            List<Campanha> campanhasRecorrentes = await _campanhaRepository.GetCampanhasRecorrentes(pageNumber, itemNumber);
            return Ok(campanhasRecorrentes);
        }
        catch (Exception ex)
        {
            _logger.LogWarning(ex.Message);
            return BadRequest();
        }
    }

    [HttpGet]
    [Route("GetQuantidadeCampanhasAtivas")]
    public async Task<IActionResult> GetQntdCampanhasAtivas()
    {
        _logger.LogWarning("Buscando quantidade de campanhas ativas...");
        try
        {
            int qntdCampanhas = await _campanhaRepository.GetQuantidadeCampanhasAtivas();
            return Ok(new { quantidadeCampanhasAtivas = qntdCampanhas });
        }
        catch (Exception ex)
        {
            _logger.LogWarning(ex.Message);
            return BadRequest();
        }
    }


    [HttpPost]
    [Route("CadastrarCampanha")]
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

    [HttpPost]
    [Route("DesativarCampanha/{id}")]
    public async Task<IActionResult> DesativarCampanha([FromRoute] int id)
    {

        if (!ModelState.IsValid) return BadRequest(ModelState);

        _logger.LogWarning(string.Format("Desativando campanha com id {0}", id));
        try
        {
            await _campanhaRepository.DesativarCampanha(id);
            return Ok();
        }
        catch (Exception ex)
        {
            _logger.LogWarning(ex.Message);
            return BadRequest();
        }

    }

}
