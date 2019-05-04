using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Narik.Common.Services.Core;
using Narik.Common.Shared.Models;

namespace NarikStarter.Modules.Demo.Services
{
    public class AccountService: IAccountService
    {

        private readonly NarikStarterDomainService _domainService;
        private readonly IPasswordHasher<ApplicationUser> _passwordHasher;

        public AccountService(NarikStarterDomainService domainService, IPasswordHasher<ApplicationUser> passwordHasher)
        {
            _domainService = domainService;
            _passwordHasher = passwordHasher;
        }

        public async Task<ApplicationUser>  GetApplicationUserByUserName(string userName)
        {
            return await _domainService.GetApplicationUserByUserName(userName);
        }

        public async Task<ServerResponse<string>> ChangePassword(int userId, string oldPassword, string newPassword)
        {
            var oldRealPassword = await _domainService.GetPasswordByUserId(userId);
            var user= _domainService.GetUserByUserId(userId);
            if (_passwordHasher.VerifyHashedPassword(new ApplicationUser(), oldRealPassword,
                    user.UserName.ToLower() + oldPassword) == PasswordVerificationResult.Success)
            {
                await _domainService.UpdateUserPassword(userId, 
                    _passwordHasher.HashPassword(null, user.UserName.ToLower() + newPassword));
                return new ServerResponse<string>(true);
            }

            return new ServerResponse<string>(false, "errors.invalid_password");
        }

        public object CreateReturnUserResult(ApplicationUser user)
        {
            throw new NotImplementedException();
        }

        public Dictionary<string, string> CustomValidateLogin(ApplicationUser user)
        {
            return  new Dictionary<string, string>();
        }

        public async Task<string> GetPasswordByUserName(string userName)
        {
            return await _domainService.GetPasswordByUserName(userName);
        }
    }
}
