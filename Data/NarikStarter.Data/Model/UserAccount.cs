
using System.Collections.Generic;

namespace NarikStarter.Data.Model
{
    public partial class UserAccount
    {
        
        public int Id { get; set; } 
        
        public string UserName { get; set; } 
        
        public string Title { get; set; } 
        
        public string Password { get; set; } 
        
        public bool IsActive { get; set; } 
        
        public int? CreateBy { get; set; }
        public ICollection<UserAccountRole> UserAccountRoles { get; set; }
    }
}
