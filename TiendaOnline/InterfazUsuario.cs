using System;
using System.Collections.Generic;

namespace TiendaOnline
{
    public class InterfazUsuario
    {
        public static void MostrarOpciones()
        {
            Console.WriteLine("\n=== Comandos Disponibles ===");
            Console.WriteLine("agregar   - Agregar un producto al inventario");
            Console.WriteLine("eliminar  - Eliminar un producto del inventario por código");
            Console.WriteLine("mostrar   - Mostrar todos los productos en el inventario");
            Console.WriteLine("stock     - Mostrar el stock de un producto por nombre");
            Console.WriteLine("venta     - Realizar una venta");
            Console.WriteLine("salir     - Salir del programa");
            Console.WriteLine("opciones  - Mostrar esta lista de comandos");
        }

        public static void AgregarProducto(Inventario inventario)
        {
            Console.Write("Ingrese el nombre del producto: ");
            string nombre = Console.ReadLine();

            Console.Write("Ingrese el precio del producto: ");
            if (!double.TryParse(Console.ReadLine(), out double precio)){
                Console.WriteLine("Precio inválido. Inténtelo nuevamente.");
                return;
            }

            Console.Write("Ingrese el código único del producto: ");
            string codigo = Console.ReadLine();

            Producto producto = new Producto(nombre, precio, codigo);
            inventario.AgregarProducto(producto);
        }

        public static void EliminarProducto(Inventario inventario){
            Console.Write("Ingrese el código del producto a eliminar: ");
            string codigo = Console.ReadLine();
            inventario.EliminarProducto(codigo);
        }

        public static void MostrarStock(Inventario inventario)
        {
            Console.Write("Ingrese el nombre del producto para consultar su stock: ");
            string nombre = Console.ReadLine();

            int stock = inventario.ObtenerStockPorNombre(nombre);
            Console.WriteLine($"El stock actual de '{nombre}' es: {stock}");
        }

        public static void RealizarVenta(Inventario inventario, Reportes reportes)
        {
            List<Producto> productosSeleccionados = new List<Producto>();
            double total = 0;

            Console.WriteLine("Ingrese los códigos de los productos a vender uno por uno. Escriba fin para terminar:");
            while (true){
                string codigo = Console.ReadLine().Trim();
                if (codigo.ToLower() == "fin"){ 
                    break;
                }

                Producto producto = inventario.ObtenerProductoPorCodigo(codigo);

                if (producto != null){
                    productosSeleccionados.Add(producto);
                    reportes.RegistrarVenta(producto);
                    inventario.EliminarProducto(codigo);
                }
                else{
                    Console.WriteLine($"Producto con código {codigo} no encontrado.");
                }
            }

            if (productosSeleccionados.Count == 0){
                Console.WriteLine("No se seleccionaron productos para la venta.");
                return;
            }

            Console.WriteLine("\n=== Resumen de Venta ===");
            foreach (var producto in productosSeleccionados){
                Console.WriteLine(producto.ToString());
                total += producto.Precio;
            }
            Console.WriteLine($"Total: {total:C}");
            Console.WriteLine("Venta realizada con éxito.");
        }
    }
}
