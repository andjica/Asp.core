using System;
using System.Collections.Generic;
using System.Text;
using Aplication.Interface;
using Aplication.Dto.Good;
namespace Aplication.Command.Add
{
    public interface IAddGood : ICommand<GoodDto>
    {
    }
}
