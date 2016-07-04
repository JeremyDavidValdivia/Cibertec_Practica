using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebDeveloper.Model
{

    public partial class Orders
    {
        [Key]
        public int OrderID { get; set; }

        [Required(ErrorMessage = "Custom ID is required")]
        [Display(Name = "Custom ID :")]
        public int CustomerID { get; set; }

        [Required(ErrorMessage = "Employee ID is required")]
        [Display(Name = "Employee ID :")]
        public int? EmployeeID { get; set; }

        [Display(Name = "Order Date :")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date, ErrorMessage = "Date only")]
        [Required(ErrorMessage = "Order Date is required")]
        public DateTime? OrderDate { get; set; }

        [Display(Name = "Required Date :")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date, ErrorMessage = "Date only")]
        public DateTime? RequiredDate { get; set; }

        [Display(Name = "Shipped Date :")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date, ErrorMessage = "Date only")]
        public DateTime? ShippedDate { get; set; }

        [Display(Name = "Ship Via :")]
        public int? ShipVia { get; set; }

        [Column(TypeName = "money")]
        [Display(Name = "Freight :")]
        public decimal? Freight { get; set; }

        [StringLength(40)]
        [Display(Name = "Ship Name :")]
        public string ShipName { get; set; }

        [StringLength(60)]
        [Display(Name = "Ship Address :")]
        public string ShipAddress { get; set; }

        [StringLength(15)]
        [Display(Name = "Ship City :")]
        public string ShipCity { get; set; }

        [StringLength(15)]
        [Display(Name = "Ship Region :")]
        public string ShipRegion { get; set; }

        [StringLength(10)]
        [Display(Name = "Ship Postal Code :")]
        public string ShipPostalCode { get; set; }

        [StringLength(15)]
        [Display(Name = "Ship Country :")]
        public string ShipCountry { get; set; }

        [Display(Name = "Customers : ")]
        public virtual Customers Customers { get; set; }

        [Display(Name = "Employees : ")]
        public virtual Employees Employees { get; set; }
    }
}
