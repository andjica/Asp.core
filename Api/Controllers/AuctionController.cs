using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Aplication.Command.Add;
using Aplication.Command.Show;
using Aplication.Command.Edit;
using Aplication.Command.Delete;
using Aplication.Exceptions;
using Aplication.Dto.Auction;
using Aplication.SearchEntity.Auction;

using Aplication.Interface;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuctionController : ControllerBase
    {

        private readonly IAddAuction _addauction;
        private readonly IShowAuctionGoodAuctioner _shall;
        private readonly IShowAuction _shacution;
        private readonly IEditAuction _editauction;
        private readonly IPaginateAuctions _paginate;
        private readonly IDeleteAuction _deleteauction;
        private IEmailSender sender;

        public AuctionController(IAddAuction addauction, IShowAuctionGoodAuctioner shall, IShowAuction shacution, IEditAuction editauction, IPaginateAuctions paginate, IDeleteAuction deleteauction,IEmailSender sender)
        {
            _addauction = addauction;
            _shall = shall;
            _shacution = shacution;
            _editauction = editauction;
            _paginate = paginate;
            _deleteauction = deleteauction;
            this.sender = sender;
        }







        /// <summary>
        /// Vraca aukciju ali i njen prozivod(kuca, auto..) kao i Korisnike(Auctioners)
        /// Filtriranje moze biti od vece cene, od manje cene 
        /// od nazima proizvoda
        /// od naziva Usera koji je postavio Aukciju
        /// </summary>
        // GET: api/Auction

        [HttpGet]
        public ActionResult <IEnumerable<AuctionGoodAuctioner>> Get([FromQuery]SearchAuction search)
        {
            try
            {
                var auctions = _shall.Execute(search);

                return Ok(auctions);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }



        //Pagination
        /// <summary>
        /// Vraca aukcije putem paginacije, takodje vraca korisnika koji je napravio Aukciju i naziv proizvoda
        /// za kog je napravljena aukcija
        /// Filtriranje moze biti od vece cene, od manje cene 
        /// od nazima proizvoda
        /// od naziva Usera koji je postavio Aukciju
        /// </summary>
        [HttpGet("Paginate")]
        // GET: api/Auction/Paginate
        public ActionResult <IEnumerable<AuctionGoodAuctioner>> Paginate([FromQuery]SearchAuctionP search)
        {
            try
            {
                var paginate = _paginate.Execute(search);

                return Ok(paginate);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }

        }

        // GET: api/Auction/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var auction = _shacution.Execute(id);

                return Ok(auction);
            }
            catch (EntityNotFound e)
            {
                return UnprocessableEntity(e.Message);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }


        /// <summary>
        /// za ValidUntil nije potrebno unositi vreme
        /// ValidUntil ce se kreirati kao petnest dana od dana kada je kreirana Aukcija
        /// Uneti u formatu:
        /// {
        ///   "auctionerId": 0,
        ///   "goodId": 0,
        ///   "maxPrice": 0
        ///  }
        /// </summary>
        // POST: api/Auction
        [HttpPost]
        public IActionResult Post([FromQuery]AddAuctionDto dto,string email)
        {
            try
            {
                _addauction.Execute(dto);
                sender.Subject = "Kreiranje  aukcije";
                sender.ToEmail = email;
                sender.Body = "Uspesno ste kreirali aukciju :)";
                sender.Send();
                return Ok();
            }
            catch (EntityNotFound e)
            {
                return UnprocessableEntity(e.Message);
            }
            catch (EntityAlreadyExist e)
            {
                return UnprocessableEntity(e.Message);
            }
            catch (EntityAuctionAlreadyExist e)
            {
                return UnprocessableEntity(e.Message);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }


        /// <summary>
        /// Edit aukcije
        /// Uneti u formatu
        /// {
        ///    "auctionerId": 2,
        ///    "goodId": 2,
        ///    "maxPrice": 4644545
        /// }
        /// </summary>

        // PUT: api/Auction/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] EditAuction dto)
        {
            dto.Id = id;

            try
            {

                _editauction.Execute(dto);

                return Ok();
            }
            catch (EntityNotFound e)
            {
                return UnprocessableEntity(e.Message);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _deleteauction.Execute(id);
                return Ok();
            }
            catch (EntityNotFound e)
            {
                return UnprocessableEntity(e.Message);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

       
    }
}
