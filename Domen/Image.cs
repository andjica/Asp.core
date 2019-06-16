using System;
using System.Collections.Generic;
using System.Text;

namespace Domen
{
    public class Image : BaseEntity
    {
   

        public string Url { get; set; }

        public int GoodId {get; set;}

        public Good Good { get; set; }
    }
}