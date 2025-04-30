using MarcouEvento.Application.InputModels;
using MarcouEvento.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MarcouEvento.WebUI.Controllers;

public class PartyController : Controller
{
    private readonly IPartyService _partyService;
    private readonly IAddressService _addressService;
    public PartyController(IPartyService partyService, IAddressService addressService)
    {
        _partyService = partyService;
        _addressService = addressService;
    }

    public async Task<IActionResult> Index()
    {
        var parties = await _partyService.GetPartiesAsync();
        return View(parties);
    }

    [HttpGet]
    public IActionResult Create()
    {
        var partyInputModel = new CadastrarPartyInputModel
        {
            Address = _addressService.PreparaInsert()
        };
        return View(partyInputModel);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CadastrarPartyInputModel cadastrarPartyInputModel)
    {
        if (ModelState.IsValid)
        {
            //vou ajustar o código da creacte.cshtml tratar os ID
            await _partyService.AddAsync(cadastrarPartyInputModel);
            return RedirectToAction(nameof(Index));
        }

        return View(cadastrarPartyInputModel);
    }
}
