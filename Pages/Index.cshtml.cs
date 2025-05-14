using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Calculator.Models;
using Calculator.Services;
using System;

namespace Calculator.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private readonly CalculatorService _calculatorService;

    [BindProperty]
    public CalculatorViewModel Calculator { get; set; }
    
    public string ErrorMessage { get; set; }

    public IndexModel(ILogger<IndexModel> logger, CalculatorService calculatorService)
    {
        _logger = logger;
        _calculatorService = calculatorService;
        Calculator = new CalculatorViewModel();
    }

    public void OnGet()
    {
    }

    public IActionResult OnPost()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        try
        {
            double result = _calculatorService.Calculate(
                Calculator.FirstNumber,
                Calculator.SecondNumber,
                Calculator.Operation
            );

            Calculator.Result = result;
            ErrorMessage = string.Empty;
        }
        catch (DivideByZeroException)
        {
            ErrorMessage = "Деление на ноль невозможно!";
            _logger.LogWarning("Попытка деления на ноль");
        }
        catch (Exception ex)
        {
            ErrorMessage = $"Произошла ошибка: {ex.Message}";
            _logger.LogError(ex, "Ошибка при вычислении");
        }

        return Page();
    }
}
