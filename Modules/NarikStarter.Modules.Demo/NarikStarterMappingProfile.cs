using System.Linq;
using AutoMapper;
using Narik.Common.Shared.Models;
using NarikStarter.Data.Model;
using NarikStarter.Modules.Demo._UserAccount;

namespace NarikStarter.Modules.Demo
{
    public class NarikStarterMappingProfile : Profile
    {
        public NarikStarterMappingProfile()
        {
            CreateMap<UserAccount, ApplicationUser>()
                .ForMember(x => x.UserId, x => x.MapFrom(s => s.Id))
                .ForMember(x => x.Roles, x => x.MapFrom(s => s.UserAccountRoles.Select(r => r.RoleId.ToString())));


            CreateMap<UserAccount, UserAccountViewModel>()
                .ForMember(x => x.Password, x => x.MapFrom(s => "$$default"));

        }
    }
}
