
//using AUA.ProjectName.Common.Consts;
//using AUA.ProjectName.DomainEntities.Entities.Accounting.AccessTokenAggregate;
//using AUA.ProjectName.DomainEntities.Entities.Accounting.AppUserAggregate;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;

//namespace AUA.ProjectName.DomainEntities.EntitiesConfig.Accounting
//{
//    public class UserContactConfig : IEntityTypeConfiguration<UserContact>
//    {
//        public void Configure(EntityTypeBuilder<UserContact> builder)
//        {

//            builder.HasNoKey();

//            builder.Property(p => p.Phone)
//                .HasMaxLength(LengthConsts.MaxStringLen25);

//            builder.Property(p => p.Email)
//                .HasMaxLength(LengthConsts.MaxStringLen100);
//        }
//    }
//}
