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
            Console.WriteLine("¡Hola otra vez! La cola FIFO está lista para atender turnos.");
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
                        AtenderPrimero();
                        break;
                    case "3":
                        MostrarPendientes();
                        break;
                    case "4":
                        MostrarSiguiente();
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

        static void AtenderPrimero()
        {
            if (cola.Count == 0)
            {
                Console.WriteLine("\n No hay personas en la cola para atender.");
                return;
            }

            string atendida = cola.Dequeue();
            Console.WriteLine($"\n Atendiendo a: {atendida}");
            Console.WriteLine($" La persona \"{atendida}\" salió de la cola (primera en llegar, primera en salir).");
            Console.WriteLine($" Personas pendientes: {cola.Count}");
        }

        static void MostrarPendientes()
        {
            Console.WriteLine($"\n Personas pendientes en cola: {cola.Count}");

            if (cola.Count > 0)
            {
                Console.WriteLine(" Orden de llegada:");
                int posicion = 1;
                foreach (string persona in cola)
                {
                    Console.WriteLine($"   {posicion}. {persona}");
                    posicion++;
                }
            }
            else
            {
                Console.WriteLine(" La cola está vacía.");
            }
        }

        static void MostrarSiguiente()
        {
            if (cola.Count == 0)
            {
                Console.WriteLine("\n No hay nadie esperando para ser atendido.");
                return;
            }

            Console.WriteLine($"\n Siguiente persona a ser atendida: {cola.Peek()}");
        }
    }
}
