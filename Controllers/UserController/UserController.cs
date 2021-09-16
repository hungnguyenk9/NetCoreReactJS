using Microsoft.AspNetCore.Mvc;
using NetCoreReactJS.Command.ClientUserCmd;
using NetCoreReactJS.Common;
using NetCoreReactJS.Models.AuthResponse;
using NetCoreReactJS.Models.Response;
using NetCoreReactJS.Query.ClientUserQuery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NetCoreReactJS.Controllers.UserController
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IClientUserCmdService _clientUserCmdService;
        private readonly IClientUserQueryService _clientUserQueryService;
        public UserController(IClientUserCmdService clientUserCmdService, IClientUserQueryService clientUserQueryService)
        {
            _clientUserCmdService = clientUserCmdService;
            _clientUserQueryService = clientUserQueryService;
        }

        // POST api/User/Register
        [HttpPost]
        public IActionResult Register(UserDTO userDTO)
        {
            try
            {

                userDTO.Password = HashMD5.GetMd5Hash(userDTO.Password);
                int userAdd = _clientUserCmdService.AddUser(userDTO.Email, userDTO.Password);
                if (userAdd < 1)
                {
                    return Ok(new ReponseModel(0, "Register Fail!", null));
                }
                else
                {
                    AuthRes res = _clientUserQueryService.GetToken(userDTO.Email, userDTO.Password);
                    return Ok(new ReponseModel(1, "Login Success!", res));
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500,"Internal server error!");
            }
        }

        // POST api/User/SignIn
        [HttpPost]
        public IActionResult SignIn(UserDTO userDTO)
        {
            try
            {

                int kq = _clientUserQueryService.Authenticate(userDTO.Email, userDTO.Password);
                if (kq < 1)
                {
                    return Ok(new ReponseModel(0,"Login Fail!", null));
                }
                else
                {
                    AuthRes res = _clientUserQueryService.GetToken(userDTO.Email, userDTO.Password);
                    return Ok(new ReponseModel(1, "Login Success!", res));
                }    
                
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error!");
            }
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
