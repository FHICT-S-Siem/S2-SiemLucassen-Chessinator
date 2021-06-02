using System;
using System.Collections.Generic;
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
        /// Get User by user id.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public Task<User> GetUserByIdAsync(Guid userId);

        /// <summary>
        /// Create user in database.
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public Task<User> CreateUserAsync(User user);

        /// <summary>
        /// Checks if username already exists.
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public Task<bool> UsernameAlreadyExistAsync(string username);

        /// <summary>
        /// Gets all users from db.
        /// </summary>
        /// <returns></returns>
        public Task<List<User>> GetAllUsersAsync();

        /// <summary>
        /// Updates user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public Task<User> UpdateUserAsync(User user);

        /// <summary>
        ///  Deletes a user with the given user guid.
        /// </summary>
        /// <param name="userGuid"></param>
        /// <returns></returns>
        public Task<bool> DeleteUserAsync(Guid userGuid);

        /// <summary>
        /// Suspends user until unsuspended.
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public Task<User> SuspendUserAsync(User user);

        /// <summary>
        /// Unsuspends user.
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public Task<User> UnsuspendUserAsync(User user);



    }
}
