using AutoMapper;
using Dtos.AulaDtos;
using Dtos.ClasseDtos;
using Dtos.CorsoDtos;
using Dtos.DocenteDtos;
using Dtos.IscrizioneDtos;
using Dtos.LezioneDtos;
using Dtos.PresenzeDtos;
using Dtos.StudenteDtos;
using Dtos.ValutazioneDtos;
using Dtos.VotoDtos;
using Models;

namespace Api.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Aula
            CreateMap<Aula, AulaDto>();
            CreateMap<AulaCreateDto, Aula>();
            CreateMap<AulaUpdateDto, Aula>();

            // Studente
            CreateMap<Studente, StudenteDto>();
            CreateMap<StudenteCreateDto, Studente>();
            CreateMap<StudenteUpdateDto, Studente>();

            // Corso
            CreateMap<Corso, CorsoDto>();
            CreateMap<CorsoCreateDto, Corso>();
            CreateMap<CorsoUpdateDto, Corso>();

            // Docente
            CreateMap<Docente, DocenteDto>();
            CreateMap<DocenteCreateDto, Docente>();
            CreateMap<DocenteUpdateDto, Docente>();

            // Lezione
            CreateMap<Lezione, LezioneDtos>();
            CreateMap<LezioneCreateDtos, Lezione>();
            CreateMap<LezioneUpdateDtos, Lezione>();

            // Presenza
            CreateMap<Presenza, PresenzaDto>();
            CreateMap<PresenzaCreateDto, Presenza>();
            CreateMap<PresenzaUpdateDto, Presenza>();

            // Valutazione
            CreateMap<Valutazione, ValutazioneDto>();
            CreateMap<ValutazioneCreateDto, Valutazione>();
            CreateMap<ValutazioneUpdateDto, Valutazione>();

            // Iscrizione
            CreateMap<Iscrizione, IscrizioneDto>();
            CreateMap<IscrizioneCreateDto, Iscrizione>();
            CreateMap<IscrizioneUpdateDto, Iscrizione>();

            // Classe
            CreateMap<Classe, ClasseDto>();
            CreateMap<ClasseCreateDto, Classe>();
            CreateMap<ClasseUpdateDto, Classe>();

            // Voto
            CreateMap<Voto, VotoDto>();
            CreateMap<VotoCreateDto, Voto>().ReverseMap();
            CreateMap<VotoUpdateDto, Voto>();
        }
    }
}
