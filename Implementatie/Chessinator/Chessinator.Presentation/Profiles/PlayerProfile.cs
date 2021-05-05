using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Chessinator.Application.Dtos;
using Chessinator.Domain.Entities;

namespace Chessinator.Presentation.Profiles
{
    public class PlayerProfile : Profile
    {
        public PlayerProfile()
        {
            CreateMap<Player, ParticipantDto>();
            CreateMap<ParticipantDto, Player>();
        }
    }
}
