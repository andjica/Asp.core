using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Aplication.Dto.Good
{
    public class GoodDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Title field is required")]
        [StringLength(50, ErrorMessage ="Max size for title is 50 characters")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Description field is required")]
        [StringLength(250, ErrorMessage = "Max size for description is 250 characters")]
        public string Description { get; set; }

        [Required(ErrorMessage = "First Price field is required")]
        [RegularExpression(@"^\d+(.\d{1,2})?$")]
        public decimal FirstPrice { get; set; }

        [Required(ErrorMessage = "Category is required field")]
        public int CategoryId { get; set; }

       

    }
}
