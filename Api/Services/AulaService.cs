
using Api.GenericRepositories.Repositories;
using Api.Responses;
using AutoMapper;
using Dtos.AulaDtos;
using Models;

namespace Api.Services
{
    public class AulaService
    {
        private readonly GRepository<Aula> _repo;
        private readonly IMapper _mapper;

        public AulaService(GRepository<Aula> repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<ApiResponse<IEnumerable<AulaDto>>> GetAllAsync()
        {
            try
            {
                var result = await _repo.GetAllAsync();
                if (!result.Success)
                    return ApiResponse<IEnumerable<AulaDto>>.Fail(result.Message!);

                var mapped = _mapper.Map<IEnumerable<AulaDto>>(result.Data);
                return ApiResponse<IEnumerable<AulaDto>>.Ok(mapped, "Lista recuperata con successo.");
            }
            catch (Exception ex)
            {
                return ApiResponse<IEnumerable<AulaDto>>.Fail($"Errore interno: {ex.Message}");
            }
        }

        public async Task<ApiResponse<AulaDto?>> GetByIdAsync(int id)
        {
            try
            {
                var result = await _repo.GetByIdAsync(id);
                if (!result.Success || result.Data == null)
                    return ApiResponse<AulaDto?>.Fail(result.Message!);

                var mapped = _mapper.Map<AulaDto>(result.Data);
                return ApiResponse<AulaDto?>.Ok(mapped);
            }
            catch (Exception ex)
            {
                return ApiResponse<AulaDto?>.Fail($"Errore interno: {ex.Message}");
            }
        }

        public async Task<ApiResponse<AulaDto>> CreateAsync(AulaCreateDto dto)
        {
            try
            {
                Aula entity = _mapper.Map<Aula>(dto);
                ApiResponse<Aula> insertResult = await _repo.InsertAsync(entity);

                if (!insertResult.Success)
                    return ApiResponse<AulaDto>.Fail(insertResult.Message!);

                ApiResponse<bool> saveResult = await _repo.SaveAsync();
                if (!saveResult.Success)
                    return ApiResponse<AulaDto>.Fail(saveResult.Message!);

                AulaDto mapped = _mapper.Map<AulaDto>(insertResult.Data);
                return ApiResponse<AulaDto>.Ok(mapped, "Aula creata con successo");
            }
            catch (Exception ex)
            {
                return ApiResponse<AulaDto>.Fail($"Errore interno: {ex.Message}");
            }
        }

        public async Task<ApiResponse<AulaDto>> UpdateAsync(AulaUpdateDto dto)
        {
            try
            {
                Aula entity = _mapper.Map<Aula>(dto);
                ApiResponse<Aula> updateResult = await _repo.UpdateAsync(entity);

                if (!updateResult.Success)
                    return ApiResponse<AulaDto>.Fail(updateResult.Message!);

                ApiResponse<bool> saveResult = await _repo.SaveAsync();
                if (!saveResult.Success)
                    return ApiResponse<AulaDto>.Fail(saveResult.Message!);

                AulaDto mapped = _mapper.Map<AulaDto>(updateResult.Data);
                return ApiResponse<AulaDto>.Ok(mapped, "Aula aggiornata con successo");
            }
            catch (Exception ex)
            {
                return ApiResponse<AulaDto>.Fail($"Errore interno: {ex.Message}");
            }
        }

        public async Task<ApiResponse<bool>> DeleteAsync(int id)
        {
            try
            {
                ApiResponse<bool> deleteResult = await _repo.DeleteAsync(id);
                if (!deleteResult.Success)
                    return ApiResponse<bool>.Fail(deleteResult.Message!);

                ApiResponse<bool> saveResult = await _repo.SaveAsync();
                if (!saveResult.Success)
                    return ApiResponse<bool>.Fail(saveResult.Message!);

                return ApiResponse<bool>.Ok(true, "Aula eliminata con successo");
            }
            catch (Exception ex)
            {
                return ApiResponse<bool>.Fail($"Errore interno: {ex.Message}");
            }
        }
    }
}
