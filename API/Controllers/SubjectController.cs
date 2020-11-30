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
    public class SubjectController : ControllerBase
    {
        private readonly IWhistleRepository _repository;
        private readonly IMapper _mapper;

        public SubjectController(IWhistleRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<DtoSubject[]>> Get()
        {
            try
            {
                var result = await _repository.GetAllSubjects();
                return _mapper.Map<DtoSubject[]>(result);
            }
            catch
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "");
            }
        }

        [Authorize(Roles = "Admin,Lawyer")]
        [HttpGet("{subjectID}")]
        public async Task<ActionResult<DtoSubject>> Get(int subjectID)
        {
            try
            {
                var result = await _repository.GetSubject(subjectID);
                return _mapper.Map<DtoSubject>(result);
            }
            catch
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "");
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<ActionResult<DtoSubject>> Post(DtoSubject subjectInput)
        {
            try
            {
                Subject s = _mapper.Map<Subject>(subjectInput);
                _repository.Add(s);
                if (await _repository.SaveChangesAsync())
                {
                    return Created($"/api/subject/", _mapper.Map<DtoSubject>(s));
                }
            }
            catch
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "");
            }
            return BadRequest();
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("{subjectID}")]
        public async Task<ActionResult<DtoSubject>> Put(int subjectID, DtoSubject subjectInput)
        {
            try
            {
                var oldSubject = await _repository.GetSubject(subjectID);
                if (oldSubject == null)
                    return NotFound("");
                _mapper.Map(subjectInput, oldSubject);
                if (await _repository.SaveChangesAsync())
                {
                    return _mapper.Map<DtoSubject>(oldSubject);
                }
            }
            catch
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "");
            }
            return BadRequest();
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{subjectID}")]
        public async Task<IActionResult> Delete(int subjectID)
        {
            try
            {
                var oldSubject = await _repository.GetSubject(subjectID);
                if (oldSubject == null)
                    return NotFound("");
                _repository.Delete(oldSubject);
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
    }
}
