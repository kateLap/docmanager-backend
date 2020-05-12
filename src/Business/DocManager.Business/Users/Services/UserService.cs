using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DocManager.Business.Contract.Core.Exceptions;
using DocManager.Business.Contract.Users.Models;
using DocManager.Business.Contract.Users.Services;
using Microsoft.AspNet.Identity;
using Repository.Contract.Entities;
using Repository.Contract.Repositories;

namespace DocManager.Business.Users.Services
{
    public class UserService : IUserRetrievingService, IUserPasswordStore<ProfileUser, Guid>
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<ProfileUser> GetById(Guid id)
        {
            UserEntity user = await GetInternal(id);

            return Mapper.Map<ProfileUser>(user);
        }

        public async Task<ProfileUser> GetByUserName(string userName)
        {
            UserEntity user = await _userRepository.GetByUserNameAsync(userName);

            return Mapper.Map<ProfileUser>(user);
        }

        public IEnumerable<ProfileUser> GetAll()
        {
            IEnumerable<UserEntity> users = _userRepository.GetAll();

            return users.Select(Mapper.Map<ProfileUser>);
        }

        public void Dispose()
        {
        }

        public async Task CreateAsync(ProfileUser user)
        {
            var userData = new UserEntity();
            FillUserData(userData, user);
            userData.Id = Guid.NewGuid();

            _userRepository.Add(userData);

            await _userRepository.CommitAsync();
        }

        public async Task UpdateAsync(ProfileUser user)
        {
            UserEntity userData = await _userRepository.GetByIdAsync(user.Id);
            FillUserData(userData, user);

            _userRepository.Update(userData);
            await _userRepository.CommitAsync();
        }

        public async Task DeleteAsync(ProfileUser user)
        {
            UserEntity userData = await _userRepository.GetByIdAsync(user.Id);

            _userRepository.Delete(userData);

            await _userRepository.CommitAsync();
        }

        public async Task<ProfileUser> FindByIdAsync(Guid userId)
        {
            return await GetById(userId);
        }

        public async Task<ProfileUser> FindByNameAsync(string userName)
        {
            UserEntity userData = await _userRepository.GetByUserNameAsync(userName);

            return Mapper.Map<UserEntity, ProfileUser>(userData);
        }

        public Task SetPasswordHashAsync(ProfileUser user, string passwordHash)
        {
            user.Password = passwordHash;
            return Task.FromResult(0);
        }

        public Task<string> GetPasswordHashAsync(ProfileUser user)
        {
            return Task.FromResult(user.Password);
        }

        public Task<bool> HasPasswordAsync(ProfileUser user)
        {
            return Task.FromResult(!string.IsNullOrEmpty(user.Password));
        }

        private async Task<UserEntity> GetInternal(Guid id)
        {
            UserEntity user = await _userRepository.GetByIdAsync(id);

            if (user == null)
            {
                throw new DocManagerException("The user does not exist.");
            }

            return user;
        }

        private void FillUserData(UserEntity userData, ProfileUser user)
        {
            userData.Id = user.Id;
            userData.Password = user.Password;
            userData.UserName = user.UserName;
            userData.FirstName = user.FirstName;
            userData.LastName = user.LastName;
            userData.WorkingPosition = Mapper.Map<WorkingPositionEntity>(user.WorkingPosition);
        }
    }
}
