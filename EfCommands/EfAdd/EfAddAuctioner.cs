using System;
using System.Collections.Generic;
using System.Text;
using Aplication.Command.Add;
using Aplication.Dto.Auctioner;
using Aplication.Exceptions;
using EfDataAccess;
using System.Linq;
using Microsoft.EntityFrameworkCore;
namespace EfCommands.EfAdd
{
    public class EfAddAuctioner : EfBase, IAddAuctioner
    {
        public EfAddAuctioner(AuctionContext context) : base(context)
        {
        }

        public void Execute(AddAuctionerDto request)
        {

            if (Context.Auctioners.Any(a => a.Email == request.Email))
            {
                throw new EntityAlreadyExist("Email");
            }

            if (!Context.Roles.Any(r => r.Id == request.RoleId))
            {
                throw new EntityNotFound("Role");
            }

            Context.Auctioners.Add(new Domen.Auctioner
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                Password = request.Password,
                RoleId = request.RoleId

            });

            Context.SaveChanges();
        }
    }
}
