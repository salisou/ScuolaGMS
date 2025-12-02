
using Api.GenericRepositories.Repositories;
using Api.Responses;
using AutoMapper;
using Dtos.StudenteDtos;
using Models;

namespace Api.Services
{
    public class StudenteService
    {
        private readonly GRepository<Studente> _repo;
        private readonly IMapper _mapper;

        public StudenteService(GRepository<Studente> repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<ApiResponse<IEnumerable<StudenteDto>>> GetAllAsync()
        {
            try
            {
                var result = await _repo.GetAllAsync();
                if (!result.Success || result.Data == null || !result.Data.Any())
                    return ApiResponse<IEnumerable<StudenteDto>>.Fail(result.Message ?? "Nessuno studente trovato.");

                var mapped = _mapper.Map<IEnumerable<StudenteDto>>(result.Data);
                return ApiResponse<IEnumerable<StudenteDto>>.Ok(mapped, "Lista studenti recuperata con successo.");
            }
            catch (Exception ex)
            {
                return ApiResponse<IEnumerable<StudenteDto>>.Fail($"Errore interno: {ex.Message}");
            }
        }

        public async Task<ApiResponse<StudenteDto?>> GetByIdAsync(int id)
        {
            try
            {
                var result = await _repo.GetByIdAsync(id);
                if (!result.Success || result.Data == null)
                    return ApiResponse<StudenteDto?>.Fail(result.Message ?? "Studente non trovato.");

                var mapped = _mapper.Map<StudenteDto>(result.Data);
                return ApiResponse<StudenteDto?>.Ok(mapped, "Studente recuperato con successo.");
            }
            catch (Exception ex)
            {
                return ApiResponse<StudenteDto?>.Fail($"Errore interno: {ex.Message}");
            }
        }

        public async Task<ApiResponse<StudenteDto>> CreateAsync(StudenteCreateDto dto)
        {
            try
            {
                var entity = _mapper.Map<Studente>(dto);
                var insertResult = await _repo.InsertAsync(entity);

                if (!insertResult.Success)
                    return ApiResponse<StudenteDto>.Fail(insertResult.Message!);

                var saveResult = await _repo.SaveAsync();
                if (!saveResult.Success)
                    return ApiResponse<StudenteDto>.Fail(saveResult.Message!);

                var mapped = _mapper.Map<StudenteDto>(insertResult.Data);
                return ApiResponse<StudenteDto>.Ok(mapped, "Studente creato con successo.");
            }
            catch (Exception ex)
            {
                return ApiResponse<StudenteDto>.Fail($"Errore interno: {ex.Message}");
            }
        }

        public async Task<ApiResponse<StudenteDto>> UpdateAsync(StudenteUpdateDto dto)
        {
            try
            {
                var entity = _mapper.Map<Studente>(dto);
                var updateResult = await _repo.UpdateAsync(entity);

                if (!updateResult.Success)
                    return ApiResponse<StudenteDto>.Fail(updateResult.Message!);

                var saveResult = await _repo.SaveAsync();
                if (!saveResult.Success)
                    return ApiResponse<StudenteDto>.Fail(saveResult.Message!);

                var mapped = _mapper.Map<StudenteDto>(updateResult.Data);
                return ApiResponse<StudenteDto>.Ok(mapped, "Studente aggiornato con successo.");
            }
            catch (Exception ex)
            {
                return ApiResponse<StudenteDto>.Fail($"Errore interno: {ex.Message}");
            }
        }

        public async Task<ApiResponse<bool>> DeleteAsync(int id)
        {
            try
            {
                var deleteResult = await _repo.DeleteAsync(id);
                if (!deleteResult.Success)
                    return ApiResponse<bool>.Fail(deleteResult.Message!);

                var saveResult = await _repo.SaveAsync();
                if (!saveResult.Success)
                    return ApiResponse<bool>.Fail(saveResult.Message!);

                return ApiResponse<bool>.Ok(true, "Studente eliminato con successo.");
            }
            catch (Exception ex)
            {
                return ApiResponse<bool>.Fail($"Errore interno: {ex.Message}");
            }
        }
    }
}
