using AutoMapper;
using MarcouEvento.Application.DTOs;
using MarcouEvento.Application.Interfaces;
using MarcouEvento.Domain.Entities;
using MarcouEvento.Domain.Interface;

namespace MarcouEvento.Application.Services;

public class ExpenseService : IExpenseService
{
    private readonly IExpenseRepository _expenseRepository;
    private readonly IMapper _mapper;

    public ExpenseService(IExpenseRepository expenseRepository, IMapper mapper)
    {
        _expenseRepository = expenseRepository;
        _mapper = mapper; ;
    }

    public async Task Add(ExpenseDTO expenseDTO)
    {
        var expenseEntity = _mapper.Map<Expense>(expenseDTO);
        await _expenseRepository.Create(expenseEntity);
    }

    public async Task Delete(int id)
    {
        var expenseEntity = await _expenseRepository.GetById(id);
        if (expenseEntity == null)
        {
            throw new NullReferenceException("Expense not found");
        }

        await _expenseRepository.Delete(expenseEntity);
    }

    public async Task<ExpenseDTO> GetById(int id)
    {
        var expenseERntity = await _expenseRepository.GetById(id);
        return _mapper.Map<ExpenseDTO>(expenseERntity);
    }

    public async Task<IEnumerable<ExpenseDTO>> GetExpenses()
    {
        var expensesEntity = await _expenseRepository.GetAllExpenses();
        return _mapper.Map<IEnumerable<ExpenseDTO>>(expensesEntity);
    }

    public async Task Update(ExpenseDTO expenseDTO)
    {
        var expenseEntity = _mapper.Map<Expense>(expenseDTO);
        await _expenseRepository.Update(expenseEntity);
    }
}
