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
                if (!result.Success)
                    return ApiResponse<IEnumerable<StudenteDto>>.Fail(result.Message!);

            }
        }
    }
}
