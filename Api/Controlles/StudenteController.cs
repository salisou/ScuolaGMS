
using Api.Responses;
using Api.Services;
using Dtos.StudenteDtos;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudenteController : ControllerBase
    {
        private readonly StudenteService _studenteService;
        private readonly ILogger<StudenteController> _logger;

        public StudenteController(StudenteService studenteService, ILogger<StudenteController> logger)
        {
            _studenteService = studenteService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllStudenti()
        {
            try
            {
                var studenti = await _studenteService.GetAllAsync();
                return Ok(studenti);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Errore durante la lettura della tabella studenti");
                return StatusCode(500, ApiResponse<IEnumerable<StudenteDto>>.Fail("Errore interno del server"));
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetStudenteById(int id)
        {
            try
            {
                var studente = await _studenteService.GetByIdAsync(id);
                return Ok(studente);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Errore durante il recupero dello studente con ID {id}");
                return StatusCode(500, ApiResponse<StudenteDto?>.Fail("Errore interno del server"));
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateStudente([FromBody] StudenteCreateDto dto)
        {
            try
            {
                var result = await _studenteService.CreateAsync(dto);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Errore durante la creazione dello studente");
                return StatusCode(500, ApiResponse<StudenteDto>.Fail("Errore interno del server"));
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStudente(int id, [FromBody] StudenteUpdateDto dto)
        {
            try
            {
                dto.StudenteId = id;
                var result = await _studenteService.UpdateAsync(dto);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Errore durante l'aggiornamento dello studente con ID {id}");
                return StatusCode(500, ApiResponse<StudenteDto>.Fail("Errore interno del server"));
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudente(int id)
        {
            try
            {
                var result = await _studenteService.DeleteAsync(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Errore durante l'eliminazione dello studente con ID {id}");
                return StatusCode(500, ApiResponse<bool>.Fail("Errore interno del server"));
            }
        }
    }
}
