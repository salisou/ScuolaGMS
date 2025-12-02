using Api.GenericRepositories.Repositories;
using Api.Responses;
using AutoMapper;
using Dtos.CorsoDtos;
using Models;

namespace Api.Services
{
    public class CorsoService
    {
        private readonly GRepository<Corso> _repo;
        private readonly IMapper _mapper;

        public CorsoService(GRepository<Corso> repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<ApiResponse<IEnumerable<CorsoDto>>> GetAllAsync()
        {
            try
            {
                var result = await _repo.GetAllAsync();
                if (!result.Success)
                    return ApiResponse<IEnumerable<CorsoDto>>.Fail(result.Message!);

                var mapped = _mapper.Map<IEnumerable<CorsoDto>>(result.Data);
                return ApiResponse<IEnumerable<CorsoDto>>.Ok(mapped, "Lista recuperata con successo.");
            }
            catch (Exception ex)
            {
                return ApiResponse<IEnumerable<CorsoDto>>.Fail($"Errore interno: {ex.Message}");
            }
        }

        public async Task<ApiResponse<CorsoDto?>> GetByIdAsync(int id)
        {
            try
            {
                var result = await _repo.GetByIdAsync(id);
                if (!result.Success || result.Data == null)
                    return ApiResponse<CorsoDto?>.Fail(result.Message!);

                var mapped = _mapper.Map<CorsoDto>(result.Data);
                return ApiResponse<CorsoDto?>.Ok(mapped);
            }
            catch (Exception ex)
            {
                return ApiResponse<CorsoDto?>.Fail($"Errore interno: {ex.Message}");
            }
        }

        public async Task<ApiResponse<CorsoDto>> CreateAsync(CorsoCreateDto dto)
        {
            try
            {
                Corso entity = _mapper.Map<Corso>(dto);
                ApiResponse<Corso> insertResult = await _repo.InsertAsync(entity);

                if (!insertResult.Success)
                    return ApiResponse<CorsoDto>.Fail(insertResult.Message!);

                ApiResponse<bool> saveResult = await _repo.SaveAsync();
                if (!saveResult.Success)
                    return ApiResponse<CorsoDto>.Fail(saveResult.Message!);

                CorsoDto mapped = _mapper.Map<CorsoDto>(insertResult.Data);
                return ApiResponse<CorsoDto>.Ok(mapped, "Corso creato con successo");
            }
            catch (Exception ex)
            {
                return ApiResponse<CorsoDto>.Fail($"Errore interno: {ex.Message}");
            }
        }

        public async Task<ApiResponse<CorsoDto>> UpdateAsync(CorsoUpdateDto dto)
        {
            try
            {
                Corso entity = _mapper.Map<Corso>(dto);
                ApiResponse<Corso> updateResult = await _repo.UpdateAsync(entity);

                if (!updateResult.Success)
                    return ApiResponse<CorsoDto>.Fail(updateResult.Message!);

                ApiResponse<bool> saveResult = await _repo.SaveAsync();
                if (!saveResult.Success)
                    return ApiResponse<CorsoDto>.Fail(saveResult.Message!);

                CorsoDto mapped = _mapper.Map<CorsoDto>(updateResult.Data);
                return ApiResponse<CorsoDto>.Ok(mapped, "Corso aggiornato con successo");
            }
            catch (Exception ex)
            {
                return ApiResponse<CorsoDto>.Fail($"Errore interno: {ex.Message}");
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

                return ApiResponse<bool>.Ok(true, "Corso eliminato con successo");
            }
            catch (Exception ex)
            {
                return ApiResponse<bool>.Fail($"Errore interno: {ex.Message}");
            }
        }
    }
}
