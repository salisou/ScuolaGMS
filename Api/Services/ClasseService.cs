using Api.GenericRepositories.Interfaces;
using Api.Responses;
using AutoMapper;
using Dtos.ClasseDtos;
using Models;

namespace Api.Services
{
    public class ClasseService
    {
        private readonly IGenericRepository<Classe> _repo;
        private readonly IMapper _mapper;

        public ClasseService(IGenericRepository<Classe> repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<ApiResponse<IEnumerable<ClasseDto>>> GetAllAsync()
        {
            try
            {
                var result = await _repo.GetAllAsync();
                if (!result.Success)
                    return ApiResponse<IEnumerable<ClasseDto>>.Fail(result.Message!);

                var mapped = _mapper.Map<IEnumerable<ClasseDto>>(result.Data);
                return ApiResponse<IEnumerable<ClasseDto>>.Ok(mapped);
            }
            catch (Exception ex)
            {
                return ApiResponse<IEnumerable<ClasseDto>>.Fail($"Errore interno: {ex.Message}");
            }
        }

        public async Task<ApiResponse<ClasseDto?>> GetByIdAsync(int id)
        {
            try
            {
                var result = await _repo.GetByIdAsync(id);
                if (!result.Success || result.Data == null)
                    return ApiResponse<ClasseDto?>.Fail(result.Message!);

                var mapped = _mapper.Map<ClasseDto>(result.Data);
                return ApiResponse<ClasseDto?>.Ok(mapped, "Lista recuperata con successo.");
            }
            catch (Exception ex)
            {
                return ApiResponse<ClasseDto?>.Fail($"Errore interno: {ex.Message}");
            }
        }

        public async Task<ApiResponse<ClasseDto>> CreateAsync(ClasseCreateDto dto)
        {
            try
            {
                Classe entity = _mapper.Map<Classe>(dto);
                ApiResponse<Classe> insertResult = await _repo.InsertAsync(entity);

                if (!insertResult.Success)
                    return ApiResponse<ClasseDto>.Fail(insertResult.Message!);

                ApiResponse<bool> saveResult = await _repo.SaveAsync();
                if (!saveResult.Success)
                    return ApiResponse<ClasseDto>.Fail(saveResult.Message!);

                ClasseDto mapped = _mapper.Map<ClasseDto>(insertResult.Data);
                return ApiResponse<ClasseDto>.Ok(mapped, "Classe creata con successo");
            }
            catch (Exception ex)
            {
                return ApiResponse<ClasseDto>.Fail($"Errore interno: {ex.Message}");
            }
        }

        public async Task<ApiResponse<ClasseDto>> UpdateAsync(ClasseUpdateDto dto)
        {
            try
            {
                Classe entity = _mapper.Map<Classe>(dto);
                ApiResponse<Classe> updateResult = await _repo.UpdateAsync(entity);

                if (!updateResult.Success)
                    return ApiResponse<ClasseDto>.Fail(updateResult.Message!);

                ApiResponse<bool> saveResult = await _repo.SaveAsync();
                if (!saveResult.Success)
                    return ApiResponse<ClasseDto>.Fail(saveResult.Message!);

                ClasseDto mapped = _mapper.Map<ClasseDto>(updateResult.Data);
                return ApiResponse<ClasseDto>.Ok(mapped, "Classe aggiornata con successo");
            }
            catch (Exception ex)
            {
                return ApiResponse<ClasseDto>.Fail($"Errore interno: {ex.Message}");
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

                return ApiResponse<bool>.Ok(true, "Classe eliminata con successo");
            }
            catch (Exception ex)
            {
                return ApiResponse<bool>.Fail($"Errore interno: {ex.Message}");
            }
        }
    }
}
