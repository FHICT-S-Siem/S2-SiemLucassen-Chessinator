using System.Threading.Tasks;
using Chessinator.Domain.Entities;

namespace Chessinator.Application.Interfaces
{
    public interface IUserRepository
    {
        public Task<User> GetUserByUsernameAsync(string username);
    }
}
