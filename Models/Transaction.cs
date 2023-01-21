using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExpenseTrackerNET7.Models
{
    public class Transaction
    {
        [Key]
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public Category? Category { get; set; }
        public decimal Amount { get; set; }
        public string Note { get; set; } = "N/A";
        public DateTime TransactionDate { get; set; } = DateTime.Now;
    }
}