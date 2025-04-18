﻿using MarcouEvento.Application.DTOs;
using MarcouEvento.Application.InputModels;
using MarcouEvento.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MarcouEvento.WebUI.Controllers;

public class AddressController : Controller
{

    private readonly IAddressService _addressService;

    public AddressController(IAddressService addressService)
    {
        _addressService = addressService;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var addresses = await _addressService.GetAddresses();
        return View(addresses);
    }

    [HttpGet]
    public IActionResult Create()
    {
        var cadastrarAddressInputModel = _addressService.PreparaInsert();
        return View(cadastrarAddressInputModel);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CadastrarAddressInputModel cadastrarAddressInputModel)
    {
        if (ModelState.IsValid)
        {
            await _addressService.Add(cadastrarAddressInputModel);
            return RedirectToAction(nameof(Index));
        }
        return View(cadastrarAddressInputModel);
    }
}
