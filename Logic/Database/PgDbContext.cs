using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Logic.Database.Models;

namespace Logic.Database;

public class PgDbContext : IdentityDbContext<User, Role, Guid>
{
    public PgDbContext(DbContextOptions options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        SeedDb.UpdateTables(modelBuilder);
    }
    
    public DbSet<Region> Regions { get; set; }
    public DbSet<Server> Servers { get; set; }
    public DbSet<Certificate> Certificates { get; set; }
    public DbSet<Payment> Payments { get; set; }
    public DbSet<VpnUser> VpnUsers { get; set; }
    public DbSet<VpnUsersPayments> VpnUsersPayments { get; set; }
    public DbSet<Bundle> Bundles { get; set; } 
    public DbSet<EmployeeAccess> EmployeeAccesses { get; set; } 
    public DbSet<Employer> Employers { get; set; } 
    public DbSet<UserPayment> UserPayments { get; set; } 
    public DbSet<Tariff> Tariffs { get; set; } 
    public DbSet<PeriodUnit> PeriodUnits { get; set; } 
}