using CashFlow.Communication.Enums;
using CashFlow.Communication.Requests;
using CashFlow.Exception;
using FluentValidation;

namespace CashFlow.Application.UseCases.Expenses;

public class ExpenseValidator : AbstractValidator<RequestExpenseJson>
{
    public ExpenseValidator()
    {
        RuleFor(expense => expense.Title).NotEmpty().WithMessage(ResourceErrorMessage.TITLE_REQUIRED);
        RuleFor(expense => expense.Amount).GreaterThan(0).WithMessage(ResourceErrorMessage.AMOUNT_GREATER_THAN_ZERO);
        RuleFor(expense => expense.Date).LessThan(DateTime.UtcNow).WithMessage(ResourceErrorMessage.EXPENSES_DATE_LESS_THAN_TODAY);
        RuleFor(expense => expense.PaymentType).IsInEnum().WithMessage(ResourceErrorMessage.INVALID_PAYMENT);
    }
}
