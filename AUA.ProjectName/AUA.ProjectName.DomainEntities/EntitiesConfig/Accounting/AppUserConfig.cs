using AUA.ProjectName.Common.Consts;
using AUA.ProjectName.DomainEntities.Entities.Accounting.AppUserAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AUA.ProjectName.DomainEntities.EntitiesConfig.Accounting
{
    public class AppUserConfig : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {

            builder
                .Property(p => p.FirstName)
                .HasMaxLength(LengthConsts.MaxStringLen50);

            builder
                .Property(p => p.LastName)
                .HasMaxLength(LengthConsts.MaxStringLen50);

            builder
                .Property(p => p.IsActive)
                .IsRequired();

            builder
                .OwnsOne(p => p.UserContact, userContact =>
                {
                    userContact.Property(p => p.Phone)
                        .HasMaxLength(LengthConsts.MaxStringLen25);

                    userContact.Property(p => p.Email)
                        .HasMaxLength(LengthConsts.MaxStringLen100);
                });

        }

    }
}
