// Entregable 3 - Gestión Simple de Nombres
// Uso práctico de List<T>

using System;
using System.Collections.Generic;
using System.Linq;

namespace Entregable3_GestionNombres
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> teamMembers = new List<string>();
            bool continuar = true;

            Console.WriteLine("╔══════════════════════════════════════════╗");
            Console.WriteLine("║ GESTIÓN DE TEAM MEMBERS - NET SIMPLES    ║");
            Console.WriteLine("║      Entregable 3 - List<T>              ║");
            Console.WriteLine("╚══════════════════════════════════════════╝");
            Console.WriteLine();

            while (continuar)
            {
                MostrarMenu();
                string opcion = Console.ReadLine() ?? "";

                switch (opcion)
                {
                    case "1": AgregarNombre(teamMembers); break;
                    case "6":
                        continuar = false;
                        Console.WriteLine("\n Hasta pronto Gestión de Team Members cerrada.");
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
            Console.WriteLine("\n--- MENÚ DE GESTIÓN ---");
            Console.WriteLine("1. Agregar nombre");
            Console.WriteLine("6. Salir");
            Console.Write("\nSeleccione una opción: ");
        }

        static void AgregarNombre(List<string> teamMembers)
        {
            Console.WriteLine("\n--- AGREGAR NOMBRE ---");
            Console.Write("Ingrese el nombre del Team Member: ");
            string nombre = Console.ReadLine()?.Trim() ?? "";

            if (string.IsNullOrWhiteSpace(nombre))
            {
                Console.WriteLine(" El nombre no puede estar vacío.");
                return;
            }

            if (teamMembers.Contains(nombre))
            {
                Console.WriteLine($" El nombre '{nombre}' ya existe en la lista.");
                return;
            }

            teamMembers.Add(nombre);
            Console.WriteLine($" '{nombre}' agregado exitosamente.");
            Console.WriteLine($"  Total de miembros: {teamMembers.Count}");
        }
    }
}
