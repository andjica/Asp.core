using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Aplication.Command.Show;
using Aplication.Command.Add;
using Aplication.Command.Edit;
using Aplication.Command.Delete;
using Aplication.SearchEntity.Good;
using Aplication.Dto.Good;
using Aplication.Exceptions;
using EfDataAccess;
namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GoodController : ControllerBase
    {

    
        private readonly IShowGoodsCategory _shgoodscategory;
        private readonly IShowGood _shgood;
        private readonly IAddGood _addgood;
        private readonly IEditGood _editgood;
        private readonly IDelete _deletegood;

        public GoodController(IShowGoodsCategory shgoodscategory, IShowGood shgood, IAddGood addgood, IEditGood editgood, IDelete deletegood)
        {

            _shgoodscategory = shgoodscategory;
            _shgood = shgood;
            _addgood = addgood;
            _editgood = editgood;
            _deletegood = deletegood;
        }


        //Vraca sve proizvode za licitaciju sa kategorijama kojim pripadaju
        // GET: api/Good
        [HttpGet]
        public IActionResult Get([FromQuery]SearchGood search)
        {
            try
            {
                var goods = _shgoodscategory.Execute(search);
                return Ok(goods);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        // GET: api/Good/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
           
            try
            {
               var good = _shgood.Execute(id);

                return Ok(good);
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

        // POST: api/Good
        [HttpPost]
        public IActionResult Post([FromBody]GoodDto dto)
        {
            try
            {
                _addgood.Execute(dto);

                return Ok();
            }
            catch (EntityAlreadyExist e)
            {
                return UnprocessableEntity(e.Message);
            }
        }

        // PUT: api/Good/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]GoodDto dto)
        {
            dto.Id = id;

            try
            {
                _editgood.Execute(dto);

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

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _deletegood.Execute(id);
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
