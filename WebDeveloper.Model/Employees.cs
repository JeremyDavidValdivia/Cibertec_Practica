using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebDeveloper.Model
{

    public partial class Employees
    {
        
        public Employees()
        {
            Employees1 = new HashSet<Employees>();
            Orders = new HashSet<Orders>();
        }

        [Key]
        public int EmployeeID { get; set; }

        [StringLength(20)]
        [Required(ErrorMessage = "Last Name is required")]
        [Display(Name = "Last Name : ")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "First Name is required")]
        [Display(Name = "First Name : ")]
        [StringLength(10)]
        public string FirstName { get; set; }

        [StringLength(30)]
        [Required(ErrorMessage = "Title is required")]
        [Display(Name = "Title : ")]
        public string Title { get; set; }

        [StringLength(25)]
        [Display(Name = "Title of Courtesy: ")]
        public string TitleOfCourtesy { get; set; }

        [Display(Name = "BirthDate : ")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date, ErrorMessage = "Date only")]
        public DateTime? BirthDate { get; set; }

        [Display(Name = "HireDate : ")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date, ErrorMessage = "Date only")]
        public DateTime? HireDate { get; set; }

        [StringLength(60)]
        [Display(Name = "Address : ")]
        public string Address { get; set; }

        [StringLength(15)]
        [Display(Name = "City : ")]
        public string City { get; set; }

        [StringLength(15)]
        [Display(Name = "Region : ")]
        public string Region { get; set; }

        [StringLength(10)]
        [Display(Name = "PostalCode : ")]
        public string PostalCode { get; set; }

        [StringLength(15)]
        [Display(Name = "Country : ")]
        public string Country { get; set; }

        [StringLength(24)]
        [Display(Name = "HomePhone : ")]
        public string HomePhone { get; set; }

        [StringLength(4)]
        [Display(Name = "Extension : ")]
        public string Extension { get; set; }

        [Column(TypeName = "image")]
        [Display(Name = "Photo : ")]
        public byte[] Photo { get; set; }

        [Column(TypeName = "ntext")]
        [Display(Name = "Notes : ")]
        public string Notes { get; set; }

        [Display(Name = "Reports To : ")]
        public int? ReportsTo { get; set; }

        [StringLength(255)]
        [Display(Name = "Photo Path : ")]
        public string PhotoPath { get; set; }

        public virtual ICollection<Employees> Employees1 { get; set; }

        public virtual Employees Employees2 { get; set; }
        
        public virtual ICollection<Orders> Orders { get; set; }
    }
}
