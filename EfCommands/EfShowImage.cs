using System;
using System.Collections.Generic;
using System.Text;
using Aplication.Command.Show;
using Aplication.Dto.Image;
using Aplication.Exceptions;
using EfDataAccess;
using System.Linq;
using Microsoft.EntityFrameworkCore;
namespace EfCommands
{
    public class 
        EfShowImage : EfBase, IShowImage
    {
        public EfShowImage(AuctionContext context) : base(context)
        {
        }

        public ImageDto Execute(int request)
        {
            var image = Context.Images.AsQueryable();


            image = image.Where(g => g.Id == request).Include(g => g.Good).AsQueryable();

            if (image == null)
            {
                throw new EntityNotFound("Image");
            }

            return image.Select(i => new ImageDto
            {
                Id = i.Id,
                Url = i.Url,
                GoodId = i.GoodId,
                GoodTitle = i.Good.Title
            }).FirstOrDefault();
        }
    }
}
