using System;
using System.Collections.Generic;
using System.Text;
using Aplication.Command.Add;
using Aplication.Dto.Image;
using Aplication.Exceptions;
using EfDataAccess;
using Aplication.Helpers;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace EfCommands.EfAdd
{
    public class EfAddImage : EfBase, IAddImage
    {
        public EfAddImage(AuctionContext context) : base(context)
        {
        }

        public void Execute(AddImageDto request)
        {

            if (!Context.Goods.Any(g => g.Id == request.GoodId))
            {
                throw new EntityNotFound("Good");
            }


            Context.Images.Add(new Domen.Image
            {
                Url = request.Url,
                GoodId = request.GoodId

            });
            Context.SaveChanges();
        }
    }
}
