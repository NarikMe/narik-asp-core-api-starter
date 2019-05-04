using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace NarikStarter.Data.Model.Mapping
{
    public partial class UserAccountMap : IEntityTypeConfiguration<UserAccount>
    {

        private readonly string _schema;
        public UserAccountMap()
            : this("dbo")
        {
        }

        public UserAccountMap(string schema)
        {
            this._schema = schema;
        }


        public void Configure(EntityTypeBuilder<UserAccount> builder)
        {
            RelationalEntityTypeBuilderExtensions.ToTable((EntityTypeBuilder) builder, "UserAccount", _schema);
            builder.HasKey(x => x.Id);

            
            builder.Property(x => x.Id).HasColumnName("Id").HasColumnType("int").IsRequired().UseSqlServerIdentityColumn();
            
            builder.Property(x => x.UserName).HasColumnName("UserName").HasColumnType("nvarchar").HasMaxLength(128).IsRequired();
            
            builder.Property(x => x.Title).HasColumnName("Title").HasColumnType("nvarchar").HasMaxLength(128).IsRequired();
            
            builder.Property(x => x.Password).HasColumnName("Password").HasColumnType("varchar").HasMaxLength(256).IsRequired();
            
            builder.Property(x => x.IsActive).HasColumnName("IsActive").HasColumnType("bit").IsRequired();
            
            builder.Property(x => x.CreateBy).HasColumnName("CreateBy").HasColumnType("int");
            
            ConfigurePartial(builder);
        }

        partial void ConfigurePartial(EntityTypeBuilder<UserAccount> builder);

     
    }
}
