﻿using CashFlow.Application.UseCases.Expenses.Report.Excel;
using CashFlow.Application.UseCases.Expenses.Report.Pdf;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace CashFlow.Api.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ReportController : ControllerBase
{
    [HttpGet("excel")]
    [ProducesResponseType(typeof(FileContentResult), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> GetExcel(
        [FromServices] IGenerateExpensesReportExcelUseCase useCase, 
        [FromHeader] DateOnly month)
    {
        byte[] file = await useCase.Execute(month);

        if (file.Length == 0) return NoContent();

        return File(file, MediaTypeNames.Application.Octet, "report.xlsx");
    }    
    
    [HttpGet("pdf")]
    [ProducesResponseType(typeof(FileContentResult), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> GepPdf(
        [FromServices] IGenerateExpensesReportPdfUseCase useCase, 
        [FromHeader] DateOnly month)
    {
        byte[] file = await useCase.Execute(month);

        if (file.Length == 0) return NoContent();

        return File(file, MediaTypeNames.Application.Pdf, "report.pdf");
    }
}
