using Api.Responses;
using Api.Services;
using Dtos.VotoDtos;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VotoController : ControllerBase
    {
        private readonly VotoService _votoService;
        private readonly ILogger<VotoController> _logger;

        public VotoController(VotoService votoService, ILogger<VotoController> logger)
        {
            _votoService = votoService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllVoti()
        {
            try
            {
                var voti = await _votoService.GetAllAsync();
                return Ok(voti);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Errore durante la lettura della tabella voti");
                return StatusCode(500, ApiResponse<IEnumerable<VotoDto>>.Fail("Errore interno del server"));
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetVotoById(int id)
        {
            try
            {
                var voto = await _votoService.GetByIdAsync(id);
                return Ok(voto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Errore durante il recupero del voto con ID {id}");
                return StatusCode(500, ApiResponse<VotoDto?>.Fail("Errore interno del server"));
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateVoto([FromBody] VotoCreateDto dto)
        {
            try
            {
                var result = await _votoService.CreateAsync(dto);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Errore durante la creazione del voto");
                return StatusCode(500, ApiResponse<VotoDto>.Fail("Errore interno del server"));
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateVoto(int id, [FromBody] VotoUpdateDto dto)
        {
            try
            {
                dto.VotoId = id;
                var result = await _votoService.UpdateAsync(dto);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Errore durante l'aggiornamento del voto con ID {id}");
                return StatusCode(500, ApiResponse<VotoDto>.Fail("Errore interno del server"));
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVoto(int id)
        {
            try
            {
                var result = await _votoService.DeleteAsync(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Errore durante l'eliminazione del voto con ID {id}");
                return StatusCode(500, ApiResponse<bool>.Fail("Errore interno del server"));
            }
        }
    }
}
