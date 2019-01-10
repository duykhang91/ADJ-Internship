using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
  public class AdminController : Controller
  {
    [Authorize(Roles = "Admin")]
    public ActionResult Index()
    {
      return View();
    }
  }
}