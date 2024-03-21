using AUA.ProjectName.Common.Consts;
using AUA.ProjectName.DomainEntities.Entities.Accounting.AccountAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AUA.ProjectName.DomainEntities.EntitiesConfig.Accounting
{
    public class AccountConfig : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder
                .Property(p => p.UserName)
                .HasMaxLength(LengthConsts.MaxStringLen50);

            builder
                .HasOne(p => p.AppUser)
                .WithMany(p => p.UserAccounts)
                .HasForeignKey(p => p.AppUserId)
                .OnDelete(DeleteBehavior.ClientNoAction);

            builder.OwnsOne(p => p.PasswordCredential, userCredential =>
            {
                userCredential.Property(p => p.Password)
                  .HasMaxLength(LengthConsts.MaxStringLen250);

                userCredential.Property(p => p.Salt)
                  .HasMaxLength(LengthConsts.MaxStringLen250);
            });


        }

    }
}
