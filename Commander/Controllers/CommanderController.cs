using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Commander.Data;
using Commander.Dtos;
using Commander.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Commander.Controllers
{
    [Route("api/commander")]
    [ApiController]
    public class CommanderController : ControllerBase
    {
        private readonly ICommanderRepo _repo;
        private readonly IMapper _mapper;

        public CommanderController(ICommanderRepo repo,IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        //private readonly MockRepo _repo = new MockRepo();
        // GET: api/Commander
        [HttpGet]
        public ActionResult <List<CommandReadDto>> Get()
        {
            var commands = _repo.GetList();
            var result = _mapper.Map<List<CommandReadDto>>(commands);
            return result;
        }

        // GET: api/Commander/5
        [HttpGet("{id}",Name ="Get")]
        public ActionResult<CommandReadDto> Get(int id)
        {
            var commands = _repo.GetCommandById(id);
            var result = _mapper.Map<CommandReadDto>(commands);
            if(result != null)
            {
                return result;
            }
            return NotFound();
        }

        // POST: api/Commander
        [HttpPost]
        public ActionResult<CommandReadDto> CreateCommand(CommandCreateDto commandCreateDto)
        {
            var commandModel = _mapper.Map<Command>(commandCreateDto);
            _repo.CreateCommand(commandModel);
            _repo.SaveChange();
            var commandreaddto = _mapper.Map<CommandReadDto>(commandModel);
            return CreatedAtRoute(nameof(Get), new { Id = commandreaddto.Id }, commandreaddto);
            //return OK(CommandReadDto);
        }

        // PUT: api/Commander/5
        [HttpPut("{id}")]
        public ActionResult UpdateCommand (int id, CommandUpdateDto commandupdatedto)
        {
            var commandModelFromRepo = _repo.GetCommandById(id);
            if(commandModelFromRepo == null)
            {
                return NotFound();
            }
            _mapper.Map(commandupdatedto,commandModelFromRepo);
            _repo.UpdateCommand(commandModelFromRepo);
            _repo.SaveChange();
            return NoContent();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public ActionResult DeleteCommand(int id)
        {
            var commandModelFromRepo = _repo.GetCommandById(id);
            if (commandModelFromRepo == null)
            {
                return NotFound();
            }
            _repo.DeleteCommand(commandModelFromRepo);
            _repo.SaveChange();
            return NoContent();
        }
    }
}
