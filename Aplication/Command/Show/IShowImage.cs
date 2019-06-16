using System;
using System.Collections.Generic;
using System.Text;
using Aplication.Interface;
using Aplication.Dto.Image;

namespace Aplication.Command.Show
{
    public interface IShowImage : ICommand<int, ImageDto>
    {
    }
}
