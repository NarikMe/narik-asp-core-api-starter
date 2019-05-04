using System.Linq;
using System.Threading.Tasks;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Narik.Common.Data;
using Narik.Common.Shared.Models;
using NarikStarter.Data.Model;

namespace NarikStarter.Modules.Demo
{
    public class NarikStarterDomainService : BaseDomainService<NarikStarterDataService>
    {
        public async Task<string> GetPasswordByUserName(string userName)
        {
            return await DataService.DbContext.UserAccounts.Where(x => x.UserName == userName)
                .Select(x => x.Password).FirstOrDefaultAsync();
        }

        public async Task UpdateUserPassword(int userId, string password)
        {
            await DataService.UpdateUserPassword(userId, password);
        }

        public async Task<string> GetPasswordByUserId(int userId)
        {
            return await DataService.DbContext.UserAccounts.Where(x => x.Id == userId)
                .Select(x => x.Password).FirstOrDefaultAsync();
        }

        public UserAccount GetUserByUserId(int userId)
        {
            return DataService.DbContext.UserAccounts.FirstOrDefault(x => x.Id == userId);
        }

        public async Task<ApplicationUser> GetApplicationUserByUserName(string userName)
        {
            return await DataService.DbContext.UserAccounts.Where(x => x.UserName == userName)
                .ProjectTo<ApplicationUser>().FirstOrDefaultAsync();
        }

        public async Task<bool> UpdateUserRoles(int userId, int[] roles)
        {
            return await DataService.UpdateUserRoles(userId, roles);
        }

        public async Task<int> GetUserRole(int userId)
        {
            return await DataService.GetUserRole(userId);
        }
    }
}
