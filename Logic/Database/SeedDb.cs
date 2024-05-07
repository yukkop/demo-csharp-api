using Logic.Database.Models;
using Logic.Enum;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Logic.Database;

public class SeedDb
{
    public static void UpdateTables(ModelBuilder modelBuilder)
    {
        CreateSuperUser(modelBuilder);
        InitializeRole(modelBuilder);
        PeriodUnit(modelBuilder);
    }
    
    private static void PeriodUnit(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PeriodUnit>().HasData(
            new PeriodUnit { Id = Guid.Parse("28d75a01-942f-446d-9986-6321141914e1"), Unit = "day" },
            new PeriodUnit { Id = Guid.Parse("9ebbb82c-27ef-4a25-a93e-524d61b0a4d7"), Unit = "month" },
            new PeriodUnit { Id = Guid.Parse("15266afb-5997-43ee-93a5-15e6a5b394bf"), Unit = "year" }
        );

        modelBuilder.Entity<Tariff>().Property(t => t.PeriodUnitId).HasDefaultValue(Guid.Parse("28d75a01-942f-446d-9986-6321141914e1"));
    }

    static void InitializeRole(ModelBuilder modelBuilder) {
        modelBuilder.Entity<Role>().HasData(
            new List<Role> {
                new Role {
                    Id = Guid.Parse("2f0bd97b-dd0d-4f54-9a4c-f89cdc06c52d"),
                    Name = UserRoleEnum.Super.ToString(),
                    NormalizedName = UserRoleEnum.Super.ToString().ToUpper() 
                },
                new Role {
                    Id = Guid.Parse("fac6a18c-14b6-4427-981b-7bbaaa77b7c6"),
                    Name = UserRoleEnum.Admin.ToString(),
                    NormalizedName = UserRoleEnum.Admin.ToString().ToUpper() 
                },
                new Role {
                    Id = Guid.Parse("f176c034-6c6c-4f7f-8841-2bd5b05a702a"),
                    Name = UserRoleEnum.VpnUser.ToString(),
                    NormalizedName = UserRoleEnum.VpnUser.ToString().ToUpper() 
                },
                new Role {
                    Id = Guid.Parse("9e479955-2de9-4a9d-b922-bbea18871593"),
                    Name = UserRoleEnum.BotSystem.ToString(),
                    NormalizedName = UserRoleEnum.BotSystem.ToString().ToUpper() 
                },
                new Role {
                    Id = Guid.Parse("1d939b37-0430-49b3-a3ab-ae83913e3745"),
                    Name = UserRoleEnum.Employer.ToString(),
                    NormalizedName = UserRoleEnum.Employer.ToString().ToUpper() 
                }
            }
        );
    }

    public static void CreateSuperUser(ModelBuilder modelBuilder) {
        modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = Guid.Parse("ad15c6e6-9ee1-45ce-b302-7d97c05981a9"),
                    CreatedAt = new DateTime(2023, 5, 7),
                    UpdatedAt = new DateTime(2023, 5, 7),
                    UserName = "super",
                    Email = "super",
                    AccessFailedCount = 0,
                    EmailConfirmed = false,
                    LockoutEnabled = false,
                    NormalizedUserName = "SUPER",
                    NormalizedEmail = "SUPER",
                    TwoFactorEnabled = false,
                    PhoneNumber = "",
                    PhoneNumberConfirmed = false,
                    SecurityStamp = "VKAM7OMLKEQLLLGFQUSC64WVQFY3RURV",
                    ConcurrencyStamp = "8c564238-a0f0-431e-94e5-a27e0a1e5930",
                    PasswordHash = "AQAAAAEAACcQAAAAELhbCt2KM3WtIHFvL1tgqRYuUSf1N43Iu4jpNMIvZLFqXS2W/IO2f2cGaGHLaUFScQ=="
                    // new PasswordHasher<ApplicationUser>().HashPassword(null, "TestPassword123!"),
                });
        
        // Connect the super user to the super role
        modelBuilder.Entity<IdentityUserRole<Guid>>().HasData(new IdentityUserRole<Guid>
        {
            UserId = Guid.Parse("ad15c6e6-9ee1-45ce-b302-7d97c05981a9"),
            RoleId = Guid.Parse("2f0bd97b-dd0d-4f54-9a4c-f89cdc06c52d")
        });
        
        modelBuilder.Entity<User>().HasData(
            new User
            {
                Id = Guid.Parse("4f543b93-c9e8-4cb4-9b97-50c853be65f3"),
                CreatedAt = new DateTime(2023, 5, 7),
                UpdatedAt = new DateTime(2023, 5, 7),
                UserName = "bot-system",
                Email = "bot-system",
                AccessFailedCount = 0,
                EmailConfirmed = false,
                LockoutEnabled = false,
                NormalizedUserName = "BOT-SYSTEM",
                NormalizedEmail = "BOT-SYSTEM",
                TwoFactorEnabled = false,
                PhoneNumber = "",
                PhoneNumberConfirmed = false,
                SecurityStamp = "MA6F44AWYGATEQBSENVLAETCPZ2ATT2N",
                ConcurrencyStamp = "05499e8c-2786-48a2-bfd4-3826b69c2f7e",
                PasswordHash = "AQAAAAEAACcQAAAAEI8giejNCgpSybLTuF2pxOtF6ProHJSdaJ+4IBrxuWr5w9tNVOfvKaLUAzvozSzt1Q=="
                // new PasswordHasher<ApplicationUser>().HashPassword(null, "TestPassword123!"),
            });
        
        modelBuilder.Entity<IdentityUserRole<Guid>>().HasData(new IdentityUserRole<Guid>
        {
            UserId = Guid.Parse("4f543b93-c9e8-4cb4-9b97-50c853be65f3"),
            RoleId = Guid.Parse("9e479955-2de9-4a9d-b922-bbea18871593")
        });
    }
}