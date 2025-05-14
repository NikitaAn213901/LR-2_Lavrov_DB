using Calculator.Data;
using Calculator.Models;
using System;

namespace Calculator.Services
{
    public class CalculatorService
    {
        private readonly CalculatorDbContext _dbContext;

        public CalculatorService(CalculatorDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public double Calculate(double firstNumber, double secondNumber, string operation)
        {
            double result = 0;

            switch (operation)
            {
                case "add":
                    result = firstNumber + secondNumber;
                    break;
                case "subtract":
                    result = firstNumber - secondNumber;
                    break;
                case "multiply":
                    result = firstNumber * secondNumber;
                    break;
                case "divide":
                    if (secondNumber == 0)
                    {
                        throw new DivideByZeroException("Деление на ноль невозможно");
                    }
                    result = firstNumber / secondNumber;
                    break;
                default:
                    throw new ArgumentException("Неизвестная операция");
            }

            // Save the calculation to the database
            SaveCalculation(firstNumber, secondNumber, operation, result);

            return result;
        }

        private void SaveCalculation(double firstNumber, double secondNumber, string operation, double result)
        {
            var calculation = new DataInputVariant
            {
                Operand_1 = firstNumber,
                Operand_2 = secondNumber,
                Type_operation = operation,
                Result = result
            };

            _dbContext.DataInputVariants.Add(calculation);
            _dbContext.SaveChanges();
        }
    }
} 