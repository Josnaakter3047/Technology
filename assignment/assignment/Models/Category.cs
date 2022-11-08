using System.ComponentModel.DataAnnotations;

namespace assignment.Models
{
    public class Category
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "This Field is required."), StringLength(50)]
        public string CategoryName { get; set; }
        //
        public virtual ICollection<Expenditures> Expenditures { get; set; }
    }
}
