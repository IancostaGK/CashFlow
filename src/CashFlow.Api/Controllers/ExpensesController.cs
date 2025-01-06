using CashFlow.Application.UseCases.Expenses.Register;
using CashFlow.Communication.Reponses;
using CashFlow.Communication.Requests;
using CashFlow.Exception.ExceptionsBase;
using Microsoft.AspNetCore.Mvc;

namespace CashFlow.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ExpensesController : ControllerBase
{
    [HttpPost]
    public IActionResult Register([FromBody] RequestExpenseJson request)
    {
        try
        {
            var reponse = new RegisterExpenseUseCase().Execute(request);
            return Created(string.Empty, reponse);
        }
        catch (ErrorOnValidationException ex) {
            var errorResponse = new ResponseErrorJson(ex.Errors);
            return BadRequest(errorResponse);
        }
        catch
        {
            var errorResponse = new ResponseErrorJson("Unkown error");
            return StatusCode(StatusCodes.Status500InternalServerError, errorResponse);
        }
    }
}
