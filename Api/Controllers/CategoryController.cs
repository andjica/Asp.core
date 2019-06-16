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
using Aplication.Exceptions;
using Aplication.SearchEntity.Category;
using Aplication.Dto.Category;
using EfDataAccess;
namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {

        private readonly IShowCategories _shcategories;
        private readonly IShowCategoryGood _shcategorygood;
        private readonly IShowCategory _shcategory;
        private readonly IAddCategory _addcategory;
        private readonly IEditCategory _editcatogry;
        private readonly IDelete _deletecategory;

        public CategoryController(IShowCategories shcategories, IShowCategoryGood shcategorygood, IShowCategory shcategory, IAddCategory addcategory, IEditCategory editcatogry, IDelete deletecategory)
        {
            _shcategories = shcategories;
            _shcategorygood = shcategorygood;
            _shcategory = shcategory;
            _addcategory = addcategory;
            _editcatogry = editcatogry;
            _deletecategory = deletecategory;
        }




        /// <summary>
        /// Vraca sve kategorije koje su aktivne
        /// Filtira po imenu kategorije, po id-u i po aktivnosti 
        /// </summary>
        // GET: api/Category
        [HttpGet]
        public ActionResult <IEnumerable<CategoryDto>> Get([FromQuery]SearchCategories search)
        {
            var categories = _shcategories.Execute(search);

            try
            {
                return Ok(categories);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        ///<summary>
        /// Vraca sve kategorije koje su aktivne zajedno sa kolekcijom svojih proizvoda
        /// Za proizvoed se prikazuje prva slika iz njegove kolekcije
        /// Filtira po imenu kategorije, po id-u i po aktivnosti 
        ///</summary>
        //Get: api/Category/CategoryGood
        [HttpGet("CategoryGood")]
        public ActionResult<IEnumerable<CategoryDto>> CategoryGood([FromQuery]SearchCategoryGood search)
        {
            var categories = _shcategorygood.Execute(search);

            try
            {
                return Ok(categories);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }


        // GET: api/Category/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try {
                var cat = _shcategory.Execute(id);

                return Ok(cat);
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
         ///  Ulazni parametri:
        ///   {
        ///     "title": "string",
        ///     "description": "string"
         ///    }
        /// </summary>
  
        // POST: api/Category
        [HttpPost]
        public IActionResult Post([FromBody]AddCategoryDto dto)
        {
            try
            {
                _addcategory.Execute(dto);

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

        // PUT: api/Category/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]EditCategory dto)
        {
            dto.Id = id;
            try
            {
                _editcatogry.Execute(dto);

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
                _deletecategory.Execute(id);
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
