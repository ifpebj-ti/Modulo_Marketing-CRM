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
    [Route("campanhas")]
    public async Task<IActionResult> Get([FromQuery] int pageNumber = 1, [FromQuery] int itemNumber = 10)
    {
        try{
            _logger.LogWarning("Buscando campanhas...");
            List<Campanha> campanhas = await _campanhaRepository.GetTodasASCampanhas(pageNumber, itemNumber);
            return Ok(campanhas);
        }catch(Exception ex)
        {
            return BadRequest();
        }

    }

    [HttpGet(Name = "GetCampanhasAtivas")]
    [Route("campanhasAtivas")]
    public async Task<IActionResult> GetCampanhasAtivas([FromQuery] int pageNumber = 1, [FromQuery] int itemNumber = 10)
    {
        try
        {
            _logger.LogWarning("Buscando campanhas ativas...");
            List<Campanha> campanhasAtivas = await _campanhaRepository.GetCampanhasAtivas(pageNumber, itemNumber);
            return Ok(campanhasAtivas);
        } catch(Exception ex)
        {
            return BadRequest();
        }
        
    }

    [HttpGet(Name = "GetCampanhasPorId")]
    [Route("campanhaPorId/{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        try 
        {
            _logger.LogWarning("Buscando campanha por id...");
            Campanha campanha = await _campanhaRepository.GetCampanhaPorId(id);
            if (campanha == null) return NotFound();
            return Ok(campanha);

        } catch(Exception ex)
        { 
            return BadRequest();
        }

    }


    [HttpPost(Name = "PostCampanhas")]
    [Route("campanha")]
    public async Task<IActionResult> Post([FromBody] CampanhaRequest request)
    {
        try
        {
            _logger.LogWarning("Criando campanha...");
            if (!ModelState.IsValid) return BadRequest(ModelState);
            Campanha campanha = await _campanhaRepository.SalvarCampanha(request);
            return CreatedAtAction(nameof(GetById), new { id = campanha.Id_Campanha }, campanha);
        } catch(Exception ex)
        {
            return BadRequest();
        }
    }



}
