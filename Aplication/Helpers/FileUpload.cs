using System;
using System.Collections.Generic;
using System.Text;

namespace Aplication.Helpers
{
    public class FileUpload
    {
        public static IEnumerable<string> AllowedExtensions => new List<string> { ".jpg", ".jpeg", ".png" };
    }
}
