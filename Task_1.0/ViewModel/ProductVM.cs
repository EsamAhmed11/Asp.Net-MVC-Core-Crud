namespace Task_1._0.ViewModel
{
    public class ProductVM
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "ID")]
        public int ProductID { get; set; }

        [Required(ErrorMessage = "You Must Enter ProductName For this Product")]
        public string ProductName { get; set; }

        [Required(ErrorMessage = "You Must Select Quantity ")]
        [RegularExpression(@"(Kilo|box|can|liter|bottle)",ErrorMessage = "You Must like that (Kilo,box,can,liter,bottle)")]
        public string QuantityPerUnit { get; set; }

        [Required(ErrorMessage= "You Must Enter ReorderLevel ")]
         public int ReorderLevel { get; set; }
        [Required(ErrorMessage = "You Must Enter UnitPrice ")]
        public decimal UnitPrice { get; set; }
        [Required(ErrorMessage= "You Must Enter UnitsInStock")]
        public int UnitsInStock { get; set; }
        [Required(ErrorMessage = "You Must Enter UnitsOnOrder For this Product")]
        public int UnitsOnOrder { get; set; }
        [Required(ErrorMessage = "You Must Select Supplier")]
        [Display(Name = "SupplierName")]
        public int SupplierID { get; set; }
    }
}
