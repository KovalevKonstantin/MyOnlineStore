using System;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Microsoft.Owin.Infrastructure;
using Microsoft.Owin.Security.Cookies;
using Owin;

[assembly: OwinStartup(typeof(MyStartup))]

public class MyStartup
{
    public void Configuration(IAppBuilder app)
    {
        app.UseCookieAuthentication(new CookieAuthenticationOptions
        {
            AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
            LoginPath = new PathString("/Pages/Account/Login.aspx"),
            CookieManager = new SystemWebCookieManager()
        });
    }

    public class SystemWebCookieManager : ICookieManager
    {
        public string GetRequestCookie(IOwinContext context, string key)
        {
            if (context == null)
                throw new ArgumentNullException("context");
            var webContext = context.Get<HttpContextBase>(typeof(HttpContextBase).FullName);
            var cookie = webContext.Request.Cookies[key];
            return cookie == null ? null : cookie.Value;
        }

        public void AppendResponseCookie(IOwinContext context, string key, string value, CookieOptions options)
        {
            if (context == null)
                throw new ArgumentNullException("context");
            if (options == null)
                throw new ArgumentNullException("options");

            var webContext = context.Get<HttpContextBase>(typeof(HttpContextBase).FullName);

            var domainHasValue = !string.IsNullOrEmpty(options.Domain);
            var pathHasValue = !string.IsNullOrEmpty(options.Path);
            var expiresHasValue = options.Expires.HasValue;

            var cookie = new HttpCookie(key, value);
            if (domainHasValue)
                cookie.Domain = options.Domain;
            if (pathHasValue)
                cookie.Path = options.Path;
            if (expiresHasValue)
                cookie.Expires = options.Expires.Value;
            if (options.Secure)
                cookie.Secure = true;
            if (options.HttpOnly)
                cookie.HttpOnly = true;

            webContext.Response.AppendCookie(cookie);
        }

        public void DeleteCookie(IOwinContext context, string key, CookieOptions options)
        {
            if (context == null)
                throw new ArgumentNullException("context");
            if (options == null)
                throw new ArgumentNullException("options");

            AppendResponseCookie(
                context,
                key,
                string.Empty,
                new CookieOptions
                {
                    Path = options.Path,
                    Domain = options.Domain,
                    Expires = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)
                });
        }
    }

    public class ApplicationUser : IdentityUser
    {
        public bool? IsEnabled { get; set; }
    }
}