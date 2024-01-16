﻿using Business.Abstract;
using Business.Requests.Fuel;
using Business.Responses.Fuel;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FuelController : ControllerBase
{
    private readonly IFuelService _fuelService;
    public FuelController()
    {
        _fuelService = ServiceRegistration.FuelService;
    }

    [HttpGet]
    public ICollection<Fuel> GetList()
    {
        IList<Fuel> fuelList = _fuelService.GetList();
        return fuelList;
    }

    [HttpPost]
    public ActionResult<AddFuelResponse> Add(AddFuelRequest request)
    {
        AddFuelResponse response = _fuelService.Add(request);

        return CreatedAtAction(nameof(GetList), response);
    }
}
