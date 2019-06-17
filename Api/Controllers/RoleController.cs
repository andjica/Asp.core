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
using Aplication.Dto.Role;
using Aplication.SearchEntity.Role;
using Aplication.Exceptions;
namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {

        private readonly IShowRoles _shroles;
        private readonly IShowRole _shrole;
        private readonly IAddRole _addrole;
        private readonly IEditRole _editrole;
        private readonly IDeleteRole _deleterole;

        public RoleController(IShowRoles shroles, IShowRole shrole, IAddRole addrole, IEditRole editrole, IDeleteRole deleterole)
        {
            _shroles = shroles;
            _shrole = shrole;
            _addrole = addrole;
            _editrole = editrole;
            _deleterole = deleterole;
        }







        // GET: api/Role
        [HttpGet]
        public IActionResult Get([FromQuery]SearchRole search)
        {
            try
            {
                var roles = _shroles.Execute(search);

                return Ok(roles);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        // GET: api/Role/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var role = _shrole.Execute(id);
                return Ok(role);
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

        // POST: api/Role
        [HttpPost]
        public IActionResult Post([FromBody] RoleDto dto)
        {
            try
            {
                _addrole.Execute(dto);
                return Ok();
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

        // PUT: api/Role/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] RoleDto dto)
        {
            dto.Id = id;
            try
            {
                _editrole.Execute(dto);

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
                _deleterole.Execute(id);
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
