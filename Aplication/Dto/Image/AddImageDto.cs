using Microsoft.AspNetCore.Http.Internal;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aplication.Dto.Image
{
    public class AddImageDto
    {
        public string Url { get; set; }

        public int GoodId { get; set; }
    }
}
