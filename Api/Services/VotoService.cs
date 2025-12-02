using Api.GenericRepositories.Interfaces;
using Api.Responses;
using AutoMapper;
using Dtos.VotoDtos;
using Models;

namespace Api.Services
{
    public class VotoService
    {
        private readonly IGenericRepository<Voto> _repo;
        private readonly IMapper _mapper;

        public VotoService(IGenericRepository<Voto> repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<ApiResponse<IEnumerable<VotoDto>>> GetAllAsync()
        {
            try
            {
                var result = await _repo.GetAllAsync();
                if (!result.Success)
                    return ApiResponse<IEnumerable<VotoDto>>.Fail(result.Message!);

                var mapped = _mapper.Map<IEnumerable<VotoDto>>(result.Data);
                return ApiResponse<IEnumerable<VotoDto>>.Ok(mapped);
            }
            catch (Exception ex)
            {
                return ApiResponse<IEnumerable<VotoDto>>.Fail($"Errore interno: {ex.Message}");
            }
        }

        public async Task<ApiResponse<VotoDto?>> GetByIdAsync(int id)
        {
            try
            {
                var result = await _repo.GetByIdAsync(id);
                if (!result.Success || result.Data == null)
                    return ApiResponse<VotoDto?>.Fail(result.Message!);

                var mapped = _mapper.Map<VotoDto>(result.Data);
                return ApiResponse<VotoDto?>.Ok(mapped);
            }
            catch (Exception ex)
            {
                return ApiResponse<VotoDto?>.Fail($"Errore interno: {ex.Message}");
            }
        }

        public async Task<ApiResponse<VotoDto>> CreateAsync(VotoCreateDto dto)
        {
            try
            {
                Voto entity = _mapper.Map<Voto>(dto);
                ApiResponse<Voto> insertResult = await _repo.InsertAsync(entity);

                if (!insertResult.Success)
                    return ApiResponse<VotoDto>.Fail(insertResult.Message!);

                ApiResponse<bool> saveResult = await _repo.SaveAsync();
                if (!saveResult.Success)
                    return ApiResponse<VotoDto>.Fail(saveResult.Message!);

                VotoDto mapped = _mapper.Map<VotoDto>(insertResult.Data);
                return ApiResponse<VotoDto>.Ok(mapped, "Voto creato con successo");
            }
            catch (Exception ex)
            {
                return ApiResponse<VotoDto>.Fail($"Errore interno: {ex.Message}");
            }
        }

        public async Task<ApiResponse<VotoDto>> UpdateAsync(VotoUpdateDto dto)
        {
            try
            {
                Voto entity = _mapper.Map<Voto>(dto);
                ApiResponse<Voto> updateResult = await _repo.UpdateAsync(entity);

                if (!updateResult.Success)
                    return ApiResponse<VotoDto>.Fail(updateResult.Message!);

                ApiResponse<bool> saveResult = await _repo.SaveAsync();
                if (!saveResult.Success)
                    return ApiResponse<VotoDto>.Fail(saveResult.Message!);

                VotoDto mapped = _mapper.Map<VotoDto>(updateResult.Data);
                return ApiResponse<VotoDto>.Ok(mapped, "Voto aggiornato con successo");
            }
            catch (Exception ex)
            {
                return ApiResponse<VotoDto>.Fail($"Errore interno: {ex.Message}");
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

                return ApiResponse<bool>.Ok(true, "Voto eliminato con successo");
            }
            catch (Exception ex)
            {
                return ApiResponse<bool>.Fail($"Errore interno: {ex.Message}");
            }
        }
    }
}
