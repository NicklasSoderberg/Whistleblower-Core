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
    public class FileController : ControllerBase
    {
        private readonly IWhistleRepository _repository;
        private readonly IMapper _mapper;

        public FileController(IWhistleRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("{whistleID}")]
        public async Task<ActionResult<DtoFile[]>> Get(int whistleID)
        {
            try
            {
                var result = await _repository.GetFiles(whistleID);
                return _mapper.Map<DtoFile[]>(result);
            }
            catch
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "");
            }
        }

        [HttpPost]
        public async Task<ActionResult<DtoFile>> Post(DtoFile FileInput)
        {
            try
            {
                File F = _mapper.Map<File>(FileInput);
                _repository.Add(F);
                if (await _repository.SaveChangesAsync())
                {
                    return Created($"/api/file/", _mapper.Map<DtoFile>(F));
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
