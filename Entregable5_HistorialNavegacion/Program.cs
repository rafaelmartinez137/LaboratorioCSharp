// Entregable 5 - Historial de Navegación

using System;
using System.Collections.Generic;

namespace Entregable5_HistorialNavegacion
{
    class Program
    {
        static Stack<string> historial = new Stack<string>();
        static string paginaActual = "";

        static void Main(string[] args)
        {
            bool continuar = true;

            Console.WriteLine("╔════════════════════════════════════════════╗");
            Console.WriteLine("║    HISTORIAL DE NAVEGACIÓN - NAVEGADOR     ║");
            Console.WriteLine("║    Entregable 5 - Rafael Martinez          ║");
            Console.WriteLine("╚════════════════════════════════════════════╝");
            Console.WriteLine();
            Console.WriteLine("¡Hola explorador! Navega con tu historial LIFO listo para usar.");
            Console.WriteLine();

            while (continuar)
            {
                MostrarMenu();
                string opcion = Console.ReadLine() ?? "";

                switch (opcion)
                {
                    case "1":
                        VisitarPagina();
                        break;
                    case "2":
                        RetrocederPagina();
                        break;
                    case "3":
                        MostrarPaginaActual();
                        break;
                    case "4":
                        MostrarHistorial();
                        break;
                    case "5":
                        continuar = false;
                        break;
                    default:
                        Console.WriteLine("\n Opción no válida. Por favor, seleccione una opción del 1 al 5.");
                        break;
                }

                if (continuar)
                {
                    Console.WriteLine("\nPresione cualquier tecla para continuar...");
                    Console.ReadKey();
                    Console.Clear();
                }
            }

            Console.WriteLine("\n¡Hasta la próxima! Cerrando el navegador.");
        }

        static void MostrarMenu()
        {
            Console.WriteLine("\n--- MENÚ HISTORIAL DE NAVEGACIÓN (LIFO) ---");
            Console.WriteLine("1. Visitar una página");
            Console.WriteLine("2. Retroceder a la página anterior");
            Console.WriteLine("3. Mostrar página actual");
            Console.WriteLine("4. Mostrar historial de navegación");
            Console.WriteLine("5. Salir");
            Console.Write("\nSeleccione una opción: ");
        }

        static void VisitarPagina()
        {
            Console.Write("\nIngrese la dirección de la página (ej. www.ejemplo.com): ");
            string pagina = (Console.ReadLine() ?? "").Trim();

            if (pagina.Length == 0)
            {
                Console.WriteLine(" Error: Debe indicar una dirección válida.");
                return;
            }

            if (paginaActual.Length > 0)
            {
                historial.Push(paginaActual);
            }

            paginaActual = pagina;
            Console.WriteLine($"\n Navegando hacia: {paginaActual}");
        }

        static void RetrocederPagina()
        {
            if (historial.Count == 0)
            {
                Console.WriteLine("\n No hay páginas anteriores en el historial.");
                return;
            }

            paginaActual = historial.Pop();
            Console.WriteLine($"\n Retrocediendo a la página anterior: {paginaActual}");
        }

        static void MostrarPaginaActual()
        {
            if (paginaActual.Length == 0)
            {
                Console.WriteLine("\n Aún no se ha visitado ninguna página.");
                return;
            }

            Console.WriteLine($"\n Página actual: {paginaActual}");
        }

        static void MostrarHistorial()
        {
            if (historial.Count == 0)
            {
                Console.WriteLine("\n El historial de navegación está vacío.");
                return;
            }

            Console.WriteLine($"\n Páginas visitadas (de la más reciente a la más antigua): {historial.Count}");
            int posicion = 1;
            foreach (string pagina in historial)
            {
                Console.WriteLine($"   {posicion}. {pagina}");
                posicion++;
            }
        }
    }
}
