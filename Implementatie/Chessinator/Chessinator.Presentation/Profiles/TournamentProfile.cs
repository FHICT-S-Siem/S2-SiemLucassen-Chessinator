using AutoMapper;
using Chessinator.Application.Dtos;
using Chessinator.Domain.Entities;

namespace Chessinator.Presentation.Profiles
{
    public class TournamentProfile : Profile
    {
        public TournamentProfile()
        {
            CreateMap<Tournament, TournamentDto>();
            CreateMap<TournamentDto, Tournament>();
        }
    }
}
