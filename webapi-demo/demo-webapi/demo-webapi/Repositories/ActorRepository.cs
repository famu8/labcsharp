using demo_webapi.Contracts;
using demo_webapi.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace demo_webapi.Repositories
{
    public class ActorRepository : IActorRepository
    {
        const string JSON_PATH = @"C:\Users\Usuario\OneDrive - UNIVERSIDAD ALICANTE\Escritorio\BIMAXPRO\PUNTO DE ENTRADA - BIMAXPRO\csharp\labc#\webapi-demo\demo-webapi\demo-webapi\Resources\Actores.json";
        public void AddActor(Actor actor)
        {
            var actores = GetActors();
            var actorExistente = actores.Exists(a => a.Id == actor.Id);
            if (actorExistente)
            {
                throw new Exception("Ya existe un autor con ese id");
            }
            actores.Add(actor);
            UpdateActores(actores);
        }

        public void DeleteActor(int id)
        {
            var actores = GetActors();
            var actor = actores.FirstOrDefault(a => a.Id == id);
            if (actor == null)
            {
                throw new Exception("El actor no existe");
            }
            actores.Remove(actor);
            UpdateActores(actores);
        }

        public Actor GetActorById(int id)
        {
            var actores = GetActors();
            var actor = actores.FirstOrDefault(a => a.Id == id);
            if(actor == null)
            {
                throw new Exception("El actor no existe");
            }
            return actor;
        }

        public List<Actor> GetActors()
        {
            try
            {
                var actoresFromFile = GetActorsFromFile();
                List < Actor > actores = JsonConvert.DeserializeObject<List<Actor>>(actoresFromFile);
                return actores;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void UpdateActor(Actor actor)
        {
            var actores = GetActors();
            var actorParaActualizar =  actores.FirstOrDefault(a => a.Id == actor.Id);
            if( actorParaActualizar == null)
            {
                throw new Exception($"El actor con Id: {actor.Id} no existe");
            }
            actorParaActualizar.Nombre = actor.Nombre;
            actorParaActualizar.Apellido = actor.Apellido;
            actorParaActualizar.Peliculas = actor.Peliculas;
            UpdateActores(actores);
        }

        private string GetActorsFromFile()
        {
            var json = File.ReadAllText(JSON_PATH);
            return json;
        }
        private void UpdateActores(List<Actor> actores)
        {
            var actoresJson = JsonConvert.SerializeObject(actores, Formatting.Indented);
            File.WriteAllText(JSON_PATH, actoresJson);
        }

}
}
