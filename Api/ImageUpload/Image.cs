
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Api.ImageUpload
{
    public class Image
    {

        public IFormFile Url { get; set; }
        public int GoodId { get; set; }
    }
}
