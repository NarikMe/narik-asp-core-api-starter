using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace NarikStarter.Data.Model.Mapping
{
    public partial class UserAccountRoleMap : IEntityTypeConfiguration<UserAccountRole>
    {

        private readonly string _schema;
        public UserAccountRoleMap()
            : this("dbo")
        {
        }

        public UserAccountRoleMap(string schema)
        {
            this._schema = schema;
        }


        public void Configure(EntityTypeBuilder<UserAccountRole> builder)
        {
            builder.ToTable("UserAccountRole", _schema);
            builder.HasKey(x => x.Id);

            
            builder.Property(x => x.Id).HasColumnName("Id").HasColumnType("int").IsRequired().UseSqlServerIdentityColumn();
            
            builder.Property(x => x.UserAccountId).HasColumnName("UserAccountId").HasColumnType("int").IsRequired();
            
            builder.Property(x => x.RoleId).HasColumnName("RoleId").HasColumnType("int").IsRequired();
            

            
            builder.HasOne(p => p.Role)
            .WithMany(p => p.UserAccountRoles).HasForeignKey(x => x.RoleId).IsRequired();
            
            builder.HasOne(p => p.UserAccount)
            .WithMany(p => p.UserAccountRoles).HasForeignKey(x => x.UserAccountId).IsRequired();
            

            ConfigurePartial(builder);
        }

        partial void ConfigurePartial(EntityTypeBuilder<UserAccountRole> builder);

     
    }
}
