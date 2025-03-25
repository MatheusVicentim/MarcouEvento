using MarcouEvento.Application.DTOs;

namespace MarcouEvento.Application.Interfaces;

public interface IExpenseService
{
    Task<IEnumerable<ExpenseDTO>> GetExpenses();
    Task<ExpenseDTO> GetById(int id);
    Task Add(ExpenseDTO expenseDTO);
    Task Update(ExpenseDTO expenseDTO);
    Task Delete(int id);
}
