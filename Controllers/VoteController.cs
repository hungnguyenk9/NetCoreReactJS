using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NetCoreReactJS.Command.VoteCmd;
using NetCoreReactJS.DTO;
using NetCoreReactJS.Models;
using NetCoreReactJS.Query.VoteQuery;
using System;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NetCoreReactJS.Controllers.Vote
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class VoteController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IVoteCmdService _voteCmdService;
        private readonly IVoteQueryService _voteQueryService;
        public VoteController(IMapper mapper, IVoteCmdService voteCmdService, IVoteQueryService voteQueryService)
        {
            _mapper = mapper;
            _voteCmdService = voteCmdService;
            _voteQueryService = voteQueryService;

        }
        // GET: api/Vote/GetByDate/date=00001-01-01&pageNum=1&pageSize=2
        [HttpGet("{date}/{pageNum}/{pageSize}")]
        public IActionResult GetByDate(DateTime date, int pageNum = 1, int pageSize = 2)
        {
            try
            {

                List<VoteItem> lst = _voteQueryService.GetListByDate(date, pageNum, pageSize);
                return Ok(new ReponseModel(1, "Get Success!", lst));
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error!");
            }
        }

        // POST api/Vote/Submmit
        [HttpPost]
        public IActionResult Submmit(VoteDTO voteDTO)
        {
            try
            {

                int count = _voteQueryService.CountVoteItem(voteDTO.ClientId, voteDTO.Email);
                if (count < 3)
                {
                    int kq = _voteCmdService.SubmitVote(voteDTO.ClientId, voteDTO.Email);
                    if (kq < 1)
                    {
                        return Ok(new ReponseModel(0, "Submmit Fail!", null));
                    }
                    else
                    {
                        return Ok(new ReponseModel(1, "Submmit Success!", count + 1));
                    }
                }
                else
                {
                    return Ok(new ReponseModel(0, "You vote over 3 times!", null));
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error!");
            }
        }

        // POST api/vote/adđ
        [Authorize]
        [HttpPost]
        public IActionResult Add(VoteItemDTO voteItem)
        {
            try
            {
                int kq = _voteCmdService.Add(_mapper.Map<VoteItem>(voteItem));
                if (kq < 1)
                {
                    return Ok(new ReponseModel(0, "Insert Fail!", null));
                }
                else
                {
                    return Ok(new ReponseModel(1, "Insert Success!", voteItem));
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error!");
            }
        }
    }
}
