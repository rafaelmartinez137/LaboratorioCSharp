// Entregable 1 - Calculadora de Consola

using System;

namespace Entregable1_Calculadora
{
    class Program
    {
        static void Main(string[] args)
        {
            bool continuar = true;

            Console.WriteLine("╔══════════════════════════════════════════╗");
            Console.WriteLine("║   CALCULADORA BANCARIA - NET             ║");
            Console.WriteLine("║   Entregable 1 - Rafael Martinez         ║");
            Console.WriteLine("╚══════════════════════════════════════════╝");
            Console.WriteLine();

            while (continuar)
            {
                MostrarMenu();
                string opcion = Console.ReadLine() ?? "";

                switch (opcion)
                {
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
        }

        static void MostrarMenu()
        {
            Console.WriteLine("\n--- MENÚ DE OPERACIONES ---");
            Console.WriteLine("1. Sumar");
            Console.WriteLine("2. Restar");
            Console.WriteLine("3. Multiplicar");
            Console.WriteLine("4. Dividir");
            Console.WriteLine("5. Salir");
            Console.Write("\nSeleccione una opción: ");
        }
    }
}
