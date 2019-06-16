using System;
using System.Collections.Generic;
using System.Text;
using Aplication.Dto.Good;
using Aplication.Interface;
namespace Aplication.Command.Show
{
    public interface IShowGood : ICommand<int, GoodImageDto>
    {
    }
}
