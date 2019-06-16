using System;
using System.Collections.Generic;
using System.Text;
using Aplication.Command.Show;
using Aplication.Dto.Image;
using Aplication.Exceptions;
using EfDataAccess;

namespace EfCommands
{
    public class EfShowImage : EfBase, IShowImage
    {
        public EfShowImage(AuctionContext context) : base(context)
        {
        }

        public ImageDto Execute(int request)
        {
            var image = Context.Images.Find(request);

            if (image == null)
            {
                throw new EntityNotFound("Image");

            }

            return new ImageDto
            {
                Id = image.Id,
                Url = image.Url,
                GoodId = image.GoodId,
                GoodTitle = image.Good.Title
            };
        }
    }
}
