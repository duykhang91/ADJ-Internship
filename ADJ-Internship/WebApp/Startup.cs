using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ADJ.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ADJ.WebApp.Identity;
using ADJ.WebApp.Infrastructure.Middlewares;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using ADJ.WebApp.Models;

namespace ADJ.WebApp
{
  public class Startup
  {
    private IServiceProvider _serviceProvider;

    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public IServiceProvider ConfigureServices(IServiceCollection services)
    {
      // Autofac Container
      var builder = new ContainerBuilder();

      // DbContext
      DbContextConfig.Register(services, Configuration);

      // Autofac
      AutofacConfig.Register(builder);

      // AutoMapper
      AutoMapperConfig.Register(builder);

      // Identity
      services.AddDbContext<AppIdentityDbContext>(options =>
          options.UseSqlServer(
              Configuration.GetConnectionString("DefaultConnection")));
      //services.AddDefaultIdentity<IdentityUser>()
      //    .AddEntityFrameworkStores<AppIdentityDbContext>();
      services.AddIdentity<ApplicationUser, IdentityRole>()
        .AddEntityFrameworkStores<AppIdentityDbContext>()
        .AddDefaultTokenProviders();

      //Password Strength Setting
      services.Configure<IdentityOptions>(options =>
      {
        // Password settings
        options.Password.RequireDigit = true;
        options.Password.RequiredLength = 8;
        options.Password.RequireNonAlphanumeric = false;
        options.Password.RequireUppercase = true;
        options.Password.RequireLowercase = false;
        options.Password.RequiredUniqueChars = 6;

        // Lockout settings
        options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(1);
        //options.Lockout.MaxFailedAccessAttempts = 0;
        options.Lockout.AllowedForNewUsers = false;

        // User settings
        options.User.RequireUniqueEmail = true;
      });

      //Setting the Account Login page
      services.ConfigureApplicationCookie(options =>
      {
        // Cookie settings
        options.Cookie.HttpOnly = true;
        options.ExpireTimeSpan = TimeSpan.FromMinutes(30);
        options.LoginPath = "/Account/Login"; // If the LoginPath is not set here,
                                              // ASP.NET Core will default to /Account/Login
        options.LogoutPath = "/Account/Logout"; // If the LogoutPath is not set here,
                                                // ASP.NET Core will default to /Account/Logout
        options.AccessDeniedPath = "/Account/AccessDenied"; // If the AccessDeniedPath is
                                                            // /Account/AccessDenied
        options.SlidingExpiration = true;
      });

      // MVC
      services.AddMemoryCache();
      services.AddDistributedMemoryCache();
      services.AddSession();
      services.Configure<CookiePolicyOptions>(options =>
      {
        // This lambda determines whether user consent for non-essential cookies is needed for a given request.
        options.CheckConsentNeeded = context => true;
        options.MinimumSameSitePolicy = SameSiteMode.None;
      });

      services.AddMvc(options =>
          {
            //options.Filters.Add(typeof(GlobalExceptionFilter));
            //options.ModelBinderProviders.Insert(0, new DateTimeUtcModelBinderProvider());
          })
          .AddJsonOptions(x =>
          {
            x.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
            x.SerializerSettings.DateTimeZoneHandling = DateTimeZoneHandling.Utc;
            x.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
          }).SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

      // Build Autofac Service Provider
      builder.Populate(services);
      var container = builder.Build();
      _serviceProvider = new AutofacServiceProvider(container);
      return _serviceProvider;
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IHostingEnvironment env, IServiceProvider services)
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

      // Session
      app.UseSession();

      // Authentication
      app.UseAuthentication();

      // AppContext
      app.UseMiddleware<ApplicationContextPrincipalBuilderMiddleware>();

      // MVC
      app.UseHttpsRedirection();
      app.UseStaticFiles();
      app.UseCookiePolicy();
      app.UseMvc(routes =>
      {
        routes.MapRoute(
                  name: "default",
                  template: "{controller=Home}/{action=Index}/{id?}");
        routes.MapRoute(
          name: "ProgressCheck",
          template: "{controller=ProgressCheck}/{action=Index}/{pageIndex?}"
          );
        routes.MapRoute(
         name: "Manifest",
         template: "{controller=Manifest}/{action=Index}/{pageIndex?}"
         );
      });

      CreateUserRoles(services).Wait();
    }

    private async Task CreateUserRoles(IServiceProvider serviceProvider)
    {
      var RoleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
      var UserManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

      IdentityResult roleResult;
      //Adding Admin Role
      var roleCheck = await RoleManager.RoleExistsAsync("Admin");
      if (!roleCheck)
      {
        //create the roles and seed them to the database
        roleResult = await RoleManager.CreateAsync(new IdentityRole("Admin"));
      }
      //Assign Admin role to the main User here we have given our newly registered 
      //login id for Admin management
      ApplicationUser user = await UserManager.FindByEmailAsync("sks@abc.com");
      var User = new ApplicationUser();
      await UserManager.AddToRoleAsync(user, "Admin");
    }
  }
}
