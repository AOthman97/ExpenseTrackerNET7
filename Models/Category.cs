using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExpenseTrackerNET7.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Icon { get; set; } = string.Empty;
        public string Type { get; set; } = "Expense";
        [NotMapped]
        public string? TitleWithIcon 
        { 
            get 
            {
                return this.Title + " " + this.Icon;
            } 
        }
    }
}