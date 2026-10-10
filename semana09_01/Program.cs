using System.Threading.Channels;

namespace semana09_01
{
    internal class Program
    {
        public static List<string> alumnos = [];
        public static List<decimal> notas = [];
        public static decimal promedio = 0.0m;

        static void Main(string[] args)
        {

            mostrarMenu();

        }

        public static void mostrarMenu()
        {
            String opcion = "";
            do
            {
                Console.WriteLine(new string('-', 30));
                Console.WriteLine("Sistema de ingreso de notas");
                Console.WriteLine(new string('-', 30));
                Console.WriteLine("\nSeleccione una opción:" +
                    "\n1. Ingresar alumnos" +
                    "\n2. Ingresar notas" +
                    "\n3. Mostrar notas" +
                    "\n4. Eliminar registro de alumno" +
                    "\n5. Salir del sistema");
                
                opcion = Console.ReadLine();

                if (opcion == null || opcion == "")
                {
                    Console.WriteLine("\n> Opción inválida, por favor seleccione una opción válida");
                    continue;
                }
                else if (opcion.Equals("1")) { IngresarNombresAlumnos(); }
                else if (opcion.Equals("2")) { IngresarNotas(); }
                else if (opcion.Equals("3")) { ImprimirNotas(); }
                else if (opcion.Equals("4")) { EliminarRegistroAlumno(); }
                else { 
                    Console.WriteLine("\n> Usted selecciono salir del sistema");
                    break;}
            }
            while (true);
        }

        public static void IngresarNombresAlumnos()
        {
            String nombreIngresado = "";
            String continuar = "";
            do
            {
                do
                {
                    Console.WriteLine("\nIngrese el nombre del alumno:");
                        
                    nombreIngresado = Console.ReadLine();

                    if (nombreIngresado == null || nombreIngresado.Trim() == "")
                    {
                        Console.WriteLine("No se ingresó ningún nombre.");
                        continue;
                    }
                    alumnos.Add(nombreIngresado);
                    Console.WriteLine($"\nEl nombre ha sido ingresado en la posicion {alumnos.Count}");
                    break;
                }
                while (true);
                Console.WriteLine("\n¿Desea ingresar otro registro de alumnos? Si/No");
                continuar = Console.ReadLine();
                if (continuar == null || continuar.ToLower() != "si")
                {
                    Console.WriteLine("\n> Usted selecciono no agregar otro registro de alumnos");
                    break;
                }
                else
                {
                    Console.WriteLine("\n> Usted selecciono agregar otro registro de alumnos");
                }
            }
            while (true);
        }

        public static void EliminarRegistroAlumno()
        {
            String nombreAlumno = "";
            int indexAlumno = 0;



            if (alumnos.Count == 0)
            {
                Console.WriteLine("\nNo es posible eliminar alumnos, no hay alumnos registrados");
            }
            else {
                Console.WriteLine("\nSeleccione el alumno a eliminar" +
                  "Ingrese '0' para consultar listado alumnos");

                nombreAlumno = Console.ReadLine();

                if (!alumnos.Contains(nombreAlumno) || nombreAlumno == null)
                {
                    Console.WriteLine("Alumno no encontrado, por favor ingrese un nombre válido");
                }
                else if (nombreAlumno == "0")
                {
                    Console.WriteLine("\n> A continuación se mostrara la lista de alumnos registrados");
                    ImprimirAlumnos();
                }
                else
                {
                    indexAlumno = alumnos.IndexOf(nombreAlumno);
                    alumnos.RemoveAt(indexAlumno);
                    notas.RemoveAt(indexAlumno);
                    Console.WriteLine($"\nEl alumno {nombreAlumno} ha sido eliminado del registro");
                }
            }
        }

        public static void IngresarNotas()
        {
            String notaIngresada = "";
            String nombreAlumno = "";
            decimal notaPrevia = 0.0m;
            int indexAlumno = 0;

            

            if (alumnos.Count == 0) {
                Console.WriteLine("\nNo es posible ingresar notas, no hay alumnos registrados");
            }
            else {

                Console.WriteLine("\nSeleccione el alumno a ingresarle nota" +
                "Ingrese '0' para consultar listado alumnos");

                nombreAlumno = Console.ReadLine();

                if (!alumnos.Contains(nombreAlumno) || nombreAlumno == null) {
                    Console.WriteLine("Alumno no encontrado, por favor ingrese un nombre válido");
                } else if (nombreAlumno == "0")
                {
                    Console.WriteLine("\n> A continuación se mostrara la lista de alumnos registrados");
                    ImprimirAlumnos();
                }
                else
                {
                    indexAlumno = alumnos.IndexOf(nombreAlumno);

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

                        notas[indexAlumno] = notaFiltrada;
                        Console.WriteLine($"\nLa nota ha sido ingresada para el alumno {alumnos[indexAlumno]}");
                        Console.WriteLine($"\nLa nota previa era {notaPrevia} la nota nueva es {notaFiltrada}");
                        break;
                    }
                    while (true);
                }

            }
        }

        public static void ImprimirAlumnos()
        {
            Console.WriteLine("\nRegistro de alumnos ingresados:");
            for (int i = 0; i < alumnos.Count; i++)
            {
                Console.WriteLine($"Alumno {i + 1}: {alumnos[i]}");
            }
        }

        public static void ImprimirNotas()
        {
            if (alumnos.Count == 0)
            {
                Console.WriteLine("\nNo es posible imprimir las notas, no hay alumnos registrados.");
            }
            else {
                promedio = notas.Average();
                Console.WriteLine($"\nAl momento hay {notas.Count} notas registradas para {alumnos.Count} alumnos" +
                    $"\n¿Desea imprimir el registro de notas? Si/No");
                String imprimir = Console.ReadLine();

                if (imprimir == null || imprimir.ToLower() != "si")
                {
                    Console.WriteLine("\n> Usted selecciono no imprimir el registro de notas");
                    return;
                }
                else
                {
                    Console.WriteLine("\n> Usted selecciono imprimir el registro de notas");
                    Console.WriteLine("\nRegistro de notas ingresadas:");
                    for (int i = 0; i < notas.Count; i++)
                    {
                        Console.WriteLine($"Nota de {alumnos[i]}: {notas[i]}");
                    }

                    Console.WriteLine($"\nPromedio de notas: {promedio}");
                }
            }

        }
    }
}
