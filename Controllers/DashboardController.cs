using ExpenseTrackerNET7.Data;
using ExpenseTrackerNET7.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTrackerNET7.Controllers
{
    public class DashboardController : Controller
    {
        private readonly AppDBContext _context;

        public DashboardController(AppDBContext context)
        {
            _context = context;
        }

        public async Task<ActionResult> Index()
        {
            DateTime StartDate = DateTime.Today.AddDays(-6);
            DateTime EndDate = DateTime.Today;

            // List of transactions within period
            List<Transaction> SelectedTransactions = await _context.Transactions
                .Include(x => x.Category)
                .Where(t => t.TransactionDate >= StartDate && t.TransactionDate <= EndDate)
                .ToListAsync();

            // Total Income
            decimal TotalIncome = SelectedTransactions
                .Where(t => t.Category?.Type == "Income")
                .Sum(a => a.Amount);
            ViewBag.TotalIncome = TotalIncome.ToString("C0");

            // Total Expenses
            decimal TotalExpenses = SelectedTransactions
                .Where(t => t.Category?.Type == "Expenses")
                .Sum(a => a.Amount);
            ViewBag.TotalExpenses = TotalIncome.ToString("C0");

            // Balance
            decimal Balance = TotalIncome- TotalExpenses;
            ViewBag.Balance = Balance.ToString("C0");

            return View();
        }
    }
}