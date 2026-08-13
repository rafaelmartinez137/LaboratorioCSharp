// Entregable 2 - Ordenamiento Básico
// Arreglos, listas, ciclos, ordenamiento y búsqueda lineal

using System;
using System.Collections.Generic;
using System.Linq;

namespace Entregable2_Ordenamiento
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numeros = new List<int>();
            bool continuar = true;

            Console.WriteLine("╔══════════════════════════════════════════╗");
            Console.WriteLine("║   ANÁLISIS DE NÚMEROS - NET              ║");
            Console.WriteLine("║ Entregable 2 - Ordenamiento - Rafael Martinez ║");
            Console.WriteLine("╚══════════════════════════════════════════╝");
            Console.WriteLine();

            int cantidad;
            do
            {
                Console.Write("¿Cuántos números desea ingresar? ");
            } while (!int.TryParse(Console.ReadLine(), out cantidad) || cantidad <= 0);

            Console.WriteLine($"\nIngrese {cantidad} números uno por uno:");
            for (int i = 0; i < cantidad; i++)
            {
                Console.Write($"Número {i + 1}: ");
                int numero;
                while (!int.TryParse(Console.ReadLine(), out numero))
                {
                    Console.Write("Ingrese un número entero válido: ");
                }
                numeros.Add(numero);
            }

            Console.WriteLine("\n Números cargados exitosamente.");

            while (continuar)
            {
                MostrarMenu();
                string opcion = Console.ReadLine() ?? "";

                switch (opcion)
                {
                    case "6": MostrarNumeros(numeros); break;
                    case "7":
                        continuar = false;
                        Console.WriteLine("\n Hasta pronto ");
                        break;
                    default:
                        Console.WriteLine("\n Opción no válida.");
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
            Console.WriteLine("\n--- MENÚ DE ANÁLISIS ---");
            Console.WriteLine("6. Mostrar todos los números");
            Console.WriteLine("7. Salir");
            Console.Write("\nSeleccione una opción: ");
        }

        static void MostrarNumeros(List<int> numeros)
        {
            Console.WriteLine("\n--- LISTA DE NÚMEROS ---");

            if (numeros.Count == 0)
            {
                Console.WriteLine(" La lista está vacía.");
                return;
            }

            Console.WriteLine($"Total de números: {numeros.Count}");
            for (int i = 0; i < numeros.Count; i++)
            {
                Console.WriteLine($"  [{i + 1}] {numeros[i]}");
            }
        }
    }
}
