﻿using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ADJ.WebApp
{
  public static class SeedData
  {
    public static async Task InitializeAsync(
        IServiceProvider services)
    {
      try
      {
        var roleManager = services
    .GetRequiredService<RoleManager<IdentityRole>>();
        await EnsureRolesAsync(roleManager);

        var userManager = services
            .GetRequiredService<UserManager<IdentityUser>>();
        await EnsureTestAdminAsync(userManager);
      }
      catch (Exception abc)
      {

      }

    }

    private static async Task EnsureRolesAsync(
    RoleManager<IdentityRole> roleManager)
    {
      var alreadyExists = await roleManager
          .RoleExistsAsync("Administrator");

      if (alreadyExists) return;

      await roleManager.CreateAsync(
          new IdentityRole("Administrator"));
    }

    private static async Task EnsureTestAdminAsync(
    UserManager<IdentityUser> userManager)
    {
      var testAdmin = await userManager.Users
          .Where(x => x .UserName == "admin@todo.local")
          .SingleOrDefaultAsync();

      if (testAdmin != null) return;

      testAdmin = new IdentityUser
      {
        UserName = "admin@todo.local",
        Email = "admin@todo.local"
      };
      await userManager.CreateAsync(
          testAdmin, "NotSecure123!!");
      await userManager.AddToRoleAsync(
          testAdmin, "Administrator");
    }
  }
}
