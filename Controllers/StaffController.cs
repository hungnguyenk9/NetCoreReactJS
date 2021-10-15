using Microsoft.AspNetCore.Mvc;
using NetCoreReactJS.Command.StaffCmd;
using NetCoreReactJS.DTO;
using NetCoreReactJS.Models;
using System;
using AutoMapper;
using NetCoreReactJS.Query.StaffQuery;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NetCoreReactJS.Controllers.Staff
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StaffController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IStaffCmdService _staffCmdService;
        private readonly IStaffQueryService _staffQueryService;
        public StaffController(IMapper mapper, IStaffCmdService staffCmdService, IStaffQueryService staffQueryService)
        {
            _mapper = mapper;
            _staffCmdService = staffCmdService;
            _staffQueryService = staffQueryService;
        }

        //api/Staff/Add
        [HttpPost]
        public IActionResult Add(StaffAddDTO staffAddDTO)
        {
            try
            {
                int rs = _staffCmdService.Add(_mapper.Map<Models.Staff>(staffAddDTO));
                if (rs < 1)
                {
                    return Ok(new ReponseModel(0, "Add fail!", null));
                }
                else
                {
                    return Ok(new ReponseModel(1, "Add Success!", staffAddDTO));
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex);
                return StatusCode(500,"Internal server error!");
            }
        }
        //api/Staff/Update
        [HttpPut]
        public IActionResult Update(StaffUpdateDTO staffUpdateDTO)
        {
            try
            {

                int rs = _staffCmdService.Update(_mapper.Map<Models.Staff>(staffUpdateDTO));
                if (rs < 1)
                {
                    return Ok(new ReponseModel(0, "Update fail!", null));
                }
                else
                {
                    return Ok(new ReponseModel(1, "Update Success!", staffUpdateDTO));
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex);
                return StatusCode(500, "Internal server error!");
            }
        }

        //api/Staff/Delete
        [HttpDelete("{stfId}")]
        public IActionResult Delete(int stfId)
        {
            try
            {

                int rs = _staffCmdService.Delete(stfId);
                if (rs < 1)
                {
                    return Ok(new ReponseModel(0, "Delete fail!", null));
                }
                else
                {
                    return Ok(new ReponseModel(1, "Delete Success!", null));
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex);
                return StatusCode(500, "Internal server error!");
            }
        }
        // api/Staff/GetByName/Name
        [HttpGet("{Name?}")]
        public IActionResult GetByName(string Name)
        {
            try
            {

                var lst = _staffQueryService.GetList(Name);
                return Ok(new ReponseModel(1, "Get Success!", lst));
            }
            catch (Exception ex)
            {
                Console.Write(ex);
                return StatusCode(500, "Internal server error!");
            }
        }
        // api/Staff/GetListMan/id
        [HttpGet("{Id}")]
        public IActionResult GetListMan(int Id = 0)
        {
            try
            {
                var lst = _staffQueryService.GetListMan(Id);
                return Ok(new ReponseModel(1, "Get Success!", lst));
            }
            catch (Exception ex)
            {
                Console.Write(ex);
                return StatusCode(500, "Internal server error!");
            }
        }

        // api/Staff/GetById/id
        [HttpGet("{Id}")]
        public IActionResult GetById(int Id = 0)
        {
            try
            {
                var rs = _staffQueryService.GetOneById(Id);
                return Ok(new ReponseModel(1, "Get Success!", rs));
            }
            catch (Exception ex)
            {
                Console.Write(ex);
                return StatusCode(500, "Internal server error!");
            }
        }

    }
}
