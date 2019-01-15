﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ADJ.BusinessService.Dtos;
using ADJ.BusinessService.Interfaces;
using ADJ.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
  public class DCBookingController : Controller
  {
    private readonly IDCBookingService _dCBookingService;
    public DCBookingController(IDCBookingService dCBookingService)
    {
      _dCBookingService = dCBookingService;
    }
    // GET: DCBooking
    public async Task<ActionResult> Index(int? pageIndex, string DestinationPort = null, string bookingref = null, DateTime? bookingdatefrom = null, DateTime? bookingdateto = null, string DC = null, DateTime? arrivaldatefrom = null, DateTime? arrivaldateto = null, string Status = null, string Container = null, bool checkClick = false)
    {
      ViewBag.DC = new List<string> { "Market Hong Kong", "Gas Customer Center", "JSI Logistics" };
      ViewBag.Haulier = new List<string> { "123 Cargo", "Cargo Core" };
      SearchingDCBooking searchingDCBooking = await _dCBookingService.getItem();
      ViewBag.DestPort = searchingDCBooking.DestinationPort;
      ViewBag.Status = searchingDCBooking.Status;
      int current = pageIndex ?? 1;
      ViewBag.pageIndex = current;
      PagedListResult<DCBookingDtos> pagedListResult = await _dCBookingService.ListDCBookingDtosAsync(current, 10, DestinationPort, bookingref, bookingdatefrom, bookingdateto, DC, arrivaldatefrom, arrivaldateto, Status, Container);
      pagedListResult.CurrentFilter = current.ToString();
      if (checkClick == true)
      {
        return PartialView("_SearchingDCBookingPartial", pagedListResult);
      }
      return View(pagedListResult);
    }
    public async Task<ActionResult> CreateOrUpdate(PagedListResult<DCBookingDtos> pagedListResult)
    {
      ViewBag.DC = new List<string> { "Market Hong Kong", "Gas Customer Center", "JSI Logistics" };
      ViewBag.Haulier = new List<string> { "123 Cargo", "Cargo Core" };
      SearchingDCBooking searchingDCBooking = await _dCBookingService.getItem();
      ViewBag.DestPort = searchingDCBooking.DestinationPort;
      ViewBag.Status = searchingDCBooking.Status;
      ViewBag.ShowResult = 0;
      int current =int.Parse(pagedListResult.CurrentFilter);
      ViewBag.pageIndex = current;
      for (int i = 0; i < pagedListResult.Items.Count(); i++)
      {
        if (pagedListResult.Items[i].selected == false)
        {
          string bookingdate = "Items[" + i + "].BookingDate";
          string id = "Items[" + i + "].Id";
          ModelState[bookingdate].ValidationState = ModelState[id].ValidationState;
        }
      }
      foreach(var item in pagedListResult.Items)
      {
        if(item.Id==0 && item.selected == false)
        {
          ViewBag.ShowResult = "empty";
          return PartialView("_AvchieveDCBookingPartial", pagedListResult);
        }
      }
      if (ModelState.IsValid)
      {
        for (int i = 0; i < pagedListResult.Items.Count(); i++)
        {
          if (pagedListResult.Items[i].selected == true)
          {
            pagedListResult.Items[i] = await _dCBookingService.CreateOrUpdate(pagedListResult.Items[i]);
            ViewBag.ShowResult = "success";
          }
        }
      }
      else
      {
        ViewBag.ShowResult = "invalid";
      }
     
      return PartialView("_AvchieveDCBookingPartial", pagedListResult);
    }
  }
}