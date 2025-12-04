using Api.GenericRepositories.Repositories;
using Api.Responses;
using AutoMapper;
using Dtos.IscrizioneDtos;
using Models;

namespace Api.Services
{
    public class IscrizioneService
    {
        private readonly GRepository<Iscrizione> _repo;
        private readonly IMapper _mapper;

        public IscrizioneService(GRepository<Iscrizione> repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<ApiResponse<IEnumerable<IscrizioneDto>>> GetAllAsync()
        {
            try
            {
                var result = await _repo.GetAllAsync();
                if (!result.Success)
                    return ApiResponse<IEnumerable<IscrizioneDto>>.Fail(result.Message!);

                var mapped = _mapper.Map<IEnumerable<IscrizioneDto>>(result.Data);
                return ApiResponse<IEnumerable<IscrizioneDto>>.Ok(mapped, "Lista recuperata con successo.");
            }
            catch (Exception ex)
            {
                return ApiResponse<IEnumerable<IscrizioneDto>>.Fail($"Errore interno: {ex.Message}");
            }
        }

        public async Task<ApiResponse<IscrizioneDto?>> GetByIdAsync(int id)
        {
            try
            {
                var result = await _repo.GetByIdAsync(id);
                if (!result.Success || result.Data == null)
                    return ApiResponse<IscrizioneDto?>.Fail(result.Message!);

                var mapped = _mapper.Map<IscrizioneDto>(result.Data);
                return ApiResponse<IscrizioneDto?>.Ok(mapped, "Iscrizione recuperata con successo.");
            }
            catch (Exception ex)
            {
                return ApiResponse<IscrizioneDto?>.Fail($"Errore interno: {ex.Message}");
            }
        }

        public async Task<ApiResponse<IscrizioneDto>> CreateAsync(IscrizioneCreateDto dto)
        {
            try
            {
                Iscrizione entity = _mapper.Map<Iscrizione>(dto);
                ApiResponse<Iscrizione> insertResult = await _repo.InsertAsync(entity);

                if (!insertResult.Success)
                    return ApiResponse<IscrizioneDto>.Fail(insertResult.Message!);

                ApiResponse<bool> saveResult = await _repo.SaveAsync();
                if (!saveResult.Success)
                    return ApiResponse<IscrizioneDto>.Fail(saveResult.Message!);

                IscrizioneDto mapped = _mapper.Map<IscrizioneDto>(insertResult.Data);
                return ApiResponse<IscrizioneDto>.Ok(mapped, "Iscrizione creata con successo");
            }
            catch (Exception ex)
            {
                return ApiResponse<IscrizioneDto>.Fail($"Errore interno: {ex.Message}");
            }
        }

        public async Task<ApiResponse<IscrizioneDto>> UpdateAsync(IscrizioneUpdateDto dto)
        {
            try
            {
                Iscrizione entity = _mapper.Map<Iscrizione>(dto);
                ApiResponse<Iscrizione> updateResult = await _repo.UpdateAsync(entity);

                if (!updateResult.Success)
                    return ApiResponse<IscrizioneDto>.Fail(updateResult.Message!);

                ApiResponse<bool> saveResult = await _repo.SaveAsync();
                if (!saveResult.Success)
                    return ApiResponse<IscrizioneDto>.Fail(saveResult.Message!);

                IscrizioneDto mapped = _mapper.Map<IscrizioneDto>(updateResult.Data);
                return ApiResponse<IscrizioneDto>.Ok(mapped, "Iscrizione aggiornata con successo");
            }
            catch (Exception ex)
            {
                return ApiResponse<IscrizioneDto>.Fail($"Errore interno: {ex.Message}");
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

                return ApiResponse<bool>.Ok(true, "Iscrizione eliminata con successo");
            }
            catch (Exception ex)
            {
                return ApiResponse<bool>.Fail($"Errore interno: {ex.Message}");
            }
        }
    }
}
