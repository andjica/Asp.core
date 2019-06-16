
using System;
using System.Collections.Generic;
using System.Text;
using Aplication.Interface;
using Aplication.Dto.Category;
namespace Aplication.Command.Show
{
    public interface IShowCategory : ICommand<int, CategoryDto>
    {
    }
}
