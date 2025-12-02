using Api.Responses;
using Api.Services;
using Dtos.AulaDtos;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AulaController : ControllerBase
    {
        private readonly AulaService _aulaService;
        private readonly ILogger<AulaController> _logger;

        public AulaController(AulaService aulaService, ILogger<AulaController> logger)
        {
            _aulaService = aulaService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAule()
        {
            try
            {
                var aule = await _aulaService.GetAllAsync();
                return Ok(aule);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Errore durante la lettura della tabella aule");
                return StatusCode(500, ApiResponse<IEnumerable<AulaDto>>.Fail("Errore interno del server"));
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAulaById(int id)
        {
            try
            {
                var aula = await _aulaService.GetByIdAsync(id);
                return Ok(aula);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Errore durante il recupero dell'aula con ID {id}");
                return StatusCode(500, ApiResponse<AulaDto?>.Fail("Errore interno del server"));
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateAula([FromBody] AulaCreateDto dto)
        {
            try
            {
                var result = await _aulaService.CreateAsync(dto);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Errore durante la creazione dell'aula");
                return StatusCode(500, ApiResponse<AulaDto>.Fail("Errore interno del server"));
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAula(int id, [FromBody] AulaUpdateDto dto)
        {
            try
            {
                dto.AulaId = id;
                var result = await _aulaService.UpdateAsync(dto);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Errore durante l'aggiornamento dell'aula con ID {id}");
                return StatusCode(500, ApiResponse<AulaDto>.Fail("Errore interno del server"));
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAula(int id)
        {
            try
            {
                var result = await _aulaService.DeleteAsync(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Errore durante l'eliminazione dell'aula con ID {id}");
                return StatusCode(500, ApiResponse<bool>.Fail("Errore interno del server"));
            }
        }
    }
}
