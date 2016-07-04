using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebDeveloper.Model
{
    public partial class Categories
    {

        public Categories()
        {
            Products = new HashSet<Products>();
        }

        [Key]
        public int CategoryID { get; set; }

        [StringLength(15)]
        [Required(ErrorMessage = "Category Name is required")]
        [Display(Name = "Category Name : ")]
        public string CategoryName { get; set; }

        [Column(TypeName = "ntext")]
        [Required(ErrorMessage = "Description is required")]
        [Display(Name = "Description : ")]
        public string Description { get; set; }

        [Column(TypeName = "image")]
        [Display(Name = "Picture : ")]
        public byte?[] Picture { get; set; }
        
        public virtual ICollection<Products> Products { get; set; }
    }
}
