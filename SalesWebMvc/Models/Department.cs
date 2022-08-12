using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SalesWebMvc.Models
{
    [Table("Departiment")]
    public class Department
    {
        [Column("Id")]
        [Display(Name="Cod")]
        public int Id { get; set; }

        [Column("Name")]
        [Display(Name="Name")]
        public string Name { get; set; }
    }
}
