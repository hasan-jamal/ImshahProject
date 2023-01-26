using ImshahProject.Web.Models;
using ImshahProject.Web.Utlity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ImshahProject.Web.Data
{
    public partial class ImshahProjectContext : IdentityDbContext<ApplicationUser>
    {
        public ImshahProjectContext()
        {
        }

        public ImshahProjectContext(
            DbContextOptions<ImshahProjectContext> options) : base(options) { }

        public virtual DbSet<Contact> Contacts { get; set; } = null!;
        public virtual DbSet<Goal> Goals { get; set; } = null!;
        public virtual DbSet<Service> Services { get; set; } = null!;
        public virtual DbSet<Slider> Sliders { get; set; } = null!;
        public virtual DbSet<About> Abouts { get; set; } = null!;
        public virtual DbSet<Information> Informations { get; set; } = null!;
        public virtual DbSet<Partner> Partners { get; set; } = null!;
        public virtual DbSet<Quote> Quotes { get; set; } = null!;

    
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            const string ROLE_ID = "c3a2cde1-caac-4a6c-a24f-1b5d35b47f59";
            const string ADMIN_ID = "a18be9c0-aa65-4af8-bd17-00bd9344e575";
            const string ROLE_CUSTOMER_ID = "a5761da7-a17f-48fa-bcd3-aa25d7b75d15";
            builder.Entity<IdentityRole>().
               HasData(new IdentityRole
               {
                   Id = ROLE_ID,
                   Name = SD.Role_Admin,
                   NormalizedName = SD.Role_Admin_NormalizedName
               });

            builder.Entity<IdentityRole>().
                HasData(new IdentityRole
                {
                    Id = ROLE_CUSTOMER_ID,
                    Name = SD.Role_Customer,
                    NormalizedName = SD.Role_Customer_NormalizedName
                });
           
            var hasher = new PasswordHasher<ApplicationUser>();
            builder.Entity<ApplicationUser>().HasData(new ApplicationUser
            {
                Id = ADMIN_ID,
                Name= "Admin",
                UserName = "adminNew",
                NormalizedUserName = "adminNew",
                Email = "admin@imashah.com",
                NormalizedEmail = "admin@imashah.com",
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "Admin@123#"),
                SecurityStamp = string.Empty
            });
            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>
            {
                RoleId = ROLE_ID,
                UserId = ADMIN_ID
            });
            builder.Entity<Information>().HasData(new Information
            {
                Id= 1,
                GetAquote = "Get Aquote",
                GetAquote_ar = "اضف التسعيرة",
            });
            builder.Entity<About>().HasData(new About
            {
                Id = 1,
                Text1 = "نص بديل ",
                Text2 = "نص بديل ",
                Text_ar1 = "نص بديل ",
                Text3 = "نص بديل ",
                Text_ar2 = "نص بديل ",
                Text_ar3 = "نص بديل ",
            });
            builder.Entity<Goal>().HasData(new Goal
            {
                Id = 1,
                Name = "نص بديل ",
                Name_ar= "نص بديل ",
                Text = "نص بديل ",
                Text_ar = "نص بديل ",
            });

        }


    }
}

