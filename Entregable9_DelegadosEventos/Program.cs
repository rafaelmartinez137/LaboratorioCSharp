// Entregable 9 - Delegados y Eventos

using System;
using System.Collections.Generic;

namespace Entregable9_DelegadosEventos
{
    class Program
    {
        static GestorOrdenes gestor = new GestorOrdenes();
        static List<Orden> ordenes = new List<Orden>();
        static List<string> bitacora = new List<string>();
        static ProcesadorMensaje procesadorActual = MostrarResumen;

        static void Main(string[] args)
        {
            bool continuar = true;

            Console.WriteLine("╔════════════════════════════════════════════╗");
            Console.WriteLine("║   SISTEMA DE ÓRDENES - DELEGADOS/EVENTOS   ║");
            Console.WriteLine("║   Entregable 9 - Rafael Martinez           ║");
            Console.WriteLine("╚════════════════════════════════════════════╝");
            Console.WriteLine();
            Console.WriteLine("¡Hola por última vez! Eventos y delegados en pleno funcionamiento.");
            Console.WriteLine();

            gestor.OrdenCreada += ProcesarMensaje;
            gestor.OrdenCreada += GuardarEnBitacora;

            while (continuar)
            {
                MostrarMenu();
                string opcion = Console.ReadLine() ?? "";

                switch (opcion)
                {
                    case "1":
                        CrearOrden();
                        break;
                    case "2":
                        MostrarOrdenes();
                        break;
                    case "3":
                        CambiarProcesador();
                        break;
                    case "4":
                        MostrarBitacora();
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

            Console.WriteLine("\n¡Hasta luego! Apagando el sistema de órdenes.");
        }

        static void MostrarMenu()
        {
            Console.WriteLine("\n--- MENÚ SISTEMA DE ÓRDENES (DELEGADOS Y EVENTOS) ---");
            Console.WriteLine("1. Crear nueva orden");
            Console.WriteLine("2. Mostrar órdenes registradas");
            Console.WriteLine("3. Cambiar procesador de mensajes");
            Console.WriteLine("4. Ver bitácora de eventos");
            Console.WriteLine("5. Salir");
            Console.Write("\nSeleccione una opción: ");
        }

        static void CrearOrden()
        {
            string cliente = LeerTexto("Ingrese el nombre del cliente: ");
            Orden orden = gestor.CrearOrden(cliente);
            ordenes.Add(orden);
        }

        static void MostrarOrdenes()
        {
            if (ordenes.Count == 0)
            {
                Console.WriteLine("\n Aún no se han creado órdenes.");
                return;
            }

            Console.WriteLine($"\n Órdenes registradas: {ordenes.Count}");
            foreach (Orden orden in ordenes)
            {
                Console.WriteLine($"   #{orden.Numero} - Cliente: {orden.Cliente} - {orden.FechaCreacion:dd/MM/yyyy HH:mm:ss}");
            }
        }

        static void ProcesarMensaje(string mensaje)
        {
            procesadorActual(mensaje);
        }

        static void GuardarEnBitacora(string mensaje)
        {
            bitacora.Add($"[{DateTime.Now:HH:mm:ss}] {mensaje}");
        }

        static void CambiarProcesador()
        {
            if (procesadorActual == MostrarResumen)
            {
                procesadorActual = MostrarDetallado;
                Console.WriteLine("\n Procesador cambiado a MODO DETALLADO.");
                MostrarDetallado("(Vista de prueba del nuevo procesador)");
            }
            else
            {
                procesadorActual = MostrarResumen;
                Console.WriteLine("\n Procesador cambiado a MODO RESUMEN.");
                MostrarResumen("(Vista de prueba del nuevo procesador)");
            }
        }

        static void MostrarResumen(string mensaje)
        {
            Console.WriteLine($"\n [EVENTO] {mensaje}");
        }

        static void MostrarDetallado(string mensaje)
        {
            Console.WriteLine("\n ════════ EVENTO RECIBIDO ════════");
            Console.WriteLine($"  Fecha y hora : {DateTime.Now:dd/MM/yyyy HH:mm:ss}");
            Console.WriteLine($"  Detalle      : {mensaje}");
            Console.WriteLine(" ═════════════════════════════════");
        }

        static void MostrarBitacora()
        {
            if (bitacora.Count == 0)
            {
                Console.WriteLine("\n La bitácora no tiene eventos registrados todavía.");
                return;
            }

            Console.WriteLine($"\n Bitácora de eventos ({bitacora.Count} registros):");
            foreach (string registro in bitacora)
            {
                Console.WriteLine($"   {registro}");
            }
        }

        static string LeerTexto(string mensaje)
        {
            Console.Write(mensaje);
            string texto = (Console.ReadLine() ?? "").Trim();

            while (texto.Length == 0)
            {
                Console.Write(" El nombre del cliente no puede estar vacío: ");
                texto = (Console.ReadLine() ?? "").Trim();
            }

            return texto;
        }
    }

    delegate void ProcesadorMensaje(string mensaje);

    class Orden
    {
        public int Numero { get; }
        public string Cliente { get; }
        public DateTime FechaCreacion { get; }

        public Orden(int numero, string cliente)
        {
            Numero = numero;
            Cliente = cliente;
            FechaCreacion = DateTime.Now;
        }
    }

    class GestorOrdenes
    {
        private int siguienteNumero = 1;

        public event ProcesadorMensaje? OrdenCreada;

        public Orden CrearOrden(string cliente)
        {
            Orden orden = new Orden(siguienteNumero, cliente);
            siguienteNumero++;

            OrdenCreada?.Invoke($"Se creó la orden #{orden.Numero} para el cliente \"{orden.Cliente}\".");

            return orden;
        }
    }
}
