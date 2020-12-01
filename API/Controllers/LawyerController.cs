using API.Data;
using API.Data.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LawyerController : ControllerBase
    {
        private readonly IWhistleRepository _repository;
        private readonly IMapper _mapper;

        public LawyerController(IWhistleRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<ActionResult<DtoLawyer[]>> Get()
        {
            try
            {
                var result = await _repository.GetAllLawyers();
                return _mapper.Map<DtoLawyer[]>(result);
            }
            catch
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "");
            }
        }
        [Authorize(Roles = "Admin")]
        [HttpDelete("{LawyerId}")]
        public async Task<IActionResult> Delete(Guid LawyerId)
        {
            try
            {
                var lawyer = _repository.GetLawyer(LawyerId).Result;
                _repository.Delete(lawyer);
                await _repository.SaveChangesAsync();
                return this.StatusCode(StatusCodes.Status200OK);
            }
            catch
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "");
            }
        }
        [Authorize(Roles = "Admin")]
        [HttpPut]
        public async Task<ActionResult<DtoLawyer>> Put(Lawyer lawyer)
        {
            try
            {
                await _repository.PutLawyer(lawyer);
                return this.StatusCode(StatusCodes.Status200OK);
            }
            catch
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "");
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<ActionResult<DtoLawyer>> Post(DtoLawyer input)
        {
            try
            {
                Lawyer lawyer = _mapper.Map<Lawyer>(input);
                _repository.Add(lawyer);
                await _repository.SaveChangesAsync();
                return this.StatusCode(StatusCodes.Status200OK);
            }
            catch
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "");
            }
        }
    }
}
