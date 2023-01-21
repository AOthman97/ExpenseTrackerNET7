using ExpenseTrackerNET7.Models;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTrackerNET7.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions options) : base(options)
        {}

        public DbSet<Category> Categories { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
    }
}