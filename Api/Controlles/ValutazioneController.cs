using Api.Responses;
using Api.Services;
using Dtos.ValutazioneDtos;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValutazioneController : ControllerBase
    {
        private readonly ValutazioneService _valutazioneService;
        private readonly ILogger<ValutazioneController> _logger;

        public ValutazioneController(ValutazioneService valutazioneService, ILogger<ValutazioneController> logger)
        {
            _valutazioneService = valutazioneService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllValutazioni()
        {
            try
            {
                var valutazioni = await _valutazioneService.GetAllAsync();
                return Ok(valutazioni);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Errore durante la lettura della tabella valutazioni");
                return StatusCode(500, ApiResponse<IEnumerable<ValutazioneDto>>.Fail("Errore interno del server"));
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetValutazioneById(int id)
        {
            try
            {
                var valutazione = await _valutazioneService.GetByIdAsync(id);
                return Ok(valutazione);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Errore durante il recupero della valutazione con ID {id}");
                return StatusCode(500, ApiResponse<ValutazioneDto?>.Fail("Errore interno del server"));
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateValutazione([FromBody] ValutazioneCreateDto dto)
        {
            try
            {
                var result = await _valutazioneService.CreateAsync(dto);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Errore durante la creazione della valutazione");
                return StatusCode(500, ApiResponse<ValutazioneDto>.Fail("Errore interno del server"));
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateValutazione(int id, [FromBody] ValutazioneUpdateDto dto)
        {
            try
            {
                dto.ValutazioneId = id;
                var result = await _valutazioneService.UpdateAsync(dto);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Errore durante l'aggiornamento della valutazione con ID {id}");
                return StatusCode(500, ApiResponse<ValutazioneDto>.Fail("Errore interno del server"));
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteValutazione(int id)
        {
            try
            {
                var result = await _valutazioneService.DeleteAsync(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Errore durante l'eliminazione della valutazione con ID {id}");
                return StatusCode(500, ApiResponse<bool>.Fail("Errore interno del server"));
            }
        }
    }
}
