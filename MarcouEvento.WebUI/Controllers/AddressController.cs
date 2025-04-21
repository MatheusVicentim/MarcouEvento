using MarcouEvento.Application.DTOs;
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

    [HttpGet]
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
            return NotFound();

        await _addressService.Delete(id.Value);

        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
            return NotFound();

        var address = await _addressService.PraparaUpdate(id.Value);
        if (address == null)
            return NotFound();
        return View(address);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(EditAddressInputModel editAddressInputModel)
    {
        if (ModelState.IsValid)
        {
            await _addressService.Update(editAddressInputModel);
            return RedirectToAction(nameof(Index));
        }
        return View(editAddressInputModel);
    }

    [HttpGet]
    public async Task<IActionResult> Details(int? id)
    {
        if(id == null) return NotFound();

        var addressViewModel = await _addressService.GetById(id.Value);
        if (addressViewModel == null) return NotFound();

        return View(addressViewModel);

    }
}
