using almacen.Models;
using System.Collections.Generic;

namespace almacen.Contracts
{
    public interface IAlmacenRepository
    {
        List<Articulo> GetArticulos();
        void AddArticulo(Articulo articulo);
        void IncrementarArticulo(int cantidad, int id);
        void DecrementarArticulo(int cantidad, int id);
    }
}
