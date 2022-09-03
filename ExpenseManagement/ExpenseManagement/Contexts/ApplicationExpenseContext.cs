using ExpenseManagement.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ExpenseManagement.Contexts
{
    public class ApplicationExpenseContext : IdentityDbContext<User>
    {
        public ApplicationExpenseContext(DbContextOptions options)
        : base(options)
        {
        }

        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);


            //seed admin role
            string ADMIN_ROLE = "341743f0-asd2–42de-afbf-59kmkkmk72cf6";
            builder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Name = "admin",
                NormalizedName = "ADMIN",
                Id = ADMIN_ROLE,
                ConcurrencyStamp = ADMIN_ROLE
            });


            //seed user role
            string USER_ROLE = "601f0ede-374e-45f0-9373-50cba7a8183e";
            builder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Name = "User",
                NormalizedName = "USER",
                Id = USER_ROLE,
                ConcurrencyStamp = USER_ROLE
            });



            //create user

            string USER_ID = "272cf1fd-6e8b-4bdb-87b8-b136033fad9e";
            var newUserDummy = new User
            {
                Id = USER_ID,
                Email = "carlosg@gmail.com",
                EmailConfirmed = true,
                FirstName = "Carlos",
                LastName = "Gomez",
                UserName = "carlosgomez",
                NormalizedUserName = "CARLOSGOMEZ"
            };

            PasswordHasher<User> ph1 = new PasswordHasher<User>();
            newUserDummy.PasswordHash = ph1.HashPassword(newUserDummy, "MyPassword_?");

            builder.Entity<User>().HasData(newUserDummy);

            builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = USER_ROLE,
                UserId = USER_ID
            });



            //create admin user
            string ADMIN_ID = "02174cf0–9412–4cfe-afbf-59f706d72cf6";
            var newAdmin = new User
            {
                Id = ADMIN_ID,
                Email = "admin@gmail.com",
                EmailConfirmed = true,
                FirstName = "Admin",
                LastName = "Super",
                UserName = "admin",
                NormalizedUserName = "ADMIN"
            };

            PasswordHasher<User> ph4 = new PasswordHasher<User>();
            newAdmin.PasswordHash = ph4.HashPassword(newAdmin, "MyPassword_?");

            builder.Entity<User>().HasData(newAdmin);

            builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = ADMIN_ROLE,
                UserId = ADMIN_ID
            });
        }
        public DbSet<Expense>? Expenses { get; set; }



    }
}
