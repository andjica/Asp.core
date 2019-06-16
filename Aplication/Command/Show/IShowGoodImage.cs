using System;
using System.Collections.Generic;
using System.Text;
using Aplication.Interface;
using Aplication.SearchEntity.Good;
using Aplication.Dto.Good;
namespace Aplication.Command.Show
{
    public interface IShowGoodImage : ICommand<SearchGood, IEnumerable<GoodImageDto>>
    {
    }
}
