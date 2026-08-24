// Entregable 6 - Diccionario de Productos

using System;
using System.Collections.Generic;

namespace Entregable6_DiccionarioProductos
{
    class Program
    {
        static Dictionary<int, Producto> inventario = new Dictionary<int, Producto>();

        static void Main(string[] args)
        {
            bool continuar = true;

            Console.WriteLine("╔════════════════════════════════════════════╗");
            Console.WriteLine("║   INVENTARIO DE PRODUCTOS - DICCIONARIO    ║");
            Console.WriteLine("║   Entregable 6 - Rafael Martinez           ║");
            Console.WriteLine("╚════════════════════════════════════════════╝");
            Console.WriteLine();
            Console.WriteLine("¡Hola de nuevo! Ahora con control total del stock del inventario.");
            Console.WriteLine();

            PrecargarProductos();

            while (continuar)
            {
                MostrarMenu();
                string opcion = Console.ReadLine() ?? "";

                switch (opcion)
                {
                    case "1":
                        BuscarProducto();
                        break;
                    case "2":
                        MostrarProductos();
                        break;
                    case "3":
                        ActualizarStock();
                        break;
                    case "4":
                        EliminarProducto();
                        break;
                    case "5":
                        MostrarStockBajo();
                        break;
                    case "6":
                        continuar = false;
                        break;
                    default:
                        Console.WriteLine("\n Opción no válida. Por favor, seleccione una opción del 1 al 6.");
                        break;
                }

                if (continuar)
                {
                    Console.WriteLine("\nPresione cualquier tecla para continuar...");
                    Console.ReadKey();
                    Console.Clear();
                }
            }

            Console.WriteLine("\n¡Hasta luego! Gracias por usar el sistema de inventario.");
        }

        static void PrecargarProductos()
        {
            inventario[101] = new Producto(101, "Arroz 1 kg", 25);
            inventario[102] = new Producto(102, "Frijoles 500 g", 8);
            inventario[103] = new Producto(103, "Aceite 1 L", 15);
            inventario[104] = new Producto(104, "Azúcar 1 kg", 4);
            inventario[105] = new Producto(105, "Café 250 g", 30);
            Console.WriteLine($" Se cargaron {inventario.Count} productos de ejemplo en el inventario.");
        }

        static void MostrarMenu()
        {
            Console.WriteLine("\n--- MENÚ INVENTARIO (Dictionary<int, Producto>) ---");
            Console.WriteLine("1. Buscar producto por ID");
            Console.WriteLine("2. Mostrar todos los productos");
            Console.WriteLine("3. Actualizar stock de un producto");
            Console.WriteLine("4. Eliminar un producto");
            Console.WriteLine("5. Mostrar productos con stock bajo");
            Console.WriteLine("6. Salir");
            Console.Write("\nSeleccione una opción: ");
        }

        static int LeerEntero(string mensaje)
        {
            Console.Write(mensaje);
            int numero;
            while (!int.TryParse(Console.ReadLine(), out numero))
            {
                Console.Write(" Por favor, ingrese un número entero válido: ");
            }
            return numero;
        }

        static void BuscarProducto()
        {
            int id = LeerEntero("\nIngrese el ID del producto: ");

            if (inventario.TryGetValue(id, out Producto? producto))
            {
                Console.WriteLine($"\n Producto encontrado: [{producto.Id}] {producto.Nombre} - Stock: {producto.Stock}");
            }
            else
            {
                Console.WriteLine($"\n No existe un producto con el ID {id}.");
            }
        }

        static void MostrarProductos()
        {
            if (inventario.Count == 0)
            {
                Console.WriteLine("\n El inventario está vacío.");
                return;
            }

            Console.WriteLine($"\n Productos en inventario: {inventario.Count}");
            foreach (Producto producto in inventario.Values)
            {
                Console.WriteLine($"   [{producto.Id}] {producto.Nombre} - Stock: {producto.Stock}");
            }
        }

        static void ActualizarStock()
        {
            int id = LeerEntero("\nIngrese el ID del producto: ");

            if (!inventario.TryGetValue(id, out Producto? producto))
            {
                Console.WriteLine($"\n No existe un producto con el ID {id}.");
                return;
            }

            Console.WriteLine($" Producto: [{producto.Id}] {producto.Nombre} - Stock actual: {producto.Stock}");
            int nuevoStock = LeerEntero("Ingrese el nuevo stock: ");

            if (nuevoStock < 0)
            {
                Console.WriteLine(" Error: El stock no puede ser negativo.");
                return;
            }

            producto.Stock = nuevoStock;
            Console.WriteLine($" Stock de \"{producto.Nombre}\" actualizado a {producto.Stock}.");
        }

        static void EliminarProducto()
        {
            int id = LeerEntero("\nIngrese el ID del producto a eliminar: ");

            if (inventario.Remove(id))
            {
                Console.WriteLine($" El producto con ID {id} fue eliminado del inventario.");
                Console.WriteLine($" Productos restantes: {inventario.Count}");
            }
            else
            {
                Console.WriteLine($"\n No existe un producto con el ID {id}.");
            }
        }

        static void MostrarStockBajo()
        {
            const int stockMinimo = 10;

            List<Producto> productosBajos = new List<Producto>();
            foreach (Producto producto in inventario.Values)
            {
                if (producto.Stock <= stockMinimo)
                {
                    productosBajos.Add(producto);
                }
            }

            if (productosBajos.Count == 0)
            {
                Console.WriteLine($"\n Ningún producto tiene stock bajo (límite: {stockMinimo} unidades).");
                return;
            }

            Console.WriteLine($"\n Productos con stock bajo (menor o igual a {stockMinimo} unidades):");
            foreach (Producto producto in productosBajos)
            {
                Console.WriteLine($"   [{producto.Id}] {producto.Nombre} - Stock: {producto.Stock}");
            }
        }
    }

    class Producto
    {
        public int Id { get; }
        public string Nombre { get; }
        public int Stock { get; set; }

        public Producto(int id, string nombre, int stock)
        {
            Id = id;
            Nombre = nombre;
            Stock = stock;
        }
    }
}
