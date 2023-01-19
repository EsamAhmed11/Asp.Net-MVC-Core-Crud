namespace Task_1._0.ViewModel
{
    public class SupplierVM
    {
        [Display(Name = "ID")]
        public int SupplierID { get; set; }
        [Required(ErrorMessage = "You Must Enter SupplierName For this Product"), MaxLength(100)]
        public string SupplierName { get; set; }
    }
}
