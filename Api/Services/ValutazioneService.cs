using Api.GenericRepositories.Repositories;
using Api.Responses;
using AutoMapper;
using Dtos.ValutazioneDtos;
using Models;

namespace Api.Services
{
    public class ValutazioneService
    {
        private readonly GRepository<Valutazione> _repo;
        private readonly IMapper _mapper;

        public ValutazioneService(GRepository<Valutazione> repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<ApiResponse<IEnumerable<ValutazioneDto>>> GetAllAsync()
        {
            try
            {
                var result = await _repo.GetAllAsync();
                if (!result.Success)
                    return ApiResponse<IEnumerable<ValutazioneDto>>.Fail(result.Message!);

                var mapped = _mapper.Map<IEnumerable<ValutazioneDto>>(result.Data);
                return ApiResponse<IEnumerable<ValutazioneDto>>.Ok(mapped);
            }
            catch (Exception ex)
            {
                return ApiResponse<IEnumerable<ValutazioneDto>>.Fail($"Errore interno: {ex.Message}");
            }
        }

        public async Task<ApiResponse<ValutazioneDto?>> GetByIdAsync(int id)
        {
            try
            {
                var result = await _repo.GetByIdAsync(id);
                if (!result.Success || result.Data == null)
                    return ApiResponse<ValutazioneDto?>.Fail(result.Message!);

                var mapped = _mapper.Map<ValutazioneDto>(result.Data);
                return ApiResponse<ValutazioneDto?>.Ok(mapped);
            }
            catch (Exception ex)
            {
                return ApiResponse<ValutazioneDto?>.Fail($"Errore interno: {ex.Message}");
            }
        }

        public async Task<ApiResponse<ValutazioneDto>> CreateAsync(ValutazioneCreateDto dto)
        {
            try
            {
                Valutazione entity = _mapper.Map<Valutazione>(dto);
                ApiResponse<Valutazione> insertResult = await _repo.InsertAsync(entity);

                if (!insertResult.Success)
                    return ApiResponse<ValutazioneDto>.Fail(insertResult.Message!);

                ApiResponse<bool> saveResult = await _repo.SaveAsync();
                if (!saveResult.Success)
                    return ApiResponse<ValutazioneDto>.Fail(saveResult.Message!);

                ValutazioneDto mapped = _mapper.Map<ValutazioneDto>(insertResult.Data);
                return ApiResponse<ValutazioneDto>.Ok(mapped, "Valutazione creata con successo");
            }
            catch (Exception ex)
            {
                return ApiResponse<ValutazioneDto>.Fail($"Errore interno: {ex.Message}");
            }
        }

        public async Task<ApiResponse<ValutazioneDto>> UpdateAsync(ValutazioneUpdateDto dto)
        {
            try
            {
                Valutazione entity = _mapper.Map<Valutazione>(dto);
                ApiResponse<Valutazione> updateResult = await _repo.UpdateAsync(entity);

                if (!updateResult.Success)
                    return ApiResponse<ValutazioneDto>.Fail(updateResult.Message!);

                ApiResponse<bool> saveResult = await _repo.SaveAsync();
                if (!saveResult.Success)
                    return ApiResponse<ValutazioneDto>.Fail(saveResult.Message!);

                ValutazioneDto mapped = _mapper.Map<ValutazioneDto>(updateResult.Data);
                return ApiResponse<ValutazioneDto>.Ok(mapped, "Valutazione aggiornata con successo");
            }
            catch (Exception ex)
            {
                return ApiResponse<ValutazioneDto>.Fail($"Errore interno: {ex.Message}");
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

                return ApiResponse<bool>.Ok(true, "Valutazione eliminata con successo");
            }
            catch (Exception ex)
            {
                return ApiResponse<bool>.Fail($"Errore interno: {ex.Message}");
            }
        }
    }
}
