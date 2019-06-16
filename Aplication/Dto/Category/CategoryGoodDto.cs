using System;
using System.Collections.Generic;
using System.Text;
using Aplication.Dto.Good;
namespace Aplication.Dto.Category
{
    public class CategoryGoodDto
    {
        public int? Id { get; set; }
        public string Title { get; set; }

        public string Description { get; set; }
        public IList<GoodImageDto> GoodImageDtos { get; set; }
      

        
    }
}
