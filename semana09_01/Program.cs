using System.Threading.Channels;

namespace semana09_01
{
    internal class Program
    {
        public static List<decimal> notas = [];
        static void Main(string[] args)
        {
            Console.WriteLine("Sistema de ingreso de notas");

            IngresarNotas();

            Console.WriteLine($"Al momento hay {notas.Count} notas registradas" +
                $"\n¿Desea imprimir el registro de notas?");
        }

        public static void IngresarNotas()
        {

            String notaIngresada = "";
            String continuar = "";

            do {

                do
                {
                    Console.WriteLine("\nIngrese una nota entre 0 y 10:");

                    notaIngresada = Console.ReadLine();

                    if (notaIngresada == null)
                    {
                        Console.WriteLine("No se ingresó ninguna nota.");
                        continue;
                    }

                    if (!decimal.TryParse(notaIngresada, out decimal numero))
                    {
                        Console.WriteLine("La nota ingresada no es un número válido.");
                        continue;
                    }

                    decimal notaFiltrada = decimal.Parse(notaIngresada);

                    if (notaFiltrada < 0 || notaFiltrada > 10)
                    {
                        Console.WriteLine("\nLa nota ingresada sale del rango valido (0 - 10)");
                        continue;
                    }

                    notas.Add(notaFiltrada);
                    Console.WriteLine($"\nLa nota ha sido ingresada en la posicion {notas.Count}");
                    break;

                    //Console.WriteLine(notaFiltrada);

                }
                while (true);

                Console.WriteLine("\n¿Desea ingresar otro registro de notas? Si/No");
                continuar = Console.ReadLine();

                if(continuar == null || continuar.ToLower() != "si")
                {
                    Console.WriteLine("\n> Usted selecciono no agregar otro registro de notas");
                    break;
                }
                else
                {
                    Console.WriteLine("\n> Usted selecciono agregar otro registro de notas");
                }

            }
            while (true);

        }
    }
}
