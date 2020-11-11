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
    public class ConversationController : ControllerBase
    {
        private readonly IWhistleRepository _repository;
        private readonly IMapper _mapper;

        public ConversationController(IWhistleRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("{whistleID}")]
        public async Task<ActionResult<DtoConversation[]>> Get(int whistleID)
        {
            try
            {
                var result = await _repository.GetConversation(whistleID);
                return _mapper.Map<DtoConversation[]>(result);
            }
            catch
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database failure");
            }
        }

        [HttpPost]
        public async Task<ActionResult<DtoConversation>> Post(DtoConversation ConversationInput)
        {
            try
            {
                Conversation C = _mapper.Map<Conversation>(ConversationInput);
                _repository.Add(C);
                if (await _repository.SaveChangesAsync())
                {
                    return Created($"/api/conversation/", _mapper.Map<DtoConversation>(C));
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
