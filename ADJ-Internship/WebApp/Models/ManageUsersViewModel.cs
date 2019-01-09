using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace ADJ.WebApp.Models
{
  public class ManageUsersViewModel
  {
    public IdentityUser[] Administrators { get; set; }

    public IdentityUser[] Everyone { get; set; }
  }
}