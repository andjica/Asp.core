using System;
using System.Collections.Generic;
using System.Text;
using Aplication.Interface;
using Aplication.Dto.Category;
using Aplication.SearchEntity.Category;

namespace Aplication.Command.Show
{
    public interface IShowCategoryGood : ICommand<SearchCategoryGood, IEnumerable<CategoryGoodDto>>
    {
    }
}
