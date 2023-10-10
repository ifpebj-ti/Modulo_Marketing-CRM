using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModuloMarketing.Api.Domain;
using ModuloMarketing.Api.Repository.Implementation;
using ModuloMarketing.Api.Repository.Interfaces;

namespace ModuloMarketing.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataComemorativaController : ControllerBase
    {
        private readonly ILogger<DataComemorativaController> _logger;
        private readonly IDataComemorativaRepository _dataComemorativaRepository;

        public DataComemorativaController(ILogger<DataComemorativaController> logger, IDataComemorativaRepository dataComemorativaRepository)
        {
            _logger = logger;
            _dataComemorativaRepository = dataComemorativaRepository;
        }


        [HttpGet]
        [Route("GetDatasComemorativasDoMes")]
        public async Task<IActionResult> GetDatasComemorativasDoMes()
        {
            _logger.LogWarning("Buscando datas comemorativas");
            try
            {
                var datasComemorativas = await _dataComemorativaRepository.GetDatasComemorativasDoMes();
                return Ok(datasComemorativas);
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex.Message);
                return BadRequest();
            }

        }

    }
}
