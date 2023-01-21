using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExpenseTrackerNET7.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Column(TypeName = "nvarchar 100")]
        public string Title { get; set; } = string.Empty;
        [Column(TypeName = "nvarchar 150")]
        public string Icon { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
    }
}