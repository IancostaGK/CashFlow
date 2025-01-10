using CashFlow.Application.AutoMapper;
using CashFlow.Application.UseCases.Expenses.Get;
using CashFlow.Application.UseCases.Expenses.GetById;
using CashFlow.Application.UseCases.Expenses.Register;
using Microsoft.Extensions.DependencyInjection;

namespace CashFlow.Infrastructure;

public static class DependencyInjectionExtension
{
    public static void AddApplication(this IServiceCollection services)
    {
        AddAutomapper(services);
        AddUseCases(services);
    }
    
    private static void AddAutomapper(IServiceCollection services)
    {
        services.AddAutoMapper(typeof(AutoMapping));
    }    
    
    private static void AddUseCases(IServiceCollection services)
    {
        services.AddScoped<IRegisterExpenseUseCase, RegisterExpenseUseCase>();
        services.AddScoped<IGetExpensesUseCase, GetExpensesUseCase>();
        services.AddScoped<IGetExpenseByIdUseCase, GetExpenseByIdUseCase>();
    }
}
