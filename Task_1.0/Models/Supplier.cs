
namespace Task_1._0.Models
{
    public class Supplier
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name ="ID")]
        public int SupplierID { get; set; }
        [Required(ErrorMessage = "You Must Enter SupplierName For this Product"), MaxLength(100)]
        public string SupplierName { get; set; }
        public virtual List<Product> products { get; set; } = new List<Product>();
    }
}
