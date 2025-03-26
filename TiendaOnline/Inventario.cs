using System;
using System.Collections.Generic;

namespace TiendaOnline
{
    public class Inventario{
        private Dictionary<string, Producto> productos; 

        public Inventario(){
            productos = new Dictionary<string, Producto>();
        }
        public void AgregarProducto(Producto producto){
            if (!productos.ContainsKey(producto.Codigo)){
                productos.Add(producto.Codigo, producto);
                Console.WriteLine($"Producto {producto.Nombre} con código {producto.Codigo} agregado al inventario.");
            }
            else{
                Console.WriteLine($"Ya existe un producto con el código {producto.Codigo} en el inventario.");
            }
        }

        public void EliminarProducto(string codigoProducto)
        {
            if (productos.Remove(codigoProducto)){
                Console.WriteLine($"Producto con código {codigoProducto} eliminado del inventario.");
            }
            else
            {
                Console.WriteLine($"Producto con código {codigoProducto} no encontrado.");
            }
        }
        public Producto ObtenerProductoPorCodigo(string codigoProducto)
        {
            if (productos.TryGetValue(codigoProducto, out Producto producto))
            {
                return producto;
            }
            Console.WriteLine($"Producto con código {codigoProducto} no encontrado.");
            return null;
        }
        public List<Producto> ObtenerTodosLosProductos()
        {
            return new List<Producto>(productos.Values);
        }

        public void MostrarInventario()
        {
            Console.WriteLine("Inventario de Productos:");
            foreach (var producto in productos.Values)
            {
                Console.WriteLine(producto.ToString());
            }
        }
        public int ObtenerStockPorNombre(string nombre)
        {
            int stock = 0;
            foreach (var producto in productos.Values)
            {
                if (producto.Nombre == nombre){
                    stock++;
                }
            }
            return stock;
        }
    }
}
