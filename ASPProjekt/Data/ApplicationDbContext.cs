using ASPProjekt.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ASPProjekt.Models;
using System.Reflection.Emit;

namespace ASPProjekt.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<TesterProfile> TesterProfiles { get; set; }
        public DbSet<ASPProjekt.Models.Report> Report { get; set; }
        public DbSet<ASPProjekt.Models.Developers> Developers { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {

            //Seed Roles
            builder.Entity<IdentityRole>().HasData(
                new IdentityRole
                {
                    Id = "2c5e174e-3b0e-446f-86af-483d56fd7210",
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                },
                new IdentityRole
                {
                    Id = "2c5e174e-3b0e-446f-86af-483d56fd7211",
                    Name = "User",
                    NormalizedName = "USER"
                },
                new IdentityRole
                {
                    Id = "2c5e174e-3b0e-446f-86af-483d56fd7212",
                    Name = "Dev",
                    NormalizedName = "DEV"
                }
            );
            //Seed Admin and User
            var hasher = new PasswordHasher<ApplicationUser>();
            builder.Entity<ApplicationUser>().HasData(
                new ApplicationUser
                {
                    Id = "8e445865-a24d-4543-a6c6-9443d048cdb9",
                    UserName = "admin@admin.admin",
                    NormalizedUserName = "ADMIN@ADMIN.ADMIN",
                    PasswordHash = hasher.HashPassword(null, "admin"),
                    Email = "admin@admin.admin",
                    NormalizedEmail = "ADMIN@ADMIN.ADMIN",
                    PhoneNumber = "123456789",
                    FirstName = "Admin",
                    LastName = "Admin"
                },
                new ApplicationUser
                {
                    Id = "8e445865-a24d-4543-a6c6-9443d048cdb8",
                    UserName = "user@user.user",
                    NormalizedUserName = "USER@USER.USER",
                    PasswordHash = hasher.HashPassword(null, "user"),
                    Email = "user@user.user",
                    NormalizedEmail = "USER@USER.USER",
                    PhoneNumber = "987654321",
                    FirstName = "User",
                    LastName = "User"
                },
                new ApplicationUser
                {
                    Id = "8e445865-a24d-4543-a6c6-9443d048cdb7",
                    UserName = "dev@dev.dev",
                    NormalizedUserName = "DEV@DEV.DEV",
                    PasswordHash = hasher.HashPassword(null, "dev"),
                    Email = "dev@dev.dev",
                    NormalizedEmail = "DEV@DEV.DEV",
                    PhoneNumber = "987654321",
                    FirstName = "Dev",
                    LastName = "Dev"
                }
             );
            //Add roles for Admin and User
            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>
                {
                    RoleId = "2c5e174e-3b0e-446f-86af-483d56fd7210",
                    UserId = "8e445865-a24d-4543-a6c6-9443d048cdb9"
                },
                new IdentityUserRole<string>
                {
                    RoleId = "2c5e174e-3b0e-446f-86af-483d56fd7211",
                    UserId = "8e445865-a24d-4543-a6c6-9443d048cdb8"
                },
                new IdentityUserRole<string>
                {
                    RoleId = "2c5e174e-3b0e-446f-86af-483d56fd7212",
                    UserId = "8e445865-a24d-4543-a6c6-9443d048cdb7"
                }
            );
            base.OnModelCreating(builder);
        }
    }

}