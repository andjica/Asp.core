using System;
using System.Collections.Generic;
using System.Text;
using Aplication.Command.Delete;
using Aplication.Exceptions;
using EfDataAccess;

namespace EfCommands.EfDelete
{
    public class EfDeleteImage : EfBase, IDelete
    {
        public EfDeleteImage(AuctionContext context) : base(context)
        {
        }

        public void Execute(int request)
        {
            var image = Context.Images.Find(request);

            if (image == null)
            {
                throw new EntityNotFound("Image");
            }

            Context.Images.Remove(image);
            Context.SaveChanges();
        }
    }
}
