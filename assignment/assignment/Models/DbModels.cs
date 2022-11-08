using Microsoft.EntityFrameworkCore;

namespace assignment.Models
{
    public class ExpenseDbContext : DbContext
    {
        public ExpenseDbContext(DbContextOptions<ExpenseDbContext> options) : base(options)
        {

        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Expenditures> Expenditures { get; set; }
    }
}
