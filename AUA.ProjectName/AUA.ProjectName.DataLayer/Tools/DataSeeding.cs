using AUA.ProjectName.Common.Consts;
using AUA.ProjectName.DomainEntities.Entities.Accounting.AccessTokenAggregate;
using AUA.ProjectName.DomainEntities.Entities.Accounting.AccountAggregate;
using AUA.ProjectName.DomainEntities.Entities.Accounting.AccountRoleAggregate;
using AUA.ProjectName.DomainEntities.Entities.Accounting.AppUserAggregate;
using AUA.ProjectName.DomainEntities.Entities.Accounting.ClientAggregate;
using AUA.ProjectName.DomainEntities.Entities.Accounting.RoleAggregate;
using AUA.ProjectName.DomainEntities.Entities.Accounting.RoleUserAccessAggregate;
using AUA.ProjectName.DomainEntities.Entities.Accounting.UserAccessAggregate;
using Microsoft.EntityFrameworkCore;

namespace AUA.ProjectName.DataLayer.Tools
{
    public static class DataSeeding
    {

        public static void Seeding(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AppUser>(p =>
                {
                    p.HasData(new AppUser
                    {
                        Id = 1L,
                        FirstName = "Rahim",
                        LastName = "Lotfi",
                        IsActive = true,
                        CreatorUserId = DefaultValueConsts.SystemUserId

                    });
                    p.OwnsOne(a => a.UserContact).HasData(new
                    {
                        AppUserId = 1L,
                        Email = "Mr_lotfi@ymail.com",
                        Phone = "+989199906342"
                    });
                });


            modelBuilder.Entity<Account>(p =>
            {
                p.HasData(new Account
                {
                    Id = 1L,
                    UserName = "admin",
                    AppUserId = 1,
                    IsActive = true,
                    CreatorUserId = DefaultValueConsts.SystemUserId
                });

                p.OwnsOne(a => a.PasswordCredential).HasData(new
                {
                    AccountId = 1L,
                    Password = "07479BB27E983DD65312BB13F34FE1DDD6E7D597AA7C91C8156B246FA12E0DCF1598CD29D3760225B6C81287F88E1F1F912D1325D4CDE7E77584CEAE6A40E2C8",
                    Salt = "OJfR9nZCD2W4hUaWJxxqGt4Bo/F4Bpcy7cdXAaTcHsI=",
                    PasswordSecurityRate = EPasswordSecurityRate.VeryWeak
                });
            });

            modelBuilder.Entity<Client>(p =>
            {
                p.HasData(new Client
                {
                    Id = 1,
                    IsActive = true,
                    Title = "Default App",
                    IsDefault = true,
                    CreatorUserId = DefaultValueConsts.SystemUserId,
                    Description = "AUA default",
                    AppType = EAppType.WebSite,
                    ClientIdentity = Guid.Parse("9245fe4a-d402-451c-b9ed-9c1a04247482")
                });

                p.OwnsOne(m => m.ClientTokenExpiration).HasData(new
                {
                    ClientId = 1,
                    AccessTokenExpirationMinutes = 60,
                    RefreshTokenExpirationMinutes = 120,
                    NotBeforeMinutes = 0
                });

            });


            modelBuilder.Entity<Role>().HasData(
                new Role { Id = 1, IsActive = true, Title = "Admin", CreatorUserId = DefaultValueConsts.SystemUserId, Description = "AUA default role" });

            modelBuilder.Entity<Role>().HasData(
                new Role { Id = 2, IsActive = true, Title = "User", CreatorUserId = DefaultValueConsts.SystemUserId, Description = "AUA default role" });


            modelBuilder.Entity<AccountRole>().HasData(
                new AccountRole { Id = 1, UserAccountId = 1, RoleId = 1, IsActive = true, CreatorUserId = DefaultValueConsts.SystemUserId, });
           

            modelBuilder.Entity<UserAccess>(p =>
            {
                p.HasData(new UserAccess
                {
                    Id = 1,
                    CreatorUserId = DefaultValueConsts.SystemUserId,
                    IsActive = true,
                    ParentId = 0,
                    AccessCode = EUserAccess.AppUser,
                    Title = "User Management",
                    Url = "../Accounting/AppUser"

                },
                 new UserAccess
                 {
                     Id = 2,
                     CreatorUserId = DefaultValueConsts.SystemUserId,
                     IsActive = true,
                     ParentId = 0,
                     AccessCode = EUserAccess.UserRole,
                     Title = "Access level management",
                     Url = "../Accounting/UserAccess"
                 },
                    new UserAccess
                    {
                        Id = 3,
                        CreatorUserId = DefaultValueConsts.SystemUserId,
                        IsActive = true,
                        ParentId = 0,
                        AccessCode = EUserAccess.UserAccess,
                        Title = "Role Management",
                        Url = "../Accounting/Role"
                    }
                 , new UserAccess
                 {
                     Id = 4,
                     CreatorUserId = DefaultValueConsts.SystemUserId,
                     IsActive = true,
                     ParentId = 0,
                     AccessCode = EUserAccess.UserRoleAccess,
                     Title = "Report access to users",
                     Url = "../reports/UserAccessReport"
                 },
                new UserAccess
                {
                    Id = 5,
                    CreatorUserId = DefaultValueConsts.SystemUserId,
                    IsActive = true,
                    ParentId = 0,
                    AccessCode = EUserAccess.ResetPassword,
                    Title = "Reset Password",
                    Url = ""
                },

                new UserAccess
                {
                    Id = 6,
                    CreatorUserId = DefaultValueConsts.SystemUserId,
                    IsActive = true,
                    ParentId = 0,
                    AccessCode = EUserAccess.UserAccessReport,
                    Title = "User Access Report",
                    Url = ""
                },
                 new UserAccess
                 {
                     Id = 7,
                     CreatorUserId = DefaultValueConsts.SystemUserId,
                     IsActive = true,
                     ParentId = 0,
                     AccessCode = EUserAccess.Account,
                     Title = "Account Management",
                     Url = ""
                 });

                p.OwnsOne(a => a.PageInf).HasData(new
                {
                    UserAccessId = 1,
                    Title = "User Management",
                    Description = "User Management"
                });

                p.OwnsOne(a => a.PageInf).HasData(new
                {
                    UserAccessId = 2,
                    Title = "Access level management",
                    Description = "Access level management"
                });

                p.OwnsOne(a => a.PageInf).HasData(new
                {
                    UserAccessId = 3,
                    Title = "Role Management",
                    Description = "Role Management"
                });

                p.OwnsOne(a => a.PageInf).HasData(new
                {
                    UserAccessId = 4,
                    Title = "Report access to users",
                    Description = "Report access to to users"
                });

                p.OwnsOne(a => a.PageInf).HasData(new
                {
                    UserAccessId = 5,
                    Title = "Reset User Password",
                    Description = "Reset Password"
                });

                p.OwnsOne(a => a.PageInf).HasData(new
                {
                    UserAccessId = 6,
                    Title = "Assign access to roles",
                    Description = "Assign access to roles"
                });

                p.OwnsOne(a => a.PageInf).HasData(new
                {
                    UserAccessId = 7,
                    Title = "Account ",
                    Description = ""
                });
            });


            modelBuilder.Entity<RoleUserAccess>().HasData(
                new RoleUserAccess { Id = 1, RoleId = 1, UserAccessId = 1, CreatorUserId = DefaultValueConsts.SystemUserId, IsActive = true },
                new RoleUserAccess { Id = 2, RoleId = 1, UserAccessId = 2, CreatorUserId = DefaultValueConsts.SystemUserId, IsActive = true },
                new RoleUserAccess { Id = 3, RoleId = 1, UserAccessId = 3, CreatorUserId = DefaultValueConsts.SystemUserId, IsActive = true },
                new RoleUserAccess { Id = 4, RoleId = 1, UserAccessId = 4, CreatorUserId = DefaultValueConsts.SystemUserId, IsActive = true },
                new RoleUserAccess { Id = 5, RoleId = 1, UserAccessId = 5, CreatorUserId = DefaultValueConsts.SystemUserId, IsActive = true },
                new RoleUserAccess { Id = 6, RoleId = 1, UserAccessId = 6, CreatorUserId = DefaultValueConsts.SystemUserId, IsActive = true },
                new RoleUserAccess { Id = 7, RoleId = 1, UserAccessId = 7, CreatorUserId = DefaultValueConsts.SystemUserId, IsActive = true },

                new RoleUserAccess { Id = 8, RoleId = 2, UserAccessId = 2, CreatorUserId = DefaultValueConsts.SystemUserId, IsActive = true },
                new RoleUserAccess { Id = 9, RoleId = 2, UserAccessId = 3, CreatorUserId = DefaultValueConsts.SystemUserId, IsActive = true },
                new RoleUserAccess { Id = 10, RoleId = 2, UserAccessId = 4, CreatorUserId = DefaultValueConsts.SystemUserId, IsActive = true },
                new RoleUserAccess { Id = 11, RoleId = 2, UserAccessId = 6, CreatorUserId = DefaultValueConsts.SystemUserId, IsActive = true }
            );



        }
    }
}
