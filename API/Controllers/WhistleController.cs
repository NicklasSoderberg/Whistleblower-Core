using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Data.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WhistleController : ControllerBase
    {
        private readonly IWhistleRepository _repository;
        private readonly IMapper _mapper;

        public WhistleController(IWhistleRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<DtoWhistle[]>> Get()
        {
            var result = await _repository.GetAllWhistles();
            return _mapper.Map<DtoWhistle[]>(result);
        }

        [HttpGet("{whistleID}")]
        public async Task<ActionResult<DtoWhistle>> Get(int whistleID)
        {
            var result = await _repository.GetWhistle(whistleID);
            return _mapper.Map<DtoWhistle>(result);
        }

        [HttpPost]
        public async Task<ActionResult<DtoWhistle>> Post(DtoWhistle WhistleInput)
        {

            Whistle W = _mapper.Map<Whistle>(WhistleInput);
            _repository.Add(W);
            if(await _repository.SaveChangesAsync())
            {
                return Created("", _mapper.Map<DtoWhistle>(W));
            }
            return BadRequest();
        }
    }
}
