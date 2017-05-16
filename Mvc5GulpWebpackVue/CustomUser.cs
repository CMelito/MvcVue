using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using System.Data.Entity.Infrastructure.Annotations;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using Twilio.Rest.Api.V2010.Account.Usage.Record;

namespace Mvc5GulpWebpackVue
{
    public class CustomUser : IUser<int>
    {
        public int Id { get; set; }
        public string UserName { get; set; }

        public string PasswordHash { get; set; }
        public  int FailedAttempts { get; set; }

        public bool TwoFactorEnabled { get; set; }
        public string PhoneNumber { get; set; }
        public bool PhoneNumberVerified { get; set; }
        public string SecurityStamp { get; set; }
    }

    public class CustomUserDbContext : DbContext
    {
        public CustomUserDbContext() : base("DefaultConnection") { }

        public DbSet<CustomUser> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            var user = modelBuilder.Entity<CustomUser>();
            user.ToTable("Users");
            user.HasKey(x => x.Id);
            user.Property(x => x.Id).IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            user.Property(x => x.UserName).IsRequired().HasMaxLength(256).HasColumnAnnotation("Index",
                new IndexAnnotation(new IndexAttribute("UserNameIndex") {IsUnique = true}));

            base.OnModelCreating(modelBuilder);
        }
    }

    public class CustomUserStore : IUserPasswordStore<CustomUser, int> , IUserLockoutStore<CustomUser,int>, IUserTwoFactorStore<CustomUser,int>, IUserPhoneNumberStore<CustomUser,int>
        ,IUserSecurityStampStore<CustomUser,int>
    {
        private readonly CustomUserDbContext context;
        
        public CustomUserStore(CustomUserDbContext context)
        {
            this.context = context;
        }
        public void Dispose()
        {
            context.Dispose();
        }

        public Task CreateAsync(CustomUser user)
        {
            context.Users.Add(user);
            return context.SaveChangesAsync();
        }

        public Task UpdateAsync(CustomUser user)
        {
            context.Users.Attach(user);
            return context.SaveChangesAsync();
        }

        public Task DeleteAsync(CustomUser user)
        {
            context.Users.Remove(user);
            return context.SaveChangesAsync();
        }

        public Task<CustomUser> FindByIdAsync(int userId)
        {
            return context.Users.FirstOrDefaultAsync(x => x.Id == userId);
        }

        public Task<CustomUser> FindByNameAsync(string userName)
        {
            return context.Users.FirstOrDefaultAsync(x => x.UserName == userName);
        }

        public Task SetPasswordHashAsync(CustomUser user, string passwordHash)
        {
            user.PasswordHash = passwordHash;
            return Task.FromResult(user.PasswordHash);
        }

        public Task<string> GetPasswordHashAsync(CustomUser user)
        {
            return Task.FromResult(user.PasswordHash);
        }

        public Task<bool> HasPasswordAsync(CustomUser user)
        {
            return Task.FromResult(user.PasswordHash != null);
        }

        public Task<DateTimeOffset> GetLockoutEndDateAsync(CustomUser user)
        {
            return Task.FromResult(DateTimeOffset.Now);
        }

        public Task SetLockoutEndDateAsync(CustomUser user, DateTimeOffset lockoutEnd)
        {
            return Task.FromResult("");
        }

        public Task<int> IncrementAccessFailedCountAsync(CustomUser user)
        {
            user.FailedAttempts++;
            return Task.FromResult(user.FailedAttempts);
        }

        public Task ResetAccessFailedCountAsync(CustomUser user)
        {
            return Task.FromResult(user.FailedAttempts = 0);
        }

        public Task<int> GetAccessFailedCountAsync(CustomUser user)
        {
            return Task.FromResult(user.FailedAttempts);
        }

        public Task<bool> GetLockoutEnabledAsync(CustomUser user)
        {
            return Task.FromResult(false);
        }

        public Task SetLockoutEnabledAsync(CustomUser user, bool enabled)
        {
            return Task.FromResult("");
        }

        public Task SetTwoFactorEnabledAsync(CustomUser user, bool enabled)
        {
            return Task.FromResult(user.TwoFactorEnabled = enabled);
        }

        public Task<bool> GetTwoFactorEnabledAsync(CustomUser user)
        {
            return Task.FromResult(user.TwoFactorEnabled);
        }

        public Task SetPhoneNumberAsync(CustomUser user, string phoneNumber)
        {
            return Task.FromResult(user.PhoneNumber = phoneNumber);
        }

        public Task<string> GetPhoneNumberAsync(CustomUser user)
        {
            return Task.FromResult(user.PhoneNumber);
        }

        public Task<bool> GetPhoneNumberConfirmedAsync(CustomUser user)
        {
            return Task.FromResult(user.PhoneNumberVerified);
        }

        public Task SetPhoneNumberConfirmedAsync(CustomUser user, bool confirmed)
        {
            return Task.FromResult(user.PhoneNumberVerified = confirmed);
        }

        public Task SetSecurityStampAsync(CustomUser user, string stamp)
        {
            return Task.FromResult(user.SecurityStamp = stamp);
        }

        public Task<string> GetSecurityStampAsync(CustomUser user)
        {
            return Task.FromResult(user.SecurityStamp);
        }
    }

}