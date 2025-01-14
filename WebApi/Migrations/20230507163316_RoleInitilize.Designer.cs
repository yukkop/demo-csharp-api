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
    [Migration("20230507163316_RoleInitilize")]
    partial class RoleInitilize
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
                            Id = new Guid("a70d7bfe-afa2-4c57-a89a-a126bcd5ec93"),
                            ConcurrencyStamp = "4cf191f5-3135-4478-bf08-95f5e4f8470d",
                            CreatedAt = new DateTime(2023, 5, 7, 18, 33, 16, 303, DateTimeKind.Local).AddTicks(1948),
                            Name = "Super",
                            NormalizedName = "SUPER",
                            UpdatedAt = new DateTime(2023, 5, 7, 18, 33, 16, 303, DateTimeKind.Local).AddTicks(1953)
                        },
                        new
                        {
                            Id = new Guid("084cb6f3-8fd9-4d4f-8628-1317ce96a568"),
                            ConcurrencyStamp = "4c862faa-ff10-4d67-afb0-d65cc29d3554",
                            CreatedAt = new DateTime(2023, 5, 7, 18, 33, 16, 303, DateTimeKind.Local).AddTicks(2186),
                            Name = "Admin",
                            NormalizedName = "ADMIN",
                            UpdatedAt = new DateTime(2023, 5, 7, 18, 33, 16, 303, DateTimeKind.Local).AddTicks(2190)
                        },
                        new
                        {
                            Id = new Guid("36d8f10c-a174-4d89-884e-e43c0b1adb8e"),
                            ConcurrencyStamp = "d639e5c0-f67c-4ba0-b2e9-872c943322cc",
                            CreatedAt = new DateTime(2023, 5, 7, 18, 33, 16, 303, DateTimeKind.Local).AddTicks(2229),
                            Name = "VpnUser",
                            NormalizedName = "VPNUSER",
                            UpdatedAt = new DateTime(2023, 5, 7, 18, 33, 16, 303, DateTimeKind.Local).AddTicks(2232)
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
                            Id = new Guid("9d95bebb-7bc4-4316-a88f-298eea345536"),
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "c4263fbc-ba09-46d3-a158-cad594ac3e3b",
                            CreatedAt = new DateTime(2021, 2, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "yukkop@admin.dev",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "YUKKOP@ADMIN.DEV",
                            NormalizedUserName = "admin",
                            PasswordHash = "YWRtaW4=",
                            PhoneNumber = "",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "MRPQE6W55J6KIZMCPQCRVL7CC6HT66BQ",
                            TwoFactorEnabled = false,
                            UpdatedAt = new DateTime(2021, 2, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UserName = "admin"
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
