using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

[assembly: OwinStartup(typeof(Mvc5GulpWebpackVue.Startup))]

namespace Mvc5GulpWebpackVue
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //const string connectionString = @"Data Source=(LocalDb)\MSSQLLocalDB;Database=Pluralsight.AspNetIdentity;trusted_connection=true;";
            app.CreatePerOwinContext(() => new CustomUserDbContext());
            app.CreatePerOwinContext<CustomUserStore>((opt, cont) => new CustomUserStore(cont.Get<CustomUserDbContext>()));
            app.CreatePerOwinContext<UserManager<CustomUser,int>>((opt, cont) =>
            {
                var userManager = new UserManager<CustomUser,int>(cont.Get<CustomUserStore>());
                userManager.RegisterTwoFactorProvider("SMS", new PhoneNumberTokenProvider<CustomUser,int> { MessageFormat = "Token: {0}"});
                userManager.SmsService = new SmsService();
                return userManager;
            });
            app.CreatePerOwinContext<SignInManager<CustomUser,int>>((opt, cont) => new SignInManager<CustomUser, int>(cont.Get<UserManager<CustomUser,int>>(), cont.Authentication));

            app.UseCookieAuthentication(new Microsoft.Owin.Security.Cookies.CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie
            });

            app.UseTwoFactorSignInCookie(DefaultAuthenticationTypes.TwoFactorCookie, TimeSpan.FromMinutes(5));
            app.UseTwoFactorRememberBrowserCookie(DefaultAuthenticationTypes.TwoFactorRememberBrowserCookie);
        }
    }
}
