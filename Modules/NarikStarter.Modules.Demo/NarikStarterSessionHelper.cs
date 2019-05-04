using CommonServiceLocator;
using Narik.Common.Services.Core;
using NarikStarter.Modules.Demo.Models;

namespace NarikStarter.Modules.Demo
{
    public class SessionHelper
    {
        private static ISessionStorage _sessionStorage;
        public static ISessionStorage SessionStorage => _sessionStorage ?? (_sessionStorage = ServiceLocator.Current.GetInstance<ISessionStorage>());
        public static NarikStarternUser User => SessionStorage["User"] as NarikStarternUser;
    }
}
