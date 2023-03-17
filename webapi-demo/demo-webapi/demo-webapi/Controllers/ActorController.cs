using Microsoft.AspNetCore.Mvc;
using demo_webapi.Contracts;
using demo_webapi.Models;
using System.Collections.Generic;
using System;

namespace demo_webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActorController : ControllerBase
    {
         private readonly IActorRepository _actorRepository;
         public ActorController(IActorRepository actorRepository)
         {
            _actorRepository = actorRepository;
        }

        [HttpGet]
        public ActionResult<List<Actor>> Get()
        {
            return _actorRepository.GetActors();
        }

        [HttpGet("{id}")]
        public ActionResult<Actor> Get(int id)
        {
            try
            {
                return _actorRepository.GetActorById(id);
            } catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpPost]  
        public ActionResult CreateActor(Actor actor) {
            try
            {
                _actorRepository.AddActor(actor);
                return Ok("Actor creado correctamente");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpPut]
        public ActionResult UpdateActor([FromBody] Actor actor)
        {
            try
            {
                _actorRepository.UpdateActor(actor);
                return Ok("Actor actualizado correctamente");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpDelete("{id}")]
        public ActionResult DeleteActor(int id)
        {
            try
            {
               _actorRepository.DeleteActor(id);
                return Ok("Actor eliminado correctamente");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}
