using System;
using System.Collections.Generic;
using System.Text;
using Aplication.Dto.Image;
namespace Aplication.Dto.Good
{
    public class GoodImageDto
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public string Description { get; set; }

        public decimal FirstPrice { get; set; }

        public DateTime CreatedAt { get; set; }

        public string Url { get; set; }

        public string CategoryName {get; set;}

       

    }
}
