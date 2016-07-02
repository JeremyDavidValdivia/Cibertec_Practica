using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebDeveloper.Model
{
    public partial class Products
    {
        [Key]
        public int ProductID { get; set; }

        [Display(Name = "Product Name : ")]
        [Required(ErrorMessage = "Product Name is required")]
        [StringLength(40)]
        public string ProductName { get; set; }

        [Display(Name = "Supplier ID : ")]
        public int? SupplierID { get; set; }

        [Display(Name = "Category ID : ")]
        public int? CategoryID { get; set; }

        [Display(Name = "Quantity Per Unit : ")]
        [Required(ErrorMessage = "Quantity Per Unit is required")]
        [StringLength(20)]
        public string QuantityPerUnit { get; set; }

        [Display(Name = "Unit Price : ")]
        [Column(TypeName = "money")]
        public decimal? UnitPrice { get; set; }

        [Display(Name = "Units In Stock : ")]
        public short? UnitsInStock { get; set; }

        [Display(Name = "Units On Order : ")]
        public short? UnitsOnOrder { get; set; }

        [Display(Name = "Reorder Level : ")]
        public short? ReorderLevel { get; set; }

        [Display(Name = "Discontinued : ")]
        [Required(ErrorMessage = "Discontinued is required")]
        public bool Discontinued { get; set; }

        [Display(Name = "Categories : ")]
        public virtual Categories Categories { get; set; }
    }
}
