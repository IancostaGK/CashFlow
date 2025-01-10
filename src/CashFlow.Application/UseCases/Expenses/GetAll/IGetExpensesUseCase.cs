using CashFlow.Communication.Reponses;

namespace CashFlow.Application.UseCases.Expenses.Get;
public interface IGetExpensesUseCase
{
    Task<ResponseListExpensesJson> Execute();

}
