using Api.GenericRepositories.Repositories;
using Api.Responses;
using AutoMapper;
using Dtos.PresenzeDtos;
using Models;

namespace Api.Services
{
    public class PresenzaService
    {
        private readonly GRepository<Presenza> _repo;
        private readonly IMapper _mapper;

        public PresenzaService(GRepository<Presenza> repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<ApiResponse<IEnumerable<PresenzaDto>>> GetAllAsync()
        {
            try
            {
                var result = await _repo.GetAllAsync();
                if (!result.Success)
                    return ApiResponse<IEnumerable<PresenzaDto>>.Fail(result.Message!);

                var mapped = _mapper.Map<IEnumerable<PresenzaDto>>(result.Data);
                return ApiResponse<IEnumerable<PresenzaDto>>.Ok(mapped);
            }
            catch (Exception ex)
            {
                return ApiResponse<IEnumerable<PresenzaDto>>.Fail($"Errore interno: {ex.Message}");
            }
        }

        public async Task<ApiResponse<PresenzaDto?>> GetByIdAsync(int id)
        {
            try
            {
                var result = await _repo.GetByIdAsync(id);
                if (!result.Success || result.Data == null)
                    return ApiResponse<PresenzaDto?>.Fail(result.Message!);

                var mapped = _mapper.Map<PresenzaDto>(result.Data);
                return ApiResponse<PresenzaDto?>.Ok(mapped);
            }
            catch (Exception ex)
            {
                return ApiResponse<PresenzaDto?>.Fail($"Errore interno: {ex.Message}");
            }
        }

        public async Task<ApiResponse<PresenzaDto>> CreateAsync(PresenzaCreateDto dto)
        {
            try
            {
                Presenza entity = _mapper.Map<Presenza>(dto);
                ApiResponse<Presenza> insertResult = await _repo.InsertAsync(entity);

                if (!insertResult.Success)
                    return ApiResponse<PresenzaDto>.Fail(insertResult.Message!);

                ApiResponse<bool> saveResult = await _repo.SaveAsync();
                if (!saveResult.Success)
                    return ApiResponse<PresenzaDto>.Fail(saveResult.Message!);

                PresenzaDto mapped = _mapper.Map<PresenzaDto>(insertResult.Data);
                return ApiResponse<PresenzaDto>.Ok(mapped, "Presenza creata con successo");
            }
            catch (Exception ex)
            {
                return ApiResponse<PresenzaDto>.Fail($"Errore interno: {ex.Message}");
            }
        }

        public async Task<ApiResponse<PresenzaDto>> UpdateAsync(PresenzaUpdateDto dto)
        {
            try
            {
                Presenza entity = _mapper.Map<Presenza>(dto);
                ApiResponse<Presenza> updateResult = await _repo.UpdateAsync(entity);

                if (!updateResult.Success)
                    return ApiResponse<PresenzaDto>.Fail(updateResult.Message!);

                ApiResponse<bool> saveResult = await _repo.SaveAsync();
                if (!saveResult.Success)
                    return ApiResponse<PresenzaDto>.Fail(saveResult.Message!);

                PresenzaDto mapped = _mapper.Map<PresenzaDto>(updateResult.Data);
                return ApiResponse<PresenzaDto>.Ok(mapped, "Presenza aggiornata con successo");
            }
            catch (Exception ex)
            {
                return ApiResponse<PresenzaDto>.Fail($"Errore interno: {ex.Message}");
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

                return ApiResponse<bool>.Ok(true, "Presenza eliminata con successo");
            }
            catch (Exception ex)
            {
                return ApiResponse<bool>.Fail($"Errore interno: {ex.Message}");
            }
        }
    }
}
