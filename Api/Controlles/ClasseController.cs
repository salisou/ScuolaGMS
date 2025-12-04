using Api.Responses;
using Api.Services;
using Dtos.ClasseDtos;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controlles
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClasseController : ControllerBase
    {
        private readonly ClasseService _classeService;
        private readonly ILogger<ClasseController> _logger;

        public ClasseController(ClasseService classeService, ILogger<ClasseController> logger)
        {
            _classeService = classeService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllClassi()
        {
            try
            {
                var classi = await _classeService.GetAllAsync();
                return Ok(classi);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Errore durante la lettura della tabella classi");
                return StatusCode(500, ApiResponse<IEnumerable<ClasseDto>>.Fail("Errore interno del server"));
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetClasseById(int id)
        {
            try
            {
                var classe = await _classeService.GetByIdAsync(id);
                return Ok(classe);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Errore durante il recupero della classe con ID {id}");
                return StatusCode(500, ApiResponse<ClasseDto?>.Fail("Errore interno del server"));
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateClasse([FromBody] ClasseCreateDto dto)
        {
            try
            {
                var result = await _classeService.CreateAsync(dto);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Errore durante la creazione di una nuova classe");
                return StatusCode(500, ApiResponse<ClasseDto>.Fail("Errore interno del server"));
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateClasse([FromBody] ClasseUpdateDto dto)
        {
            try
            {
                var result = await _classeService.UpdateAsync(dto);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Errore durante l'aggiornamento della classe");
                return StatusCode(500, ApiResponse<ClasseDto>.Fail("Errore interno del server"));
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteClasse([FromBody] int id)
        {
            try
            {
                var result = await _classeService.DeleteAsync(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Errore durante la cancellazione della classe");
                return StatusCode(500, ApiResponse<bool>.Fail("Errore interno del server"));
            }
        }
    }
}