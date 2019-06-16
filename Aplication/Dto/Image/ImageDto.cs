using Microsoft.AspNetCore.Http.Internal;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aplication.Dto.Image
{
    public class ImageDto
    {

        public int Id { get; set; }
        public string  Url { get; set; }

        public int GoodId { get; set; }
    }
}
