using System;
using System.Collections.Generic;
using System.Text;

namespace Aplication.Dto.Good
{
    public class GoodCategoryDto
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public string Description { get; set; }

        public decimal FirstPrice { get; set; }

        public int CategoryId { get; set; }

        public string CategoryTitle { get; set; }
    }
}
