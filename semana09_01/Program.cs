using System.Threading.Channels;

namespace semana09_01
{
    internal class Program
    {
        public static List<string> alumnos = [];
        public static List<decimal> notas = [];
        public static decimal promedio = 0.0m;
        public static List<decimal> notasPrevias = []; //   Variable que almacena valores previos de notas para poder mostrar el cambio de nota en la consola.

        public static String continuar = "";

        public static int largoDiv = 50; // Variable que almacena el largo de la linea divisoria en la consola.

        static void Main(string[] args)
        {

            mostrarMenu();

        }

        public static void mostrarMenu()
        {
            String opcion = "";
            do
            {
                Console.WriteLine(new string('-', largoDiv));
                Console.WriteLine("Sistema de ingreso de notas");
                Console.WriteLine(new string('-', largoDiv));
                Console.WriteLine("\nSeleccione una opción:" +
                    "\n1. Ingresar alumnos" +
                    "\n2. Ingresar notas" +
                    "\n3. Mostrar notas" +
                    "\n4. Eliminar registro de alumno" +
                    "\n5. Salir del sistema");

                Console.Write("\nOpción: ");
                
                opcion = Console.ReadLine() ?? string.Empty;

                Console.WriteLine(new string('-', largoDiv));

                if (string.IsNullOrWhiteSpace(opcion))
                {
                    Console.WriteLine("\n> Opción inválida, por favor seleccione una opción válida");
                    continue;
                }
                else if (opcion.Equals("1")) { IngresarNombresAlumnos(); }
                else if (opcion.Equals("2")) { IngresarNotas(); }
                else if (opcion.Equals("3")) { ImprimirNotas(); }
                else if (opcion.Equals("4")) { EliminarRegistroAlumno(); }
                else if (opcion.Equals("5")) { Console.WriteLine("\n> Usted selecciono salir del sistema"); break; }
                else { 
                    Console.WriteLine("\n> Opcion invalida, porfavor seleccione una opcion valida");
                    continue;}
            }
            while (true);
        }

        public static void IngresarNombresAlumnos()
        {
            String nombreIngresado = "";

            do
            {
                do
                {
                    Console.WriteLine("\nIngrese el nombre del alumno:");
                    Console.Write("\nNombre: ");
                        
                    nombreIngresado = Console.ReadLine() ?? string.Empty;

                    if (string.IsNullOrWhiteSpace(nombreIngresado) || !nombreIngresado.All(c => char.IsLetter(c) || char.IsWhiteSpace(c)))
                    {
                        Console.WriteLine("No se ingresó ningún nombre.");
                        continue;
                    }

                    //  Se agrega a lista por medio de metodo Add() el nombre ingresado, y se agrega un valor 0.0m a la lista de notas y notasPrevias para mantener la consistencia de los índices.
                    //  Si no se hace esto, al ingresar una nota para un alumno, se podría intentar acceder a un índice que no existe en la lista de notas, lo que generaría un error.
                    alumnos.Add(nombreIngresado);
                    notas.Add(0.0m);
                    notasPrevias.Add(0.0m);
                    Console.WriteLine($"\nEl nombre ha sido ingresado en la posicion {alumnos.Count}");
                    break;
                }
                while (true);

                Console.WriteLine("\n¿Desea ingresar otro registro de alumnos? Si/No");
                Console.Write("\n\nR: ");

                continuar = Console.ReadLine() ?? string.Empty;
                if (string.IsNullOrWhiteSpace(continuar) || continuar.ToLower() != "si")
                {
                    Console.WriteLine("\n> Usted selecciono no agregar otro registro de alumnos");
                    break;
                }
                else
                {
                    Console.WriteLine("\n> Usted selecciono agregar otro registro de alumnos");
                    Console.WriteLine(new string('-', largoDiv));
                }
            }
            while (true);
        }

        public static void EliminarRegistroAlumno()
        {
            String nombreAlumno = "";
            int indexAlumno = 0;

            do {
                // Se verifica si hay alumnos registrados antes de intentar eliminar uno.
                if (alumnos.Count == 0)
                {
                    Console.WriteLine("\nNo es posible eliminar alumnos, no hay alumnos registrados");
                    break;
                }
                else
                {
                    Console.WriteLine("\nSeleccione el alumno a eliminar" +
                      "- Ingrese '0' para consultar listado alumnos -");
                    Console.Write("\nAlumno: ");

                    nombreAlumno = Console.ReadLine() ?? string.Empty;

                    if (string.IsNullOrWhiteSpace(nombreAlumno) || !nombreAlumno.All(c => char.IsLetter(c) || char.IsWhiteSpace(c)))
                    {
                        Console.WriteLine("\n> A continuación se mostrara la lista de alumnos registrados");
                        ImprimirAlumnos();
                        continue;
                    }
                    else if (!alumnos.Contains(nombreAlumno) || nombreAlumno == null)
                    {
                        Console.WriteLine("Alumno no encontrado, por favor ingrese un nombre válido");
                        continue;
                    }
                    else
                    {
                        // Se obtiene el índice del alumno a eliminar en la lista alumnos.
                        indexAlumno = alumnos.IndexOf(nombreAlumno);

                        // Se eliminan los elementos de las listas alumnos, notas y notasPrevias en la misma posición para mantener la consistencia de los índices.
                        alumnos.RemoveAt(indexAlumno);
                        notas.RemoveAt(indexAlumno);
                        notasPrevias.RemoveAt(indexAlumno);
                        Console.WriteLine($"\nEl alumno {nombreAlumno} ha sido eliminado del registro");
                        break;
                    }
                }
            } while (true);

        }

        public static void IngresarNotas()
        {
            String notaIngresada = "";
            String nombreAlumno = "";
            int indexAlumno = 0;

            do {

                // Se verifica si hay alumnos registrados antes de intentar ingresar una nota.
                if (alumnos.Count == 0)
                {
                    Console.WriteLine("\nNo es posible ingresar notas, no hay alumnos registrados");
                    break;
                }
                else
                {

                    Console.WriteLine("\nSeleccione el alumno a ingresarle nota\n" +
                    "Ingrese '0' para consultar listado alumnos");
                    Console.Write("\nNombre: ");

                    nombreAlumno = Console.ReadLine() ?? string.Empty;

                    if (string.IsNullOrWhiteSpace(nombreAlumno) || nombreAlumno.Equals("0") || !nombreAlumno.All(c => char.IsLetter(c) || char.IsWhiteSpace(c)))
                    {
                        Console.WriteLine("\n> A continuación se mostrara la lista de alumnos registrados");
                        ImprimirAlumnos();
                        continue;

                    }
                    else if (!alumnos.Contains(nombreAlumno) || nombreAlumno == null)
                    {
                        Console.WriteLine("Alumno no encontrado, por favor ingrese un nombre válido");
                        continue;
                    }
                    else
                    {
                        indexAlumno = alumnos.IndexOf(nombreAlumno);
                        Console.WriteLine(indexAlumno);

                        do
                        {
                            Console.WriteLine("\nIngrese una nota entre 0 y 10:");
                            Console.Write("\nNota: ");

                            notaIngresada = Console.ReadLine() ?? string.Empty;

                            if (string.IsNullOrWhiteSpace(notaIngresada))
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

                            // Se actualiza la nota del alumno en la lista de notas en la posición correspondiente al índice del alumno.
                            notas[indexAlumno] = notaFiltrada;

                            Console.WriteLine($"\nLa nota ha sido ingresada para el alumno {alumnos[indexAlumno]}");
                            Console.WriteLine($"\nLa nota previa era {notasPrevias[indexAlumno]} la nota nueva es {notaFiltrada}");

                            // Se actualiza la nota previa con la nueva nota ingresada para poder mostrar el cambio en la consola.
                            notasPrevias[indexAlumno] = notaFiltrada;

                            break;
                        }
                        while (true);
                    }

                }

                Console.WriteLine("\n¿Desea ingresar otro registro de notas? Si/No");
                Console.Write("\nR: ");

                continuar = Console.ReadLine() ?? string.Empty;

                if (string.IsNullOrWhiteSpace(continuar) || continuar.ToLower() != "si")
                {
                    Console.WriteLine("\n\n> Usted selecciono no agregar otro registro de notas");
                    break;
                }
                else
                {
                    Console.WriteLine("\n> Usted selecciono agregar otro registro de notas");
                    Console.WriteLine(new string('-', largoDiv));
                }

            } while (true);

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
                Console.WriteLine("\n[!] No es posible imprimir las notas, no hay alumnos registrados.");
                return;
            }

            if (notas.Count == 0)
            {
                Console.WriteLine("\n[!] No hay notas ingresadas aún.");
                return;
            }

            Console.WriteLine($"\n> Al momento hay {notas.Count} notas registradas para {alumnos.Count} alumnos.");
            Console.Write("¿Desea imprimir el registro de notas? (Si/No): ");
            Console.Write("\nR: ");

            string imprimir = Console.ReadLine() ?? string.Empty;

            if (string.IsNullOrEmpty(imprimir) || !imprimir.Trim().Equals("si", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("\n> Operación cancelada. No se imprimirá el registro.");
                return;
            }

            decimal promedio = notas.Average();

            // Se dibuja una tabla limpia en la consola
            Console.WriteLine("\n"+ new string('=', largoDiv));
            Console.WriteLine("               REGISTRO DE NOTAS                  ");
            Console.WriteLine(new string('-', largoDiv));

            // Encabezados con ancho fijo: N° (4 char), Alumno (25 char), Nota (10 char)
            Console.WriteLine($"{"N°",-4} | {"Nombre del Alumno",-25} | {"Nota",-10}");
            Console.WriteLine(new string('-', largoDiv));

            for (int i = 0; i < notas.Count; i++)
            {
                // {i + 1,-4}  -> Alineado a la izquierda, ocupa 4 espacios
                // {alumnos[i],-25} -> Alineado a la izquierda, ocupa 25 espacios
                // {notas[i],8:F2}  -> Alineado a la derecha, 2 decimales, ocupa 8 espacios
                Console.WriteLine($"{i + 1,-4} | {alumnos[i],-25} | {notas[i],8:F2}");
            }

            Console.WriteLine(new string('-', largoDiv));
            Console.WriteLine($"{"PROMEDIO GENERAL:",-32} | {promedio,8:F2}");
            Console.WriteLine(new string('=', largoDiv) + "\n");
        }
    }
}
