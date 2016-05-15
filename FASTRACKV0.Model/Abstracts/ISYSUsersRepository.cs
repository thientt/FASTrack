// ***********************************************************************
// Assembly         : FASTrack.Model
// Author           : tranthiencdsp@gmail.com
// Created          : 11-04-2015
//
// Last Modified By : tranthiencdsp@gmail.com
// Last Modified On : 03-22-2016
// ***********************************************************************
// <copyright file="ISYSUsersRepository.cs" company="Atmel Corporation">
//     Copyright © Atmel Corporation 2015
// </copyright>
// <summary></summary>
// ***********************************************************************
using FASTrack.Model.DTO;
using FASTrack.Model.Types;
using System.Collections.Generic;
using System.Threading.Tasks;

/// <summary>
/// 
/// </summary>
namespace FASTrack.Model.Abstracts
{
    /// <summary>
    /// 
    /// </summary>
    public interface ISYSUsersRepository : IRepository<SYSUsersDto>
    {
        /// <summary>
        /// Logins the specified email.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <param name="password">The password.</param>
        /// <returns></returns>
        SYSUsersDto Login(string email, string password);

        /// <summary>
        /// Logins the asynchronous.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <param name="password">The password.</param>
        /// <returns></returns>
        Task<SYSUsersDto> LoginAsync(string email, string password);

        /// <summary>
        /// Unlocked the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        SaveResult Unlocked(int id);

        /// <summary>
        /// Locked the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        SaveResult Locked(int id);

        /// <summary>
        /// Unlocked the asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        Task<SaveResult> UnlockedAsync(int id);

        /// <summary>
        /// Locked the asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        Task<SaveResult> LockedAsync(int id);

        /// <summary>
        /// Gets all unlocked.
        /// </summary>
        /// <returns></returns>
        IEnumerable<SYSUsersDto> FindAllUnlocked();

        /// <summary>
        /// Gets all unlocked asynchronous.
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<SYSUsersDto>> FindAllUnlockedAsync();

        /// <summary>
        /// Gets all locked.
        /// </summary>
        /// <returns></returns>
        IEnumerable<SYSUsersDto> FindAllLocked();

        /// <summary>
        /// Gets all locked asynchronous.
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<SYSUsersDto>> FindAllLockedAsync();

        /// <summary>
        /// Sets the role.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="roleType">Type of the role.</param>
        /// <returns></returns>
        SaveResult SetRole(int id, RoleType roleType);

        /// <summary>
        /// Sets the role asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="roleType">Type of the role.</param>
        /// <returns></returns>
        Task<SaveResult> SetRoleAsync(int id, RoleType roleType);

        /// <summary>
        /// Checks the exist email.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <returns>SYSUsersDto.</returns>
        SYSUsersDto CheckExistEmail(string email);

        /// <summary>
        /// Checks the exist email asynchronous.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <returns>Task&lt;SYSUsersDto&gt;.</returns>
        Task<SYSUsersDto> CheckExistEmailAsync(string email);

        /// <summary>
        /// Resets the password.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="newPassword">The new password.</param>
        /// <returns>SaveResult.</returns>
        SaveResult ResetPassword(int id, string newPassword);

        /// <summary>
        /// Resets the password asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="newPassword">The new password.</param>
        /// <returns>Task&lt;SaveResult&gt;.</returns>
        Task<SaveResult> ResetPasswordAsync(int id, string newPassword);

        /// <summary>
        /// Confirms the register.
        /// </summary>
        /// <param name="guid">The unique identifier.</param>
        /// <returns>SaveResult.</returns>
        SaveResult ConfirmRegister(string guid);

        /// <summary>
        /// Confirms the register asynchronous.
        /// </summary>
        /// <param name="guid">The unique identifier.</param>
        /// <returns>Task&lt;SaveResult&gt;.</returns>
        Task<SaveResult> ConfirmRegisterAsync(string guid);

        /// <summary>
        /// Confirms the recover pass.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="guid">The unique identifier.</param>
        /// <returns>SaveResult.</returns>
        SaveResult ConfirmRecoverPass(int id, string guid);

        /// <summary>
        /// Confirms the recover pass asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="guid">The unique identifier.</param>
        /// <returns>Task&lt;SaveResult&gt;.</returns>
        Task<SaveResult> ConfirmRecoverPassAsync(int id, string guid);
    }
}
