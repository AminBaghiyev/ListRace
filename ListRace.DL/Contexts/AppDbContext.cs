using ListRace.Core.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace ListRace.DL.Contexts;

public class AppDbContext : IdentityDbContext<IdentityUser, IdentityRole, string>
{
    public DbSet<Category> Categories { get; set; }
    public DbSet<Place> Places { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        #region Roles
        modelBuilder.Entity<IdentityRole>().HasData(
            new IdentityRole { Id = "36f92c7f-a6e4-48b1-96e9-f3b284c6a5b7", Name = "Admin", NormalizedName = "ADMIN" },
            new IdentityRole { Id = "601a1942-44a1-4f22-bebf-b24df757d368", Name = "User", NormalizedName = "USER" }
        );
        #endregion

        #region User
        IdentityUser admin = new()
        {
            Id = "90f58f47-7bd6-4005-b6ee-e40f632a8fc3",
            UserName = "admin",
            NormalizedUserName = "ADMIN"
        };

        PasswordHasher<IdentityUser> hasher = new();
        admin.PasswordHash = hasher.HashPassword(admin, "admin123");

        modelBuilder.Entity<IdentityUser>().HasData(admin);

        modelBuilder.Entity<IdentityUserRole<string>>().HasData(
            new IdentityUserRole<string> { UserId = admin.Id, RoleId = "36f92c7f-a6e4-48b1-96e9-f3b284c6a5b7" }
        );
        #endregion

        base.OnModelCreating(modelBuilder);
    }
}
