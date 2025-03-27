using System;
using System.Collections.Generic;

namespace TiendaOnline
{
    public class Reportes{
        private List<Producto> productosVendidos; 

        public Reportes(){
            productosVendidos = new List<Producto>();
        }

        public void RegistrarVenta(Producto producto){
            productosVendidos.Add(producto);
            Console.WriteLine($"Producto {producto.Nombre} con código {producto.Codigo} registrado como vendido.");
        }
        public void StockPorNombre(Inventario inventario, string nombreProducto){
            int stock = inventario.ObtenerStockPorNombre(nombreProducto);
            Console.WriteLine($"El stock actual de '{nombreProducto}' es: {stock}");
        }
    }
}
