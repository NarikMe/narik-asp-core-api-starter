using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace NarikStarter.Data.Model.Mapping
{
    public partial class RoleMap : IEntityTypeConfiguration<Role>
    {

        private readonly string _schema;
        public RoleMap()
            : this("dbo")
        {
        }

        public RoleMap(string schema)
        {
            this._schema = schema;
        }


        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.ToTable("Role", _schema);
            builder.HasKey(x => x.Id);

            
            builder.Property(x => x.Id).HasColumnName("Id").HasColumnType("int").IsRequired().UseSqlServerIdentityColumn();
            
            builder.Property(x => x.Title).HasColumnName("Title").HasColumnType("nvarchar").HasMaxLength(50).IsRequired();
            
            builder.Property(x => x.IsActive).HasColumnName("IsActive").HasColumnType("bit").IsRequired();
            

            

            ConfigurePartial(builder);
        }

        partial void ConfigurePartial(EntityTypeBuilder<Role> builder);

     
    }
}
