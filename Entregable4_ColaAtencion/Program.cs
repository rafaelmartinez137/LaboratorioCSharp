// Entregable 4 - Cola de Atención

using System;
using System.Collections.Generic;

namespace Entregable4_ColaAtencion
{
    class Program
    {
        static Queue<string> cola = new Queue<string>();

        static void Main(string[] args)
        {
            bool continuar = true;

            Console.WriteLine("╔════════════════════════════════════════════╗");
            Console.WriteLine("║      COLA DE ATENCIÓN - MÓDULO TURNOS      ║");
            Console.WriteLine("║      Entregable 4 - Rafael Martinez        ║");
            Console.WriteLine("╚════════════════════════════════════════════╝");
            Console.WriteLine();
            Console.WriteLine("¡Hola! Bienvenido a la Cola de Atención.");
            Console.WriteLine();

            while (continuar)
            {
                MostrarMenu();
                string opcion = Console.ReadLine() ?? "";

                switch (opcion)
                {
                    case "1":
                        RegistrarPersona();
                        break;
                    case "2":
                    case "3":
                    case "4":
                        Console.WriteLine("\n Función en desarrollo. Estará disponible en la próxima versión.");
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

            Console.WriteLine("\n¡Hasta pronto! Gracias por usar el sistema de turnos.");
        }

        static void MostrarMenu()
        {
            Console.WriteLine("\n--- MENÚ COLA DE ATENCIÓN (FIFO) ---");
            Console.WriteLine("1. Registrar persona en cola");
            Console.WriteLine("2. Atender al primero");
            Console.WriteLine("3. Mostrar cantidad de pendientes");
            Console.WriteLine("4. Mostrar siguiente persona");
            Console.WriteLine("5. Salir");
            Console.Write("\nSeleccione una opción: ");
        }

        static void RegistrarPersona()
        {
            Console.Write("\nIngrese el nombre de la persona: ");
            string nombre = (Console.ReadLine() ?? "").Trim();

            if (nombre.Length == 0)
            {
                Console.WriteLine(" Error: El nombre no puede estar vacío.");
                return;
            }

            cola.Enqueue(nombre);
            Console.WriteLine($" \"{nombre}\" fue registrado en la cola. Posición asignada: {cola.Count}");
        }
    }
}
