using Api.GenericRepositories.Repositories;
using Api.Responses;
using AutoMapper;
using Dtos.DocenteDtos;
using Models;

namespace Api.Services
{
    public class DocenteService
    {
        private readonly GRepository<Docente> _repo;
        private readonly IMapper _mapper;

        public DocenteService(GRepository<Docente> repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<ApiResponse<IEnumerable<DocenteDto>>> GetAllAsync()
        {
            var result = await _repo.GetAllAsync();

            var mapped = _mapper.Map<IEnumerable<DocenteDto>>(result.Data);
            return ApiResponse<IEnumerable<DocenteDto>>.Ok(mapped, "Lista recuperata con successo.");
        }

        public async Task<ApiResponse<DocenteDto>> GetByIdAsync(int id)
        {
            var result = await _repo.GetByIdAsync(id);
            if (!result.Success || result.Data == null)
            {
                return ApiResponse<DocenteDto>.Fail("Docente non trovato.");
            }
            var mapped = _mapper.Map<DocenteDto>(result.Data);
            return ApiResponse<DocenteDto>.Ok(mapped, "Docente recuperato con successo.");
        }

        public async Task<ApiResponse<DocenteDto>> CreateAsync(DocenteCreateDto dto)
        {
            Docente entity = _mapper.Map<Docente>(dto);
            ApiResponse<Docente> insertResult = await _repo.InsertAsync(entity);
            if (!insertResult.Success)
                return ApiResponse<DocenteDto>.Fail(insertResult.Message!);
            ApiResponse<bool> saveResult = await _repo.SaveAsync();
            if (!saveResult.Success)
                return ApiResponse<DocenteDto>.Fail(saveResult.Message!);
            DocenteDto mapped = _mapper.Map<DocenteDto>(insertResult.Data);
            return ApiResponse<DocenteDto>.Ok(mapped, "Docente creato con successo.");
        }

        public async Task<ApiResponse<DocenteDto>> UpdateAsync(int id, DocenteUpdateDto dto)
        {
            var existingResult = await _repo.GetByIdAsync(id);
            if (!existingResult.Success || existingResult.Data == null)
            {
                return ApiResponse<DocenteDto>.Fail("Docente non trovato.");
            }

            Docente entity = _mapper.Map<Docente>(dto);
            entity.DocenteId = id;

            ApiResponse<Docente> updateResult = await _repo.UpdateAsync(entity);
            if (!updateResult.Success)
                return ApiResponse<DocenteDto>.Fail(updateResult.Message!);
            ApiResponse<bool> saveResult = await _repo.SaveAsync();
            if (!saveResult.Success)
                return ApiResponse<DocenteDto>.Fail(saveResult.Message!);
            DocenteDto mapped = _mapper.Map<DocenteDto>(updateResult.Data);
            return ApiResponse<DocenteDto>.Ok(mapped, "Docente aggiornato con successo.");
        }

        public async Task<ApiResponse<bool>> DeleteAsync(int id)
        {
            var existingResult = await _repo.GetByIdAsync(id);
            if (!existingResult.Success || existingResult.Data == null)
            {
                return ApiResponse<bool>.Fail("Docente non trovato.");
            }
            ApiResponse<bool> deleteResult = await _repo.DeleteAsync(id);
            if (!deleteResult.Success)
                return ApiResponse<bool>.Fail(deleteResult.Message!);
            ApiResponse<bool> saveResult = await _repo.SaveAsync();
            if (!saveResult.Success)
                return ApiResponse<bool>.Fail(saveResult.Message!);
            return ApiResponse<bool>.Ok(true, "Docente eliminato con successo.");
        }
    }
}
