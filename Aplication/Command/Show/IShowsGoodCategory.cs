using System;
using System.Collections.Generic;
using System.Text;
using Aplication.Interface;
using Aplication.Dto.Good;
using Aplication.SearchEntity.Good;
namespace Aplication.Command.Show
{
    public interface IShowGoodsCategory : ICommand<SearchGood, IEnumerable<GoodCategoryDto>>
    {
    }
}
