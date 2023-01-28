using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ExpenseTrackerNET7.Data;
using ExpenseTrackerNET7.Models;

namespace ExpenseTrackerNET7.Controllers
{
    public class TransactionController : Controller
    {
        private readonly AppDBContext _context;

        public TransactionController(AppDBContext context)
        {
            _context = context;
        }

        // GET: Transaction
        public async Task<IActionResult> Index()
        {
            var appDBContext = _context.Transactions.Include(t => t.Category);
            return View(await appDBContext.ToListAsync());
        }

        // GET: Transaction/AddOrEdit
        public IActionResult AddOrEdit(int Id = 0)
        {
            PopulateCategories();
            if (Id == 0)
                return View(new Transaction());
            else
                return View(_context.Transactions.Find(Id));
        }

        // POST: Transaction/AddOrEdit
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit([Bind("Id,CategoryId,Amount,Note,TransactionDate")] Transaction transaction)
        {
            if (ModelState.IsValid)
            {
                if (transaction.Id == 0)
                    _context.Add(transaction);
                else
                    _context.Transactions.Update(transaction);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            PopulateCategories();
            return View(transaction);
        }

        // GET: Transaction/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Transactions == null)
            {
                return NotFound();
            }

            var transaction = await _context.Transactions
                .Include(t => t.Category)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (transaction == null)
            {
                return NotFound();
            }

            return View(transaction);
        }

        // POST: Transaction/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Transactions == null)
            {
                return Problem("Entity set 'AppDBContext.Transactions'  is null.");
            }
            var transaction = await _context.Transactions.FindAsync(id);
            if (transaction != null)
            {
                _context.Transactions.Remove(transaction);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [NonAction]
        public void PopulateCategories()
        {
            var CategoriesCollection = _context.Categories.ToList();
            Category DefaultChoice = new Category() { Id = 0, Title = "Choose a Category" };
            CategoriesCollection.Insert(0, DefaultChoice);
            ViewBag.CategoryList = CategoriesCollection;
        }
    }
}
