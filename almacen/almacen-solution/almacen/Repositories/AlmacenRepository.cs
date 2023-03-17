using almacen.Contracts;
using almacen.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;


namespace almacen.Repositories
{
    public class AlmacenRepository : IAlmacenRepository
    {
        const string JSON_PATH = @"C:\Users\Usuario\OneDrive - UNIVERSIDAD ALICANTE\Escritorio\BIMAXPRO\PUNTO DE ENTRADA - BIMAXPRO\csharp\labc#\almacen\almacen-solution\almacen\Resources\Articulos.json";
        public List<Articulo> GetArticulos()
        {
            try
            {
                var articulosFromFile = GetArticulosFromFile();
                List<Articulo> actores = JsonConvert.DeserializeObject<List<Articulo>>(articulosFromFile);
                return actores;
            }
            catch (Exception)
            {
                throw;
            }
        }
        private string GetArticulosFromFile()
        {
            var json = File.ReadAllText(JSON_PATH);
            return json;
        }
        public int ObtenerSiguienteId()
        {
            int maxId = 0;
            if (File.Exists(JSON_PATH))
            {
                string contenidoArchivo = File.ReadAllText(JSON_PATH);
                List<Articulo> listaArticulos = JsonConvert.DeserializeObject<List<Articulo>>(contenidoArchivo);
                if (listaArticulos.Count > 0)
                {
                    maxId = listaArticulos.Max(obj => obj.Id);
                }
            }
            return maxId + 1;
        }
        private void UpdateArticulos(List<Articulo> articulos)
        {
            var articulosJson = JsonConvert.SerializeObject(articulos, Formatting.Indented);
            File.WriteAllText(JSON_PATH, articulosJson);
        }


        public void AddArticulo(Articulo articulo)
        {
            var articulos = GetArticulos();
            var articuloExistente = articulos.Exists(a => a.Id == articulo.Id);
            if (articuloExistente)
            {
                throw new Exception("Ya existe un autor con ese id");
            }
            //da igual el id que me pasen por la peticion HTTP porque despues de comprobar si existe o no 
            //le añadire el id siguiente al correspondiente en la 'bbdd', evitando asi saltos de id y futuros conflictos
            articulo.Id = ObtenerSiguienteId();
            articulos.Add(articulo);
            UpdateArticulos(articulos);
        }

        public void DecrementarArticulo(int cantidad, int id)
        {
            var articulos = GetArticulos();
            var articulo = articulos.FirstOrDefault(articulos => articulos.Id == id);
            if (articulo == null || articulo.Cantidad < cantidad)
            {
                throw new BadHttpRequestException("No hay suficiente género en el almacen.");
            }
            articulo.Cantidad -= cantidad;
            UpdateArticulos(articulos);
        }

        public void IncrementarArticulo(int cantidad, int id)
        {
            var articulos = GetArticulos();
            var articulo = articulos.FirstOrDefault(articulos => articulos.Id == id);
            if (articulo==null)
            {
                throw new Exception("El articulo no existe");
            }
            articulo.Cantidad += cantidad;
            UpdateArticulos(articulos);
        }
    }
}
