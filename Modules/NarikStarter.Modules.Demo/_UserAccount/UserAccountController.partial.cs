using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using Narik.Common.Data.DomainService;
using Narik.Common.Shared.Models;

namespace NarikStarter.Modules.Demo._UserAccount
{
    public partial class UserAccountController
    {
        private readonly IPasswordHasher<ApplicationUser> _passwordHasher;

        public UserAccountController(IPasswordHasher<ApplicationUser> passwordHasher)
        {
            _passwordHasher = passwordHasher;
        }

        protected override EntityUpdateFiledsInfo GetEntityUpdateFiledsInfo(UserAccountViewModel entity)
        {
            var preventItems = new List<string>();
            if (entity.Password == "$$default")
                preventItems.Add("Password");
            return new EntityUpdateFiledsInfo(preventItems);
        }

        protected override void CompleteBeforeSubmitPost(UserAccountViewModel entity, PostData<UserAccountViewModel> postData, bool isNew)
        {
            var currentId = Convert.ToInt32(SessionHelper.User.UserId);
            entity.CreateBy = currentId;
            entity.Password = _passwordHasher.HashPassword(null, entity.UserName.ToLower() + entity.Password);
           
        }

    }
}
