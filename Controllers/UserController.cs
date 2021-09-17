using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NetCoreReactJS.Command.ClientUserCmd;
using NetCoreReactJS.Common;
using NetCoreReactJS.DTO;
using NetCoreReactJS.Models;
using NetCoreReactJS.Query.ClientUserQuery;
using System;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NetCoreReactJS.Controllers.User
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
                int userAdd = _clientUserCmdService.Add(userDTO.Email, userDTO.Password);
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
    }
}
