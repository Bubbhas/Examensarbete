using GameOfDojan.Data;
using GameOfDojan.Models;
using GameOfDojan.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace GameOfDojan
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        private IConfiguration _configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Authentication med Azure AD (Open ID Connect)

            services.AddAuthentication(options =>
            {
                options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;
            })
            .AddOpenIdConnect(options =>
            {
                _configuration.Bind("AzureAd", options);
            })
            .AddCookie();

            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            //services.AddScoped<IActionContextAccessor, ActionContextAccessor>();
            services.AddScoped<IHttpService, HttpService>();
            services.AddDbContext<GameOfDojanDbContext>(
                options => options.UseSqlServer(_configuration.GetConnectionString("GameOfDojan")));

            services.AddTransient<IShoePicService, ShoePicService>();
            services.AddTransient<IAiService, AiService>();
            services.AddTransient<UserService, UserService>();
            services.AddTransient<IShoePicData, ShoePicData>();
            services.AddTransient<IUserData, UserData>();
            services.AddTransient<IEmailSender, EmailSender>();
            services.AddIdentity<ApplicationUser, IdentityRole>()
                 .AddEntityFrameworkStores<GameOfDojanDbContext>()
                 //.AddDefaultUI() DENNA ÄR DÅLIG
                 .AddDefaultTokenProviders();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
                  .AddRazorPagesOptions(options =>
                  {
                      options.AllowAreas = true;
                      options.Conventions.AuthorizeAreaFolder("Identity", "/Account/Manage");
                      options.Conventions.AuthorizeAreaPage("Identity", "/Account/Logout");
                  });

            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = $"/Identity/Account/Login";
                options.LogoutPath = $"/Identity/Account/Logout";
                options.AccessDeniedPath = $"/Identity/Account/AccessDenied";
            });
            services.AddHttpContextAccessor();

            //services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            // using Microsoft.AspNetCore.Identity.UI.Services;
            services.TryAddSingleton<IEmailSender, EmailSender>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseRewriter(new RewriteOptions().AddRedirectToHttpsPermanent());

            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseAuthentication();

            app.UseMvc(ConfigureRoutes);
        }

        private void ConfigureRoutes(IRouteBuilder routeBuilder)
        {
            // Sätt upp default routing

            // /Home/Index/4

            routeBuilder.MapRoute("Default", "{controller=Home}/{action=Index}/{id?}");
        }
    }
}

