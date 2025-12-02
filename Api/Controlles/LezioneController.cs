using Api.Responses;
using Api.Services;
using Dtos.LezioneDtos;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LezioneController : ControllerBase
    {
        private readonly LezioneService _lezioneService;
        private readonly ILogger<LezioneController> _logger;

        public LezioneController(LezioneService lezioneService, ILogger<LezioneController> logger)
        {
            _lezioneService = lezioneService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllLezioni()
        {
            try
            {
                var lezioni = await _lezioneService.GetAllAsync();
                return Ok(lezioni);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Errore durante la lettura della tabella lezioni");
                return StatusCode(500, ApiResponse<IEnumerable<LezioneDtos>>.Fail("Errore interno del server"));
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetLezioneById(int id)
        {
            try
            {
                var lezione = await _lezioneService.GetByIdAsync(id);
                return Ok(lezione);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Errore durante il recupero della lezione con ID {id}");
                return StatusCode(500, ApiResponse<LezioneDtos?>.Fail("Errore interno del server"));
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateLezione([FromBody] LezioneCreateDtos dto)
        {
            try
            {
                var result = await _lezioneService.CreateAsync(dto);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Errore durante la creazione della lezione");
                return StatusCode(500, ApiResponse<LezioneDtos>.Fail("Errore interno del server"));
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateLezione(int id, [FromBody] LezioneUpdateDtos dto)
        {
            try
            {
                dto.LezioneId = id;
                var result = await _lezioneService.UpdateAsync(dto);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Errore durante l'aggiornamento della lezione con ID {id}");
                return StatusCode(500, ApiResponse<LezioneDtos>.Fail("Errore interno del server"));
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLezione(int id)
        {
            try
            {
                var result = await _lezioneService.DeleteAsync(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Errore durante l'eliminazione della lezione con ID {id}");
                return StatusCode(500, ApiResponse<bool>.Fail("Errore interno del server"));
            }
        }
    }
}
