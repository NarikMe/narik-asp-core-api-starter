using Narik.Common.Web.Infrastructure.OData;
using NarikStarter.Data.Model;

namespace NarikStarter.Modules.Demo._UserAccount
{
    public partial class UserAccountController:NarikODataController<UserAccount,
    UserAccountViewModel,NarikStarterDomainService>
    {
        
    }
}
