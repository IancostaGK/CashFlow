using AutoMapper;
using CashFlow.Communication.Reponses;
using CashFlow.Domain.Repositories.Expenses;

namespace CashFlow.Application.UseCases.Expenses.Get;

public class GetExpensesUseCase : IGetExpensesUseCase
{
    private readonly IExpensesReadOnlyRepository _repository;
    private readonly IMapper _mapper;

    public GetExpensesUseCase(IExpensesReadOnlyRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<ResponseListExpensesJson> Execute()
    {
        var result = await _repository.GetAll();

        return new ResponseListExpensesJson
        {
            Expenses = _mapper.Map<List<ResponseExpenseJson>>(result)
        };
    }
}
