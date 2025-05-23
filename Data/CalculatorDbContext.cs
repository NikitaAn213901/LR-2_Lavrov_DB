using Microsoft.EntityFrameworkCore;
using Calculator.Models;

namespace Calculator.Data
{
    public class CalculatorDbContext : DbContext
    {
        public CalculatorDbContext(DbContextOptions<CalculatorDbContext> options)
            : base(options)
        {
        }

        public DbSet<DataInputVariant> DataInputVariants { get; set; }
    }
} 