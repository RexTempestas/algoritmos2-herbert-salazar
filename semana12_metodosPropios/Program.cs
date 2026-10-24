//using System.Threading.Channels;

namespace semana12_metodosPropios
{
    internal class Program
    {

        static string nombre = "";
        static List<string> listaNombres = new List<string>(); //No uso parametros porque las uso en todo el programa, por eso las declaro como variables globales.
        static List<decimal> listaNotas = new List<decimal>();
        static void Main(string[] args)
        {
            // Se establece la codificación de salida de la consola a UTF-8 para permitir la correcta visualización de caracteres especiales.
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            //nombre = obtenerNombre();
            nombre = "Usuario";

            mostrarTituto();

            mostrarMenu();
        }

        static string obtenerNombre()
        {
            Console.WriteLine("Ingresa tu nombre");
            return Console.ReadLine() ?? string.Empty;
        }

        static void mostrarTituto()
        {
            saludar(nombre);

            Console.WriteLine("\nBIENVENIDO AL SISTEMA DE CONTROL DEL NOTAS");
        }

        static void saludar(string Nombre)
        {
            Console.WriteLine($"\nHola {Nombre}");
        }

        static void mostrarMenu()
        {
            int opcion = 0;

            do
            {
                Console.WriteLine("\n"  + new string('-',50));
                Console.WriteLine("MENU DE OPCIONES");
                Console.WriteLine(new string('-', 50));
                Console.WriteLine("\n1. Registrar estudiante");
                Console.WriteLine("2. Registrar nota");
                Console.WriteLine("3. Consultar estudiante");
                Console.WriteLine("4. Calcular promedio");
                Console.WriteLine("0. Salir");
                
                Console.Write("\nIngrese su opcion: ");
                opcion = int.TryParse(Console.ReadLine(), out int result) ? result : -1;

                switch (opcion)
                { 
                    case 1:
                        Console.WriteLine(new string('-', 50));
                        registrarEstudiante();
                        break;
                    case 2:
                        Console.WriteLine(new string('-', 50));
                        registrarNota();
                        break;
                    case 3:
                        Console.WriteLine(new string('-', 50));
                        consultarEstudiantes();
                        break;
                    case 4:
                        Console.WriteLine(new string('-', 50));
                        calcularPromedio();
                        break;
                    case 0:
                        Console.WriteLine("\nFIN DEL PROGRAMA");
                        break;
                    default:
                        Console.WriteLine("\nValor invalido"); 
                        break;
                }

            } while (opcion != 0);
        }

        static void registrarEstudiante()
        {
            Console.WriteLine("\nIngrese el nombre del estudiante:");

            Console.Write("Nombre: ");
            string nombreEstudiante = Console.ReadLine() ?? string.Empty;

            if (!string.IsNullOrWhiteSpace(nombreEstudiante))
            {
                listaNombres.Add(nombreEstudiante);
                listaNotas.Add(0); // Inicializa la nota del estudiante en 0

                Console.WriteLine($"\nEstudiante '{nombreEstudiante}' registrado exitosamente.");
            }
            else
            {
                Console.WriteLine("\nEl nombre del estudiante no puede estar vacío.");
            }
        }

        static void registrarNota()
        {
            Console.WriteLine("Ingrese nombre de estudiante a ingresar nota");

            Console.Write("Nombre: ");
            string nombreEstudiante = Console.ReadLine() ?? string.Empty;
            
            if (!string.IsNullOrWhiteSpace(nombreEstudiante) && listaNombres.Contains(nombreEstudiante))
            {
                int indiceEstudiante = listaNombres.IndexOf(nombreEstudiante);

                Console.WriteLine($"\nEstudiante '{nombreEstudiante}' encontrado.");

                Console.WriteLine("\nIngrese la nota del estudiante:");
                Console.Write("Nota: ");

                if (decimal.TryParse(Console.ReadLine(), out decimal nota))
                {
                    listaNotas[indiceEstudiante] = nota;

                    Console.WriteLine($"\nNota '{nota}' de {listaNombres[indiceEstudiante]} registrada exitosamente.");
                }
                else
                {
                    Console.WriteLine("\nValor de nota inválido.");
                }
            }
            else
            {
                Console.WriteLine("\nEl estudiante no está registrado. Por favor, registre al estudiante primero.");
                return;
            }

        }

        static void consultarEstudiantes()
        {
            if (listaNombres.Count == 0)
            {
                Console.WriteLine("\nNo hay estudiantes registrados.");
                return;
            }
            else
            {
                Console.WriteLine(new string('-', 30));
                Console.WriteLine("Estudiantes registrados:");
                Console.WriteLine(new string('-', 30));

                foreach (var estudiante in listaNombres)
                {
                    Console.WriteLine($"Nombre :{estudiante}/ Promedio: {listaNotas[listaNombres.IndexOf(estudiante)]}");
                }
            }

        }

        static void calcularPromedio()
        {
            if (listaNotas.Count == 0)
            {
                Console.WriteLine("\nNo hay notas registradas para calcular el promedio.");
                return;
            }
            decimal sumaNotas = 0;
            foreach (var nota in listaNotas)
            {
                sumaNotas += nota;
            }
            decimal promedio = sumaNotas / listaNotas.Count;
            Console.WriteLine($"\nEl promedio general de las notas es: '{promedio}'");
        }
    }
}
