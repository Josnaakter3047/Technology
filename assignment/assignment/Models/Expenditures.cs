using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace assignment.Models
{
    public class Expenditures
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please Select one"), ForeignKey("Category")]
        public int CategoryId { get; set; }
        [Required, Display(Name = "Date of Expense"), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DateOfExpense { get; set; }
        [Required(ErrorMessage = "This Field is required."), Column(TypeName = "money"), Display(Name = "Total Amount")]
        public decimal TotalAmount { get; set; }
        //nev
        public virtual Category Category { get; set; }

    }
    public class ExpenseView
    {
        public int Id { get; set; }
        [ForeignKey("Categories")]
        public int CategoryId { get; set; }
        [Required, Display(Name = "Date of Expense"), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DateOfExpense { get; set; }
        [Required, Column(TypeName = "money"), Display(Name = "Total Amount")]
        public decimal TotalAmount { get; set; }
        public string CategoryName { get; set; }
    }
}
