// Entregable 7 - Sistema de Empleados

using System;
using System.Collections.Generic;

namespace Entregable7_SistemaEmpleados
{
    class Program
    {
        static List<Empleado> empleados = new List<Empleado>();

        static void Main(string[] args)
        {
            bool continuar = true;

            Console.WriteLine("╔════════════════════════════════════════════╗");
            Console.WriteLine("║      SISTEMA DE EMPLEADOS - POO            ║");
            Console.WriteLine("║      Entregable 7 - Rafael Martinez        ║");
            Console.WriteLine("╚════════════════════════════════════════════╝");
            Console.WriteLine();
            Console.WriteLine("¡Hola! Bienvenido al Sistema de Empleados.");
            Console.WriteLine();

            CargarEmpleados();

            while (continuar)
            {
                MostrarMenu();
                string opcion = Console.ReadLine() ?? "";

                switch (opcion)
                {
                    case "1":
                        MostrarEmpleados();
                        break;
                    case "2":
                        Console.WriteLine("\n Función en desarrollo. Estará disponible en la próxima versión.");
                        break;
                    case "3":
                        continuar = false;
                        break;
                    default:
                        Console.WriteLine("\n Opción no válida. Por favor, seleccione una opción del 1 al 3.");
                        break;
                }

                if (continuar)
                {
                    Console.WriteLine("\nPresione cualquier tecla para continuar...");
                    Console.ReadKey();
                    Console.Clear();
                }
            }

            Console.WriteLine("\n¡Hasta luego! Gracias por usar el sistema de empleados.");
        }

        static void CargarEmpleados()
        {
            empleados.Add(new Developer("Ana Torres", 60000));
            empleados.Add(new Developer("Luis Gómez", 55000));
            empleados.Add(new Empleado("Carla Ruíz", 40000));
            Console.WriteLine($" Se registraron {empleados.Count} empleados en el sistema.");
        }

        static void MostrarMenu()
        {
            Console.WriteLine("\n--- MENÚ EMPLEADOS (HERENCIA Y SOBRESCRITURA) ---");
            Console.WriteLine("1. Mostrar empleados con su bono");
            Console.WriteLine("2. Mostrar total de bonos a pagar");
            Console.WriteLine("3. Salir");
            Console.Write("\nSeleccione una opción: ");
        }

        static void MostrarEmpleados()
        {
            if (empleados.Count == 0)
            {
                Console.WriteLine("\n No hay empleados registrados.");
                return;
            }

            Console.WriteLine($"\n Empleados registrados: {empleados.Count}");
            foreach (Empleado empleado in empleados)
            {
                empleado.MostrarInformacion();
            }
        }
    }

    class Empleado
    {
        private string nombre;
        private decimal salario;

        public string Nombre { get { return nombre; } }
        public decimal Salario { get { return salario; } }

        public Empleado(string nombre, decimal salario)
        {
            if (string.IsNullOrWhiteSpace(nombre))
            {
                throw new ArgumentException("El nombre no puede estar vacío.");
            }

            if (salario <= 0)
            {
                throw new ArgumentException("El salario debe ser mayor a cero.");
            }

            this.nombre = nombre.Trim();
            this.salario = salario;
        }

        public virtual decimal CalcularBono()
        {
            return salario * 0.05m;
        }

        public virtual void MostrarInformacion()
        {
            Console.WriteLine($"   [{GetType().Name}] {Nombre} - Salario: {Salario:C} - Bono: {CalcularBono():C}");
        }
    }

    class Developer : Empleado
    {
        public Developer(string nombre, decimal salario) : base(nombre, salario)
        {
        }

        public override decimal CalcularBono()
        {
            return Salario * 0.10m;
        }
    }
}
