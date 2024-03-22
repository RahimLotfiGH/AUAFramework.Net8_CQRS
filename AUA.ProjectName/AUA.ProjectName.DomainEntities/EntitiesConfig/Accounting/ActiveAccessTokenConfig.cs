using AUA.ProjectName.Common.Consts;
using AUA.ProjectName.DomainEntities.Entities.Accounting.ActiveAccessTokenAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AUA.ProjectName.DomainEntities.EntitiesConfig.Accounting
{
    public class ActiveAccessTokenConfig : IEntityTypeConfiguration<ActiveAccessToken>
    {
        public void Configure(EntityTypeBuilder<ActiveAccessToken> builder)
        {

            builder
                .OwnsOne(p => p.TokenInfo, tokenInfo =>
                {
                    
                    tokenInfo.Property(p => p.RefreshToken)
                             .HasMaxLength(LengthConsts.MaxStringLen200);

                    tokenInfo.Property(p => p.AccessToken)
                             .HasMaxLength(LengthConsts.MaxStringLen2000);
                });
        }

    }
}
