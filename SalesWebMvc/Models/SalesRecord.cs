using SalesWebMvc.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace SalesWebMvc.Models
{
    [Table("SalesRecord")]
    public class SalesRecord
    {
        [Column("Id")]
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Column("Date")]
        [Display(Name = "Date")]
        public DateTime Date { get; set; }

        [Column("Amount")]
        [Display(Name = "Amount")]
        public double Amount { get; set; }

        public SalesStatus Satus { get; set; }

        public Seller Saller { get; set; }

        public SalesRecord()
        {
        }

        public SalesRecord(int id, DateTime date, double amount, SalesStatus satus, Seller saller)
        {
            Id = id;
            Date = date;
            Amount = amount;
            Satus = satus;
            Saller = saller;
        }
    }
}
