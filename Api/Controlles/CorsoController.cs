using Api.Responses;
using Api.Services;
using Dtos.CorsoDtos;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CorsoController : ControllerBase
    {
        private readonly CorsoService _corsoService;
        private readonly ILogger<CorsoController> _logger;

        public CorsoController(CorsoService corsoService, ILogger<CorsoController> logger)
        {
            _corsoService = corsoService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCorsi()
        {
            try
            {
                var corsi = await _corsoService.GetAllAsync();
                return Ok(corsi);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Errore durante la lettura della tabella corsi");
                return StatusCode(500, ApiResponse<IEnumerable<CorsoDto>>.Fail("Errore interno del server"));
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCorsoById(int id)
        {
            try
            {
                var corso = await _corsoService.GetByIdAsync(id);
                return Ok(corso);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Errore durante il recupero del corso con ID {id}");
                return StatusCode(500, ApiResponse<CorsoDto?>.Fail("Errore interno del server"));
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateCorso([FromBody] CorsoCreateDto dto)
        {
            try
            {
                var result = await _corsoService.CreateAsync(dto);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Errore durante la creazione del corso");
                return StatusCode(500, ApiResponse<CorsoDto>.Fail("Errore interno del server"));
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCorso(int id, [FromBody] CorsoUpdateDto dto)
        {
            try
            {
                dto.CorsoId = id;
                var result = await _corsoService.UpdateAsync(dto);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Errore durante l'aggiornamento del corso con ID {id}");
                return StatusCode(500, ApiResponse<CorsoDto>.Fail("Errore interno del server"));
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCorso(int id)
        {
            try
            {
                var result = await _corsoService.DeleteAsync(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Errore durante l'eliminazione del corso con ID {id}");
                return StatusCode(500, ApiResponse<bool>.Fail("Errore interno del server"));
            }
        }
    }
}
