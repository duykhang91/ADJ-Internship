using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ADJ.BusinessService.Dtos;
using ADJ.BusinessService.Implementations;
using ADJ.BusinessService.Interfaces;
using ADJ.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApp.Controllers
{
  public class OrderController : Controller
  {
    private readonly IOrderDisplayService _orderService;
    private readonly int pageSize;

    public OrderController(IOrderDisplayService orderService)
    {
      _orderService = orderService;
      pageSize = 20;
    }

    public async Task<IActionResult> Display(string poNumberFilter, string order, int? pageIndex)
    {
      int current = pageIndex ?? 1;
      PagedListResult<OrderDTO> pagedlistResult = await _orderService.DisplaysAsync(poNumberFilter, current, pageSize);

      ViewData["poNumberParam"] = order == "poNumber" ? "poNumber_desc" : "poNumber";

      switch (order)
      {
        case "poNumber":
          pagedlistResult.Items = pagedlistResult.Items.OrderBy(p => p.PONumber).ToList();
          break;
        case "poNumber_desc":
          pagedlistResult.Items = pagedlistResult.Items.OrderByDescending(p => p.PONumber).ToList();
          break;
      }

      ViewBag.CurrentPage = current;
      ViewBag.Sort = order;

      return View(pagedlistResult);
    }
  }
}