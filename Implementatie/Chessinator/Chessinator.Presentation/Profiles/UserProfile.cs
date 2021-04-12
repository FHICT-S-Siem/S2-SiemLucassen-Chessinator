using AutoMapper;
using Chessinator.Application.Dtos;
using Chessinator.Domain.Entities;

namespace Chessinator.Presentation.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserDto, User>();
            CreateMap<User, UserDto>();
        }
    }
}
