using Microsoft.AspNetCore.Mvc;
using almacen.Contracts;
using almacen.Models;
using System.Collections.Generic;
using System;
using System.Numerics;

namespace almacen.Controllers
{
    [ApiController]
    [Route("/almacen")]
    public class AlmacenController : ControllerBase
    {
        private readonly IAlmacenRepository _almacenRepository;
        public AlmacenController(IAlmacenRepository almacenRepository)
        {
            _almacenRepository = almacenRepository;     
        }


        [HttpGet]
        public ActionResult<List<Articulo>> Get()
        {
            return _almacenRepository.GetArticulos();
        }

        [HttpPost("crearArticulo")]
        public ActionResult CrearArticulo(Articulo articulo)
        {
            try
            {
                _almacenRepository.AddArticulo(articulo);
                return Ok("Articulo creado correctamente");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("incrementar")]
        public ActionResult SumarCantidadArticulo(int cantidad, int id)
        {
            try
            {
                _almacenRepository.IncrementarArticulo(cantidad, id);
                return Ok($"Se ha sumado la cantidad de {cantidad} al articulo con id: {id} ");
            }
            catch (Exception e) 
            {
                return NotFound("Error actualizando la cantidad del articulo");
            }
        }

        [HttpPut("decrementar")]
        public ActionResult RestarCantidadArticulo(int cantidad, int id)
        {
            try
            {
                if (cantidad <= 0 )
                {
                    return BadRequest("No es posible introducir una cantidad negativa");
                }
                _almacenRepository.DecrementarArticulo(cantidad, id);
                return Ok($"Se ha restado la cantidad de {cantidad} al articulo con id: {id} ");
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }
    }
}
