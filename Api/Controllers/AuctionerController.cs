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
using Aplication.Dto.Auctioner;
using Aplication.Exceptions;
using Aplication.SearchEntity.Auctioner;
namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuctionerController : ControllerBase
    {
        private readonly IAddAuctioner _addauctioner;
        private readonly IShowAuctioners _shauctioners;
        private readonly IShowAuctioner _shacutioner;
        private readonly IEditAuctioner _editauctioner;
        private readonly IDeleteAuctioner _deleteauctioner;

        public AuctionerController(IAddAuctioner addauctioner, IShowAuctioners shauctioners, IShowAuctioner shacutioner, IEditAuctioner editauctioner, IDeleteAuctioner deleteauctioner)
        {
            _addauctioner = addauctioner;
            _shauctioners = shauctioners;
            _shacutioner = shacutioner;
            _editauctioner = editauctioner;
            _deleteauctioner = deleteauctioner;
        }





        /// <summary>
        /// Vraca Usere i filtrira po Imenu, Prezimenu i Ulozi(Admin ili User)
        /// </summary>
        // GET: api/Auctioner
        [HttpGet]
        public ActionResult <IEnumerable<AuctionerDto>> Get([FromQuery]SearchAuctioner search)
        {
            try
            {
                var auctioners = _shauctioners.Execute(search);
                return Ok(auctioners);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        // GET: api/Auctioner/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var auctioner = _shacutioner.Execute(id);

                return Ok(auctioner);
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
        /// {
        ///     "firstName": "string",
        ///     "lastName": "string",
        ///     "email": "string",
        ///     "password": "string",
        ///     "roleId": 0
        /// </summary>
        // POST: api/Auctioner
        [HttpPost]
        public IActionResult Post([FromBody] AddAuctionerDto dto)
        {
            try
            {
                _addauctioner.Execute(dto);
                return Ok();
            }
            catch (EntityAlreadyExist e)
            {
                return UnprocessableEntity(e.Message);
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
        /// Format za Edit Auctioner :
        /// {
        ///     "firstName": "string",
        ///      "lastName": "string",
        ///     "email": "string",
        ///     "password": "string",
        ///     "roleId": 0
        /// }
        /// </summary>
        // PUT: api/Auctioner/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] EditAuctioner edit)
        {
            edit.Id = id;

            try {
                _editauctioner.Execute(edit);
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
                _deleteauctioner.Execute(id);
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
