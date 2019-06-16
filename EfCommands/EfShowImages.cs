using System;
using System.Collections.Generic;
using System.Text;
using Aplication.Command;
using Aplication.Dto.Image;
using Aplication.SearchEntity;
using Aplication.Exceptions;
using Aplication.Command.Show;
using EfDataAccess;
using System.Linq;
namespace EfCommands
{
    public class EfShowImages : EfBase, IShowImages
    {
        public EfShowImages(AuctionContext context) : base(context)
        {
        }

        public IEnumerable<ImageDto> Execute(SearchImage request)
        {

            return Context.Images.Select(c => new ImageDto
            {
                Id = c.Id,
                Url = c.Url,
                GoodId = c.GoodId
            });
        }
    }
}
