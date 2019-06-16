using System;
using System.Collections.Generic;
using System.Text;
using Aplication.Dto.Category;
using Aplication.Interface;
namespace Aplication.Command.Add
{
    public interface IAddCategory : ICommand<AddCategoryDto>
    {
    }
}
