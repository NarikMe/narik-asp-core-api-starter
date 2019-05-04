

namespace NarikStarter.Data.Model
{
    public partial class UserAccountRole
    {
        
        public int Id { get; set; } 
        
        public int UserAccountId { get; set; } 
        
        public int RoleId { get; set; } 
        

        
        public Role Role { get; set; } 
        
        public UserAccount UserAccount { get; set; } 
        

        

    }
}
