using System;
using System.Collections.Generic;
using System.Text;
using Aplication.Dto.Image;
using Aplication.Interface;
using Aplication.SearchEntity;
namespace Aplication.Command.Show
{
    public interface IShowImages : ICommand<SearchImage, IEnumerable<ImageDto>>
    {
    }

}