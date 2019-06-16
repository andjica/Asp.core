using System;
using System.Collections.Generic;
using System.Text;
using Aplication.Interface;
using Aplication.SearchEntity.Category;
using Aplication.Dto.Category;
namespace Aplication.Command.Show
{
    public interface IShowCategories : ICommand<SearchCategories, IEnumerable<CategoryDto>>
    {
    }
}
