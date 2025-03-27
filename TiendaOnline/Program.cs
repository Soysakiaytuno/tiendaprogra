using System;

namespace TiendaOnline
{
    class Program
    {
        static void Main(string[] args)
        {
            Inventario inventario = new Inventario();
            Reportes reportes = new Reportes();

            bool continuar = true;

            InterfazUsuario.MostrarOpciones();

            while (continuar)
            {
                Console.Write("\nIngrese un comando: ");
                string comando = Console.ReadLine();
                comando = comando.ToLower();
                comando = comando.Trim();
                comando = comando.Replace (" ", "");
                switch (comando)
                {
                    case "agregar":
                        InterfazUsuario.AgregarProducto(inventario);
                        break;

                    case "eliminar":
                        InterfazUsuario.EliminarProducto(inventario);
                        break;

                    case "mostrar":
                        inventario.MostrarInventario();
                        break;

                    case "stock":
                        InterfazUsuario.MostrarStock(inventario);
                        break;

                    case "venta":
                        InterfazUsuario.RealizarVenta(inventario, reportes);
                        break;

                    case "salir":
                        Console.WriteLine("Saliendo del programa. ¡Gracias por usar la tienda online!");
                        continuar = false;
                        break;

                    case "opciones":
                        InterfazUsuario.MostrarOpciones();
                        break;
                    case "mostrarnombre":
                        InterfazUsuario.Mostrarproducto(inventario);
                        break;

                    default:
                        Console.WriteLine("Comando no reconocido. Intente nuevamente o ingrese 'opciones' para ver la lista de comandos.");
                        break;
                }
            }
        }
    }
}
