﻿// <auto-generated />
using System;
using Logic.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace WebApi.Migrations
{
    [DbContext(typeof(PgDbContext))]
    [Migration("20230508231301_BotSystemUserAndRoleRelations")]
    partial class BotSystemUserAndRoleRelations
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Logic.Database.Models.Certificate", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("PublicKey")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("ReceiveBytes")
                        .HasColumnType("numeric(20,0)");

                    b.Property<Guid>("ServerId")
                        .HasColumnType("uuid");

                    b.Property<decimal>("TransmitBytes")
                        .HasColumnType("numeric(20,0)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.HasIndex("ServerId");

                    b.ToTable("Certificates");
                });

            modelBuilder.Entity("Logic.Database.Models.Payment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("CapturedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("ConfirmationUrl")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Currency")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("IdempotenceKey")
                        .HasColumnType("uuid");

                    b.Property<float>("IncomeValue")
                        .HasColumnType("real");

                    b.Property<bool>("Paid")
                        .HasColumnType("boolean");

                    b.Property<Guid?>("PaymentId")
                        .HasColumnType("uuid");

                    b.Property<bool>("Refundable")
                        .HasColumnType("boolean");

                    b.Property<float>("RefundedValue")
                        .HasColumnType("real");

                    b.Property<string>("ReturnUrl")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("Test")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<float>("Value")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.ToTable("Payments");
                });

            modelBuilder.Entity("Logic.Database.Models.Region", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("IsoCountryCode")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.ToTable("Regions");
                });

            modelBuilder.Entity("Logic.Database.Models.Role", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("2f0bd97b-dd0d-4f54-9a4c-f89cdc06c52d"),
                            ConcurrencyStamp = "3fd7367c-5fda-4ee8-8817-5f7b5f7fa1f4",
                            CreatedAt = new DateTime(2023, 5, 9, 1, 13, 1, 37, DateTimeKind.Local).AddTicks(8568),
                            Name = "Super",
                            NormalizedName = "SUPER",
                            UpdatedAt = new DateTime(2023, 5, 9, 1, 13, 1, 37, DateTimeKind.Local).AddTicks(8572)
                        },
                        new
                        {
                            Id = new Guid("fac6a18c-14b6-4427-981b-7bbaaa77b7c6"),
                            ConcurrencyStamp = "4102391e-28e3-4607-9d55-7ed7b4f277f6",
                            CreatedAt = new DateTime(2023, 5, 9, 1, 13, 1, 37, DateTimeKind.Local).AddTicks(8861),
                            Name = "Admin",
                            NormalizedName = "ADMIN",
                            UpdatedAt = new DateTime(2023, 5, 9, 1, 13, 1, 37, DateTimeKind.Local).AddTicks(8864)
                        },
                        new
                        {
                            Id = new Guid("f176c034-6c6c-4f7f-8841-2bd5b05a702a"),
                            ConcurrencyStamp = "a20d5663-bb3c-49c3-abdb-dcfad428bc22",
                            CreatedAt = new DateTime(2023, 5, 9, 1, 13, 1, 37, DateTimeKind.Local).AddTicks(8908),
                            Name = "VpnUser",
                            NormalizedName = "VPNUSER",
                            UpdatedAt = new DateTime(2023, 5, 9, 1, 13, 1, 37, DateTimeKind.Local).AddTicks(8911)
                        },
                        new
                        {
                            Id = new Guid("9e479955-2de9-4a9d-b922-bbea18871593"),
                            ConcurrencyStamp = "e58f9ee2-5da6-4b23-9f35-a9ecad4cd069",
                            CreatedAt = new DateTime(2023, 5, 9, 1, 13, 1, 37, DateTimeKind.Local).AddTicks(8947),
                            Name = "BotSystem",
                            NormalizedName = "BOTSYSTEM",
                            UpdatedAt = new DateTime(2023, 5, 9, 1, 13, 1, 37, DateTimeKind.Local).AddTicks(8950)
                        },
                        new
                        {
                            Id = new Guid("1d939b37-0430-49b3-a3ab-ae83913e3745"),
                            ConcurrencyStamp = "1f2eba0a-7947-4eec-bffd-2ee0d8c3ce70",
                            CreatedAt = new DateTime(2023, 5, 9, 1, 13, 1, 37, DateTimeKind.Local).AddTicks(8986),
                            Name = "Employer",
                            NormalizedName = "EMPLOYER",
                            UpdatedAt = new DateTime(2023, 5, 9, 1, 13, 1, 37, DateTimeKind.Local).AddTicks(8989)
                        });
                });

            modelBuilder.Entity("Logic.Database.Models.Server", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("CountUsers")
                        .HasColumnType("integer");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Ip")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Port")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("RegionId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.HasIndex("RegionId");

                    b.ToTable("Servers");
                });

            modelBuilder.Entity("Logic.Database.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("integer");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("boolean");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("boolean");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("text");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("ad15c6e6-9ee1-45ce-b302-7d97c05981a9"),
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "8c564238-a0f0-431e-94e5-a27e0a1e5930",
                            CreatedAt = new DateTime(2023, 5, 7, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "super",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            NormalizedEmail = "SUPER",
                            NormalizedUserName = "SUPER",
                            PasswordHash = "AQAAAAEAACcQAAAAELhbCt2KM3WtIHFvL1tgqRYuUSf1N43Iu4jpNMIvZLFqXS2W/IO2f2cGaGHLaUFScQ==",
                            PhoneNumber = "",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "VKAM7OMLKEQLLLGFQUSC64WVQFY3RURV",
                            TwoFactorEnabled = false,
                            UpdatedAt = new DateTime(2023, 5, 7, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UserName = "super"
                        },
                        new
                        {
                            Id = new Guid("4f543b93-c9e8-4cb4-9b97-50c853be65f3"),
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "05499e8c-2786-48a2-bfd4-3826b69c2f7e",
                            CreatedAt = new DateTime(2023, 5, 7, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "bot-system",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            NormalizedEmail = "BOT-SYSTEM",
                            NormalizedUserName = "BOT-SYSTEM",
                            PasswordHash = "AQAAAAEAACcQAAAAEI8giejNCgpSybLTuF2pxOtF6ProHJSdaJ+4IBrxuWr5w9tNVOfvKaLUAzvozSzt1Q==",
                            PhoneNumber = "",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "MA6F44AWYGATEQBSENVLAETCPZ2ATT2N",
                            TwoFactorEnabled = false,
                            UpdatedAt = new DateTime(2023, 5, 7, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UserName = "bot-system"
                        });
                });

            modelBuilder.Entity("Logic.Database.Models.VpnUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("Balance")
                        .HasColumnType("integer");

                    b.Property<Guid?>("CertificateId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("DateOfLastBalanceDecrease")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("FirstName")
                        .HasColumnType("text");

                    b.Property<bool>("FreePeriodUsed")
                        .HasColumnType("boolean");

                    b.Property<string>("LastName")
                        .HasColumnType("text");

                    b.Property<Guid?>("RegionId")
                        .HasColumnType("uuid");

                    b.Property<long>("TelegramId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Username")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("CertificateId");

                    b.HasIndex("RegionId");

                    b.ToTable("VpnUsers");
                });

            modelBuilder.Entity("Logic.Database.Models.VpnUsersCertificates", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid?>("CertificateId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<Guid?>("VpnUserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("CertificateId");

                    b.HasIndex("VpnUserId");

                    b.ToTable("VpnUsersCertificates");
                });

            modelBuilder.Entity("Logic.Database.Models.VpnUsersPayments", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<Guid?>("PaymentId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("ValueToBalance")
                        .HasColumnType("integer");

                    b.Property<Guid?>("VpnUserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("PaymentId");

                    b.HasIndex("VpnUserId");

                    b.ToTable("VpnUsersPayments");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("text");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("text");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uuid");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);

                    b.HasData(
                        new
                        {
                            UserId = new Guid("ad15c6e6-9ee1-45ce-b302-7d97c05981a9"),
                            RoleId = new Guid("2f0bd97b-dd0d-4f54-9a4c-f89cdc06c52d")
                        },
                        new
                        {
                            UserId = new Guid("4f543b93-c9e8-4cb4-9b97-50c853be65f3"),
                            RoleId = new Guid("9e479955-2de9-4a9d-b922-bbea18871593")
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Value")
                        .HasColumnType("text");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Logic.Database.Models.Certificate", b =>
                {
                    b.HasOne("Logic.Database.Models.Server", "Server")
                        .WithMany()
                        .HasForeignKey("ServerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Server");
                });

            modelBuilder.Entity("Logic.Database.Models.Server", b =>
                {
                    b.HasOne("Logic.Database.Models.Region", "Region")
                        .WithMany("Servers")
                        .HasForeignKey("RegionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Region");
                });

            modelBuilder.Entity("Logic.Database.Models.VpnUser", b =>
                {
                    b.HasOne("Logic.Database.Models.Certificate", "Certificate")
                        .WithMany()
                        .HasForeignKey("CertificateId");

                    b.HasOne("Logic.Database.Models.Region", "Region")
                        .WithMany()
                        .HasForeignKey("RegionId");

                    b.Navigation("Certificate");

                    b.Navigation("Region");
                });

            modelBuilder.Entity("Logic.Database.Models.VpnUsersCertificates", b =>
                {
                    b.HasOne("Logic.Database.Models.Certificate", "Certificate")
                        .WithMany()
                        .HasForeignKey("CertificateId");

                    b.HasOne("Logic.Database.Models.VpnUser", "VpnUser")
                        .WithMany("CertificateHistory")
                        .HasForeignKey("VpnUserId");

                    b.Navigation("Certificate");

                    b.Navigation("VpnUser");
                });

            modelBuilder.Entity("Logic.Database.Models.VpnUsersPayments", b =>
                {
                    b.HasOne("Logic.Database.Models.Payment", "Payment")
                        .WithMany()
                        .HasForeignKey("PaymentId");

                    b.HasOne("Logic.Database.Models.VpnUser", "VpnUser")
                        .WithMany("PaymentHistory")
                        .HasForeignKey("VpnUserId");

                    b.Navigation("Payment");

                    b.Navigation("VpnUser");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.HasOne("Logic.Database.Models.Role", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.HasOne("Logic.Database.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.HasOne("Logic.Database.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.HasOne("Logic.Database.Models.Role", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Logic.Database.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.HasOne("Logic.Database.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Logic.Database.Models.Region", b =>
                {
                    b.Navigation("Servers");
                });

            modelBuilder.Entity("Logic.Database.Models.VpnUser", b =>
                {
                    b.Navigation("CertificateHistory");

                    b.Navigation("PaymentHistory");
                });
#pragma warning restore 612, 618
        }
    }
}
