using System;

namespace TiendaOnline
{
    public class Producto
    {
        public string Nombre { get; set; }
        public double Precio { get; set; }
        public string Codigo { get; set; }

        public Producto(string nombre, double precio, string codigo){
            Nombre = nombre.ToLower();
            Precio = precio;
            Codigo = codigo;
        }

        public override string ToString(){
            return $"Producto: {Nombre}, Código: {Codigo}, Precio: {Precio:C}";
        }
    }
}
