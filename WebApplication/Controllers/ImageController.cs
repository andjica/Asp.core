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
using Aplication.Dto.Image;
using Aplication.SearchEntity;

namespace WebApplication.Controllers
{
    public class 
        ImageController : Controller
    {
        private readonly IAddImage _addimage;
        private readonly IShowImages _shimages;
        private readonly IShowImage _shimage;
        private readonly IDeleteImage deleteimage;

        public ImageController(IAddImage addimage, IShowImages shimages, IShowImage shimage, IDeleteImage deleteimage)
        {
            _addimage = addimage;
            _shimages = shimages;
            _shimage = shimage;
            this.deleteimage = deleteimage;
        }


        // GET: Image
        public ActionResult Index([FromQuery]SearchImage search)
        {
            try
            {
                var images = _shimages.Execute(search);
                return View(images);
            }
            catch (Exception)
            {
                TempData["error"] = "Greska";
                return View();
            }
            

        }
            // GET: Image/Details/5
        public ActionResult Details(int id)
        {
            try {
                var image = _shimage.Execute(id);
                return View(image);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        // GET: Image/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Image/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Image/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Image/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Image/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Image/Delete/5
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