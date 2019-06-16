using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Aplication.Dto.Category
{
    public class AddCategoryDto
    {
        
        [Required(ErrorMessage = "This field is requeired")]
        [StringLength(40, ErrorMessage = "Category only allows 40 characters")]
        public string Title { get; set; }
        [Required(ErrorMessage = "This field is requeired")]
        [StringLength(150, ErrorMessage = "Description only allows 150 characters")]
        public string Description { get; set; }
    }
}
