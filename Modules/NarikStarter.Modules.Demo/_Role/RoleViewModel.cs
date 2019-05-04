using Narik.Common.Shared.Interfaces;

namespace NarikStarter.Modules.Demo._Role
{
    public partial class RoleViewModel : INarikViewModel
    {
        public long ViewModelId { get => Id; set => Id = (int)value; }
        
        public int Id { get; set; } 
        
        public string Title { get; set; } 
        
        public bool IsActive { get; set; } 
        
    }
}
