namespace Task_1._0.Models
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name ="ID")]
        public int ProductID { get; set; }
        [Required(ErrorMessage = "You Must Enter ProductName For this Product"),MaxLength(100)]
        public string ProductName { get; set; }
        [Required(ErrorMessage = "You Must Enter QuantityPerUnit Like that {Kilo, box, can, liter, bottle} For this Product")]
        public string QuantityPerUnit { get; set; }
        public int ReorderLevel { get; set; }
        [Required(ErrorMessage = "You Must Enter UnitPrice For this Product")]
        public decimal UnitPrice { get; set; }
        [Required(ErrorMessage = "You Must Enter UnitsInStock For this Product")]
        public int UnitsInStock { get; set; }
        [Required(ErrorMessage = "You Must Enter UnitsOnOrder For this Product")]
        public int UnitsOnOrder { get; set; }

        [ForeignKey("_Supplier")]
        [Display(Name ="SupplierName")]
        public int SupplierID { get; set; }
        public virtual Supplier _Supplier { get; set; }
    }
}
