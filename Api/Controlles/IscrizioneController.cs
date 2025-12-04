using Api.Responses;
using Api.Services;
using Dtos.IscrizioneDtos;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IscrizioneController : ControllerBase
    {
        private readonly IscrizioneService _iscrizioneService;
        private readonly ILogger<IscrizioneController> _logger;

        public IscrizioneController(IscrizioneService iscrizioneService, ILogger<IscrizioneController> logger)
        {
            _iscrizioneService = iscrizioneService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllIscrizioni()
        {
            try
            {
                var iscrizioni = await _iscrizioneService.GetAllAsync();
                return Ok(iscrizioni);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Errore durante la lettura della tabella iscrizioni");
                return StatusCode(500, ApiResponse<IEnumerable<IscrizioneDto>>.Fail("Errore interno del server"));
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetIscrizioneById(int id)
        {
            try
            {
                var iscrizione = await _iscrizioneService.GetByIdAsync(id);
                return Ok(iscrizione);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Errore durante il recupero dell'iscrizione con ID {id}");
                return StatusCode(500, ApiResponse<IscrizioneDto?>.Fail("Errore interno del server"));
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateIscrizione([FromBody] IscrizioneCreateDto dto)
        {
            try
            {
                var result = await _iscrizioneService.CreateAsync(dto);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Errore durante la creazione dell'iscrizione");
                return StatusCode(500, ApiResponse<IscrizioneDto>.Fail("Errore interno del server"));
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateIscrizione(int id, [FromBody] IscrizioneUpdateDto dto)
        {
            try
            {
                dto.IscrizioneId = id;
                var result = await _iscrizioneService.UpdateAsync(dto);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Errore durante l'aggiornamento dell'iscrizione con ID {id}");
                return StatusCode(500, ApiResponse<IscrizioneDto>.Fail("Errore interno del server"));
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteIscrizione(int id)
        {
            try
            {
                var result = await _iscrizioneService.DeleteAsync(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Errore durante l'eliminazione dell'iscrizione con ID {id}");
                return StatusCode(500, ApiResponse<bool>.Fail("Errore interno del server"));
            }
        }
    }
}
