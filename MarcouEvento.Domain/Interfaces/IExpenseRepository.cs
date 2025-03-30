using MarcouEvento.Domain.Entities;

namespace MarcouEvento.Domain.Interface;

public interface IExpenseRepository
{
    Task<IEnumerable<Expense>> Get();
    Task<Expense> GetById(int id);
    Task<Expense> Create(Expense expense);
    Task<Expense> Update(Expense expense);
    Task<Expense> Delete(Expense expense);   
}
