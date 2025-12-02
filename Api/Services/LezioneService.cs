using Api.GenericRepositories.Repositories;
using Api.Responses;
using AutoMapper;
using Dtos.LezioneDtos;
using Models;

namespace Api.Services
{
    public class LezioneService
    {
        private readonly GRepository<Lezione> _repo;
        private readonly IMapper _mapper;

        public LezioneService(GRepository<Lezione> repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<ApiResponse<IEnumerable<LezioneDtos>>> GetAllAsync()
        {
            try
            {
                var result = await _repo.GetAllAsync();
                if (!result.Success)
                    return ApiResponse<IEnumerable<LezioneDtos>>.Fail(result.Message!);

                var mapped = _mapper.Map<IEnumerable<LezioneDtos>>(result.Data);
                return ApiResponse<IEnumerable<LezioneDtos>>.Ok(mapped);
            }
            catch (Exception ex)
            {
                return ApiResponse<IEnumerable<LezioneDtos>>.Fail($"Errore interno: {ex.Message}");
            }
        }

        public async Task<ApiResponse<LezioneDtos?>> GetByIdAsync(int id)
        {
            try
            {
                var result = await _repo.GetByIdAsync(id);
                if (!result.Success || result.Data == null)
                    return ApiResponse<LezioneDtos?>.Fail(result.Message!);

                var mapped = _mapper.Map<LezioneDtos>(result.Data);
                return ApiResponse<LezioneDtos?>.Ok(mapped);
            }
            catch (Exception ex)
            {
                return ApiResponse<LezioneDtos?>.Fail($"Errore interno: {ex.Message}");
            }
        }

        public async Task<ApiResponse<LezioneDtos>> CreateAsync(LezioneCreateDtos dto)
        {
            try
            {
                Lezione entity = _mapper.Map<Lezione>(dto);
                ApiResponse<Lezione> insertResult = await _repo.InsertAsync(entity);

                if (!insertResult.Success)
                    return ApiResponse<LezioneDtos>.Fail(insertResult.Message!);

                ApiResponse<bool> saveResult = await _repo.SaveAsync();
                if (!saveResult.Success)
                    return ApiResponse<LezioneDtos>.Fail(saveResult.Message!);

                LezioneDtos mapped = _mapper.Map<LezioneDtos>(insertResult.Data);
                return ApiResponse<LezioneDtos>.Ok(mapped, "Lezione creata con successo");
            }
            catch (Exception ex)
            {
                return ApiResponse<LezioneDtos>.Fail($"Errore interno: {ex.Message}");
            }
        }

        public async Task<ApiResponse<LezioneDtos>> UpdateAsync(LezioneUpdateDtos dto)
        {
            try
            {
                Lezione entity = _mapper.Map<Lezione>(dto);
                ApiResponse<Lezione> updateResult = await _repo.UpdateAsync(entity);

                if (!updateResult.Success)
                    return ApiResponse<LezioneDtos>.Fail(updateResult.Message!);

                ApiResponse<bool> saveResult = await _repo.SaveAsync();
                if (!saveResult.Success)
                    return ApiResponse<LezioneDtos>.Fail(saveResult.Message!);

                LezioneDtos mapped = _mapper.Map<LezioneDtos>(updateResult.Data);
                return ApiResponse<LezioneDtos>.Ok(mapped, "Lezione aggiornata con successo");
            }
            catch (Exception ex)
            {
                return ApiResponse<LezioneDtos>.Fail($"Errore interno: {ex.Message}");
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

                return ApiResponse<bool>.Ok(true, "Lezione eliminata con successo");
            }
            catch (Exception ex)
            {
                return ApiResponse<bool>.Fail($"Errore interno: {ex.Message}");
            }
        }
    }
}
