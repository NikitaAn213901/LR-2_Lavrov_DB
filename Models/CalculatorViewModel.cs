using System.ComponentModel.DataAnnotations;

namespace Calculator.Models
{
    public class CalculatorViewModel
    {
        [Required(ErrorMessage = "Введите первое число")]
        [Display(Name = "Первое число")]
        public double FirstNumber { get; set; }

        [Required(ErrorMessage = "Введите второе число")]
        [Display(Name = "Второе число")]
        public double SecondNumber { get; set; }

        [Required(ErrorMessage = "Выберите операцию")]
        [Display(Name = "Операция")]
        public string Operation { get; set; }

        [Display(Name = "Результат")]
        public double? Result { get; set; }
    }
} 