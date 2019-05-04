using Narik.Common.Shared.Interfaces;

namespace NarikStarter.Modules.Demo._UserAccount
{
    public partial class UserAccountViewModel : INarikViewModel
    {
        public long ViewModelId { get => Id; set => Id = (int)value; }
        
        public int Id { get; set; } 
        
        public string UserName { get; set; } 
        
        public string Title { get; set; } 
        
        public string Password { get; set; } 
        
        public bool IsActive { get; set; } 
        
        public int? CreateBy { get; set; } 
        
        
    }
}
