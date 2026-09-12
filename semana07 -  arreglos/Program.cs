namespace semana07____arreglos
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] nombres = {"Alice", "Bob", "Charlie", "David", "Ana"};
            decimal[] notas = {8.5m, 5.5m, 7.5m, 4.5m,8.0m };
            //decimal promedio = notas.Average();
            decimal promedio = 0;
            int contadorAprobados = 0, contadorReprobados = 0;
            decimal notaMayor = 0.0m, notaMenor = 10m;
            bool continuarRegistro = true;

            /**do
            {

            } while (continuarRegistro);**/

            Console.WriteLine($"Numero de alumnos registrados: {notas.Length}\n");

            Console.WriteLine("Registro de notas:\n");

            for (int i = 0; i < nombres.Length; i++)
            {
                Console.WriteLine($"{nombres[i]} ({i+1}) -> {notas[i]}");

                if (notas[i] > 6)
                {
                    contadorAprobados++;
                }

                if (notas[i] > notaMayor) {
                    notaMayor = notas[i];
                }

                if (notas[i] < notaMenor)
                {
                    notaMenor = notas[i];
                }

                promedio += notas[i];
            }

            contadorReprobados = nombres.Length - contadorAprobados;

            promedio /= notas.Length;

            Console.WriteLine($"\nAlumnos aprobados: {contadorAprobados}");
            Console.WriteLine($"Alumnos reprobados: {contadorReprobados}");

            Console.WriteLine($"\nPorcentaje aprobados: {(contadorAprobados * 1.0 /notas.Length)*100.0}%");
            Console.WriteLine($"Porcentaje reprobados: {(contadorReprobados * 1.0 /notas.Length)*100.0}%");
            
            Console.WriteLine($"\nNota mayor: {notaMayor}");
            Console.WriteLine($"Nota menor: {notaMenor}");

            Console.WriteLine($"\nPromedio de notas: {promedio}");
            
        }
    }
}
