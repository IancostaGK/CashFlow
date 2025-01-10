using AutoMapper;
using CashFlow.Communication.Reponses;
using CashFlow.Communication.Requests;
using CashFlow.Domain.Entities;

namespace CashFlow.Application.AutoMapper;

public class AutoMapping : Profile
{
    public AutoMapping()
    {
        RequestToEntity();
        RequestToResponse();
    }

    private void RequestToEntity() {
        CreateMap<RequestExpenseJson, Expense>();
    }

    private void RequestToResponse() {
        CreateMap<Expense, ResponseRequestExpenseJson>();
        CreateMap<Expense, ResponseExpenseJson>();
    }
}
