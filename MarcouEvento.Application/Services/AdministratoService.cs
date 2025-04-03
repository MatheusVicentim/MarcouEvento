using AutoMapper;
using MarcouEvento.Application.DTOs;
using MarcouEvento.Application.Interfaces;
using MarcouEvento.Domain.Entities;
using MarcouEvento.Domain.Interface;

namespace MarcouEvento.Application.Services;

public class AdministratoService : IAdministratorService
{
    private readonly IAdministratorRepository _administratorRepository;
    private readonly IMapper _mapper;

    public AdministratoService(IAdministratorRepository administrator, IMapper mapper)
    {
        _administratorRepository = administrator;
        _mapper = mapper;
    }

    public async Task Add(AdministratorDTO administratorDTO)
    {
        var administratorEntity = _mapper.Map<Administrator>(administratorDTO);
        await _administratorRepository.Create(administratorEntity);
    }

    public async Task Delete(int id)
    {
        var administratorEntity = await _administratorRepository.GetById(id);
        if (administratorEntity == null)
        {
            throw new NullReferenceException("Administrator not found");
        }

        await _administratorRepository.Delete(administratorEntity);
    }

    public async Task<IEnumerable<AdministratorDTO>> GetAdministrators()
    {
        var administratorsEntity = await _administratorRepository.GetAllAdministrators();
        return _mapper.Map<IEnumerable<AdministratorDTO>>(administratorsEntity);
    }

    public async Task<AdministratorDTO> GetById(int id)
    {
        var administratorEntity = await _administratorRepository.GetById(id);
        return _mapper.Map<AdministratorDTO>(administratorEntity);
    }

    public async Task Update(AdministratorDTO administratorDTO)
    {
        var administratorEntity = _mapper.Map<Administrator>(administratorDTO);
        await _administratorRepository.Update(administratorEntity);
    }
}
