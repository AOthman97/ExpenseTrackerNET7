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
        // We made it as nullable here because when we're inserting/updating a transaction this property is just a navigational
        // property to set the foreign key relationship between these two entities and it would not get binded
        public Category? Category { get; set; }
        public decimal Amount { get; set; }
        public string Note { get; set; } = "N/A";
        public DateTime TransactionDate { get; set; } = DateTime.Now;

        // To get the title of the category directly
        [NotMapped]
        public string? CategoryTitleWithIcon
        {
            get
            {
                return Category == null ? "" : Category.Icon + " " + Category.Title;
            }
        }

        [NotMapped]
        public string? FormattedAmount
        {
            get
            {
                return ((Category == null || Category.Type == "Expenses") ? "- " : "+") + Amount.ToString("C0");
            }
        }
    }
}