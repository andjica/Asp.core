using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Aplication.Dto.Category
{
    public class EditCategory
    {
        public int Id { get; set; }

        [StringLength(40, ErrorMessage = "Category only allows 40 characters")]
        public string Title { get; set; }

        [StringLength(40, ErrorMessage = "Description")]
        public string Description { get; set; }
    }
}
