using System;
using System.Collections.Generic;
using System.Text;
using Aplication.Command.Show;
using Aplication.Dto.Auctioner;
using Aplication.Interface;
using Aplication.SearchEntity.Auctioner;
using EfDataAccess;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace EfCommands
{
    public class EfShowAuctioners : EfBase, IShowAuctioners
    {
        public EfShowAuctioners(AuctionContext context) : base(context)
        {
        }

        public IEnumerable<AuctionerDto> Execute(SearchAuctioner request)
        {
            var auctioners = Context.Auctioners.AsQueryable();

            //filtriramo po imenu
            if (request.Ime != null)
            {
                var name = request.Ime.ToLower();
                auctioners = auctioners.Where(a => a.FirstName.ToLower().Contains(name));
            }

            //filtriramo po prezimenu
            if (request.Prezime != null)
            {
                var lastname = request.Prezime.ToLower();
                auctioners = auctioners.Where(a => a.LastName.ToLower().Contains(lastname));
            }

            //filtriramo po roleid
            if (request.RoleId != 0)
            {
                auctioners = auctioners.Where(a => a.Role.Id == request.RoleId);
            }


            //filtriramo po imenu same uloge
            if (request.RoleName != null)
            {
                var imeUloge = request.RoleName.ToLower();
                auctioners = auctioners.Where(a => a.Role.Name.ToLower().Contains(imeUloge));
            }



            return auctioners.Select(a => new AuctionerDto
            {
                Id = a.Id,
                FirstName = a.FirstName,
                LastName = a.LastName,
                Email = a.Email,
                CreatedAt = a.CreatedAt,
                Role = a.Role.Name
            });

        }
    }
}
