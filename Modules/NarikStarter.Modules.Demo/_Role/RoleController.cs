using Narik.Common.Web.Infrastructure.OData;
using NarikStarter.Data.Model;

namespace NarikStarter.Modules.Demo._Role
{
    public partial class RoleController:NarikODataController<Role,
    RoleViewModel, NarikStarterDomainService>
    {
        
    }
}
