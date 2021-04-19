using System.Threading.Tasks;
using Chessinator.Domain.Entities;

namespace Chessinator.Application.Interfaces
{
    public interface IUserRepository
    {
        /// <summary>
        /// Get User by username.
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public Task<User> GetUserByUsernameAsync(string username);

        /// <summary>
        /// Create user in database.
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public Task<User> CreateUserAsync(User user);

        /// <summary>
        /// Checks if username allready exists.
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public Task<bool> UsernameAlreadyExistAsync(string username);
        
    }
}
