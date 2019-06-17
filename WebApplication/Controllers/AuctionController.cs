using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Aplication.Command.Show;
using Aplication.Command.Edit;
using Aplication.Command.Add;
using Aplication.Command.Delete;
using Aplication.Dto.Auctioner;
using Aplication.Dto.Good;
using Aplication.Dto.Auction;
using Aplication.SearchEntity.Auction;
using Aplication.SearchEntity.Auctioner;
using Aplication.SearchEntity.Good;
using EfDataAccess;

namespace WebApplication.Controllers
{
    public class AuctionController : Controller
    {
        private readonly IShowAuctionGoodAuctioner _shall;
        private readonly IShWebAuction _shone;
        private readonly IAddWebAuction _addauction;
        private readonly AuctionContext Context;
        private readonly IShowAuctioners _shauctionres;
        private readonly IShowGoodsCategory _shgoods;
        private readonly IEditAuction _editacu;
        private readonly IDeleteAuction _delete;

        public AuctionController(IShowAuctionGoodAuctioner shall, IShWebAuction shone, IAddWebAuction addauction, AuctionContext context, IShowAuctioners shauctionres, IShowGoodsCategory shgoods, IEditAuction editacu, IDeleteAuction delete)
        {
            _shall = shall;
            _shone = shone;
            _addauction = addauction;
            Context = context;
            _shauctionres = shauctionres;
            _shgoods = shgoods;
            _editacu = editacu;
            _delete = delete;
        }












        // GET: Auction
        public ActionResult Index(SearchAuction search)
        {

            try
            {
                var all = _shall.Execute(search);
                return View(all);
            }
            catch (Exception)
            {
                return View();

            }

        }

        // GET: Auction/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                var auction = _shone.Execute(id);
                return View(auction);
            }
            catch (Exception)
            {
                return View();
            }
        }

        // GET: Auction/Create
        public ActionResult Create([FromQuery]SearchAuctioner searchau,SearchGood searchg)
        {
           
            try
            {
                ViewBag.Auctioners = _shauctionres.Execute(searchau);

                ViewBag.Goods = _shgoods.Execute(searchg);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
            

            
            return View();
        }
       
       
        // POST: Auction/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([FromForm] AddWAuction dto)
        {
            try
            {
                _addauction.Execute(dto);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                TempData["error"] = "Greska";
            }
            return View();
        }

        // GET: Auction/Edit/5
        public ActionResult Edit(int id)
        {
            var auction =_shone.Execute(id);
            
            return View(auction);
        }

        // POST: Auction/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, EditAuction dto)
        {
            if (!ModelState.IsValid)
            {
                return View(dto);
            }
            try
            {
                _editacu.Execute(dto);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Auction/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Auction/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}