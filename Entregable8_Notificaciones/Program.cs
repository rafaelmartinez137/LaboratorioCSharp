// Entregable 8 - Interfaces de Notificación

using System;
using System.Collections.Generic;

namespace Entregable8_Notificaciones
{
    class Program
    {
        static List<INotificador> notificadores = new List<INotificador>
        {
            new EmailNotificador(),
            new SmsNotificador(),
            new TeamsNotificador()
        };

        static void Main(string[] args)
        {
            bool continuar = true;

            Console.WriteLine("╔════════════════════════════════════════════╗");
            Console.WriteLine("║   CENTRO DE NOTIFICACIONES - INTERFACES    ║");
            Console.WriteLine("║   Entregable 8 - Rafael Martinez           ║");
            Console.WriteLine("╚════════════════════════════════════════════╝");
            Console.WriteLine();
            Console.WriteLine("Hola Email, SMS y Teams ya están conectados.");
            Console.WriteLine();

            while (continuar)
            {
                MostrarMenu();
                string opcion = Console.ReadLine() ?? "";

                switch (opcion)
                {
                    case "1":
                        EnviarCon(BuscarNotificador("Email"));
                        break;
                    case "2":
                        EnviarCon(BuscarNotificador("SMS"));
                        break;
                    case "3":
                        EnviarCon(BuscarNotificador("Teams"));
                        break;
                    case "4":
                        EnviarPorTodosLosCanales();
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

            Console.WriteLine("\n¡Hasta pronto! Cerrando el centro de notificaciones.");
        }

        static void MostrarMenu()
        {
            Console.WriteLine("\n--- MENÚ NOTIFICACIONES (POLIMORFISMO CON INTERFACES) ---");
            Console.WriteLine("1. Enviar correo electrónico (Email)");
            Console.WriteLine("2. Enviar mensaje de texto (SMS)");
            Console.WriteLine("3. Enviar mensaje por Teams");
            Console.WriteLine("4. Enviar por todos los canales");
            Console.WriteLine("5. Salir");
            Console.Write("\nSeleccione una opción: ");
        }

        static INotificador? BuscarNotificador(string canal)
        {
            foreach (INotificador notificador in notificadores)
            {
                if (notificador.Canal == canal)
                {
                    return notificador;
                }
            }

            return null;
        }

        static void EnviarCon(INotificador? notificador)
        {
            if (notificador == null)
            {
                Console.WriteLine("\n Ese canal de notificación no está disponible todavía.");
                return;
            }

            string destinatario = LeerTexto($"Ingrese el destinatario ({notificador.Canal}): ");
            string mensaje = LeerTexto("Ingrese el mensaje a enviar: ");

            notificador.Enviar(destinatario, mensaje);
        }

        static void EnviarPorTodosLosCanales()
        {
            string destinatario = LeerTexto("Ingrese el destinatario: ");
            string mensaje = LeerTexto("Ingrese el mensaje a enviar: ");

            Console.WriteLine("\n Enviando por todos los canales disponibles...");
            int enviados = 0;

            foreach (INotificador notificador in notificadores)
            {
                if (notificador.Enviar(destinatario, mensaje))
                {
                    enviados++;
                }
            }

            Console.WriteLine($"\n Resultado: {enviados} de {notificadores.Count} notificaciones enviadas.");
        }

        static string LeerTexto(string mensaje)
        {
            Console.Write(mensaje);
            string texto = (Console.ReadLine() ?? "").Trim();

            while (texto.Length == 0)
            {
                Console.Write(" El texto no puede estar vacío. Intente nuevamente: ");
                texto = (Console.ReadLine() ?? "").Trim();
            }

            return texto;
        }
    }

    interface INotificador
    {
        string Canal { get; }

        bool Enviar(string destinatario, string mensaje);
    }

    class EmailNotificador : INotificador
    {
        public string Canal { get { return "Email"; } }

        public bool Enviar(string destinatario, string mensaje)
        {
            if (!destinatario.Contains("@"))
            {
                Console.WriteLine("\n Error: El destinatario no es un correo electrónico válido.");
                return false;
            }

            Console.WriteLine("\n ──── EMAIL ────");
            Console.WriteLine($" Destinatario : {destinatario}");
            Console.WriteLine($" Mensaje      : {mensaje}");
            Console.WriteLine(" Estado       : Enviado correctamente.");
            return true;
        }
    }

    class SmsNotificador : INotificador
    {
        public string Canal { get { return "SMS"; } }

        public bool Enviar(string destinatario, string mensaje)
        {
            if (mensaje.Length > 160)
            {
                Console.WriteLine("\n Error: Un SMS no puede superar los 160 caracteres.");
                return false;
            }

            Console.WriteLine("\n ──── SMS ────");
            Console.WriteLine($" Número       : {destinatario}");
            Console.WriteLine($" Mensaje      : {mensaje}");
            Console.WriteLine(" Estado       : Enviado correctamente.");
            return true;
        }
    }

    class TeamsNotificador : INotificador
    {
        public string Canal { get { return "Teams"; } }

        public bool Enviar(string destinatario, string mensaje)
        {
            if (destinatario.Length < 3)
            {
                Console.WriteLine("\n Error: El usuario o canal de Teams no es válido.");
                return false;
            }

            Console.WriteLine("\n ──── TEAMS ────");
            Console.WriteLine($" Usuario/Canal: {destinatario}");
            Console.WriteLine($" Mensaje      : {mensaje}");
            Console.WriteLine(" Estado       : Entregado en el chat de Teams.");
            return true;
        }
    }
}
