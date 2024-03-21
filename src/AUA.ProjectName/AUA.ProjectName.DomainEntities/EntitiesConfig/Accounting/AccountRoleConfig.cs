using AUA.ProjectName.DomainEntities.Entities.Accounting.AccountRoleAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AUA.ProjectName.DomainEntities.EntitiesConfig.Accounting
{
    public class AccountRoleConfig : IEntityTypeConfiguration<AccountRole>
    {
        public void Configure(EntityTypeBuilder<AccountRole> builder)
        {

            builder
                .HasOne(p => p.UserAccount)
                .WithMany(p => p.UserRoles)
                .HasForeignKey(p => p.UserAccountId)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .HasOne(p => p.Role)
                .WithMany(p => p.UserRoles)
                .HasForeignKey(p => p.RoleId)
                .OnDelete(DeleteBehavior.NoAction);

        }

    }
}
