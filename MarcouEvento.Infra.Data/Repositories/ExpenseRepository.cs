using MarcouEvento.Domain.Entities;
using MarcouEvento.Domain.Interface;
using MarcouEvento.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace MarcouEvento.Infra.Data.Repositories;

public class ExpenseRepository : IExpenseRepository
{
    private ApplicationDbContext _expenseDbContext;
    public ExpenseRepository(ApplicationDbContext context)
    {
        _expenseDbContext = context;
    }
    public async Task<Expense> Create(Expense expense)
    {
        _expenseDbContext.Add(expense);
        await _expenseDbContext.SaveChangesAsync();

        return expense;
    }

    public async Task<Expense> Delete(Expense expense)
    {
        _expenseDbContext.Remove(expense);
        await _expenseDbContext.SaveChangesAsync();

        return expense;
    }

    public async Task<IEnumerable<Expense>> GetAllExpenses()
    {
        return await _expenseDbContext.Expenses.ToListAsync();
    }

    public async Task<Expense> GetById(int id)
    {
        return await _expenseDbContext.Expenses.FindAsync(id);
    }

    public async Task<Expense> Update(Expense expense)
    {
        _expenseDbContext.Update(expense);
        await _expenseDbContext.SaveChangesAsync();

        return expense;
    }
}
