using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NetCoreReactJS.Command.DeptCmd;
using NetCoreReactJS.Common;
using NetCoreReactJS.DTO;
using NetCoreReactJS.Models;
using System;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NetCoreReactJS.Controllers.Dept
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DeptController : ControllerBase
    {
        private readonly IDeptCmdService _deptCmdService;
        public DeptController(IDeptCmdService deptCmdService)
        {
            _deptCmdService = deptCmdService;
        }

        // POST api/Dept/Add
        [HttpPost]
        public IActionResult Add(DeptDTO deptDTO)
        {
            try
            {
                
                int rs = _deptCmdService.Add(deptDTO.DeptName, deptDTO.ManId, deptDTO.DeptId);
                if (rs < 1)
                {
                    return Ok(new ReponseModel(0, "Add fail!", null));
                }
                else
                {
                    return Ok(new ReponseModel(1, "Add Success!", deptDTO));
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500,"Internal server error!");
            }
        }
        // POST api/Dept/Update
        [HttpPut]
        public IActionResult Update(DeptUpdateDTO deptDTO)
        {
            try
            {

                int rs = _deptCmdService.Update(deptDTO.Id, deptDTO.DeptName, deptDTO.ManId, deptDTO.DeptId);
                if (rs < 1)
                {
                    return Ok(new ReponseModel(0, "Update fail!", null));
                }
                else
                {
                    return Ok(new ReponseModel(1, "Update Success!", deptDTO));
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error!");
            }
        }

    }
}
