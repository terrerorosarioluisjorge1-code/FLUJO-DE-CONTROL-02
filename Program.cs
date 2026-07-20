using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace FLUJO_DE_CONTROL_PART_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
           
            Console.WriteLine("=================INGRESE LA CANTIDAD DE ESTUDIANTES=================");
            Console.WriteLine("==========================================================================");

            int n;
            while (!int.TryParse(Console.ReadLine(), out n) || n <= 0)
            {
                Console.WriteLine("Número inválido. Ingrese un número entero mayor que 0:");
            }

            var alumnos = new List<(string Nombre, double[] Notas, double Promedio, string Estatus)>();

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine();
                Console.WriteLine($"Estudiante #{i + 1} - Nombre:");

                string nombre = Console.ReadLine() ?? string.Empty;

                double[] notas = new double[5];

                for (int j = 0; j < 5; j++)
                {
                    double valor;
                    while (true)
                    {
                        Console.WriteLine($"Nota {j + 1}:");
                        string entrada = Console.ReadLine() ?? string.Empty;

                        // Intentar parsear con la cultura actual o Invariant como fallback
                        if (double.TryParse(entrada, NumberStyles.Number | NumberStyles.AllowThousands, CultureInfo.CurrentCulture, out valor)
                            || double.TryParse(entrada, NumberStyles.Number | NumberStyles.AllowThousands, CultureInfo.InvariantCulture, out valor))
                        {
                            if (valor >= 0 && valor <= 100)
                            {
                                notas[j] = valor;
                                break;
                            }
                        }

                        Console.WriteLine("Entrada inválida. Introduce un número entre 0 y 100.");
                    }
                }

                double promedio = notas.Average();
                string estatus = promedio >= 70.0 ? "Aprobado" : "Reprobado";

                alumnos.Add((nombre, notas, promedio, estatus));
            }

            Console.WriteLine();
            Console.WriteLine("================================================================================================================");
            Console.WriteLine("Nombre\t\t\tNota1\tNota2\tNota3\tNota4\tNota5\tPromedio\tEstatus");
            Console.WriteLine("================================================================================================================");

            foreach (var a in alumnos)
            {
                string n1 = a.Notas[0].ToString("0.##", CultureInfo.InvariantCulture);
                string n2 = a.Notas[1].ToString("0.##", CultureInfo.InvariantCulture);
                string n3 = a.Notas[2].ToString("0.##", CultureInfo.InvariantCulture);
                string n4 = a.Notas[3].ToString("0.##", CultureInfo.InvariantCulture);
                string n5 = a.Notas[4].ToString("0.##", CultureInfo.InvariantCulture);
                string prom = a.Promedio.ToString("0.##", CultureInfo.InvariantCulture);

                Console.WriteLine($"{a.Nombre,-25}\t{n1}\t{n2}\t{n3}\t{n4}\t{n5}\t{prom}\t{a.Estatus}");
            }

            Console.WriteLine();
            Console.WriteLine("Presione cualquier tecla para salir...");
            Console.ReadKey();
        }
    }
}





















