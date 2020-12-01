using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Data.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
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

        [Authorize(Roles = "Admin,Lawyer")]
        [HttpGet]
        public async Task<ActionResult<DtoWhistle[]>> Get()
        {
            try
            {
                var result = await _repository.GetAllWhistles();
                return _mapper.Map<DtoWhistle[]>(result);
            }
            catch
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "");
            }
        }

        [Authorize(Roles = "Admin,Lawyer")]
        [HttpGet("{whistleID}")]
        public async Task<ActionResult<DtoWhistle>> Get(int whistleID)
        {
            try
            {
                var result = await _repository.GetWhistle(whistleID);
                return _mapper.Map<DtoWhistle>(result);
            }
            catch
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "");
            }
        }

        [HttpPost]
        public async Task<ActionResult<DtoWhistle>> Post(DtoWhistle WhistleInput)
        {
            try
            {
                Whistle W = _mapper.Map<Whistle>(WhistleInput);
                _repository.Add(W);
                if (await _repository.SaveChangesAsync())
                {
                    return Created($"/api/whistle/", _mapper.Map<DtoWhistle>(W));
                }
            }
            catch
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "");
            }
            return BadRequest();
        }

        [Authorize(Roles = "Admin,Lawyer")]
        [HttpPut("{whistleID}")]
        public async Task<ActionResult<DtoWhistle>> Put(int whistleID, DtoWhistle WhistleInput)
        {
            try
            {
                var oldWhistle = await _repository.GetWhistle(whistleID);
                if (oldWhistle == null)
                    return NotFound("");
                _mapper.Map(WhistleInput, oldWhistle);
                if (await _repository.SaveChangesAsync())
                {
                    return _mapper.Map<DtoWhistle>(oldWhistle);
                }
            }
            catch
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "");
            }
            return BadRequest();
        }

        [Authorize(Roles = "Admin,Lawyer")]
        [HttpDelete("{whistleID}")]
        public async Task<IActionResult> Delete(int whistleID)
        {
            try
            {
                var oldWhistle = await _repository.GetWhistle(whistleID);
                if (oldWhistle == null)
                    return NotFound("");
                _repository.Delete(oldWhistle);
                if (await _repository.SaveChangesAsync())
                {
                    return Ok();
                }
            }
            catch
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "");
            }
            return BadRequest();
        }

        
        [HttpGet()]
        [Route("userId/{userId}")]
        public async Task<ActionResult<DtoWhistle>> GetUser([FromRoute] Guid userId)
        {
            try
            {
                var userWhistle = await _repository.GetUserWhistle(userId);
                return _mapper.Map<DtoWhistle>(userWhistle);
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, e);
            }
        }
    }
}
