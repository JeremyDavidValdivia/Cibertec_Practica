using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebDeveloper.Model
{
    public partial class Customers
    {
      
        public Customers()
        {
            Orders = new HashSet<Orders>();
        }

        [Key]
        public int CustomerID { get; set; }

        [StringLength(40)]
        [Required(ErrorMessage = "Company Name is required")]
        [Display(Name = "Company Name : ")]
        public string CompanyName { get; set; }

        [StringLength(30)]
        [Required(ErrorMessage = "Contact Name is required")]
        [Display(Name = "Contact Name : ")]
        public string ContactName { get; set; }

        [StringLength(30)]
        [Display(Name = "Contact Title : ")]
        public string ContactTitle { get; set; }

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
        [Display(Name = "Postal Code : ")]
        public string PostalCode { get; set; }

        [StringLength(15)]
        [Display(Name = "Country : ")]
        public string Country { get; set; }

        [StringLength(24)]
        [Display(Name = "Phone : ")]
        public string Phone { get; set; }

        [StringLength(24)]
        [Display(Name = "Fax : ")]
        public string Fax { get; set; }
        
        public virtual ICollection<Orders> Orders { get; set; }
    }
}
