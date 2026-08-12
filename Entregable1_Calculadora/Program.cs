// Entregable 1 - Calculadora 

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
                    case "1": RealizarOperacion("suma"); break;
                 case "2": RealizarOperacion("resta"); break;
                    case "3": RealizarOperacion("multiplicación"); break;
                    case "4": RealizarOperacion("división"); break;
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

        // Solicita un número y repite hasta que la entrada sea válida
        static double LeerNumero(string mensaje)
        {
            Console.Write(mensaje);
            double numero;
            while (!double.TryParse(Console.ReadLine(), out numero))
            {
                Console.Write(" Por favor, ingrese un número válido: ");
            }
            return numero;
        }

        static void RealizarOperacion(string operacion)
        {
            Console.WriteLine($"\n--- OPERACIÓN: {operacion.ToUpper()} ---");

            double numero1 = LeerNumero("Ingrese el primer número: ");
          double numero2 = LeerNumero("Ingrese el segundo número: ");

            switch (operacion)
            {
                case "suma":
                    Console.WriteLine($"\n Resultado: {numero1} + {numero2} = {numero1 + numero2}");
                    break;

                case "resta":
                    Console.WriteLine($"\n Resultado: {numero1} - {numero2} = {numero1 - numero2}");
                    break;

                case "multiplicación":
                    Console.WriteLine($"\n Resultado: {numero1} × {numero2} = {numero1 * numero2}");
                    break;

                case "división":
                    if (numero2 == 0)
                    {
                     Console.WriteLine("\n Error: No es posible dividir entre cero.");
                        Console.WriteLine("  La división entre cero no está definida en los números reales.");
                    }
                    else
                    {
                      Console.WriteLine($"\n Resultado: {numero1} ÷ {numero2} = {numero1 / numero2:F4}");
                    }
                    break;
            }
        }
    }
}
