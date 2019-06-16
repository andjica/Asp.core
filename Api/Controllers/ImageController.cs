using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Aplication.Command.Show;
using Aplication.Command.Add;
using Aplication.Command.Delete;
using Aplication.Exceptions;
using Aplication.Helpers;
using Api.ImageUpload;
using Aplication.SearchEntity;
using Aplication.Dto.Image;
using System.IO;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {

        private readonly IAddImage _addimage;
        private readonly IShowImages _shimages;
        private readonly IShowImage _shimage;
        private readonly IDelete _deleteimage;

        public ImageController(IAddImage addimage, IShowImages shimages, IShowImage shimage, IDelete deleteimage)
        {
            _addimage = addimage;
            _shimages = shimages;
            _shimage = shimage;
            _deleteimage = deleteimage;
        }




        // GET: api/Image
        [HttpGet]
        public IActionResult Get([FromQuery]SearchImage search)
        {
            try
            {
                var images = _shimages.Execute(search);
                return Ok(images);
            }
            catch(Exception) {
                return StatusCode(500);
            }
        }

        // GET: api/Image/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
               var image =  _shimage.Execute(id);

                return Ok(image);

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

        // POST: api/Image
        [HttpPost]
        public IActionResult Post([FromForm] Image img)
        {
            var ext = Path.GetExtension(img.Url.FileName);

            if (!FileUpload.AllowedExtensions.Contains(ext))
            {
                return UnprocessableEntity("Image extension is not allowed.");
            }
            try
            {
                var newFileName = Guid.NewGuid().ToString() + "_" + img.Url.FileName;

                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "img", newFileName);
                img.Url.CopyTo(new FileStream(filePath, FileMode.Create));


                var dto = new AddImageDto
                {

                    Url = newFileName,
                    GoodId = img.GoodId
                };

                _addimage.Execute(dto);
                return NoContent();
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

        // PUT: api/Image/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _deleteimage.Execute(id);
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
