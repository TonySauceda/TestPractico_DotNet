using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test02.Core.Requests;
using Test02.Core.Responses;
using Test02.DataAccess.DbModels;
using Test02.DataAccess.Interfaces;
using Test02.Logic;

namespace Test02.WebApi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IWorkshiftService _workshiftService;
        private readonly IGenderService _genderService;
        private readonly IPhoneTypeService _phoneTypeService;

        private readonly UserLogic _userLogic;

        public UsersController(IUserService userService, IWorkshiftService workshiftService, IGenderService genderService, IPhoneTypeService phoneTypeService)
        {
            _userService = userService;
            _workshiftService = workshiftService;
            _genderService = genderService;
            _phoneTypeService = phoneTypeService;

            _userLogic = new UserLogic(_userService, _workshiftService, _genderService, _phoneTypeService);
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] string searchBy = "")
        {
            var usuarios = await _userService.ObtenerListaAsync(searchBy);
            var response = JsonConvert.SerializeObject(new ListResponse<Users> { Items = usuarios }, Formatting.Indented, new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateUserRequest request)
        {
            var usuario = await _userLogic.GuardarUsuarioAsync(request);

            if (usuario == null)
                return BadRequest(UserLogic._badRequestResponse);

            string usuarioUri = $"{Request.Scheme}://{Request.Host.Value}{Request.Path}/{usuario.KeyUser}";
            var response = JsonConvert.SerializeObject(new CreateUserResponse { Id = usuario.KeyUser }, Formatting.Indented, new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });
            return Created(usuarioUri, response);
        }

        [HttpPut]
        public async Task<IActionResult> Put(UpdateUserRequest request)
        {

            var result = await _userLogic.ModificarUsuarioAsync(request);

            if (!result)
                return BadRequest(UserLogic._badRequestResponse);

            return NoContent();
        }
    }
}
