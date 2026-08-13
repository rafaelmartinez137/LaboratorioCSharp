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
                    case "1": MostrarMayorMenor(numeros); break;
                    case "2": CalcularPromedio(numeros); break;
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
            Console.WriteLine("1. Mostrar número mayor y menor");
            Console.WriteLine("2. Calcular promedio");
            Console.WriteLine("6. Mostrar todos los números");
            Console.WriteLine("7. Salir");
            Console.Write("\nSeleccione una opción: ");
        }

        static void MostrarMayorMenor(List<int> numeros)
        {
            Console.WriteLine("\n--- NÚMERO MAYOR Y MENOR ---");

            if (numeros.Count == 0)
            {
                Console.WriteLine(" La lista está vacía.");
                return;
            }

            int mayor = numeros[0];
            int menor = numeros[0];
            foreach (int numero in numeros)
            {
                if (numero > mayor) mayor = numero;
                if (numero < menor) menor = numero;
            }

            Console.WriteLine($"Número mayor: {mayor}");
            Console.WriteLine($"Número menor: {menor}");
            Console.WriteLine($"Diferencia (rango): {mayor - menor}");
        }

        static void CalcularPromedio(List<int> numeros)
        {
            Console.WriteLine("\n--- PROMEDIO ---");

            if (numeros.Count == 0)
            {
                Console.WriteLine(" La lista está vacía.");
                return;
            }

            int suma = 0;
            foreach (int numero in numeros)
            {
                suma += numero;
            }

            double promedio = (double)suma / numeros.Count;
            Console.WriteLine($"Suma total: {suma}");
            Console.WriteLine($"Cantidad de números: {numeros.Count}");
            Console.WriteLine($"Promedio: {promedio:F2}");
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
