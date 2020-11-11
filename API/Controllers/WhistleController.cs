﻿using System;
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
            try
            {
                var result = await _repository.GetAllWhistles();
                return _mapper.Map<DtoWhistle[]>(result);
            }
            catch
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database failure");
            }
        }

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
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database failure");
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
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database failure");
            }
            return BadRequest();
        }

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
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database failure");
            }
            return BadRequest();
        }

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
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database failure");
            }
            return BadRequest();
        }
    }
}
