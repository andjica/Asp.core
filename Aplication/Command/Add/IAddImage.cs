using System;
using System.Collections.Generic;
using System.Text;
using Aplication.Dto.Image;
using Aplication.Interface;
namespace Aplication.Command.Add
{
    public interface IAddImage : ICommand<AddImageDto>
    {
    }
}
